using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace COIME.Common.Control
{
    public class NotifyIconUtil
    {
        /*
         * for ALT + F4 problem
         * see http://d.hatena.ne.jp/hnx8/20131208/1386486457
         */
        [DllImport("user32")]
        static extern IntPtr GetForegroundWindow();
        [System.Runtime.InteropServices.DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [System.Runtime.InteropServices.DllImport("user32")]
        static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// Setup NotifyIcon.
        /// The icon added to the notification area, and then retry until it succeeds.
        /// </summary>
        /// <param name="notifyIcon"></param>
        public static void Setup(NotifyIcon notifyIcon)
        {
            AntiAltF4(notifyIcon);
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

        private static void AntiAltF4(NotifyIcon notifyIcon)
        {
            var cms = notifyIcon.ContextMenuStrip;
            if (cms != null)
            {
                cms.PreviewKeyDown += (sender, e) =>
                {
                    if (e.Alt)
                    {
                        SetForegroundWindow(GetDesktopWindow());
                    }
                };
                cms.Closing += (sender, e) =>
                {
                    FieldInfo fi = typeof(NotifyIcon).GetField("window", BindingFlags.NonPublic | BindingFlags.Instance);
                    NativeWindow window = fi.GetValue(notifyIcon) as NativeWindow;
                    IntPtr handle = GetForegroundWindow();
                    if (handle == window.Handle)
                    {
                        SetForegroundWindow(GetDesktopWindow());
                    }
                };
            }
        }
    }
}
