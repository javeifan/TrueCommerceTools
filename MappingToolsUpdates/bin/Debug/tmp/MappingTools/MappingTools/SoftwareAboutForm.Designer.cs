
namespace MappingTools
{
    partial class SoftwareAboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftwareAboutForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btSoftwareAboutOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.palSoftwareAbout = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.palSoftwareAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MappingTools.Properties.Resources.MPT_ICO;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 124);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btSoftwareAboutOK
            // 
            this.btSoftwareAboutOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSoftwareAboutOK.Location = new System.Drawing.Point(427, 12);
            this.btSoftwareAboutOK.Name = "btSoftwareAboutOK";
            this.btSoftwareAboutOK.Size = new System.Drawing.Size(107, 27);
            this.btSoftwareAboutOK.TabIndex = 1;
            this.btSoftwareAboutOK.Text = "OK";
            this.btSoftwareAboutOK.UseVisualStyleBackColor = true;
            this.btSoftwareAboutOK.Click += new System.EventHandler(this.SoftwareAboutOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mapping Tools";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bulid id:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "(c) Copyright Sam.Shi.  All rights reserved.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(356, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Email: eien.gs127@gmail.com";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(131, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(400, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "This offering is based on the work of mapping specialist in TrueCommerce.";
            // 
            // palSoftwareAbout
            // 
            this.palSoftwareAbout.BackColor = System.Drawing.Color.Gainsboro;
            this.palSoftwareAbout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.palSoftwareAbout.Controls.Add(this.btSoftwareAboutOK);
            this.palSoftwareAbout.Location = new System.Drawing.Point(-5, 131);
            this.palSoftwareAbout.Name = "palSoftwareAbout";
            this.palSoftwareAbout.Size = new System.Drawing.Size(551, 75);
            this.palSoftwareAbout.TabIndex = 10;
            // 
            // SoftwareAboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 186);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.palSoftwareAbout);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SoftwareAboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About MappingTools";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.palSoftwareAbout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btSoftwareAboutOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel palSoftwareAbout;
    }
}