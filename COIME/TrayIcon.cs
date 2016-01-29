using COIME.Common.Control;
using NHotkey;
using NHotkey.WindowsForms;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace COIME
{
    public partial class TrayIcon : Component
    {
        private InputForm InputForm;

        public TrayIcon()
        {
            InitializeComponent();
        }

        public TrayIcon(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Setup()
        {
            // Hot key
            HotkeyManager.Current.AddOrReplace("ShowInputForm", Keys.Control | Keys.F12, hotkey_ShowInputForm);

            // event
            notifyIcon.DoubleClick += new System.EventHandler(notifyIcon_Click);
            // context menu
            exitStripMenuItem.Click += new System.EventHandler(exitToolStripMenuItem_Click);

            // for Invoke (need Control's handle creation)
            var dummy = contextMenuStrip.Handle;

            NotifyIconUtil.Setup(notifyIcon);
        }

        private void hotkey_ShowInputForm(object sender, HotkeyEventArgs e)
        {
            e.Handled = true;
            showInputForm();
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            showInputForm();
        }

        private void showInputForm()
        {
            contextMenuStrip.BeginInvoke((MethodInvoker)(() =>
            {
                if (InputForm == null)
                {
                    InputForm = new InputForm();
                    InputForm.StartPosition = FormStartPosition.CenterScreen;
                    InputForm.ShowDialog();
                    InputForm.StartPosition = FormStartPosition.Manual;
                }
                else if (!InputForm.Visible)
                {
                    InputForm.ShowDialog();
                }
            }));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}
