
namespace MappingTools
{
    partial class SpawnDailyEmailHelper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpawnDailyEmailHelper));
            this.laSayHiTo = new System.Windows.Forms.Label();
            this.laEMSubject = new System.Windows.Forms.Label();
            this.tbSayHi = new System.Windows.Forms.TextBox();
            this.tbSuggestSubjectName = new System.Windows.Forms.TextBox();
            this.laMailCCTo = new System.Windows.Forms.Label();
            this.laSendTo = new System.Windows.Forms.Label();
            this.tbMailCCTo = new System.Windows.Forms.TextBox();
            this.tbMailSendTo = new System.Windows.Forms.TextBox();
            this.btCCToAddrContects = new System.Windows.Forms.Button();
            this.btSendToAddrContects = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbInputMailMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMailTrailer = new System.Windows.Forms.TextBox();
            this.btWTXEmialHelperCancel = new System.Windows.Forms.Button();
            this.btShowInOutLook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // laSayHiTo
            // 
            this.laSayHiTo.AutoSize = true;
            this.laSayHiTo.Location = new System.Drawing.Point(17, 22);
            this.laSayHiTo.Name = "laSayHiTo";
            this.laSayHiTo.Size = new System.Drawing.Size(58, 15);
            this.laSayHiTo.TabIndex = 11;
            this.laSayHiTo.Text = "Say Hi To:";
            // 
            // laEMSubject
            // 
            this.laEMSubject.AutoSize = true;
            this.laEMSubject.Location = new System.Drawing.Point(227, 22);
            this.laEMSubject.Name = "laEMSubject";
            this.laEMSubject.Size = new System.Drawing.Size(49, 15);
            this.laEMSubject.TabIndex = 10;
            this.laEMSubject.Text = "Subject:";
            // 
            // tbSayHi
            // 
            this.tbSayHi.Location = new System.Drawing.Point(81, 19);
            this.tbSayHi.Name = "tbSayHi";
            this.tbSayHi.Size = new System.Drawing.Size(132, 23);
            this.tbSayHi.TabIndex = 1;
            this.tbSayHi.TextChanged += new System.EventHandler(this.SayHi_TextChanged);
            // 
            // tbSuggestSubjectName
            // 
            this.tbSuggestSubjectName.Location = new System.Drawing.Point(282, 19);
            this.tbSuggestSubjectName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSuggestSubjectName.Name = "tbSuggestSubjectName";
            this.tbSuggestSubjectName.Size = new System.Drawing.Size(132, 23);
            this.tbSuggestSubjectName.TabIndex = 2;
            // 
            // laMailCCTo
            // 
            this.laMailCCTo.AutoSize = true;
            this.laMailCCTo.Location = new System.Drawing.Point(17, 83);
            this.laMailCCTo.Name = "laMailCCTo";
            this.laMailCCTo.Size = new System.Drawing.Size(41, 15);
            this.laMailCCTo.TabIndex = 19;
            this.laMailCCTo.Text = "CC To:";
            // 
            // laSendTo
            // 
            this.laSendTo.AutoSize = true;
            this.laSendTo.Location = new System.Drawing.Point(17, 53);
            this.laSendTo.Name = "laSendTo";
            this.laSendTo.Size = new System.Drawing.Size(51, 15);
            this.laSendTo.TabIndex = 18;
            this.laSendTo.Text = "Send To:";
            // 
            // tbMailCCTo
            // 
            this.tbMailCCTo.Location = new System.Drawing.Point(81, 80);
            this.tbMailCCTo.Name = "tbMailCCTo";
            this.tbMailCCTo.Size = new System.Drawing.Size(263, 23);
            this.tbMailCCTo.TabIndex = 5;
            this.tbMailCCTo.TextChanged += new System.EventHandler(this.tbMailCCTo_TextChanged);
            // 
            // tbMailSendTo
            // 
            this.tbMailSendTo.Location = new System.Drawing.Point(81, 50);
            this.tbMailSendTo.Name = "tbMailSendTo";
            this.tbMailSendTo.Size = new System.Drawing.Size(263, 23);
            this.tbMailSendTo.TabIndex = 3;
            this.tbMailSendTo.TextChanged += new System.EventHandler(this.tbMailSendTo_TextChanged);
            // 
            // btCCToAddrContects
            // 
            this.btCCToAddrContects.Location = new System.Drawing.Point(350, 80);
            this.btCCToAddrContects.Name = "btCCToAddrContects";
            this.btCCToAddrContects.Size = new System.Drawing.Size(64, 23);
            this.btCCToAddrContects.TabIndex = 6;
            this.btCCToAddrContects.Text = "Contects";
            this.btCCToAddrContects.UseVisualStyleBackColor = true;
            this.btCCToAddrContects.Click += new System.EventHandler(this.SpawnCcToContects_Click);
            // 
            // btSendToAddrContects
            // 
            this.btSendToAddrContects.Location = new System.Drawing.Point(350, 50);
            this.btSendToAddrContects.Name = "btSendToAddrContects";
            this.btSendToAddrContects.Size = new System.Drawing.Size(64, 23);
            this.btSendToAddrContects.TabIndex = 4;
            this.btSendToAddrContects.Text = "Contects";
            this.btSendToAddrContects.UseVisualStyleBackColor = true;
            this.btSendToAddrContects.Click += new System.EventHandler(this.SpawnSendToContects_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Paste daily cases here: ";
            // 
            // tbInputMailMsg
            // 
            this.tbInputMailMsg.Location = new System.Drawing.Point(20, 130);
            this.tbInputMailMsg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbInputMailMsg.Multiline = true;
            this.tbInputMailMsg.Name = "tbInputMailMsg";
            this.tbInputMailMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInputMailMsg.Size = new System.Drawing.Size(394, 234);
            this.tbInputMailMsg.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Daily Email Trailer:";
            // 
            // tbMailTrailer
            // 
            this.tbMailTrailer.Location = new System.Drawing.Point(20, 395);
            this.tbMailTrailer.Multiline = true;
            this.tbMailTrailer.Name = "tbMailTrailer";
            this.tbMailTrailer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMailTrailer.Size = new System.Drawing.Size(394, 88);
            this.tbMailTrailer.TabIndex = 8;
            this.tbMailTrailer.TextChanged += new System.EventHandler(this.tbMailTrailer_TextChanged);
            // 
            // btWTXEmialHelperCancel
            // 
            this.btWTXEmialHelperCancel.Location = new System.Drawing.Point(282, 505);
            this.btWTXEmialHelperCancel.Name = "btWTXEmialHelperCancel";
            this.btWTXEmialHelperCancel.Size = new System.Drawing.Size(132, 26);
            this.btWTXEmialHelperCancel.TabIndex = 10;
            this.btWTXEmialHelperCancel.Text = "Cancel";
            this.btWTXEmialHelperCancel.UseVisualStyleBackColor = true;
            this.btWTXEmialHelperCancel.Click += new System.EventHandler(this.btSpawnEmialHelperCancel_Click);
            // 
            // btShowInOutLook
            // 
            this.btShowInOutLook.Location = new System.Drawing.Point(20, 505);
            this.btShowInOutLook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btShowInOutLook.Name = "btShowInOutLook";
            this.btShowInOutLook.Size = new System.Drawing.Size(234, 26);
            this.btShowInOutLook.TabIndex = 9;
            this.btShowInOutLook.Text = "Show In OutLook";
            this.btShowInOutLook.UseVisualStyleBackColor = true;
            this.btShowInOutLook.Click += new System.EventHandler(this.ShowInOutLook_Click);
            // 
            // SpawnDailyEmailHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 558);
            this.Controls.Add(this.btWTXEmialHelperCancel);
            this.Controls.Add(this.btShowInOutLook);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMailTrailer);
            this.Controls.Add(this.tbInputMailMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btCCToAddrContects);
            this.Controls.Add(this.btSendToAddrContects);
            this.Controls.Add(this.laMailCCTo);
            this.Controls.Add(this.laSendTo);
            this.Controls.Add(this.tbMailCCTo);
            this.Controls.Add(this.tbMailSendTo);
            this.Controls.Add(this.laSayHiTo);
            this.Controls.Add(this.laEMSubject);
            this.Controls.Add(this.tbSayHi);
            this.Controls.Add(this.tbSuggestSubjectName);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SpawnDailyEmailHelper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Spawn Daily Email Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label laSayHiTo;
        private System.Windows.Forms.Label laEMSubject;
        private System.Windows.Forms.TextBox tbSayHi;
        private System.Windows.Forms.TextBox tbSuggestSubjectName;
        private System.Windows.Forms.Label laMailCCTo;
        private System.Windows.Forms.Label laSendTo;
        private System.Windows.Forms.TextBox tbMailCCTo;
        private System.Windows.Forms.TextBox tbMailSendTo;
        private System.Windows.Forms.Button btCCToAddrContects;
        private System.Windows.Forms.Button btSendToAddrContects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbInputMailMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMailTrailer;
        private System.Windows.Forms.Button btWTXEmialHelperCancel;
        private System.Windows.Forms.Button btShowInOutLook;
    }
}