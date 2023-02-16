namespace MappingTools
{
    partial class VANConsultantDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VANConsultantDetails));
            this.laConsultant = new System.Windows.Forms.Label();
            this.tbIntertradeConsultant = new System.Windows.Forms.TextBox();
            this.btInterTradeOK = new System.Windows.Forms.Button();
            this.btInterTradeCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // laConsultant
            // 
            this.laConsultant.AutoSize = true;
            this.laConsultant.Location = new System.Drawing.Point(34, 31);
            this.laConsultant.Name = "laConsultant";
            this.laConsultant.Size = new System.Drawing.Size(82, 20);
            this.laConsultant.TabIndex = 0;
            this.laConsultant.Text = "Consultant:";
            // 
            // tbIntertradeConsultant
            // 
            this.tbIntertradeConsultant.Location = new System.Drawing.Point(119, 28);
            this.tbIntertradeConsultant.Name = "tbIntertradeConsultant";
            this.tbIntertradeConsultant.Size = new System.Drawing.Size(266, 27);
            this.tbIntertradeConsultant.TabIndex = 1;
            this.tbIntertradeConsultant.TextChanged += new System.EventHandler(this.tbIntertradeConsultant_TextChanged);
            // 
            // btInterTradeOK
            // 
            this.btInterTradeOK.Location = new System.Drawing.Point(83, 92);
            this.btInterTradeOK.Name = "btInterTradeOK";
            this.btInterTradeOK.Size = new System.Drawing.Size(87, 29);
            this.btInterTradeOK.TabIndex = 6;
            this.btInterTradeOK.Text = "OK";
            this.btInterTradeOK.UseVisualStyleBackColor = true;
            this.btInterTradeOK.Click += new System.EventHandler(this.InterTradeOK_Click);
            // 
            // btInterTradeCancel
            // 
            this.btInterTradeCancel.Location = new System.Drawing.Point(254, 92);
            this.btInterTradeCancel.Name = "btInterTradeCancel";
            this.btInterTradeCancel.Size = new System.Drawing.Size(87, 29);
            this.btInterTradeCancel.TabIndex = 7;
            this.btInterTradeCancel.Text = "Cancel";
            this.btInterTradeCancel.UseVisualStyleBackColor = true;
            this.btInterTradeCancel.Click += new System.EventHandler(this.InterTradeCancel_Click);
            // 
            // VANConsultantDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(429, 142);
            this.Controls.Add(this.btInterTradeCancel);
            this.Controls.Add(this.btInterTradeOK);
            this.Controls.Add(this.tbIntertradeConsultant);
            this.Controls.Add(this.laConsultant);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VANConsultantDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label laConsultant;
        private System.Windows.Forms.TextBox tbIntertradeConsultant;
        private System.Windows.Forms.Button btInterTradeOK;
        private System.Windows.Forms.Button btInterTradeCancel;
    }
}