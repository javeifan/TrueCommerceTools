
namespace MappingToolsUpdates
{
    partial class MappingToolsUpdates
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
            this.btMappingToolsUpdatesUpdate = new System.Windows.Forms.Button();
            this.btMappingToolsUpdatesCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.laVersionCompare = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btMappingToolsUpdatesUpdate
            // 
            this.btMappingToolsUpdatesUpdate.Location = new System.Drawing.Point(362, 205);
            this.btMappingToolsUpdatesUpdate.Name = "btMappingToolsUpdatesUpdate";
            this.btMappingToolsUpdatesUpdate.Size = new System.Drawing.Size(104, 30);
            this.btMappingToolsUpdatesUpdate.TabIndex = 0;
            this.btMappingToolsUpdatesUpdate.Text = "Update Now";
            this.btMappingToolsUpdatesUpdate.UseVisualStyleBackColor = true;
            this.btMappingToolsUpdatesUpdate.Click += new System.EventHandler(this.MappingToolsUpdatesUpdate_Click);
            // 
            // btMappingToolsUpdatesCancel
            // 
            this.btMappingToolsUpdatesCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btMappingToolsUpdatesCancel.Location = new System.Drawing.Point(483, 205);
            this.btMappingToolsUpdatesCancel.Name = "btMappingToolsUpdatesCancel";
            this.btMappingToolsUpdatesCancel.Size = new System.Drawing.Size(104, 30);
            this.btMappingToolsUpdatesCancel.TabIndex = 1;
            this.btMappingToolsUpdatesCancel.Text = "Cancel";
            this.btMappingToolsUpdatesCancel.UseVisualStyleBackColor = true;
            this.btMappingToolsUpdatesCancel.Click += new System.EventHandler(this.MappingToolsUpdatesCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "Update Available!";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 107);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(615, 5);
            this.progressBar1.TabIndex = 3;
            // 
            // laVersionCompare
            // 
            this.laVersionCompare.AutoSize = true;
            this.laVersionCompare.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laVersionCompare.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.laVersionCompare.Location = new System.Drawing.Point(9, 71);
            this.laVersionCompare.Name = "laVersionCompare";
            this.laVersionCompare.Size = new System.Drawing.Size(0, 15);
            this.laVersionCompare.TabIndex = 4;
            // 
            // MappingToolsUpdates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btMappingToolsUpdatesCancel;
            this.ClientSize = new System.Drawing.Size(615, 263);
            this.Controls.Add(this.laVersionCompare);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btMappingToolsUpdatesCancel);
            this.Controls.Add(this.btMappingToolsUpdatesUpdate);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "MappingToolsUpdates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mapping Tools Update";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MappingToolsUpdates_Closed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btMappingToolsUpdatesUpdate;
        private System.Windows.Forms.Button btMappingToolsUpdatesCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label laVersionCompare;
    }
}

