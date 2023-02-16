namespace MappingTools
{
    partial class VANIntertradeDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VANIntertradeDetails));
            this.laConsultant = new System.Windows.Forms.Label();
            this.tbIntertradeConsultant = new System.Windows.Forms.TextBox();
            this.laProjectLink = new System.Windows.Forms.Label();
            this.tbIntertradeProjectLink = new System.Windows.Forms.TextBox();
            this.laLinkName = new System.Windows.Forms.Label();
            this.tbIntertradeLinkDetail = new System.Windows.Forms.TextBox();
            this.btInterTradeOK = new System.Windows.Forms.Button();
            this.btInterTradeCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // laConsultant
            // 
            this.laConsultant.AutoSize = true;
            this.laConsultant.Location = new System.Drawing.Point(34, 31);
            this.laConsultant.Name = "laConsultant";
            this.laConsultant.Size = new System.Drawing.Size(68, 15);
            this.laConsultant.TabIndex = 0;
            this.laConsultant.Text = "Consultant:";
            // 
            // tbIntertradeConsultant
            // 
            this.tbIntertradeConsultant.Location = new System.Drawing.Point(119, 28);
            this.tbIntertradeConsultant.Name = "tbIntertradeConsultant";
            this.tbIntertradeConsultant.Size = new System.Drawing.Size(266, 23);
            this.tbIntertradeConsultant.TabIndex = 1;
            // 
            // laProjectLink
            // 
            this.laProjectLink.AutoSize = true;
            this.laProjectLink.Location = new System.Drawing.Point(31, 72);
            this.laProjectLink.Name = "laProjectLink";
            this.laProjectLink.Size = new System.Drawing.Size(72, 15);
            this.laProjectLink.TabIndex = 2;
            this.laProjectLink.Text = "Project Link:";
            // 
            // tbIntertradeProjectLink
            // 
            this.tbIntertradeProjectLink.Location = new System.Drawing.Point(119, 68);
            this.tbIntertradeProjectLink.Name = "tbIntertradeProjectLink";
            this.tbIntertradeProjectLink.Size = new System.Drawing.Size(266, 23);
            this.tbIntertradeProjectLink.TabIndex = 3;
            // 
            // laLinkName
            // 
            this.laLinkName.AutoSize = true;
            this.laLinkName.Location = new System.Drawing.Point(37, 112);
            this.laLinkName.Name = "laLinkName";
            this.laLinkName.Size = new System.Drawing.Size(65, 15);
            this.laLinkName.TabIndex = 4;
            this.laLinkName.Text = "Link Detail:";
            // 
            // tbIntertradeLinkDetail
            // 
            this.tbIntertradeLinkDetail.Location = new System.Drawing.Point(119, 108);
            this.tbIntertradeLinkDetail.Name = "tbIntertradeLinkDetail";
            this.tbIntertradeLinkDetail.Size = new System.Drawing.Size(266, 23);
            this.tbIntertradeLinkDetail.TabIndex = 5;
            // 
            // btInterTradeOK
            // 
            this.btInterTradeOK.Location = new System.Drawing.Point(72, 162);
            this.btInterTradeOK.Name = "btInterTradeOK";
            this.btInterTradeOK.Size = new System.Drawing.Size(87, 29);
            this.btInterTradeOK.TabIndex = 6;
            this.btInterTradeOK.Text = "OK";
            this.btInterTradeOK.UseVisualStyleBackColor = true;
            this.btInterTradeOK.Click += new System.EventHandler(this.InterTradeOK_Click);
            // 
            // btInterTradeCancel
            // 
            this.btInterTradeCancel.Location = new System.Drawing.Point(255, 162);
            this.btInterTradeCancel.Name = "btInterTradeCancel";
            this.btInterTradeCancel.Size = new System.Drawing.Size(87, 29);
            this.btInterTradeCancel.TabIndex = 7;
            this.btInterTradeCancel.Text = "Cancel";
            this.btInterTradeCancel.UseVisualStyleBackColor = true;
            this.btInterTradeCancel.Click += new System.EventHandler(this.InterTradeCancel_Click);
            // 
            // VANIntertradeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(429, 223);
            this.Controls.Add(this.btInterTradeCancel);
            this.Controls.Add(this.btInterTradeOK);
            this.Controls.Add(this.tbIntertradeLinkDetail);
            this.Controls.Add(this.laLinkName);
            this.Controls.Add(this.tbIntertradeProjectLink);
            this.Controls.Add(this.laProjectLink);
            this.Controls.Add(this.tbIntertradeConsultant);
            this.Controls.Add(this.laConsultant);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VANIntertradeDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Intertrade Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label laConsultant;
        private System.Windows.Forms.TextBox tbIntertradeConsultant;
        private System.Windows.Forms.Label laProjectLink;
        private System.Windows.Forms.TextBox tbIntertradeProjectLink;
        private System.Windows.Forms.Label laLinkName;
        private System.Windows.Forms.TextBox tbIntertradeLinkDetail;
        private System.Windows.Forms.Button btInterTradeOK;
        private System.Windows.Forms.Button btInterTradeCancel;
    }
}