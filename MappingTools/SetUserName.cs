using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MappingTools
{
    public partial class SetUserName : Form
    {
        /*[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );*/
        public SetUserName()
        {
            InitializeComponent();
            
            //取消圆形边框
            //this.FormBorderStyle = FormBorderStyle.None;
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));

            stbSetUserName.Text = MappingToolsCommonFuncs.GetSoftwareUserName();
            stbSetUserName.Select();
        }

        private void UserNameOK_Click(object sender, EventArgs e)
        {
            if (stbSetUserName.Text.Trim() != "")
            {
                MappingToolsCommonFuncs.SetSoftwareUserName(stbSetUserName.Text);
                mainForm.RefreshUserName();
                this.Close();
            }
            else
                slaCanNotBeEmpty.Visible = true;
        }

        private void UserNameTextChanged(object sender, EventArgs e)
        {
            if(stbSetUserName.Text.Trim()!="")
                slaCanNotBeEmpty.Visible = false;
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        this.Close();//esc关闭窗体
                        break;
                }
            }
            return false;
        }
        private void SetUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)//判断如果按下的是ESC键
            {
                if (MessageBox.Show("是否要退出程序", "信息提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();//退出应用程序
                }
            }
        }
    }
}
