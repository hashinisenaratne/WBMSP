using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Water_Board_Management
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());


            //Database db = new Database("billing", "month");
            //BillingRow row = new BillingRow("september/2001",1212,45621.25,"tjtyjyj");
            //db.insert(row);
        }
    }
}
