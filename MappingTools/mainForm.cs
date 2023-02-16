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
using System.Windows.Forms.VisualStyles;
using System.Runtime.CompilerServices;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;


namespace MappingTools
{
    public partial class mainForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public static mainForm mainform;
        public static bool ifVANEmailTemplatesOpened = false;

        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        public mainForm()
        {
            mainform = this;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true);


            InitializeComponent();

            pbCommonTools_bottom.Visible = true;
            ssbtCommonTools.BackColor = Color.FromArgb(255, 255, 255);
            ssbtCommonTools.ForeColor = Color.FromArgb(107, 197, 205);
            //添加窗体圆角
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));


            //workspace location for further use
            string workspaceLoc = ConfigurationManager.AppSettings["workspace"];
            if (File.Exists("SpawnDailyIssueCasesRecord.txt"))
                File.Delete("SpawnDailyIssueCasesRecord.txt");
            //slaUserName初始化用户名
            slaUserName.Text = MappingToolsCommonFuncs.GetSoftwareUserName();

            stbUserName.Size = slaUserName.Size;
            stbUserName.Location = slaUserName.Location;
            //为stbUserName 添加回车事件
            stbUserName.KeyUp += new KeyEventHandler(UserName_KeyUp);

            //判断advanced clone mode是否开启，首次则创建设置
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings["AdvancedCloneMode"] == null)
                {
                    config.AppSettings.Settings.Add("AdvancedCloneMode", "False");
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                else if (ConfigurationManager.AppSettings["AdvancedCloneMode"].ToUpper() == "FALSE")
                    //config.AppSettings.Settings["AdvancedCloneMode"].Value = tbWorkSpace_Loc.Text;
                    uiswAdvancedCloneMode.Active = false;
                else if (ConfigurationManager.AppSettings["AdvancedCloneMode"].ToUpper() == "TRUE")
                    uiswAdvancedCloneMode.Active = true;

            }
            catch
            { }
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

        /*        private void MainFormMeanAbout_Click(object sender, EventArgs e)
                {
                    SoftwareAboutForm form_SoftwareAboutForm = new SoftwareAboutForm();
                    form_SoftwareAboutForm.ShowDialog();
                }*/

        private void SetOrChangeUserName_Click(object sender, EventArgs e)
        {
            SetUserName form_setUserName = new SetUserName();
            form_setUserName.ShowDialog();
        }

        private void CheckForUpdates_Click(object sender, EventArgs e)
        {
            string versionNumFromServer = MappingToolsCommonFuncs.GetVersionNumFromServer();
            if (versionNumFromServer != MappingToolsCommonFuncs.GetSoftwareVersion() && versionNumFromServer != "" && MappingToolsCommonFuncs.GetSoftwareVersion() != "")
            {
                NewVersionFound form_newVersionFound = new NewVersionFound();
                form_newVersionFound.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("You are up to date!");
                try
                {
                    File.Delete(@"Update.xml");
                }
                catch
                {
                }

            }
        }
        public static void CloseMainForm()
        {
            mainform.Close();
        }

        private bool commmonToolsClicked = true;
        private bool helpClicked = false;
        private bool settingsClicked = false;




        private void CommonTools_MouseEnter(object sender, EventArgs e)
        {
            pbCommonTools_bottom.Visible = true;
            ssbtCommonTools.BackColor = Color.FromArgb(255, 255, 255);
            ssbtCommonTools.ForeColor = Color.FromArgb(107, 197, 205);
        }

        private void CommonTools_MouseLeave(object sender, EventArgs e)
        {
            if (commmonToolsClicked == false)
            {
                pbCommonTools_bottom.Visible = false;
                ssbtCommonTools.ForeColor = Color.FromArgb(255, 255, 255);
                ssbtCommonTools.BackColor = Color.Transparent;
            }
        }

        private void CommonTools_Click(object sender, EventArgs e)
        {
            commmonToolsClicked = true;
            helpClicked = false;
            settingsClicked = false;

            pbHelp_bottom.Visible = false;
            ssbtHelp.ForeColor = Color.FromArgb(255, 255, 255);
            ssbtHelp.BackColor = Color.Transparent;

            pbSettings_bottom.Visible = false;

            ssbtSettings.ForeColor = Color.FromArgb(255, 255, 255);
            ssbtSettings.BackColor = Color.Transparent;

            plCommonTools.Visible = true;
            plHelp.Visible = false;
            plSettings.Visible = false;
        }

        private void Help_MouseEnter(object sender, EventArgs e)
        {
            pbHelp_bottom.Visible = true;
            ssbtHelp.ForeColor = Color.FromArgb(102, 187, 207);
            ssbtHelp.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void Help_MouseLeave(object sender, EventArgs e)
        {
            if (helpClicked == false)
            {
                pbHelp_bottom.Visible = false;
                ssbtHelp.ForeColor = Color.FromArgb(255, 255, 255);
                ssbtHelp.BackColor = Color.Transparent;


            }
        }
        private void Help_Click(object sender, EventArgs e)
        {
            slaVersionValue.Text = MappingToolsCommonFuncs.GetSoftwareVersion();

            commmonToolsClicked = false;
            helpClicked = true;
            settingsClicked = false;

            pbCommonTools_bottom.Visible = false;
            ssbtCommonTools.ForeColor = Color.FromArgb(255, 255, 255);
            ssbtCommonTools.BackColor = Color.Transparent;

            pbSettings_bottom.Visible = false;
            ssbtSettings.ForeColor = Color.FromArgb(255, 255, 255);
            ssbtSettings.BackColor = Color.Transparent;

            plCommonTools.Visible = false;
            plHelp.Visible = true;
            plSettings.Visible = false;
        }




        private void Settings_MouseEnter(object sender, EventArgs e)
        {
            pbSettings_bottom.Visible = true;
            ssbtSettings.ForeColor = Color.FromArgb(98, 178, 211);
            ssbtSettings.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void Settings_MouseLeave(object sender, EventArgs e)
        {
            if (settingsClicked == false)
            {
                pbSettings_bottom.Visible = false;
                ssbtSettings.ForeColor = Color.FromArgb(255, 255, 255);
                ssbtSettings.BackColor = Color.Transparent;
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            commmonToolsClicked = false;
            helpClicked = false;
            settingsClicked = true;


            pbCommonTools_bottom.Visible = false;
            ssbtCommonTools.ForeColor = Color.FromArgb(255, 255, 255);
            ssbtCommonTools.BackColor = Color.Transparent;


            pbHelp_bottom.Visible = false;
            ssbtHelp.ForeColor = Color.FromArgb(255, 255, 255);
            ssbtHelp.BackColor = Color.Transparent;

            plCommonTools.Visible = false;
            plHelp.Visible = false;
            plSettings.Visible = true;
        }

        private void CreateMTS_Click(object sender, EventArgs e)
        {
            TypeTreeMaker form_TypeTreeMaker = new TypeTreeMaker();
            form_TypeTreeMaker.ShowDialog();
        }

        private void CloneMap_Click(object sender, EventArgs e)
        {
            MapClone form_MapClone = new MapClone();
            form_MapClone.ShowDialog();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            //点击UserName以外的窗体部分则写入UserName并隐藏stbUserName
            if (stbUserName.Text != null && stbUserName.Text != "")
                MappingToolsCommonFuncs.SetSoftwareUserName(stbUserName.Text);
            slaUserName.Text = MappingToolsCommonFuncs.GetSoftwareUserName();
            stbUserName.Visible = false;
        }

        private void MainFormMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MainFormCloseTop_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserName_Click(object sender, EventArgs e)
        {
            stbUserName.Text = slaUserName.Text;

            stbUserName.Visible = true;
            stbUserName.SelectAll();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            stbUserName.Visible = false;
        }

        private void UserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                if (stbUserName.Text.Trim() != "")
                    MappingToolsCommonFuncs.SetSoftwareUserName(stbUserName.Text);
                slaUserName.Text = MappingToolsCommonFuncs.GetSoftwareUserName();
                stbUserName.Visible = false;
            }

        }
        public static void RefreshUserName()
        {
            mainform.slaUserName.Text = MappingToolsCommonFuncs.GetSoftwareUserName();
        }
        public static void MinimizeMainForm()
        {
            mainform.WindowState = FormWindowState.Minimized;
        }
        public static void NormalMainForm()
        {
            mainform.WindowState = FormWindowState.Normal;
        }

        private void AdvancedCloneMode_ValueChanged(object sender, bool value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (uiswAdvancedCloneMode.Active == true)
                config.AppSettings.Settings["AdvancedCloneMode"].Value = "True";
            else if (uiswAdvancedCloneMode.Active == false)
                config.AppSettings.Settings["AdvancedCloneMode"].Value = "False";
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void SharePointLogin_Click(object sender, EventArgs e)
        {
            SharePointAuthentication form_SharePointLogin = new SharePointAuthentication();
            form_SharePointLogin.ShowDialog();
        }

        /*        private void SHAREPOINTTEST(object sender, EventArgs e)
{
  if (Directory.Exists("test//") == false)
  {
      Directory.CreateDirectory("test//");
      System.Windows.MessageBox.Show(SharePointFileHelper.UploadFile("http://shanghai.truecommerce.com/Docs/Documents/Services/WTX Mapping/", "test\\Test_upload.txt", "Sam.Shi", "Gxfkx1314//////", "tccom"));
  }
  System.Windows.MessageBox.Show(SharePointFileHelper.UploadFile("http://shanghai.truecommerce.com/Docs/Documents/Services/WTX Mapping/", "test\\Test_upload.txt", "Sam.Shi", "Gxfkx1314//////", "tccom"));
}*/
    }
}