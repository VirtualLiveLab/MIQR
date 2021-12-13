using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIQR
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

            FormSplash formSplash = new FormSplash();
            formSplash.Show();
            formSplash.Refresh();
            Thread.Sleep(3000);
            formSplash.Close();
            
            Application.Run(new Form1());
        }
    }
}