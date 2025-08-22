using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDSystem.DVLD.Login;
using DVLDSystem.DVLD.Applications.Manage_License_Release_and_Detention;

namespace DVLDSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormTest());
            Application.Run(new frmLogin());
        }
    }
}