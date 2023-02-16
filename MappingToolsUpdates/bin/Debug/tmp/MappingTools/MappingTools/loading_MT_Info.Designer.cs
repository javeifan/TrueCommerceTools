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
            this.tbDisclaimer = new System.Windows.Forms.TextBox();
            this.laVersionNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MT_version_timer
            // 
            this.MT_version_timer.Interval = 2500;
            this.MT_version_timer.Tick += new System.EventHandler(this.MT_version_timer_Tick);
            // 
            // tbDisclaimer
            // 
            this.tbDisclaimer.BackColor = System.Drawing.SystemColors.Window;
            this.tbDisclaimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDisclaimer.Enabled = false;
            this.tbDisclaimer.Location = new System.Drawing.Point(21, 129);
            this.tbDisclaimer.Multiline = true;
            this.tbDisclaimer.Name = "tbDisclaimer";
            this.tbDisclaimer.ReadOnly = true;
            this.tbDisclaimer.ShortcutsEnabled = false;
            this.tbDisclaimer.Size = new System.Drawing.Size(518, 81);
            this.tbDisclaimer.TabIndex = 0;
            // 
            // laVersionNum
            // 
            this.laVersionNum.AutoSize = true;
            this.laVersionNum.BackColor = System.Drawing.Color.White;
            this.laVersionNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.laVersionNum.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laVersionNum.ForeColor = System.Drawing.Color.Red;
            this.laVersionNum.Location = new System.Drawing.Point(530, 230);
            this.laVersionNum.Name = "laVersionNum";
            this.laVersionNum.Size = new System.Drawing.Size(0, 14);
            this.laVersionNum.TabIndex = 1;
            // 
            // loading_MT_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MappingTools.Properties.Resources.MT_Info;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(578, 252);
            this.Controls.Add(this.laVersionNum);
            this.Controls.Add(this.tbDisclaimer);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loading_MT_Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mapping Tools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer MT_version_timer;
        private System.Windows.Forms.TextBox tbDisclaimer;
        private System.Windows.Forms.Label laVersionNum;
    }
}