using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace My.Common.WinAPI
{
    /// <summary>
    /// http://blog.kur.jp/entry/2009/12/05/activewin/
    /// </summary>
    public class GetForegroundWindowUtil
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        public static Process GetForegroundProcess()
        {
            Process result = null;
            IntPtr hWnd = GetForegroundWindow();
            if (hWnd != IntPtr.Zero)
            {
                int id = 0;
                GetWindowThreadProcessId(hWnd, out id);
                try
                {
                    result = Process.GetProcessById(id);
                }
                catch
                {
                    //nothing
                }
            }
            return result;
        }
    }
}
