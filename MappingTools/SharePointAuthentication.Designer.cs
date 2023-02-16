
namespace MappingTools
{
    partial class SharePointAuthentication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharePointAuthentication));
            this.stbSharePointUserName = new Sunny.UI.UITextBox();
            this.stbSharePointUserPwd = new Sunny.UI.UITextBox();
            this.slaSharePointUserName = new Sunny.UI.UISymbolLabel();
            this.slaSharePointPwd = new Sunny.UI.UISymbolLabel();
            this.sbtSharePointLoginCheck = new Sunny.UI.UISymbolButton();
            this.sbtSharePointLoginCancel = new Sunny.UI.UISymbolButton();
            this.slaSharePonitAuthentication_Info = new Sunny.UI.UILabel();
            this.slaDomain = new Sunny.UI.UISymbolLabel();
            this.stbSharePointDomain = new Sunny.UI.UITextBox();
            this.SuspendLayout();
            // 
            // stbSharePointUserName
            // 
            this.stbSharePointUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.stbSharePointUserName.FillColor = System.Drawing.Color.White;
            this.stbSharePointUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stbSharePointUserName.Location = new System.Drawing.Point(185, 34);
            this.stbSharePointUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stbSharePointUserName.Maximum = 2147483647D;
            this.stbSharePointUserName.Minimum = -2147483648D;
            this.stbSharePointUserName.Name = "stbSharePointUserName";
            this.stbSharePointUserName.Padding = new System.Windows.Forms.Padding(5);
            this.stbSharePointUserName.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.stbSharePointUserName.Size = new System.Drawing.Size(195, 33);
            this.stbSharePointUserName.Style = Sunny.UI.UIStyle.Custom;
            this.stbSharePointUserName.TabIndex = 0;
            this.stbSharePointUserName.TextChanged += new System.EventHandler(this.SharePointUserName_TextChanged);
            // 
            // stbSharePointUserPwd
            // 
            this.stbSharePointUserPwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.stbSharePointUserPwd.FillColor = System.Drawing.Color.White;
            this.stbSharePointUserPwd.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.stbSharePointUserPwd.Location = new System.Drawing.Point(185, 130);
            this.stbSharePointUserPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stbSharePointUserPwd.Maximum = 2147483647D;
            this.stbSharePointUserPwd.Minimum = -2147483648D;
            this.stbSharePointUserPwd.Name = "stbSharePointUserPwd";
            this.stbSharePointUserPwd.Padding = new System.Windows.Forms.Padding(5);
            this.stbSharePointUserPwd.PasswordChar = '●';
            this.stbSharePointUserPwd.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.stbSharePointUserPwd.Size = new System.Drawing.Size(195, 33);
            this.stbSharePointUserPwd.Style = Sunny.UI.UIStyle.Custom;
            this.stbSharePointUserPwd.TabIndex = 2;
            this.stbSharePointUserPwd.TextChanged += new System.EventHandler(this.SharePointPwd_TextChanged);
            // 
            // slaSharePointUserName
            // 
            this.slaSharePointUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slaSharePointUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.slaSharePointUserName.Location = new System.Drawing.Point(37, 32);
            this.slaSharePointUserName.Name = "slaSharePointUserName";
            this.slaSharePointUserName.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.slaSharePointUserName.Size = new System.Drawing.Size(131, 35);
            this.slaSharePointUserName.Style = Sunny.UI.UIStyle.Custom;
            this.slaSharePointUserName.Symbol = 61447;
            this.slaSharePointUserName.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.slaSharePointUserName.TabIndex = 3;
            this.slaSharePointUserName.Text = "User Name:";
            this.slaSharePointUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // slaSharePointPwd
            // 
            this.slaSharePointPwd.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.slaSharePointPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.slaSharePointPwd.Location = new System.Drawing.Point(37, 128);
            this.slaSharePointPwd.Name = "slaSharePointPwd";
            this.slaSharePointPwd.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.slaSharePointPwd.Size = new System.Drawing.Size(120, 35);
            this.slaSharePointPwd.Style = Sunny.UI.UIStyle.Custom;
            this.slaSharePointPwd.Symbol = 61758;
            this.slaSharePointPwd.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.slaSharePointPwd.TabIndex = 4;
            this.slaSharePointPwd.Text = "Password:";
            this.slaSharePointPwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sbtSharePointLoginCheck
            // 
            this.sbtSharePointLoginCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sbtSharePointLoginCheck.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.sbtSharePointLoginCheck.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.sbtSharePointLoginCheck.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.sbtSharePointLoginCheck.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.sbtSharePointLoginCheck.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbtSharePointLoginCheck.Location = new System.Drawing.Point(37, 222);
            this.sbtSharePointLoginCheck.Name = "sbtSharePointLoginCheck";
            this.sbtSharePointLoginCheck.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.sbtSharePointLoginCheck.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.sbtSharePointLoginCheck.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.sbtSharePointLoginCheck.RectSelectedColor = System.Drawing.Color.Empty;
            this.sbtSharePointLoginCheck.Size = new System.Drawing.Size(138, 35);
            this.sbtSharePointLoginCheck.Style = Sunny.UI.UIStyle.Custom;
            this.sbtSharePointLoginCheck.TabIndex = 5;
            this.sbtSharePointLoginCheck.Text = "Check";
            this.sbtSharePointLoginCheck.Click += new System.EventHandler(this.SharePointLoginCheck_Click);
            // 
            // sbtSharePointLoginCancel
            // 
            this.sbtSharePointLoginCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sbtSharePointLoginCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.sbtSharePointLoginCancel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.sbtSharePointLoginCancel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.sbtSharePointLoginCancel.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.sbtSharePointLoginCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.sbtSharePointLoginCancel.Location = new System.Drawing.Point(242, 222);
            this.sbtSharePointLoginCancel.Name = "sbtSharePointLoginCancel";
            this.sbtSharePointLoginCancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.sbtSharePointLoginCancel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.sbtSharePointLoginCancel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.sbtSharePointLoginCancel.RectSelectedColor = System.Drawing.Color.Empty;
            this.sbtSharePointLoginCancel.Size = new System.Drawing.Size(138, 35);
            this.sbtSharePointLoginCancel.Style = Sunny.UI.UIStyle.Custom;
            this.sbtSharePointLoginCancel.Symbol = 61453;
            this.sbtSharePointLoginCancel.TabIndex = 20;
            this.sbtSharePointLoginCancel.Text = "Cancel";
            this.sbtSharePointLoginCancel.Click += new System.EventHandler(this.SharePointLoginCancel_Click);
            // 
            // slaSharePonitAuthentication_Info
            // 
            this.slaSharePonitAuthentication_Info.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slaSharePonitAuthentication_Info.ForeColor = System.Drawing.Color.Red;
            this.slaSharePonitAuthentication_Info.Location = new System.Drawing.Point(181, 168);
            this.slaSharePonitAuthentication_Info.Name = "slaSharePonitAuthentication_Info";
            this.slaSharePonitAuthentication_Info.Size = new System.Drawing.Size(199, 23);
            this.slaSharePonitAuthentication_Info.TabIndex = 21;
            this.slaSharePonitAuthentication_Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // slaDomain
            // 
            this.slaDomain.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.slaDomain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.slaDomain.Location = new System.Drawing.Point(37, 80);
            this.slaDomain.Name = "slaDomain";
            this.slaDomain.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.slaDomain.Size = new System.Drawing.Size(120, 35);
            this.slaDomain.Style = Sunny.UI.UIStyle.Custom;
            this.slaDomain.Symbol = 57455;
            this.slaDomain.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.slaDomain.TabIndex = 23;
            this.slaDomain.Text = "Domain:";
            this.slaDomain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stbSharePointDomain
            // 
            this.stbSharePointDomain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.stbSharePointDomain.FillColor = System.Drawing.Color.White;
            this.stbSharePointDomain.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.stbSharePointDomain.Location = new System.Drawing.Point(185, 82);
            this.stbSharePointDomain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stbSharePointDomain.Maximum = 2147483647D;
            this.stbSharePointDomain.Minimum = -2147483648D;
            this.stbSharePointDomain.Name = "stbSharePointDomain";
            this.stbSharePointDomain.Padding = new System.Windows.Forms.Padding(5);
            this.stbSharePointDomain.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.stbSharePointDomain.Size = new System.Drawing.Size(195, 33);
            this.stbSharePointDomain.Style = Sunny.UI.UIStyle.Custom;
            this.stbSharePointDomain.TabIndex = 22;
            this.stbSharePointDomain.TextChanged += new System.EventHandler(this.SharePointDomain_TextChanged);
            // 
            // SharePointAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 288);
            this.Controls.Add(this.slaDomain);
            this.Controls.Add(this.stbSharePointDomain);
            this.Controls.Add(this.slaSharePonitAuthentication_Info);
            this.Controls.Add(this.sbtSharePointLoginCancel);
            this.Controls.Add(this.sbtSharePointLoginCheck);
            this.Controls.Add(this.slaSharePointPwd);
            this.Controls.Add(this.slaSharePointUserName);
            this.Controls.Add(this.stbSharePointUserPwd);
            this.Controls.Add(this.stbSharePointUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SharePointAuthentication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Share Point Login";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITextBox stbSharePointUserName;
        private Sunny.UI.UITextBox stbSharePointUserPwd;
        private Sunny.UI.UISymbolLabel slaSharePointUserName;
        private Sunny.UI.UISymbolLabel slaSharePointPwd;
        private Sunny.UI.UISymbolButton sbtSharePointLoginCheck;
        private Sunny.UI.UISymbolButton sbtSharePointLoginCancel;
        private Sunny.UI.UILabel slaSharePonitAuthentication_Info;
        private Sunny.UI.UISymbolLabel slaDomain;
        private Sunny.UI.UITextBox stbSharePointDomain;
    }
}