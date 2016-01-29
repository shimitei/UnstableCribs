using System;
using System.Windows.Forms;

namespace COIME.Common.Control
{
    public class NotifyIconUtil
    {
        /// <summary>
        /// Setup NotifyIcon.
        /// The icon added to the notification area, and then retry until it succeeds.
        /// </summary>
        /// <param name="notifyIcon"></param>
        public static void Setup(NotifyIcon notifyIcon)
        {
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
    }
}
