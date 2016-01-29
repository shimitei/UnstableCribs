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
            // for Invoke (need Control's handle creation)
            var dummy = contextMenuStrip.Handle;
            // event
            notifyIcon.DoubleClick += new System.EventHandler(notifyIcon_Click);
            // context menu
            exitStripMenuItem.Click += new System.EventHandler(exitToolStripMenuItem_Click);
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            contextMenuStrip.BeginInvoke((MethodInvoker)(() =>
            {
                if (InputForm == null || InputForm.IsDisposed)
                {
                    InputForm = new InputForm();
                    InputForm.Show();
                }
                InputForm.WindowState = FormWindowState.Normal;
                InputForm.Activate();
            }));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}
