using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace FraxMemoryEditor
{
    [Flags]
    public enum ProcessAccessFlags : int
    {
        All = 0x001F0FFF,
        Terminate = 0x00000001,
        CreateThread = 0x00000002,
        VMOperation = 0x00000008,
        VMRead = 0x00000010,
        VMWrite = 0x00000020,
        DupHandle = 0x00000040,
        SetInformation = 0x00000200,
        QueryInformation = 0x00000400,
        Synchronize = 0x00100000
    }

    [Flags]
    public enum SnapshotFlags : uint
    {
        HeapList = 0x00000001,
        Process = 0x00000002,
        Thread = 0x00000004,
        Module = 0x00000008,
        Module32 = 0x00000010,
        Inherit = 0x80000000,
        All = 0x0000001F,
        NoHeaps = 0x40000000
    }

    [StructLayout(LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct MODULEENTRY32
    {
        internal uint dwSize;
        internal uint th32ModuleID;
        internal uint th32ProcessID;
        internal uint GlblcntUsage;
        internal uint ProccntUsage;
        internal IntPtr modBaseAddr;
        internal uint modBaseSize;
        internal IntPtr hModule;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string szModule;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        internal string szExePath;
    }

    class Memory
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(ProcessAccessFlags processAccessFlags, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesWritten);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateToolhelp32Snapshot(SnapshotFlags dwFlags, uint th32ProcessID);
        [DllImport("kernel32.dll")]
        static extern bool Module32First(IntPtr hSnapshot, ref MODULEENTRY32 lpme);
        [DllImport("kernel32.dll")]
        static extern bool Module32Next(IntPtr hSnapshot, ref MODULEENTRY32 lpme);
        private IntPtr handle;
        private Process process;
        private bool attached;
        public Process Process { get => process; }
        public bool Attached { get => attached; }

        /// <summary>
        /// Attaches memory object to process
        /// </summary>
        /// <param name="processId">Process ID of targeted process</param>
        public void AttachToProcess(int processId)
        {
            Process proc;
            try { proc = Process.GetProcessById(processId); }
            catch { return; }
            handle = OpenProcess(ProcessAccessFlags.All, false, proc.Id);
            if (handle != IntPtr.Zero)
            {
                attached = true;
                process = proc;
            }
            else
            {
                attached = false;
                process = null;
            }
        }

        /// <summary>
        /// Detaches memory object from process
        /// </summary>
        public void Detach()
        {
            handle = IntPtr.Zero;
            process = null;
            attached = false;
        }

        /// <summary>
        /// Reads process memory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address">Target address</param>
        /// <returns></returns>
        public T ReadMemory<T>(IntPtr address) where T : struct
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];
            int bytesRead;
            ReadProcessMemory(handle, address, buffer, buffer.Length, out bytesRead);
            //somewhat working conversion
            return MemoryMarshal.Cast<byte, T>(buffer)[0];
        }

        /// <summary>
        /// Reads process memory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address">Target address.</param>
        /// <param name="type">Optionally inferr type during runtime.</param>
        /// <returns></returns>
        public T ReadMemory<T>(IntPtr address, T type) where T : struct
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];
            int bytesRead;
            ReadProcessMemory(handle, address, buffer, buffer.Length, out bytesRead);
            //somewhat working conversion
            return MemoryMarshal.Cast<byte, T>(buffer)[0];
        }

        /// <summary>
        /// Reads an array from process memory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address">Target address</param>
        /// <param name="size">Size of array in bytes</param>
        /// <returns></returns>
        public T[] ReadMemoryArray<T>(IntPtr address, Int32 size)
        {
            byte[] buffer = new byte[size];
            int bytesRead;
            ReadProcessMemory(handle, address, buffer, buffer.Length, out bytesRead);
            T[] result = new T[size / Marshal.SizeOf(typeof(T))];
            Buffer.BlockCopy(buffer, 0, result, 0, buffer.Length);
            return result;
        }

        /// <summary>
        /// Writes value to writable/readonly process memory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address">Target address</param>
        /// <param name="value">Can be inferred during runtime</param>
        public void WriteMemory<T>(IntPtr address, T value)
        {
            int bytesWritten;
            byte[] buffer = (byte[])typeof(BitConverter)
            .GetMethod("GetBytes", new Type[] { typeof(T) })
            .Invoke(null, new object[] { value });
            UInt32 lastProtection;
            VirtualProtectEx(handle, address, buffer.Length, 0x40, out lastProtection);
            WriteProcessMemory(handle, address, buffer, buffer.Length, out bytesWritten);
            VirtualProtectEx(handle, address, buffer.Length, lastProtection, out lastProtection);
        }

        /// <summary>
        /// Scans all process modules for value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Value to scan for</param>
        /// <param name="addressList">Outputs found addresses</param>
        /// <returns>Formatted addresses</returns>
        public List<string> ScanValue<T>(T value, List<IntPtr> addressList) where T : struct
        {
            if (!attached)
                return null;

            List<string> list = new List<string>();
            if (addressList.Count == 0)
            {
                IntPtr modules = CreateToolhelp32Snapshot(SnapshotFlags.Module | SnapshotFlags.Module32, (UInt32)process.Id);
                MODULEENTRY32 module = new MODULEENTRY32() { dwSize = (UInt32)Marshal.SizeOf(typeof(MODULEENTRY32)) };
                if (!Module32First(modules, ref module))
                    return null;
                do {
                    T[] buffer = ReadMemoryArray<T>(module.modBaseAddr, (Int32)module.modBaseSize);
                    for (int i = 0; i < buffer.Count(); i++)
                    {
                        if (Comparer<T>.Default.Compare(buffer[i], value) == 0)
                        {
                            addressList.Add(new IntPtr((Int64)module.modBaseAddr + i * Marshal.SizeOf(typeof(T))));
                            list.Add((module.modBaseAddr + i * Marshal.SizeOf(typeof(T))).ToString("X"));
                        }
                    }
                } while (Module32Next(modules, ref module));
            }
            else
            {
                List<IntPtr> tempList = new List<IntPtr>();
                foreach (IntPtr address in addressList)
                {
                    T scannedValue = ReadMemory<T>(address);
                    if (Comparer<T>.Default.Compare(scannedValue, value) == 0)
                    {
                        tempList.Add(address);
                        list.Add(address.ToString("X"));
                    }
                }
                addressList = tempList;
            }
            return list;
        }
    }
}
