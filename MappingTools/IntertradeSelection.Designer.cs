namespace MappingTools
{
    partial class IntertradeSelection
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
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntertradeSelection));
            this.laCCName = new System.Windows.Forms.Label();
            this.tbCCName = new System.Windows.Forms.TextBox();
            this.laIs832 = new System.Windows.Forms.Label();
            this.checkboxIs832 = new System.Windows.Forms.CheckBox();
            this.btInterTradeSelectOK = new System.Windows.Forms.Button();
            this.btInterTradeSelectCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // laCCName
            // 
            this.laCCName.AutoSize = true;
            this.laCCName.Location = new System.Drawing.Point(34, 31);
            this.laCCName.Name = "laCCName";
            this.laCCName.Size = new System.Drawing.Size(68, 15);
            this.laCCName.TabIndex = 0;
            this.laCCName.Text = "Consultant:";
            // 
            // tbCCName
            // 
            this.tbCCName.Location = new System.Drawing.Point(119, 28);
            this.tbCCName.Name = "tbCCName";
            this.tbCCName.Size = new System.Drawing.Size(266, 23);
            this.tbCCName.TabIndex = 1;

            // 
            // laIs832
            // 
            this.laIs832.AutoSize = true;
            this.laIs832.Location = new System.Drawing.Point(31, 72);
            this.laIs832.Name = "laIs832";
            this.laIs832.Size = new System.Drawing.Size(72, 15);
            this.laIs832.TabIndex = 0;
            this.laIs832.Text = "Only using Intertrade for 832 transactions: ";
            // 
            // checkboxIs832
            // 
            this.checkboxIs832.Location = new System.Drawing.Point(285, 68);
            this.checkboxIs832.Name = "checkboxIs832";
            this.checkboxIs832.Size = new System.Drawing.Size(20, 20);
            this.checkboxIs832.Checked = false;

            // 
            // btInterTradeOK
            // 
            this.btInterTradeSelectOK.Location = new System.Drawing.Point(72, 162);
            this.btInterTradeSelectOK.Name = "btInterTradeOK";
            this.btInterTradeSelectOK.Size = new System.Drawing.Size(87, 29);
            this.btInterTradeSelectOK.TabIndex = 6;
            this.btInterTradeSelectOK.Text = "OK";
            this.btInterTradeSelectOK.UseVisualStyleBackColor = true;
            this.btInterTradeSelectOK.Click += new System.EventHandler(this.btInterTradeSelectOK_Click);
            // 
            // btInterTradeCancel
            // 
            this.btInterTradeSelectCancel.Location = new System.Drawing.Point(255, 162);
            this.btInterTradeSelectCancel.Name = "btInterTradeCancel";
            this.btInterTradeSelectCancel.Size = new System.Drawing.Size(87, 29);
            this.btInterTradeSelectCancel.TabIndex = 7;
            this.btInterTradeSelectCancel.Text = "Cancel";
            this.btInterTradeSelectCancel.UseVisualStyleBackColor = true;
            this.btInterTradeSelectCancel.Click += new System.EventHandler(this.btInterTradeSelectCancel_Click);

            //
            // IntertradeSelection
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(429, 223);
            this.Controls.Add(this.btInterTradeSelectOK);
            this.Controls.Add(this.btInterTradeSelectCancel);
            this.Controls.Add(this.laCCName);
            this.Controls.Add(this.tbCCName);
            this.Controls.Add(this.laIs832);
            this.Controls.Add(this.checkboxIs832);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IntertradeSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label laCCName;
        private System.Windows.Forms.TextBox tbCCName;
        private System.Windows.Forms.Label laIs832;
        private System.Windows.Forms.CheckBox checkboxIs832;
        private System.Windows.Forms.Button btInterTradeSelectOK;
        private System.Windows.Forms.Button btInterTradeSelectCancel;
    }
}