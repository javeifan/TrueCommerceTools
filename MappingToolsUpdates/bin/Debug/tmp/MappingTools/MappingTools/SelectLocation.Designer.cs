namespace MappingTools
{
    partial class SelectLocation
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
            this.ws_loc_browse = new System.Windows.Forms.Button();
            this.ws_loc_ok = new System.Windows.Forms.Button();
            this.ws_loc_cancel = new System.Windows.Forms.Button();
            this.tbWorkSpace_Loc = new System.Windows.Forms.TextBox();
            this.workspaceText = new System.Windows.Forms.Label();
            this.selectLoc_Pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.selectLoc_Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // ws_loc_browse
            // 
            this.ws_loc_browse.Location = new System.Drawing.Point(477, 109);
            this.ws_loc_browse.Name = "ws_loc_browse";
            this.ws_loc_browse.Size = new System.Drawing.Size(78, 23);
            this.ws_loc_browse.TabIndex = 0;
            this.ws_loc_browse.Text = "Browse...";
            this.ws_loc_browse.UseVisualStyleBackColor = true;
            this.ws_loc_browse.Click += new System.EventHandler(this.ws_loc_browse_Click);
            // 
            // ws_loc_ok
            // 
            this.ws_loc_ok.Location = new System.Drawing.Point(380, 159);
            this.ws_loc_ok.Name = "ws_loc_ok";
            this.ws_loc_ok.Size = new System.Drawing.Size(78, 23);
            this.ws_loc_ok.TabIndex = 1;
            this.ws_loc_ok.Text = "OK";
            this.ws_loc_ok.UseVisualStyleBackColor = true;
            this.ws_loc_ok.Click += new System.EventHandler(this.ws_loc_ok_Click);
            // 
            // ws_loc_cancel
            // 
            this.ws_loc_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ws_loc_cancel.Location = new System.Drawing.Point(477, 159);
            this.ws_loc_cancel.Name = "ws_loc_cancel";
            this.ws_loc_cancel.Size = new System.Drawing.Size(78, 23);
            this.ws_loc_cancel.TabIndex = 2;
            this.ws_loc_cancel.Text = "Cancel";
            this.ws_loc_cancel.UseVisualStyleBackColor = true;
            this.ws_loc_cancel.Click += new System.EventHandler(this.ws_loc_cancel_Click);
            // 
            // tbWorkSpace_Loc
            // 
            this.tbWorkSpace_Loc.Location = new System.Drawing.Point(95, 112);
            this.tbWorkSpace_Loc.Name = "tbWorkSpace_Loc";
            this.tbWorkSpace_Loc.Size = new System.Drawing.Size(363, 22);
            this.tbWorkSpace_Loc.TabIndex = 3;
            // 
            // workspaceText
            // 
            this.workspaceText.AutoSize = true;
            this.workspaceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workspaceText.Location = new System.Drawing.Point(12, 115);
            this.workspaceText.Name = "workspaceText";
            this.workspaceText.Size = new System.Drawing.Size(73, 15);
            this.workspaceText.TabIndex = 4;
            this.workspaceText.Text = "WorkSpace:";
            // 
            // selectLoc_Pic
            // 
            this.selectLoc_Pic.Image = global::MappingTools.Properties.Resources.Loc_Sel_Pic;
            this.selectLoc_Pic.Location = new System.Drawing.Point(2, 2);
            this.selectLoc_Pic.Name = "selectLoc_Pic";
            this.selectLoc_Pic.Size = new System.Drawing.Size(571, 79);
            this.selectLoc_Pic.TabIndex = 5;
            this.selectLoc_Pic.TabStop = false;
            // 
            // SelectLocation
            // 
            this.AcceptButton = this.ws_loc_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ws_loc_cancel;
            this.ClientSize = new System.Drawing.Size(576, 212);
            this.ControlBox = false;
            this.Controls.Add(this.selectLoc_Pic);
            this.Controls.Add(this.workspaceText);
            this.Controls.Add(this.tbWorkSpace_Loc);
            this.Controls.Add(this.ws_loc_cancel);
            this.Controls.Add(this.ws_loc_ok);
            this.Controls.Add(this.ws_loc_browse);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MappingTools";
            ((System.ComponentModel.ISupportInitialize)(this.selectLoc_Pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ws_loc_browse;
        private System.Windows.Forms.Button ws_loc_ok;
        private System.Windows.Forms.Button ws_loc_cancel;
        private System.Windows.Forms.TextBox tbWorkSpace_Loc;
        private System.Windows.Forms.Label workspaceText;
        private System.Windows.Forms.PictureBox selectLoc_Pic;
    }
}

