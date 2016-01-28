using System;
using System.Windows.Forms;

namespace COIME
{
    static class Program
    {
        static InputForm InputForm;

        /// <summary>
        /// Entry point
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Setup
            InputForm = new InputForm();
            // for Invoke (need Control's handle creation)
            var dummy = InputForm.Handle;

            Application.Run();
        }
    }
}
