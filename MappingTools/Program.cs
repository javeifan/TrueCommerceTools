using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MappingTools
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
            //Application.Run(new selectLocation());
            loading_MT_Info form1 = new loading_MT_Info();
            
            form1.ShowDialog();

            SelectLocation form2 = new SelectLocation();
            form2.ShowDialog();
            if (form2.closeflag == false)
            {
                Application.Run(new mainForm());
            }
        }
    }
}
