
namespace MappingTools
{
    partial class VANEmailTemplates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VANEmailTemplates));
            this.tbCustInfoName = new System.Windows.Forms.TextBox();
            this.tbCustInfoID = new System.Windows.Forms.TextBox();
            this.tbSuppInfoName = new System.Windows.Forms.TextBox();
            this.tbSuppInfoID = new System.Windows.Forms.TextBox();
            this.lbTemplatesType = new System.Windows.Forms.ListBox();
            this.tbGenerateTemplate = new System.Windows.Forms.TextBox();
            this.btVanTemplateShowInOutlook = new System.Windows.Forms.Button();
            this.btVANTemplateClearAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.laTemplateType = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTemplateSuggestion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboxCustPrimaryID = new System.Windows.Forms.ComboBox();
            this.cboxSuppPrimaryID = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.laOtherSuggestionsFor = new System.Windows.Forms.Label();
            this.btCopySuggestion = new System.Windows.Forms.Button();
            this.lbOtherSuggestions = new System.Windows.Forms.ListBox();
            this.llaTemplateEdit = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // tbCustInfoName
            // 
            this.tbCustInfoName.Location = new System.Drawing.Point(150, 55);
            this.tbCustInfoName.Name = "tbCustInfoName";
            this.tbCustInfoName.Size = new System.Drawing.Size(241, 23);
            this.tbCustInfoName.TabIndex = 0;
            this.tbCustInfoName.TextChanged += new System.EventHandler(this.CustName_TextChanged);
            this.tbCustInfoName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CustName_MouseDoubleClick);
            // 
            // tbCustInfoID
            // 
            this.tbCustInfoID.Location = new System.Drawing.Point(150, 95);
            this.tbCustInfoID.Multiline = true;
            this.tbCustInfoID.Name = "tbCustInfoID";
            this.tbCustInfoID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCustInfoID.Size = new System.Drawing.Size(241, 23);
            this.tbCustInfoID.TabIndex = 1;
            this.tbCustInfoID.TextChanged += new System.EventHandler(this.CustIDInfo_TextChanged);
            this.tbCustInfoID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CustID_MouseDoubleClick);
            // 
            // tbSuppInfoName
            // 
            this.tbSuppInfoName.Location = new System.Drawing.Point(150, 212);
            this.tbSuppInfoName.Name = "tbSuppInfoName";
            this.tbSuppInfoName.Size = new System.Drawing.Size(241, 23);
            this.tbSuppInfoName.TabIndex = 3;
            this.tbSuppInfoName.TextChanged += new System.EventHandler(this.SuppName_TextChanged);
            this.tbSuppInfoName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SuppName_MouseDoubleClick);
            // 
            // tbSuppInfoID
            // 
            this.tbSuppInfoID.Location = new System.Drawing.Point(150, 251);
            this.tbSuppInfoID.Multiline = true;
            this.tbSuppInfoID.Name = "tbSuppInfoID";
            this.tbSuppInfoID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSuppInfoID.Size = new System.Drawing.Size(241, 23);
            this.tbSuppInfoID.TabIndex = 4;
            this.tbSuppInfoID.TextChanged += new System.EventHandler(this.SuppIDInfo_TextChanged);
            this.tbSuppInfoID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SuppID_MouseDoubleClick);
            // 
            // lbTemplatesType
            // 
            this.lbTemplatesType.FormattingEnabled = true;
            this.lbTemplatesType.ItemHeight = 15;
            this.lbTemplatesType.Location = new System.Drawing.Point(21, 355);
            this.lbTemplatesType.Name = "lbTemplatesType";
            this.lbTemplatesType.Size = new System.Drawing.Size(179, 199);
            this.lbTemplatesType.TabIndex = 6;
            this.lbTemplatesType.SelectedIndexChanged += new System.EventHandler(this.TemplatesSelectedTypeChanged);
            // 
            // tbGenerateTemplate
            // 
            this.tbGenerateTemplate.BackColor = System.Drawing.SystemColors.Control;
            this.tbGenerateTemplate.Location = new System.Drawing.Point(431, 55);
            this.tbGenerateTemplate.Multiline = true;
            this.tbGenerateTemplate.Name = "tbGenerateTemplate";
            this.tbGenerateTemplate.ReadOnly = true;
            this.tbGenerateTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbGenerateTemplate.Size = new System.Drawing.Size(361, 302);
            this.tbGenerateTemplate.TabIndex = 7;
            // 
            // btVanTemplateShowInOutlook
            // 
            this.btVanTemplateShowInOutlook.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVanTemplateShowInOutlook.Location = new System.Drawing.Point(431, 527);
            this.btVanTemplateShowInOutlook.Name = "btVanTemplateShowInOutlook";
            this.btVanTemplateShowInOutlook.Size = new System.Drawing.Size(199, 27);
            this.btVanTemplateShowInOutlook.TabIndex = 9;
            this.btVanTemplateShowInOutlook.Text = "Show in Outlook";
            this.btVanTemplateShowInOutlook.UseVisualStyleBackColor = true;
            this.btVanTemplateShowInOutlook.Click += new System.EventHandler(this.VanTemplateShowInOutlook_Click);
            // 
            // btVANTemplateClearAll
            // 
            this.btVANTemplateClearAll.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVANTemplateClearAll.Location = new System.Drawing.Point(656, 527);
            this.btVANTemplateClearAll.Name = "btVANTemplateClearAll";
            this.btVANTemplateClearAll.Size = new System.Drawing.Size(136, 27);
            this.btVANTemplateClearAll.TabIndex = 10;
            this.btVANTemplateClearAll.Text = "Clear All";
            this.btVANTemplateClearAll.UseVisualStyleBackColor = true;
            this.btVANTemplateClearAll.Click += new System.EventHandler(this.VANTemplateClearAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Customer Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(21, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Qualifier&&EDI ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(21, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Customer Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Partner Information";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(21, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Partner Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(21, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Qualifier&&EDI ID:";
            // 
            // laTemplateType
            // 
            this.laTemplateType.AutoSize = true;
            this.laTemplateType.BackColor = System.Drawing.Color.Transparent;
            this.laTemplateType.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laTemplateType.Location = new System.Drawing.Point(21, 332);
            this.laTemplateType.Name = "laTemplateType";
            this.laTemplateType.Size = new System.Drawing.Size(95, 17);
            this.laTemplateType.TabIndex = 18;
            this.laTemplateType.Text = "Template Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(428, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Generate Template:";
            // 
            // tbTemplateSuggestion
            // 
            this.tbTemplateSuggestion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTemplateSuggestion.Location = new System.Drawing.Point(431, 398);
            this.tbTemplateSuggestion.Multiline = true;
            this.tbTemplateSuggestion.Name = "tbTemplateSuggestion";
            this.tbTemplateSuggestion.ReadOnly = true;
            this.tbTemplateSuggestion.Size = new System.Drawing.Size(361, 112);
            this.tbTemplateSuggestion.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(428, 378);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Suggestion:";
            // 
            // cboxCustPrimaryID
            // 
            this.cboxCustPrimaryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCustPrimaryID.FormattingEnabled = true;
            this.cboxCustPrimaryID.Items.AddRange(new object[] {
            "No Primary EDI ID"});
            this.cboxCustPrimaryID.Location = new System.Drawing.Point(189, 134);
            this.cboxCustPrimaryID.Name = "cboxCustPrimaryID";
            this.cboxCustPrimaryID.Size = new System.Drawing.Size(202, 23);
            this.cboxCustPrimaryID.TabIndex = 24;
            this.cboxCustPrimaryID.SelectedIndexChanged += new System.EventHandler(this.CustPrimaryID_SelectedIndexChanged);
            // 
            // cboxSuppPrimaryID
            // 
            this.cboxSuppPrimaryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSuppPrimaryID.FormattingEnabled = true;
            this.cboxSuppPrimaryID.Items.AddRange(new object[] {
            "No Primary EDI ID"});
            this.cboxSuppPrimaryID.Location = new System.Drawing.Point(189, 290);
            this.cboxSuppPrimaryID.Name = "cboxSuppPrimaryID";
            this.cboxSuppPrimaryID.Size = new System.Drawing.Size(202, 23);
            this.cboxSuppPrimaryID.TabIndex = 25;
            this.cboxSuppPrimaryID.SelectedIndexChanged += new System.EventHandler(this.SuppPrimaryID_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(22, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 15);
            this.label10.TabIndex = 26;
            this.label10.Text = "Primary Qualifier&&EDI ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(22, 293);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 15);
            this.label11.TabIndex = 27;
            this.label11.Text = "Primary Qualifier&&EDI ID:";
            // 
            // laOtherSuggestionsFor
            // 
            this.laOtherSuggestionsFor.AutoSize = true;
            this.laOtherSuggestionsFor.BackColor = System.Drawing.Color.Transparent;
            this.laOtherSuggestionsFor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laOtherSuggestionsFor.Location = new System.Drawing.Point(209, 332);
            this.laOtherSuggestionsFor.Name = "laOtherSuggestionsFor";
            this.laOtherSuggestionsFor.Size = new System.Drawing.Size(121, 17);
            this.laOtherSuggestionsFor.TabIndex = 29;
            this.laOtherSuggestionsFor.Text = "Other Suggestions";
            // 
            // btCopySuggestion
            // 
            this.btCopySuggestion.BackColor = System.Drawing.SystemColors.Control;
            this.btCopySuggestion.FlatAppearance.BorderSize = 0;
            this.btCopySuggestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCopySuggestion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCopySuggestion.Location = new System.Drawing.Point(432, 482);
            this.btCopySuggestion.Name = "btCopySuggestion";
            this.btCopySuggestion.Size = new System.Drawing.Size(359, 27);
            this.btCopySuggestion.TabIndex = 30;
            this.btCopySuggestion.Text = "QUICK COPY";
            this.btCopySuggestion.UseVisualStyleBackColor = false;
            this.btCopySuggestion.Click += new System.EventHandler(this.CopySuggestion_Click);
            // 
            // lbOtherSuggestions
            // 
            this.lbOtherSuggestions.FormattingEnabled = true;
            this.lbOtherSuggestions.HorizontalScrollbar = true;
            this.lbOtherSuggestions.ItemHeight = 15;
            this.lbOtherSuggestions.Location = new System.Drawing.Point(212, 355);
            this.lbOtherSuggestions.Name = "lbOtherSuggestions";
            this.lbOtherSuggestions.Size = new System.Drawing.Size(179, 199);
            this.lbOtherSuggestions.TabIndex = 31;
            this.lbOtherSuggestions.SelectedIndexChanged += new System.EventHandler(this.OtherSuggestionsChanged);
            // 
            // llaTemplateEdit
            // 
            this.llaTemplateEdit.AutoSize = true;
            this.llaTemplateEdit.BackColor = System.Drawing.Color.Transparent;
            this.llaTemplateEdit.Location = new System.Drawing.Point(173, 334);
            this.llaTemplateEdit.Name = "llaTemplateEdit";
            this.llaTemplateEdit.Size = new System.Drawing.Size(27, 15);
            this.llaTemplateEdit.TabIndex = 32;
            this.llaTemplateEdit.TabStop = true;
            this.llaTemplateEdit.Text = "Edit";
            this.llaTemplateEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TemplateEdit_LinkClick);
            // 
            // VANEmailTemplates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MappingTools.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(823, 574);
            this.Controls.Add(this.llaTemplateEdit);
            this.Controls.Add(this.lbOtherSuggestions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCustInfoName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btCopySuggestion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbCustInfoID);
            this.Controls.Add(this.cboxCustPrimaryID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.laOtherSuggestionsFor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSuppInfoName);
            this.Controls.Add(this.tbTemplateSuggestion);
            this.Controls.Add(this.lbTemplatesType);
            this.Controls.Add(this.cboxSuppPrimaryID);
            this.Controls.Add(this.laTemplateType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btVANTemplateClearAll);
            this.Controls.Add(this.tbSuppInfoID);
            this.Controls.Add(this.tbGenerateTemplate);
            this.Controls.Add(this.btVanTemplateShowInOutlook);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VANEmailTemplates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VAN Email Templates";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VANEmailTemplates_FormClosed);
            this.Load += new System.EventHandler(this.VANEmailTemplates_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbOtherSuggestions;
        private System.Windows.Forms.Button btCopySuggestion;
        private System.Windows.Forms.Label laOtherSuggestionsFor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboxSuppPrimaryID;
        private System.Windows.Forms.ComboBox cboxCustPrimaryID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbTemplateSuggestion;
        private System.Windows.Forms.TextBox tbGenerateTemplate;
        private System.Windows.Forms.TextBox tbSuppInfoID;
        private System.Windows.Forms.TextBox tbSuppInfoName;
        private System.Windows.Forms.TextBox tbCustInfoID;
        private System.Windows.Forms.TextBox tbCustInfoName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label laTemplateType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btVANTemplateClearAll;
        private System.Windows.Forms.Button btVanTemplateShowInOutlook;
        private System.Windows.Forms.ListBox lbTemplatesType;
        private System.Windows.Forms.LinkLabel llaTemplateEdit;
    }
}