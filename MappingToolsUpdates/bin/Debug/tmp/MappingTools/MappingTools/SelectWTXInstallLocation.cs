using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace MappingTools
{
    public partial class SelectWTXInstallLocation : Form
    {
        public SelectWTXInstallLocation()
        {
            InitializeComponent();
            string WtxInstallationPath = ConfigurationManager.AppSettings["WtxInstallationPath"];
            tbWTXLoc.Text = WtxInstallationPath;
        }

        private void WTX_loc_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowDialog();
            tbWTXLoc.Text = folderDlg.SelectedPath;
        }

        private void SelectWTXLoc_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectWTXLoc_OK_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings["WtxInstallationPath"] != null)
                    config.AppSettings.Settings["WtxInstallationPath"].Value = tbWTXLoc.Text;
                else
                    config.AppSettings.Settings.Add("WtxInstallationPath", tbWTXLoc.Text);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch
            {
                MessageBox.Show("Error!");
            }
            //move to next form
            if (tbWTXLoc.Text == null | Directory.Exists(tbWTXLoc.Text) == false)
            {
                MessageBox.Show("Please select a folder!");
            }
            else
            {
                //move
                //closeflag = false;
                this.Close();
            }
        }
    }
}
