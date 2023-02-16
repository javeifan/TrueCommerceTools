
namespace MappingTools
{
    partial class SelectWTXInstallLocation
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
            this.tbWTXLoc = new System.Windows.Forms.TextBox();
            this.btWTX_loc_Browse = new System.Windows.Forms.Button();
            this.btSelectWTXLoc_OK = new System.Windows.Forms.Button();
            this.btSelectWTXLoc_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbWTXLoc
            // 
            this.tbWTXLoc.Location = new System.Drawing.Point(22, 33);
            this.tbWTXLoc.Name = "tbWTXLoc";
            this.tbWTXLoc.Size = new System.Drawing.Size(329, 22);
            this.tbWTXLoc.TabIndex = 0;
            // 
            // btWTX_loc_Browse
            // 
            this.btWTX_loc_Browse.Location = new System.Drawing.Point(372, 31);
            this.btWTX_loc_Browse.Name = "btWTX_loc_Browse";
            this.btWTX_loc_Browse.Size = new System.Drawing.Size(75, 23);
            this.btWTX_loc_Browse.TabIndex = 1;
            this.btWTX_loc_Browse.Text = "Browse..";
            this.btWTX_loc_Browse.UseVisualStyleBackColor = true;
            this.btWTX_loc_Browse.Click += new System.EventHandler(this.WTX_loc_Browse_Click);
            // 
            // btSelectWTXLoc_OK
            // 
            this.btSelectWTXLoc_OK.Location = new System.Drawing.Point(276, 69);
            this.btSelectWTXLoc_OK.Name = "btSelectWTXLoc_OK";
            this.btSelectWTXLoc_OK.Size = new System.Drawing.Size(75, 23);
            this.btSelectWTXLoc_OK.TabIndex = 2;
            this.btSelectWTXLoc_OK.Text = "OK";
            this.btSelectWTXLoc_OK.UseVisualStyleBackColor = true;
            this.btSelectWTXLoc_OK.Click += new System.EventHandler(this.SelectWTXLoc_OK_Click);
            // 
            // btSelectWTXLoc_Cancel
            // 
            this.btSelectWTXLoc_Cancel.Location = new System.Drawing.Point(372, 69);
            this.btSelectWTXLoc_Cancel.Name = "btSelectWTXLoc_Cancel";
            this.btSelectWTXLoc_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btSelectWTXLoc_Cancel.TabIndex = 3;
            this.btSelectWTXLoc_Cancel.Text = "Cancel";
            this.btSelectWTXLoc_Cancel.UseVisualStyleBackColor = true;
            this.btSelectWTXLoc_Cancel.Click += new System.EventHandler(this.SelectWTXLoc_Cancel_Click);
            // 
            // SelectWTXInstallLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 116);
            this.ControlBox = false;
            this.Controls.Add(this.btSelectWTXLoc_Cancel);
            this.Controls.Add(this.btSelectWTXLoc_OK);
            this.Controls.Add(this.btWTX_loc_Browse);
            this.Controls.Add(this.tbWTXLoc);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectWTXInstallLocation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WTX/ITX";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbWTXLoc;
        private System.Windows.Forms.Button btWTX_loc_Browse;
        private System.Windows.Forms.Button btSelectWTXLoc_OK;
        private System.Windows.Forms.Button btSelectWTXLoc_Cancel;
    }
}