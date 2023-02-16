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
using System.Windows;

namespace MappingTools
{
    public partial class mainForm : Form
    {
        public static mainForm mainform;
        public static bool ifVANEmailTemplatesOpened=false;
        public mainForm()
        {
            mainform = this;
            InitializeComponent();
            //workspace location for further use
            string workspaceLoc = ConfigurationManager.AppSettings["workspace"];

        }

        private void MapClone_Click(object sender, EventArgs e)
        {
            MapClone form_MapClone = new MapClone();
            form_MapClone.ShowDialog();
        }

        private void MainFormExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TypeTreeMaker_Click(object sender, EventArgs e)
        {
            TypeTreeMaker form_TypeTreeMaker = new TypeTreeMaker();
            form_TypeTreeMaker.ShowDialog();
        }

        private void CreateNewMap_Click(object sender, EventArgs e)
        {
            /* CreateNewMap form_CreateNewMap = new CreateNewMap();
             form_CreateNewMap.ShowDialog();*/
        }

        private void WTXDailyEmailHelper_Click(object sender, EventArgs e)
        {
            WTXDailyEmailHelper form_WTXDailyEmailHelper = new WTXDailyEmailHelper();
            form_WTXDailyEmailHelper.ShowDialog();
        }

        private void HelpContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.ibm.com/support/knowledgecenter/SSVSD8_9.0.0/com.ibm.websphere.dtx.welcome.doc/kc_welcome_900.html");
        }

        private void setUpWTXITXDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectWTXInstallLocation form_SelectWTXInstallLocation = new SelectWTXInstallLocation();
            form_SelectWTXInstallLocation.ShowDialog();
        }

        private void SpawnDailyEmailHelper_Click(object sender, EventArgs e)
        {
            SpawnDailyEmailHelper form_SpawnDailyEmialHelper = new SpawnDailyEmailHelper();
            form_SpawnDailyEmialHelper.ShowDialog();
        }

        private void VANEmailTemplates_Click(object sender, EventArgs e)
        {
            if (ifVANEmailTemplatesOpened == false)
            {
                VANEmailTemplates form_VANEmailTemplates = new VANEmailTemplates();
                form_VANEmailTemplates.Show();
                ifVANEmailTemplatesOpened = true;
            }
        }

        private void MainFormMeanAbout_Click(object sender, EventArgs e)
        {
            SoftwareAboutForm form_SoftwareAboutForm = new SoftwareAboutForm();
            form_SoftwareAboutForm.ShowDialog();
        }
    }
}
