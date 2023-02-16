
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
            this.btCCToAddrContacts = new System.Windows.Forms.Button();
            this.btSendToAddrContacts = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbInputMailMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMailTrailer = new System.Windows.Forms.TextBox();
            this.btWTXEmialHelperCancel = new System.Windows.Forms.Button();
            this.btShowInOutLook = new System.Windows.Forms.Button();
            this.cblIssuesRecord = new System.Windows.Forms.CheckedListBox();
            this.laIssueRecordInServer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbIssueRecordSelectAll = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // laSayHiTo
            // 
            this.laSayHiTo.AutoSize = true;
            this.laSayHiTo.Location = new System.Drawing.Point(17, 22);
            this.laSayHiTo.Name = "laSayHiTo";
            this.laSayHiTo.Size = new System.Drawing.Size(74, 20);
            this.laSayHiTo.TabIndex = 11;
            this.laSayHiTo.Text = "Say Hi To:";
            // 
            // laEMSubject
            // 
            this.laEMSubject.AutoSize = true;
            this.laEMSubject.Location = new System.Drawing.Point(227, 22);
            this.laEMSubject.Name = "laEMSubject";
            this.laEMSubject.Size = new System.Drawing.Size(61, 20);
            this.laEMSubject.TabIndex = 10;
            this.laEMSubject.Text = "Subject:";
            // 
            // tbSayHi
            // 
            this.tbSayHi.Location = new System.Drawing.Point(81, 19);
            this.tbSayHi.Name = "tbSayHi";
            this.tbSayHi.Size = new System.Drawing.Size(132, 27);
            this.tbSayHi.TabIndex = 1;
            this.tbSayHi.TextChanged += new System.EventHandler(this.SayHi_TextChanged);
            // 
            // tbSuggestSubjectName
            // 
            this.tbSuggestSubjectName.Location = new System.Drawing.Point(282, 19);
            this.tbSuggestSubjectName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSuggestSubjectName.Name = "tbSuggestSubjectName";
            this.tbSuggestSubjectName.Size = new System.Drawing.Size(132, 27);
            this.tbSuggestSubjectName.TabIndex = 2;
            // 
            // laMailCCTo
            // 
            this.laMailCCTo.AutoSize = true;
            this.laMailCCTo.Location = new System.Drawing.Point(17, 83);
            this.laMailCCTo.Name = "laMailCCTo";
            this.laMailCCTo.Size = new System.Drawing.Size(50, 20);
            this.laMailCCTo.TabIndex = 19;
            this.laMailCCTo.Text = "CC To:";
            // 
            // laSendTo
            // 
            this.laSendTo.AutoSize = true;
            this.laSendTo.Location = new System.Drawing.Point(17, 53);
            this.laSendTo.Name = "laSendTo";
            this.laSendTo.Size = new System.Drawing.Size(65, 20);
            this.laSendTo.TabIndex = 18;
            this.laSendTo.Text = "Send To:";
            // 
            // tbMailCCTo
            // 
            this.tbMailCCTo.Location = new System.Drawing.Point(81, 80);
            this.tbMailCCTo.Name = "tbMailCCTo";
            this.tbMailCCTo.Size = new System.Drawing.Size(263, 27);
            this.tbMailCCTo.TabIndex = 5;
            this.tbMailCCTo.TextChanged += new System.EventHandler(this.tbMailCCTo_TextChanged);
            // 
            // tbMailSendTo
            // 
            this.tbMailSendTo.Location = new System.Drawing.Point(81, 50);
            this.tbMailSendTo.Name = "tbMailSendTo";
            this.tbMailSendTo.Size = new System.Drawing.Size(263, 27);
            this.tbMailSendTo.TabIndex = 3;
            this.tbMailSendTo.TextChanged += new System.EventHandler(this.tbMailSendTo_TextChanged);
            // 
            // btCCToAddrContacts
            // 
            this.btCCToAddrContacts.Location = new System.Drawing.Point(350, 80);
            this.btCCToAddrContacts.Name = "btCCToAddrContacts";
            this.btCCToAddrContacts.Size = new System.Drawing.Size(64, 23);
            this.btCCToAddrContacts.TabIndex = 6;
            this.btCCToAddrContacts.Text = "Contacts";
            this.btCCToAddrContacts.UseVisualStyleBackColor = true;
            this.btCCToAddrContacts.Click += new System.EventHandler(this.SpawnCcToContacts_Click);
            // 
            // btSendToAddrContacts
            // 
            this.btSendToAddrContacts.Location = new System.Drawing.Point(350, 50);
            this.btSendToAddrContacts.Name = "btSendToAddrContacts";
            this.btSendToAddrContacts.Size = new System.Drawing.Size(64, 23);
            this.btSendToAddrContacts.TabIndex = 4;
            this.btSendToAddrContacts.Text = "Contacts";
            this.btSendToAddrContacts.UseVisualStyleBackColor = true;
            this.btSendToAddrContacts.Click += new System.EventHandler(this.SpawnSendToContacts_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Paste daily cases here: ";
            // 
            // tbInputMailMsg
            // 
            this.tbInputMailMsg.Location = new System.Drawing.Point(20, 261);
            this.tbInputMailMsg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbInputMailMsg.Multiline = true;
            this.tbInputMailMsg.Name = "tbInputMailMsg";
            this.tbInputMailMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInputMailMsg.Size = new System.Drawing.Size(394, 157);
            this.tbInputMailMsg.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Daily Email Trailer:";
            // 
            // tbMailTrailer
            // 
            this.tbMailTrailer.Location = new System.Drawing.Point(20, 449);
            this.tbMailTrailer.Multiline = true;
            this.tbMailTrailer.Name = "tbMailTrailer";
            this.tbMailTrailer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMailTrailer.Size = new System.Drawing.Size(394, 88);
            this.tbMailTrailer.TabIndex = 8;
            this.tbMailTrailer.TextChanged += new System.EventHandler(this.tbMailTrailer_TextChanged);
            // 
            // btWTXEmialHelperCancel
            // 
            this.btWTXEmialHelperCancel.Location = new System.Drawing.Point(282, 763);
            this.btWTXEmialHelperCancel.Name = "btWTXEmialHelperCancel";
            this.btWTXEmialHelperCancel.Size = new System.Drawing.Size(132, 26);
            this.btWTXEmialHelperCancel.TabIndex = 10;
            this.btWTXEmialHelperCancel.Text = "Cancel";
            this.btWTXEmialHelperCancel.UseVisualStyleBackColor = true;
            this.btWTXEmialHelperCancel.Click += new System.EventHandler(this.btSpawnEmialHelperCancel_Click);
            // 
            // btShowInOutLook
            // 
            this.btShowInOutLook.Location = new System.Drawing.Point(20, 763);
            this.btShowInOutLook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btShowInOutLook.Name = "btShowInOutLook";
            this.btShowInOutLook.Size = new System.Drawing.Size(234, 26);
            this.btShowInOutLook.TabIndex = 9;
            this.btShowInOutLook.Text = "Show In OutLook";
            this.btShowInOutLook.UseVisualStyleBackColor = true;
            this.btShowInOutLook.Click += new System.EventHandler(this.ShowInOutLook_Click);
            // 
            // cblIssuesRecord
            // 
            this.cblIssuesRecord.CheckOnClick = true;
            this.cblIssuesRecord.FormattingEnabled = true;
            this.cblIssuesRecord.HorizontalScrollbar = true;
            this.cblIssuesRecord.Location = new System.Drawing.Point(20, 135);
            this.cblIssuesRecord.Name = "cblIssuesRecord";
            this.cblIssuesRecord.Size = new System.Drawing.Size(394, 92);
            this.cblIssuesRecord.TabIndex = 26;
            // 
            // laIssueRecordInServer
            // 
            this.laIssueRecordInServer.AutoSize = true;
            this.laIssueRecordInServer.Location = new System.Drawing.Point(20, 116);
            this.laIssueRecordInServer.Name = "laIssueRecordInServer";
            this.laIssueRecordInServer.Size = new System.Drawing.Size(162, 20);
            this.laIssueRecordInServer.TabIndex = 27;
            this.laIssueRecordInServer.Text = "Issues Record In Server:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(190, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(285, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Use \"||\" to split case tittle and issue detail.";
            // 
            // cbIssueRecordSelectAll
            // 
            this.cbIssueRecordSelectAll.AutoSize = true;
            this.cbIssueRecordSelectAll.Location = new System.Drawing.Point(340, 115);
            this.cbIssueRecordSelectAll.Name = "cbIssueRecordSelectAll";
            this.cbIssueRecordSelectAll.Size = new System.Drawing.Size(93, 24);
            this.cbIssueRecordSelectAll.TabIndex = 29;
            this.cbIssueRecordSelectAll.Text = "Select All";
            this.cbIssueRecordSelectAll.UseVisualStyleBackColor = true;
            this.cbIssueRecordSelectAll.CheckedChanged += new System.EventHandler(this.IssueRecordSelectAll_CheckChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 579);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(394, 164);
            this.textBox1.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 556);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 25);
            this.label4.TabIndex = 31;
            this.label4.Text = "QA";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // SpawnDailyEmailHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 802);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbIssueRecordSelectAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.laIssueRecordInServer);
            this.Controls.Add(this.cblIssuesRecord);
            this.Controls.Add(this.btWTXEmialHelperCancel);
            this.Controls.Add(this.btShowInOutLook);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMailTrailer);
            this.Controls.Add(this.tbInputMailMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btCCToAddrContacts);
            this.Controls.Add(this.btSendToAddrContacts);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpawnDailyEmailHelper_Closing);
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
        private System.Windows.Forms.Button btCCToAddrContacts;
        private System.Windows.Forms.Button btSendToAddrContacts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbInputMailMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMailTrailer;
        private System.Windows.Forms.Button btWTXEmialHelperCancel;
        private System.Windows.Forms.Button btShowInOutLook;
        private System.Windows.Forms.CheckedListBox cblIssuesRecord;
        private System.Windows.Forms.Label laIssueRecordInServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbIssueRecordSelectAll;
        private System.Windows.Forms.TextBox tbInputQA;
        private System.Windows.Forms.Label label4;
    }
}