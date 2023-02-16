namespace MappingTools
{
    partial class NewVersionFound
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewVersionFound));
            this.laNewVerionFoundInfo = new System.Windows.Forms.Label();
            this.btNewVersionUpdate = new System.Windows.Forms.Button();
            this.btNewVersionCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // laNewVerionFoundInfo
            // 
            this.laNewVerionFoundInfo.AutoSize = true;
            this.laNewVerionFoundInfo.Location = new System.Drawing.Point(50, 19);
            this.laNewVerionFoundInfo.Name = "laNewVerionFoundInfo";
            this.laNewVerionFoundInfo.Size = new System.Drawing.Size(0, 15);
            this.laNewVerionFoundInfo.TabIndex = 0;
            // 
            // btNewVersionUpdate
            // 
            this.btNewVersionUpdate.Location = new System.Drawing.Point(77, 82);
            this.btNewVersionUpdate.Name = "btNewVersionUpdate";
            this.btNewVersionUpdate.Size = new System.Drawing.Size(75, 23);
            this.btNewVersionUpdate.TabIndex = 1;
            this.btNewVersionUpdate.Text = "Update";
            this.btNewVersionUpdate.UseVisualStyleBackColor = true;
            this.btNewVersionUpdate.Click += new System.EventHandler(this.NewVersionUpdate_Click);
            // 
            // btNewVersionCancel
            // 
            this.btNewVersionCancel.Location = new System.Drawing.Point(219, 82);
            this.btNewVersionCancel.Name = "btNewVersionCancel";
            this.btNewVersionCancel.Size = new System.Drawing.Size(75, 23);
            this.btNewVersionCancel.TabIndex = 2;
            this.btNewVersionCancel.Text = "Cancel";
            this.btNewVersionCancel.UseVisualStyleBackColor = true;
            this.btNewVersionCancel.Click += new System.EventHandler(this.NewVersionCancel_Click);
            // 
            // NewVersionFound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 134);
            this.Controls.Add(this.btNewVersionCancel);
            this.Controls.Add(this.btNewVersionUpdate);
            this.Controls.Add(this.laNewVerionFoundInfo);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewVersionFound";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Version!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label laNewVerionFoundInfo;
        private System.Windows.Forms.Button btNewVersionUpdate;
        private System.Windows.Forms.Button btNewVersionCancel;
    }
}