using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace COIME
{
    public partial class TrayIcon : Component
    {
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
            // context menu
            exitStripMenuItem.Click += new System.EventHandler(exitToolStripMenuItem_Click);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}
