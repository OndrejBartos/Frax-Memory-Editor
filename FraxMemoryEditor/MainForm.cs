using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FraxMemoryEditor
{
    public partial class MainForm : Form
    {
        private Memory memory = new Memory();
        private List<IntPtr> scannedValues = new List<IntPtr>();
        private Type[] typeArray = { typeof(SByte), typeof(Int16), typeof(Int32), typeof(Int64),
                                    typeof(Byte), typeof(UInt16), typeof(UInt32), typeof(UInt64),
                                    typeof(Single), typeof(Double) };
        private Dictionary<IntPtr, Type> savedValues = new Dictionary<IntPtr, Type>();
        private Dictionary<IntPtr, dynamic> frozenValues = new Dictionary<IntPtr, dynamic>();
        private const int resultBoxVisibleCount = 13;
        public MainForm()
        {
            InitializeComponent();
            //Change to double buffered otherwise the listview is buggy
            resultBox.GetType()
            .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            .SetValue(resultBox, true, null);
            savedValuesBox.GetType()
            .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            .SetValue(resultBox, true, null);
        }

        private void ProcessChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if(comboBox.SelectedItem.ToString() == "Click this to deattach!")
            {
                memory.Detach();
                attachedLabel.Text = "DEATTACHED";
                return;
            }
            memory.AttachToProcess(Convert.ToInt32(comboBox.SelectedItem.ToString().Split(' ')[1]));
            if (memory.Attached)
            {
                attachedLabel.Text = "ATTACHED: " + memory.Process.Id;
            }  
        }

        private void UpdateProcessList(object sender, EventArgs e)
        {
            List<string> processes = Process.GetProcesses().Select(p => p.ProcessName + " " + p.Id).ToList();
            processes.Sort();
            processes.Insert(0, "Click this to deattach!");
            processComboBox.DataSource = processes;
        }

        private void ScanButtonClicked(object sender, EventArgs e)
        {
            List<string> result = null;
            dynamic value = Convert.ChangeType(valueTextBox.Text, typeArray[typeComboBox.SelectedIndex]);
            result = memory.ScanValue(value, scannedValues);
            if(result != null)
            {
                resultBox.Items.Clear();
                countLabel.Text = "Count: " + result.Count;
                //Fill listview with item containing subitems with the scanned value
                resultBox.Items.AddRange(result.Select(x => new ListViewItem(new string[] { x, value.ToString() })).ToArray());
            }
        }

        private void UpdateValues(object sender, EventArgs e)
        {
            if (resultBox.Items.Count != 0)
            {
                //update only visible items
                for (int i = resultBox.TopItem.Index; i <= resultBox.TopItem.Index + resultBoxVisibleCount && i < resultBox.Items.Count; i++)
                {
                    ListViewItem item = resultBox.Items[i];
                    //resultBox.TopItem
                    if (string.IsNullOrEmpty(item.Text) || item.SubItems.Count == 0)
                        continue;

                    //add second column if there is none
                    if (item.SubItems.Count == 1)
                        item.SubItems.Add(new ListViewItem.ListViewSubItem());

                    IntPtr address = new IntPtr(Convert.ToInt64(item.Text, 16));
                    //generic type will get inferred during runtime
                    item.SubItems[1].Text = memory.ReadMemory(address, (dynamic)Activator.CreateInstance(typeArray[typeComboBox.SelectedIndex])).ToString();
                }
            }
            foreach (ListViewItem item in savedValuesBox.Items)
            {
                if (string.IsNullOrEmpty(item.Text) || item.SubItems.Count == 0)
                    continue;

                //add second column if there is none
                if (item.SubItems.Count == 1)
                    item.SubItems.Add(new ListViewItem.ListViewSubItem());

                IntPtr address = new IntPtr(Convert.ToInt64(item.Text, 16));
                //generic type will get inferred during runtime
                item.SubItems[2].Text = memory.ReadMemory(address, (dynamic)Activator.CreateInstance(savedValues[address])).ToString();
            }
        }

        private void ResetValues(object sender, EventArgs e)
        {
            //clear values
            countLabel.Text = "Count: 0";
            resultBox.Items.Clear();
            scannedValues.Clear();
        }

        private void SaveValue(object sender, EventArgs e)
        {
            foreach(ListViewItem item in resultBox.SelectedItems)
            {
                //Create new item
                ListViewItem currentItem = savedValuesBox.Items.Add(new ListViewItem(item.Text));
                currentItem.SubItems.Add(typeComboBox.Text);
                //Add temp value holder
                currentItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                savedValues.Add(new IntPtr(Convert.ToInt64(item.Text, 16)), typeArray[typeComboBox.SelectedIndex]);
            }
        }

        private void ChangeValue(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Enter the value: ");
            if (string.IsNullOrEmpty(input))
                return;
            
            ListView listView = (ListView)((ContextMenuStrip)(((ToolStripMenuItem)sender).Owner)).SourceControl;
            foreach (ListViewItem item in listView.SelectedItems)
            {
                IntPtr address = new IntPtr(Convert.ToInt64(item.Text, 16));
                if (frozenValues.ContainsKey(address))
                {
                    frozenValues[address] = Convert.ChangeType(input, savedValues[address]);
                }
                else
                {
                    dynamic value = Convert.ChangeType(input, savedValues[address]);
                    memory.WriteMemory(address, value);
                }
            }
        }

        private void RemoveSavedValues(object sender, EventArgs e)
        {
            foreach(ListViewItem item in savedValuesBox.SelectedItems)
            {
                frozenValues.Remove(new IntPtr(Convert.ToInt64(item.Text, 16)));
                item.Remove();
            }
        }

        private void FreezeValue(object sender, EventArgs e)
        {
            foreach (ListViewItem item in savedValuesBox.SelectedItems)
            {
                IntPtr address = new IntPtr(Convert.ToInt64(item.Text, 16));
                if (frozenValues.ContainsKey(address))
                {
                    frozenValues.Remove(address);
                }
                else
                {
                    frozenValues.Add(address, Convert.ChangeType(item.SubItems[2].Text, savedValues[address]));
                }
            }
        }

        private void HoldFrozenValues(object sender, EventArgs e)
        {
            foreach (KeyValuePair<IntPtr, dynamic> pair in frozenValues)
            {
                memory.WriteMemory(pair.Key, pair.Value);
            }
        }
    }
}
