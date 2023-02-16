using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace MappingTools
{
    public partial class SelectLocation : Form
    {
        public bool closeflag = true;
        public SelectLocation()
        {
            InitializeComponent();
            //load workspace location from app.config
            string workspaceLoc = ConfigurationManager.AppSettings["workspace"];
            tbWorkSpace_Loc.Text = workspaceLoc;
            tbWorkSpace_Loc.Select();
        }

        private void ws_loc_ok_Click(object sender, EventArgs e)
        {
            //save workspace location into app.config
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings["workspace"] != null)
                    config.AppSettings.Settings["workspace"].Value = tbWorkSpace_Loc.Text;
                else
                    config.AppSettings.Settings.Add("workspace", tbWorkSpace_Loc.Text);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch
            {
                MessageBox.Show("Error!");
            }
            //move to next form
            if (tbWorkSpace_Loc == null | Directory.Exists(tbWorkSpace_Loc.Text) == false)
            {
                MessageBox.Show("Please select a folder!");
            }
            else 
            {
                //move
                closeflag = false;
                this.Close();
            }

        }

        private void ws_loc_browse_Click(object sender, EventArgs e)
        {
            //choose workspace location
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowDialog();
            tbWorkSpace_Loc.Text = folderDlg.SelectedPath;
        }

        private void ws_loc_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
