using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MappingTools
{
    public partial class TypeTreeMaker : Form
    {
        //public bool closeflag = true;
        public TypeTreeMaker()
        {
            InitializeComponent();
            //load TypeTreeMaker save location from app.config
            string typetreeInfoInputSample = "_Header\r\nItem1 min max\r\nItem2 min max\r\n\r\n_Line\r\nItem1 min max\r\nItem2 min max";
            typetreeInfoInput.Text = typetreeInfoInputSample;
            string mtsLoc = ConfigurationManager.AppSettings["mtsSaveLoc"];
            tbMTS_Loc.Text = mtsLoc;
            tbMTS_Loc.Select();
            try
            {
                if (File.Exists(@"TTMakerInstruction.txt"))
                {
                    StreamReader streamReader = new StreamReader(@"TTMakerInstruction.txt", Encoding.Default);
                    tbTTMakerInstructions.Text = streamReader.ReadToEnd();
                }
            }
            catch
            { 
            }
        }
        private void mts_loc_Browse_Click(object sender, EventArgs e)
        {
            //choose mtr location
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowDialog();
            tbMTS_Loc.Text = folderDlg.SelectedPath;
        }
        private void mtsCreateAndSave_Click(object sender, EventArgs e)
        {
            //save workspace location into app.config
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings["mtsSaveLoc"] != null)
                    config.AppSettings.Settings["mtsSaveLoc"].Value = tbMTS_Loc.Text;
                else
                    config.AppSettings.Settings.Add("mtsSaveLoc", tbMTS_Loc.Text);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch
            {
                MessageBox.Show("Error!");
            }
            //move to next form
            if (tbMTS_Loc == null | Directory.Exists(tbMTS_Loc.Text) == false)
            {
                MessageBox.Show("Please select a folder!");
            }
            else if(typetreeInfoInput.Text == null|| typetreeInfoInput.Text == "")
            {
                MessageBox.Show("Please input something...");
            }
            else
            {
                //move
                //closeflag = false;
                /*******CREATE MTS BY USING CreateMTS()*******/
                MappingToolsFunc.StreamWriterForMts(Path.Combine(tbMTS_Loc.Text, "TypeTreeMaker.mts"), typetreeInfoInput.Text);

                try
                {
                    DialogResult dr = MessageBox.Show("Success! Do you want to open the target folde now?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("explorer.exe", tbMTS_Loc.Text);
                    }
                }
                catch
                {
                    MessageBox.Show("Error, please try again...", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*******END*******/
            }
        }
        private void TypeTreeMaker_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CheckByTTMaker_Click(object sender, EventArgs e)
        {
            string TTMakerPath = ConfigurationManager.AppSettings["WtxInstallationPath"] + "\\ttmakr64.exe";
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = @TTMakerPath;
                info.Arguments = "";
                info.WindowStyle = ProcessWindowStyle.Minimized;
                Process pro = Process.Start(info);
                pro.WaitForExit();
            }
            catch
            {
                MessageBox.Show("TTMaker64.exe not found, please check the installation path of WTX/ITX.\r\n(File --> WTX/ITX Installation Directory)");
                MessageBox.Show(TTMakerPath);
            }
        }

        private void TypeTreeMaker_Load(object sender, EventArgs e)
        {
            mainForm.MinimizeMainForm();
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            this.TopMost = false;
        }

        private void TypeTreeMaker_Closed(object sender, FormClosedEventArgs e)
        {
            mainForm.NormalMainForm();   
        }
    }
}