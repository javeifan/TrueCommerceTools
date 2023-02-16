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
using System.Runtime.InteropServices;

namespace MappingTools
{
    public partial class SelectLocation : Form
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
        public bool closeflag = true;

        /// <summary>
        /// 拖动无边框窗体
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        public SelectLocation()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true);

            InitializeComponent();
            //load workspace location from app.config
            

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));

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

        private void SelectLocation_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
    }
}
