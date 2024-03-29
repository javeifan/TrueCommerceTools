﻿namespace MappingTools
{
    partial class MapClone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapClone));
            this.tbClone_currentMap = new System.Windows.Forms.TextBox();
            this.tbClone_targetMap = new System.Windows.Forms.TextBox();
            this.clone_Clone_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clone_Cancel_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbClone_currentMap
            // 
            this.tbClone_currentMap.Location = new System.Drawing.Point(145, 32);
            this.tbClone_currentMap.Name = "tbClone_currentMap";
            this.tbClone_currentMap.Size = new System.Drawing.Size(263, 23);
            this.tbClone_currentMap.TabIndex = 0;
            // 
            // tbClone_targetMap
            // 
            this.tbClone_targetMap.Location = new System.Drawing.Point(145, 80);
            this.tbClone_targetMap.Name = "tbClone_targetMap";
            this.tbClone_targetMap.Size = new System.Drawing.Size(263, 23);
            this.tbClone_targetMap.TabIndex = 1;
            this.tbClone_targetMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TargetMap_MouseClick);
            // 
            // clone_Clone_button
            // 
            this.clone_Clone_button.Location = new System.Drawing.Point(88, 132);
            this.clone_Clone_button.Name = "clone_Clone_button";
            this.clone_Clone_button.Size = new System.Drawing.Size(87, 27);
            this.clone_Clone_button.TabIndex = 2;
            this.clone_Clone_button.Text = "Clone";
            this.clone_Clone_button.UseVisualStyleBackColor = true;
            this.clone_Clone_button.Click += new System.EventHandler(this.Clone_CloneButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Target Name:";
            // 
            // clone_Cancel_button
            // 
            this.clone_Cancel_button.Location = new System.Drawing.Point(284, 132);
            this.clone_Cancel_button.Name = "clone_Cancel_button";
            this.clone_Cancel_button.Size = new System.Drawing.Size(87, 27);
            this.clone_Cancel_button.TabIndex = 5;
            this.clone_Cancel_button.Text = "Cancel";
            this.clone_Cancel_button.UseVisualStyleBackColor = true;
            this.clone_Cancel_button.Click += new System.EventHandler(this.Clone_CancelButton_Click);
            // 
            // MapClone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 190);
            this.Controls.Add(this.clone_Cancel_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clone_Clone_button);
            this.Controls.Add(this.tbClone_targetMap);
            this.Controls.Add(this.tbClone_currentMap);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapClone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clone";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbClone_currentMap;
        private System.Windows.Forms.TextBox tbClone_targetMap;
        private System.Windows.Forms.Button clone_Clone_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clone_Cancel_button;
    }
}