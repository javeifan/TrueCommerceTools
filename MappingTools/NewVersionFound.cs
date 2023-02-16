using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MappingTools
{
    public partial class NewVersionFound : Form
    {
        public NewVersionFound()
        {
            InitializeComponent();
            string versionNumFromServer = (MappingToolsCommonFuncs.GetVersionNumFromServer());
            laNewVerionFoundInfo.Text = "Latest version was found(" + versionNumFromServer + ")! Update now?";
        }

        private void NewVersionUpdate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"MappingToolsUpdates.exe");
            this.Close();
            mainForm.CloseMainForm();
        }

        private void NewVersionCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
