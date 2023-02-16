namespace MappingTools
{
    partial class SelectLocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectLocation));
            this.selectLoc_Pic = new System.Windows.Forms.PictureBox();
            this.ws_loc_ok = new Sunny.UI.UIButton();
            this.ws_loc_cancel = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.tbWorkSpace_Loc = new Sunny.UI.UITextBox();
            this.ws_loc_browse = new Sunny.UI.UIButton();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)(this.selectLoc_Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // selectLoc_Pic
            // 
            this.selectLoc_Pic.Image = global::MappingTools.Properties.Resources.Loc_Sel_Pic;
            this.selectLoc_Pic.Location = new System.Drawing.Point(-11, 7);
            this.selectLoc_Pic.Name = "selectLoc_Pic";
            this.selectLoc_Pic.Size = new System.Drawing.Size(153, 183);
            this.selectLoc_Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.selectLoc_Pic.TabIndex = 5;
            this.selectLoc_Pic.TabStop = false;
            // 
            // ws_loc_ok
            // 
            this.ws_loc_ok.BackColor = System.Drawing.Color.Transparent;
            this.ws_loc_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ws_loc_ok.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.ws_loc_ok.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.ws_loc_ok.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.ws_loc_ok.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.ws_loc_ok.Font = new System.Drawing.Font("Segoe UI Black", 13.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ws_loc_ok.ForeSelectedColor = System.Drawing.Color.Empty;
            this.ws_loc_ok.Location = new System.Drawing.Point(355, 136);
            this.ws_loc_ok.Name = "ws_loc_ok";
            this.ws_loc_ok.Radius = 35;
            this.ws_loc_ok.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.ws_loc_ok.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.ws_loc_ok.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.ws_loc_ok.RectSelectedColor = System.Drawing.Color.Empty;
            this.ws_loc_ok.Size = new System.Drawing.Size(101, 38);
            this.ws_loc_ok.Style = Sunny.UI.UIStyle.Custom;
            this.ws_loc_ok.StyleCustomMode = true;
            this.ws_loc_ok.TabIndex = 19;
            this.ws_loc_ok.Text = "OK";
            this.ws_loc_ok.Click += new System.EventHandler(this.ws_loc_ok_Click);
            // 
            // ws_loc_cancel
            // 
            this.ws_loc_cancel.BackColor = System.Drawing.Color.Transparent;
            this.ws_loc_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ws_loc_cancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.ws_loc_cancel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.ws_loc_cancel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.ws_loc_cancel.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.ws_loc_cancel.Font = new System.Drawing.Font("Segoe UI Black", 13.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ws_loc_cancel.ForeSelectedColor = System.Drawing.Color.Empty;
            this.ws_loc_cancel.Location = new System.Drawing.Point(463, 136);
            this.ws_loc_cancel.Name = "ws_loc_cancel";
            this.ws_loc_cancel.Radius = 35;
            this.ws_loc_cancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.ws_loc_cancel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.ws_loc_cancel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.ws_loc_cancel.RectSelectedColor = System.Drawing.Color.Empty;
            this.ws_loc_cancel.Size = new System.Drawing.Size(101, 38);
            this.ws_loc_cancel.Style = Sunny.UI.UIStyle.Custom;
            this.ws_loc_cancel.StyleCustomMode = true;
            this.ws_loc_cancel.TabIndex = 20;
            this.ws_loc_cancel.Text = "Cancel";
            this.ws_loc_cancel.Click += new System.EventHandler(this.ws_loc_cancel_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Segoe UI Black", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.uiLabel1.Location = new System.Drawing.Point(99, 92);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(109, 26);
            this.uiLabel1.TabIndex = 21;
            this.uiLabel1.Text = "WorkSpace:";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbWorkSpace_Loc
            // 
            this.tbWorkSpace_Loc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbWorkSpace_Loc.FillColor = System.Drawing.Color.White;
            this.tbWorkSpace_Loc.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWorkSpace_Loc.Location = new System.Drawing.Point(207, 92);
            this.tbWorkSpace_Loc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbWorkSpace_Loc.Maximum = 2147483647D;
            this.tbWorkSpace_Loc.Minimum = -2147483648D;
            this.tbWorkSpace_Loc.Name = "tbWorkSpace_Loc";
            this.tbWorkSpace_Loc.Padding = new System.Windows.Forms.Padding(5);
            this.tbWorkSpace_Loc.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.tbWorkSpace_Loc.Size = new System.Drawing.Size(249, 29);
            this.tbWorkSpace_Loc.Style = Sunny.UI.UIStyle.Custom;
            this.tbWorkSpace_Loc.TabIndex = 22;
            // 
            // ws_loc_browse
            // 
            this.ws_loc_browse.BackColor = System.Drawing.Color.Transparent;
            this.ws_loc_browse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ws_loc_browse.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.ws_loc_browse.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.ws_loc_browse.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.ws_loc_browse.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.ws_loc_browse.Font = new System.Drawing.Font("Segoe UI Black", 13.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ws_loc_browse.ForeSelectedColor = System.Drawing.Color.Empty;
            this.ws_loc_browse.Location = new System.Drawing.Point(463, 86);
            this.ws_loc_browse.Name = "ws_loc_browse";
            this.ws_loc_browse.Radius = 35;
            this.ws_loc_browse.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.ws_loc_browse.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.ws_loc_browse.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.ws_loc_browse.RectSelectedColor = System.Drawing.Color.Empty;
            this.ws_loc_browse.Size = new System.Drawing.Size(101, 38);
            this.ws_loc_browse.Style = Sunny.UI.UIStyle.Custom;
            this.ws_loc_browse.StyleCustomMode = true;
            this.ws_loc_browse.TabIndex = 23;
            this.ws_loc_browse.Text = "Browse...";
            this.ws_loc_browse.Click += new System.EventHandler(this.ws_loc_browse_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("Segoe UI Black", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(33)))));
            this.uiLabel2.Location = new System.Drawing.Point(148, 9);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(389, 32);
            this.uiLabel2.TabIndex = 24;
            this.uiLabel2.Text = "WE ALWAYS HAVE TIME ENOUGH,";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("Segoe UI Black", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(33)))));
            this.uiLabel3.Location = new System.Drawing.Point(242, 41);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(322, 32);
            this.uiLabel3.TabIndex = 25;
            this.uiLabel3.Text = "IF WE WILL BUT USE IT ARIGHT.";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SelectLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(576, 196);
            this.ControlBox = false;
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.ws_loc_browse);
            this.Controls.Add(this.tbWorkSpace_Loc);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.ws_loc_cancel);
            this.Controls.Add(this.ws_loc_ok);
            this.Controls.Add(this.selectLoc_Pic);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MappingTools";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectLocation_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.selectLoc_Pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox selectLoc_Pic;
        private Sunny.UI.UIButton ws_loc_ok;
        private Sunny.UI.UIButton ws_loc_cancel;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox tbWorkSpace_Loc;
        private Sunny.UI.UIButton ws_loc_browse;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
    }
}

