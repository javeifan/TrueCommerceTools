namespace MappingTools
{
    partial class TypeTreeMaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypeTreeMaker));
            this.typetreeInfoInput = new System.Windows.Forms.TextBox();
            this.mtsCreateAndSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbMTS_Loc = new System.Windows.Forms.TextBox();
            this.mtsSavePathChoose = new System.Windows.Forms.Button();
            this.laSavePath = new System.Windows.Forms.Label();
            this.laInstructions = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btCheckByTTMaker = new System.Windows.Forms.Button();
            this.tbTTMakerInstructions = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // typetreeInfoInput
            // 
            this.typetreeInfoInput.Location = new System.Drawing.Point(14, 29);
            this.typetreeInfoInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.typetreeInfoInput.Multiline = true;
            this.typetreeInfoInput.Name = "typetreeInfoInput";
            this.typetreeInfoInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.typetreeInfoInput.Size = new System.Drawing.Size(256, 374);
            this.typetreeInfoInput.TabIndex = 0;
            // 
            // mtsCreateAndSave
            // 
            this.mtsCreateAndSave.Location = new System.Drawing.Point(229, 513);
            this.mtsCreateAndSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtsCreateAndSave.Name = "mtsCreateAndSave";
            this.mtsCreateAndSave.Size = new System.Drawing.Size(185, 26);
            this.mtsCreateAndSave.TabIndex = 1;
            this.mtsCreateAndSave.Text = "Create and Save (*.mts)";
            this.mtsCreateAndSave.UseVisualStyleBackColor = true;
            this.mtsCreateAndSave.Click += new System.EventHandler(this.mtsCreateAndSave_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(434, 513);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 26);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.TypeTreeMaker_Cancel_Click);
            // 
            // tbMTS_Loc
            // 
            this.tbMTS_Loc.Location = new System.Drawing.Point(14, 466);
            this.tbMTS_Loc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbMTS_Loc.Name = "tbMTS_Loc";
            this.tbMTS_Loc.Size = new System.Drawing.Size(400, 23);
            this.tbMTS_Loc.TabIndex = 3;
            // 
            // mtsSavePathChoose
            // 
            this.mtsSavePathChoose.Location = new System.Drawing.Point(434, 466);
            this.mtsSavePathChoose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtsSavePathChoose.Name = "mtsSavePathChoose";
            this.mtsSavePathChoose.Size = new System.Drawing.Size(87, 26);
            this.mtsSavePathChoose.TabIndex = 4;
            this.mtsSavePathChoose.Text = "Browse..";
            this.mtsSavePathChoose.UseVisualStyleBackColor = true;
            this.mtsSavePathChoose.Click += new System.EventHandler(this.mts_loc_Browse_Click);
            // 
            // laSavePath
            // 
            this.laSavePath.AutoSize = true;
            this.laSavePath.BackColor = System.Drawing.Color.Transparent;
            this.laSavePath.Location = new System.Drawing.Point(12, 447);
            this.laSavePath.Name = "laSavePath";
            this.laSavePath.Size = new System.Drawing.Size(250, 15);
            this.laSavePath.TabIndex = 5;
            this.laSavePath.Text = "Save Path (Default name: TypeTreeMaker.mts):";
            // 
            // laInstructions
            // 
            this.laInstructions.AutoSize = true;
            this.laInstructions.BackColor = System.Drawing.Color.Transparent;
            this.laInstructions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laInstructions.Location = new System.Drawing.Point(291, 29);
            this.laInstructions.Name = "laInstructions";
            this.laInstructions.Size = new System.Drawing.Size(75, 17);
            this.laInstructions.TabIndex = 6;
            this.laInstructions.Text = "Instruction :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(291, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "*Please make sure the last line is not blank.";
            // 
            // btCheckByTTMaker
            // 
            this.btCheckByTTMaker.Location = new System.Drawing.Point(14, 410);
            this.btCheckByTTMaker.Name = "btCheckByTTMaker";
            this.btCheckByTTMaker.Size = new System.Drawing.Size(256, 23);
            this.btCheckByTTMaker.TabIndex = 9;
            this.btCheckByTTMaker.Text = "Check (TTMaker)";
            this.btCheckByTTMaker.UseVisualStyleBackColor = true;
            this.btCheckByTTMaker.Click += new System.EventHandler(this.CheckByTTMaker_Click);
            // 
            // tbTTMakerInstructions
            // 
            this.tbTTMakerInstructions.BackColor = System.Drawing.SystemColors.Control;
            this.tbTTMakerInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTTMakerInstructions.Location = new System.Drawing.Point(294, 60);
            this.tbTTMakerInstructions.Multiline = true;
            this.tbTTMakerInstructions.Name = "tbTTMakerInstructions";
            this.tbTTMakerInstructions.ReadOnly = true;
            this.tbTTMakerInstructions.Size = new System.Drawing.Size(227, 343);
            this.tbTTMakerInstructions.TabIndex = 10;
            // 
            // TypeTreeMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MappingTools.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(548, 561);
            this.Controls.Add(this.tbTTMakerInstructions);
            this.Controls.Add(this.btCheckByTTMaker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.laInstructions);
            this.Controls.Add(this.laSavePath);
            this.Controls.Add(this.mtsSavePathChoose);
            this.Controls.Add(this.tbMTS_Loc);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.mtsCreateAndSave);
            this.Controls.Add(this.typetreeInfoInput);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "TypeTreeMaker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TypeTreeMaker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TypeTreeMaker_Closed);
            this.Load += new System.EventHandler(this.TypeTreeMaker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox typetreeInfoInput;
        private System.Windows.Forms.Button mtsCreateAndSave;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbMTS_Loc;
        private System.Windows.Forms.Button mtsSavePathChoose;
        private System.Windows.Forms.Label laSavePath;
        private System.Windows.Forms.Label laInstructions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCheckByTTMaker;
        private System.Windows.Forms.TextBox tbTTMakerInstructions;
    }
}