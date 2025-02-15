using Grifindo_Leave_Manager.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Leave_Manager {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Fix for high DPI scaling issues
            if (Environment.OSVersion.Version.Major >= 6) 
            {
                SetProcessDPIAware();
            }

            Application.Run(new LoginForm());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
