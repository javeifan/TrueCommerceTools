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

namespace MappingTools
{
    public partial class SharePointAuthentication : Form
    {
        public SharePointAuthentication()
        {
            InitializeComponent();
            try
            {
                stbSharePointUserPwd.Text = MappingToolsCommonFuncs.SharePointPwdLoad(MappingToolsCommonFuncs.FileContent("ciphertext"), MappingToolsCommonFuncs.FileContent("entropy"));
            }
            catch 
            { 
            }
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings["SharePointUserName"] == null)
                {
                    config.AppSettings.Settings.Add("SharePointUserName", "");
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                else if (ConfigurationManager.AppSettings["SharePointUserName"] != "")
                {
                    stbSharePointUserName.Text = ConfigurationManager.AppSettings["SharePointUserName"];
                    stbSharePointUserName.SelectAll();
                }
            }
            catch
            { 
            }
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings["SharePointDomain"] == null)
                {
                    config.AppSettings.Settings.Add("SharePointDomain", "");
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                else if (ConfigurationManager.AppSettings["SharePointDomain"] != "")
                {
                    stbSharePointDomain.Text = ConfigurationManager.AppSettings["SharePointDomain"];
                }
            }
            catch
            {
            }
        }

        private void SharePointLoginCheck_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (stbSharePointUserName.Text.Trim() == "")
                slaSharePonitAuthentication_Info.Text = "User name can not be empty!";
            else if (stbSharePointUserPwd.Text == "")
                slaSharePonitAuthentication_Info.Text = "Password can not be empty!";
            else if (stbSharePointDomain.Text=="")
                slaSharePonitAuthentication_Info.Text = "Domain can not be empty!";
            else
            {
                config.AppSettings.Settings["SharePointUserName"].Value = stbSharePointUserName.Text;
                config.AppSettings.Settings["SharePointDomain"].Value = stbSharePointDomain.Text;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                //Save Password
                MappingToolsCommonFuncs.SharePointPwdSave(stbSharePointUserPwd.Text);

            }
            try
            {
                byte[] filecontents = SharePointFileHelper.CreateWebClient(stbSharePointUserName.Text, stbSharePointUserPwd.Text, stbSharePointDomain.Text).DownloadData("http://shanghai.truecommerce.com/Docs/Documents/Services/WTX Mapping/Mapping Assignments2.xlsx");
                MessageBox.Show("Success");
            }
            catch
            {
                MessageBox.Show("Failed!");
            }
        }

        private void SharePointLoginCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SharePointUserName_TextChanged(object sender, EventArgs e)
        {
            slaSharePonitAuthentication_Info.Text = "";
        }

        private void SharePointPwd_TextChanged(object sender, EventArgs e)
        {
            slaSharePonitAuthentication_Info.Text = "";
        }

        private void SharePointDomain_TextChanged(object sender, EventArgs e)
        {
            slaSharePonitAuthentication_Info.Text = "";
        }
    }
}
