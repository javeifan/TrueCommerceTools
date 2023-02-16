namespace MappingTools
{
    partial class SetUserName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetUserName));
            this.stbSetUserNameOK = new Sunny.UI.UIButton();
            this.slaUserName = new Sunny.UI.UISymbolLabel();
            this.stbSetUserName = new Sunny.UI.UITextBox();
            this.slaCanNotBeEmpty = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // stbSetUserNameOK
            // 
            this.stbSetUserNameOK.BackColor = System.Drawing.Color.Transparent;
            this.stbSetUserNameOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stbSetUserNameOK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.stbSetUserNameOK.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.stbSetUserNameOK.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.stbSetUserNameOK.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.stbSetUserNameOK.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.stbSetUserNameOK.ForeSelectedColor = System.Drawing.Color.Empty;
            this.stbSetUserNameOK.Location = new System.Drawing.Point(101, 100);
            this.stbSetUserNameOK.Name = "stbSetUserNameOK";
            this.stbSetUserNameOK.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.stbSetUserNameOK.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.stbSetUserNameOK.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(201)))), ((int)(((byte)(202)))));
            this.stbSetUserNameOK.RectSelectedColor = System.Drawing.Color.Empty;
            this.stbSetUserNameOK.Size = new System.Drawing.Size(158, 35);
            this.stbSetUserNameOK.Style = Sunny.UI.UIStyle.Custom;
            this.stbSetUserNameOK.StyleCustomMode = true;
            this.stbSetUserNameOK.TabIndex = 19;
            this.stbSetUserNameOK.Text = "OK";
            this.stbSetUserNameOK.Click += new System.EventHandler(this.UserNameOK_Click);
            // 
            // slaUserName
            // 
            this.slaUserName.BackColor = System.Drawing.Color.Transparent;
            this.slaUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.slaUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.slaUserName.Location = new System.Drawing.Point(11, 27);
            this.slaUserName.Name = "slaUserName";
            this.slaUserName.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.slaUserName.Size = new System.Drawing.Size(157, 35);
            this.slaUserName.Style = Sunny.UI.UIStyle.Custom;
            this.slaUserName.Symbol = 61447;
            this.slaUserName.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.slaUserName.TabIndex = 20;
            this.slaUserName.Text = "User Name:";
            // 
            // stbSetUserName
            // 
            this.stbSetUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.stbSetUserName.FillColor = System.Drawing.Color.White;
            this.stbSetUserName.Font = new System.Drawing.Font("Segoe UI Black", 13.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.stbSetUserName.Location = new System.Drawing.Point(175, 29);
            this.stbSetUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stbSetUserName.Maximum = 2147483647D;
            this.stbSetUserName.Minimum = -2147483648D;
            this.stbSetUserName.Name = "stbSetUserName";
            this.stbSetUserName.Padding = new System.Windows.Forms.Padding(5);
            this.stbSetUserName.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.stbSetUserName.Size = new System.Drawing.Size(150, 31);
            this.stbSetUserName.Style = Sunny.UI.UIStyle.Custom;
            this.stbSetUserName.TabIndex = 22;
            this.stbSetUserName.TextChanged += new System.EventHandler(this.UserNameTextChanged);
            // 
            // slaCanNotBeEmpty
            // 
            this.slaCanNotBeEmpty.BackColor = System.Drawing.Color.Transparent;
            this.slaCanNotBeEmpty.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slaCanNotBeEmpty.ForeColor = System.Drawing.Color.Red;
            this.slaCanNotBeEmpty.Location = new System.Drawing.Point(174, 61);
            this.slaCanNotBeEmpty.Name = "slaCanNotBeEmpty";
            this.slaCanNotBeEmpty.Size = new System.Drawing.Size(136, 25);
            this.slaCanNotBeEmpty.TabIndex = 23;
            this.slaCanNotBeEmpty.Text = "Can not be empty!";
            this.slaCanNotBeEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.slaCanNotBeEmpty.Visible = false;
            // 
            // SetUserName
            // 
            this.AcceptButton = this.stbSetUserNameOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(357, 162);
            this.Controls.Add(this.slaCanNotBeEmpty);
            this.Controls.Add(this.stbSetUserName);
            this.Controls.Add(this.slaUserName);
            this.Controls.Add(this.stbSetUserNameOK);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SetUserName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set User Name";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SetUserName_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIButton stbSetUserNameOK;
        private Sunny.UI.UISymbolLabel slaUserName;
        private Sunny.UI.UITextBox stbSetUserName;
        private Sunny.UI.UILabel slaCanNotBeEmpty;
    }
}