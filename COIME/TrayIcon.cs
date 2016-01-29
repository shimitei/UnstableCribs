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
            // event
            notifyIcon.DoubleClick += new System.EventHandler(notifyIcon_Click);
            // context menu
            exitStripMenuItem.Click += new System.EventHandler(exitToolStripMenuItem_Click);

            // for Invoke (need Control's handle creation)
            var dummy = contextMenuStrip.Handle;

            // setup notify icon
            while (true)
            {
                int tickCount = Environment.TickCount;
                notifyIcon.Visible = true;
                tickCount = Environment.TickCount - tickCount;
                if (tickCount < 4000)
                {
                    // Success if less than 4 seconds
                    break;
                }
                // retry
                notifyIcon.Visible = false;
            }
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
