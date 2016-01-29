using System;
using System.Windows.Forms;

namespace COIME
{
    static class Program
    {
        static TrayIcon TrayIcon;

        /// <summary>
        /// Entry point
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TrayIcon = new TrayIcon();
            TrayIcon.Setup();

            Application.Run();
        }
    }
}
