namespace MappingTools
{
    partial class loading_MT_Info
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loading_MT_Info));
            this.MT_version_timer = new System.Windows.Forms.Timer(this.components);
            this.laVersionNum = new System.Windows.Forms.Label();
            this.slaVersionNum = new Sunny.UI.UILabel();
            this.slasDisclaimer = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MT_version_timer
            // 
            this.MT_version_timer.Interval = 2500;
            this.MT_version_timer.Tick += new System.EventHandler(this.MT_version_timer_Tick);
            // 
            // laVersionNum
            // 
            this.laVersionNum.AutoSize = true;
            this.laVersionNum.BackColor = System.Drawing.Color.White;
            this.laVersionNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.laVersionNum.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laVersionNum.ForeColor = System.Drawing.Color.Red;
            this.laVersionNum.Location = new System.Drawing.Point(24, 203);
            this.laVersionNum.Name = "laVersionNum";
            this.laVersionNum.Size = new System.Drawing.Size(0, 14);
            this.laVersionNum.TabIndex = 1;
            // 
            // slaVersionNum
            // 
            this.slaVersionNum.BackColor = System.Drawing.Color.Transparent;
            this.slaVersionNum.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slaVersionNum.ForeColor = System.Drawing.Color.White;
            this.slaVersionNum.Location = new System.Drawing.Point(473, 228);
            this.slaVersionNum.Name = "slaVersionNum";
            this.slaVersionNum.Size = new System.Drawing.Size(100, 18);
            this.slaVersionNum.TabIndex = 2;
            this.slaVersionNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // slasDisclaimer
            // 
            this.slasDisclaimer.BackColor = System.Drawing.Color.Transparent;
            this.slasDisclaimer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slasDisclaimer.Location = new System.Drawing.Point(29, 99);
            this.slasDisclaimer.Name = "slasDisclaimer";
            this.slasDisclaimer.Size = new System.Drawing.Size(236, 85);
            this.slasDisclaimer.TabIndex = 4;
            this.slasDisclaimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("Segoe UI Black", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(63)))), ((int)(((byte)(90)))));
            this.uiLabel1.Location = new System.Drawing.Point(24, 46);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(197, 50);
            this.uiLabel1.TabIndex = 5;
            this.uiLabel1.Text = "Mapping";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel2.Font = new System.Drawing.Font("Segoe UI Black", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(198)))), ((int)(((byte)(139)))));
            this.uiLabel2.Location = new System.Drawing.Point(189, 46);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(107, 50);
            this.uiLabel2.TabIndex = 6;
            this.uiLabel2.Text = "Tools";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MappingTools.Properties.Resources.MT_Info_TC_logo;
            this.pictureBox1.Location = new System.Drawing.Point(28, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // loading_MT_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MappingTools.Properties.Resources.MT_Info;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(574, 252);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.slasDisclaimer);
            this.Controls.Add(this.slaVersionNum);
            this.Controls.Add(this.laVersionNum);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loading_MT_Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mapping Tools";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer MT_version_timer;
        private System.Windows.Forms.Label laVersionNum;
        private Sunny.UI.UILabel slaVersionNum;
        private Sunny.UI.UILabel slasDisclaimer;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}