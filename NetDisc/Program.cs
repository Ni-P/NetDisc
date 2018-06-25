using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetDisc
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
            MainForm app = new MainForm();
            Application.Run(app);

            app.FormClosed += (object o, FormClosedEventArgs e) =>
            {
                Environment.Exit(0);
            };
        }
    }
}
