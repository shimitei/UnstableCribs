using System;
using System.Runtime.InteropServices;

namespace COIME
{
    /// <summary>
    /// http://tomoemon.hateblo.jp/entry/20080430/p2
    /// </summary>
    public class SetForegroundWindowHelper
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, ref uint procId);

        // callback
        private delegate int EnumerateWindowsCallback(IntPtr hWnd, int lParam);

        [DllImport("user32", EntryPoint = "EnumWindows")]
        private static extern int EnumWindows(EnumerateWindowsCallback lpEnumFunc, int lParam);

        private uint target_pid = 0;
        private IntPtr target_hwnd = IntPtr.Zero;

        private int EnumerateWindows(IntPtr hWnd, int lParam)
        {
            uint procId = 0;
            uint result = GetWindowThreadProcessId(hWnd, ref procId);
            if (procId == target_pid)
            {
                //found
                target_hwnd = hWnd;
                return 0;
            }

            // continue
            return 1;
        }

        public static void Wakeup(uint pid)
        {
            var helper = new SetForegroundWindowHelper();
            helper.WakeupWindow(pid);
        }

        public void WakeupWindow(uint pid)
        {
            target_pid = pid;
            EnumWindows(new EnumerateWindowsCallback(EnumerateWindows), 0);
            if (target_hwnd == IntPtr.Zero)
            {
                return;
            }

            if (IsIconic(target_hwnd))
            {
                const int SW_RESTORE = 9;
                ShowWindowAsync(target_hwnd, SW_RESTORE);
            }
            SetForegroundWindow(target_hwnd);
            target_hwnd = IntPtr.Zero;
        }
    }
}
