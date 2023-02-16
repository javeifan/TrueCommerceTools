
namespace MappingTools
{
    partial class EmailAddressSelections
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailAddressSelections));
            this.clEmailAddresses = new System.Windows.Forms.CheckedListBox();
            this.tbEmialAddrOK = new System.Windows.Forms.Button();
            this.tbEmailAddrCancel = new System.Windows.Forms.Button();
            this.EamilAddrItemMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbAddEmailAddrName = new System.Windows.Forms.TextBox();
            this.tbAddEmailAddrAddress = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.EamilAddrItemMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // clEmailAddresses
            // 
            this.clEmailAddresses.BackColor = System.Drawing.SystemColors.Control;
            this.clEmailAddresses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clEmailAddresses.CheckOnClick = true;
            this.clEmailAddresses.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clEmailAddresses.FormattingEnabled = true;
            this.clEmailAddresses.Location = new System.Drawing.Point(14, 13);
            this.clEmailAddresses.Name = "clEmailAddresses";
            this.clEmailAddresses.Size = new System.Drawing.Size(312, 155);
            this.clEmailAddresses.Sorted = true;
            this.clEmailAddresses.TabIndex = 0;
            this.clEmailAddresses.SelectedIndexChanged += new System.EventHandler(this.EmailAddrSelItemChanged);
            this.clEmailAddresses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EmailAddressItems_RightClick);
            // 
            // tbEmialAddrOK
            // 
            this.tbEmialAddrOK.Location = new System.Drawing.Point(13, 254);
            this.tbEmialAddrOK.Name = "tbEmialAddrOK";
            this.tbEmialAddrOK.Size = new System.Drawing.Size(143, 23);
            this.tbEmialAddrOK.TabIndex = 1;
            this.tbEmialAddrOK.Text = "OK";
            this.tbEmialAddrOK.UseVisualStyleBackColor = true;
            this.tbEmialAddrOK.Click += new System.EventHandler(this.EmialAddrOK_Click);
            // 
            // tbEmailAddrCancel
            // 
            this.tbEmailAddrCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.tbEmailAddrCancel.Location = new System.Drawing.Point(182, 254);
            this.tbEmailAddrCancel.Name = "tbEmailAddrCancel";
            this.tbEmailAddrCancel.Size = new System.Drawing.Size(142, 23);
            this.tbEmailAddrCancel.TabIndex = 2;
            this.tbEmailAddrCancel.Text = "Cancel";
            this.tbEmailAddrCancel.UseVisualStyleBackColor = true;
            this.tbEmailAddrCancel.Click += new System.EventHandler(this.tbEmailAddrCancel_Click);
            // 
            // EamilAddrItemMenuStrip
            // 
            this.EamilAddrItemMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EamilAddrItemMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delToolStripMenuItem});
            this.EamilAddrItemMenuStrip.Name = "contextMenuStrip1";
            this.EamilAddrItemMenuStrip.Size = new System.Drawing.Size(108, 26);
            // 
            // delToolStripMenuItem
            // 
            this.delToolStripMenuItem.Name = "delToolStripMenuItem";
            this.delToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.delToolStripMenuItem.Text = "Delete";
            this.delToolStripMenuItem.Click += new System.EventHandler(this.EmailAddrItemMenu_Delete);
            // 
            // tbAddEmailAddrName
            // 
            this.tbAddEmailAddrName.Location = new System.Drawing.Point(13, 219);
            this.tbAddEmailAddrName.Name = "tbAddEmailAddrName";
            this.tbAddEmailAddrName.Size = new System.Drawing.Size(75, 20);
            this.tbAddEmailAddrName.TabIndex = 4;
            // 
            // tbAddEmailAddrAddress
            // 
            this.tbAddEmailAddrAddress.Location = new System.Drawing.Point(94, 219);
            this.tbAddEmailAddrAddress.Name = "tbAddEmailAddrAddress";
            this.tbAddEmailAddrAddress.Size = new System.Drawing.Size(149, 20);
            this.tbAddEmailAddrAddress.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(249, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddEmailAddr_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Add a Contact:";
            // 
            // EmailAddressSelections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.tbEmailAddrCancel;
            this.ClientSize = new System.Drawing.Size(350, 294);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbAddEmailAddrAddress);
            this.Controls.Add(this.tbAddEmailAddrName);
            this.Controls.Add(this.tbEmailAddrCancel);
            this.Controls.Add(this.tbEmialAddrOK);
            this.Controls.Add(this.clEmailAddresses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmailAddressSelections";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contacts";
            this.EamilAddrItemMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clEmailAddresses;
        private System.Windows.Forms.Button tbEmialAddrOK;
        private System.Windows.Forms.Button tbEmailAddrCancel;
        private System.Windows.Forms.ContextMenuStrip EamilAddrItemMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem delToolStripMenuItem;
        private System.Windows.Forms.TextBox tbAddEmailAddrName;
        private System.Windows.Forms.TextBox tbAddEmailAddrAddress;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}