using My.Common.WinAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace COIME
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
            setupProcessComboBox();
            suggestCollection = new SuggestCollection(textBox);
            autocompleteMenu.SetAutocompleteItems(suggestCollection);
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                sendKeysAndClose(textBox.Text);
            }
            else if (e.Control && e.KeyCode == Keys.Space)
            {
                autocompleteMenu.Show(textBox, true);
            }
        }

        private void setupProcessComboBox()
        {
            var list = new List<Process>(Process.GetProcesses());
            var fp = GetForegroundWindowUtil.GetForegroundProcess();
            if (fp != null) list.Insert(0, fp);
            comboBox.DataSource = list.Select(x => new {
                pid = x.Id,
                name = (string.IsNullOrEmpty(x.MainWindowTitle))
                    ? x.ProcessName
                    : x.ProcessName + " - " + x.MainWindowTitle
            }).ToList();
            comboBox.ValueMember = "pid";
            comboBox.DisplayMember = "name";
        }

        private uint getTargetProcessId()
        {
            uint pid = Convert.ToUInt32(comboBox.SelectedValue);
            return pid;
        }

        private void sendKeysAndClose(string s)
        {
            sendKeys(s);
            Close();
        }

        private void sendKeys(string s)
        {
            var pid = getTargetProcessId();
            if (pid != 0)
            {
                SetForegroundWindowHelper.Wakeup(pid);
                SendKeys.Send(s);
            }
        }
    }
}
