using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace LogLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                AppDomain.CurrentDomain.AssemblyResolve += (sender, arg) => { if (arg.Name.Contains("Ribbon")) return Assembly.Load(Properties.Resources.System_Windows_Forms_Ribbon35); return null; };
            }
            catch (Exception)
            {
                // We're going nowhere if the DLL did not load
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
