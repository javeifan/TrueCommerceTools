namespace MappingTools
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.mapClone_button = new System.Windows.Forms.Button();
            this.MainFormMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setUpWTXITXDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpContentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typetreeMaker_Button = new System.Windows.Forms.Button();
            this.btCreateNewMap = new System.Windows.Forms.Button();
            this.btWTXDailyEmailHelper = new System.Windows.Forms.Button();
            this.btSpawnDailyEmailHelper = new System.Windows.Forms.Button();
            this.btVANEmailTemplates = new System.Windows.Forms.Button();
            this.aboutMappingToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MainFormMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapClone_button
            // 
            this.mapClone_button.Location = new System.Drawing.Point(294, 66);
            this.mapClone_button.Name = "mapClone_button";
            this.mapClone_button.Size = new System.Drawing.Size(227, 31);
            this.mapClone_button.TabIndex = 1;
            this.mapClone_button.Text = "Clone Map";
            this.mapClone_button.UseVisualStyleBackColor = true;
            this.mapClone_button.Click += new System.EventHandler(this.MapClone_Click);
            // 
            // MainFormMenu
            // 
            this.MainFormMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainFormMenu.Location = new System.Drawing.Point(0, 0);
            this.MainFormMenu.Name = "MainFormMenu";
            this.MainFormMenu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.MainFormMenu.Size = new System.Drawing.Size(563, 24);
            this.MainFormMenu.TabIndex = 1;
            this.MainFormMenu.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setUpWTXITXDirectoryToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // setUpWTXITXDirectoryToolStripMenuItem
            // 
            this.setUpWTXITXDirectoryToolStripMenuItem.Name = "setUpWTXITXDirectoryToolStripMenuItem";
            this.setUpWTXITXDirectoryToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.setUpWTXITXDirectoryToolStripMenuItem.Text = "WTX/ITX Installation Directory";
            this.setUpWTXITXDirectoryToolStripMenuItem.Click += new System.EventHandler(this.setUpWTXITXDirectoryToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.MainFormExit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpContentsToolStripMenuItem,
            this.toolStripSeparator1,
            this.checkToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutMappingToolsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // checkToolStripMenuItem
            // 
            this.checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            this.checkToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.checkToolStripMenuItem.Text = "Check for Updates";
            // 
            // helpContentsToolStripMenuItem
            // 
            this.helpContentsToolStripMenuItem.Name = "helpContentsToolStripMenuItem";
            this.helpContentsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.helpContentsToolStripMenuItem.Text = "Help Contents";
            this.helpContentsToolStripMenuItem.Click += new System.EventHandler(this.HelpContentsToolStripMenuItem_Click);
            // 
            // typetreeMaker_Button
            // 
            this.typetreeMaker_Button.Location = new System.Drawing.Point(29, 222);
            this.typetreeMaker_Button.Name = "typetreeMaker_Button";
            this.typetreeMaker_Button.Size = new System.Drawing.Size(227, 31);
            this.typetreeMaker_Button.TabIndex = 4;
            this.typetreeMaker_Button.Text = "Create MTS";
            this.typetreeMaker_Button.UseVisualStyleBackColor = true;
            this.typetreeMaker_Button.Click += new System.EventHandler(this.TypeTreeMaker_Click);
            // 
            // btCreateNewMap
            // 
            this.btCreateNewMap.Location = new System.Drawing.Point(29, 66);
            this.btCreateNewMap.Name = "btCreateNewMap";
            this.btCreateNewMap.Size = new System.Drawing.Size(227, 31);
            this.btCreateNewMap.TabIndex = 0;
            this.btCreateNewMap.Text = "Create New Map{Developing}";
            this.btCreateNewMap.UseVisualStyleBackColor = true;
            this.btCreateNewMap.Click += new System.EventHandler(this.CreateNewMap_Click);
            // 
            // btWTXDailyEmailHelper
            // 
            this.btWTXDailyEmailHelper.Location = new System.Drawing.Point(29, 145);
            this.btWTXDailyEmailHelper.Name = "btWTXDailyEmailHelper";
            this.btWTXDailyEmailHelper.Size = new System.Drawing.Size(227, 31);
            this.btWTXDailyEmailHelper.TabIndex = 2;
            this.btWTXDailyEmailHelper.Text = "WTX Daily Email Helper";
            this.btWTXDailyEmailHelper.UseVisualStyleBackColor = true;
            this.btWTXDailyEmailHelper.Click += new System.EventHandler(this.WTXDailyEmailHelper_Click);
            // 
            // btSpawnDailyEmailHelper
            // 
            this.btSpawnDailyEmailHelper.Location = new System.Drawing.Point(294, 145);
            this.btSpawnDailyEmailHelper.Name = "btSpawnDailyEmailHelper";
            this.btSpawnDailyEmailHelper.Size = new System.Drawing.Size(227, 31);
            this.btSpawnDailyEmailHelper.TabIndex = 3;
            this.btSpawnDailyEmailHelper.Text = "Spawn Daily Email Helper";
            this.btSpawnDailyEmailHelper.UseVisualStyleBackColor = true;
            this.btSpawnDailyEmailHelper.Click += new System.EventHandler(this.SpawnDailyEmailHelper_Click);
            // 
            // btVANEmailTemplates
            // 
            this.btVANEmailTemplates.Location = new System.Drawing.Point(294, 222);
            this.btVANEmailTemplates.Name = "btVANEmailTemplates";
            this.btVANEmailTemplates.Size = new System.Drawing.Size(227, 31);
            this.btVANEmailTemplates.TabIndex = 5;
            this.btVANEmailTemplates.Text = "VAN Email Templates";
            this.btVANEmailTemplates.UseVisualStyleBackColor = true;
            this.btVANEmailTemplates.Click += new System.EventHandler(this.VANEmailTemplates_Click);
            // 
            // aboutMappingToolsToolStripMenuItem
            // 
            this.aboutMappingToolsToolStripMenuItem.Name = "aboutMappingToolsToolStripMenuItem";
            this.aboutMappingToolsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.aboutMappingToolsToolStripMenuItem.Text = "About MappingTools";
            this.aboutMappingToolsToolStripMenuItem.Click += new System.EventHandler(this.MainFormMeanAbout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(228, 6);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 307);
            this.Controls.Add(this.btVANEmailTemplates);
            this.Controls.Add(this.btSpawnDailyEmailHelper);
            this.Controls.Add(this.btWTXDailyEmailHelper);
            this.Controls.Add(this.btCreateNewMap);
            this.Controls.Add(this.typetreeMaker_Button);
            this.Controls.Add(this.mapClone_button);
            this.Controls.Add(this.MainFormMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainFormMenu;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mapping Tools";
            this.MainFormMenu.ResumeLayout(false);
            this.MainFormMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mapClone_button;
        private System.Windows.Forms.MenuStrip MainFormMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button typetreeMaker_Button;
        private System.Windows.Forms.Button btCreateNewMap;
        private System.Windows.Forms.Button btWTXDailyEmailHelper;
        private System.Windows.Forms.ToolStripMenuItem helpContentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUpWTXITXDirectoryToolStripMenuItem;
        private System.Windows.Forms.Button btSpawnDailyEmailHelper;
        private System.Windows.Forms.Button btVANEmailTemplates;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutMappingToolsToolStripMenuItem;
    }
}