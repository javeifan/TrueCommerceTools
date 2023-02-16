using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Windows.Media;
namespace MappingTools
{
    public partial class MapClone : Form
    {
        public MapClone()
        {
            InitializeComponent();
        }
        public static string GetWorkSpace()
        {
            string workspace = ConfigurationManager.AppSettings["workspace"];
            return workspace;
        }
        public static bool isStandardMap(string mapName)
        {
            var index = mapName.IndexOf(".R");
            if (index > 0)
            {
                return true;
            }
            return false;
        }
        //release num + 1
        public static string ReleaseAdd(string mapName)
        {
            if (isStandardMap(mapName))
            {
                string newMapName = null;
                string[] sArray = mapName.Split('R');
                var releaseNum = Convert.ToInt32(sArray[sArray.Count() - 1]);
                for (int i = 0; i < sArray.Count() - 1; i++)
                {
                    newMapName += sArray[i] + "R";
                }
                newMapName += (releaseNum + 1).ToString();
                return newMapName;
            }
            return null;
        }
        public static void CloneMap(string currentMap, string targetMap)
        {
            string currentMapPath = Path.Combine(GetWorkSpace(), currentMap);
            string targetMapPath = Path.Combine(GetWorkSpace(), targetMap);
            string[] picklist = Directory.GetFiles(currentMapPath);
            bool isrewrite = true;
            foreach (string f in picklist)
            {
                if (Path.GetExtension(Path.Combine(currentMapPath, f)) != ".project")
                {
                    // Remove path from the file name.
                    string fName = f.Substring(currentMapPath.Length + 1);
                    //target file name
                    string tfName = fName.Replace(currentMap, targetMap);
                    File.Copy(Path.Combine(currentMapPath, fName), Path.Combine(targetMapPath, tfName), isrewrite);
                }
            }
        }
        //failed.F'MapNameRename': Do not use.
        public static void MapNameRename(string currentMap, string targetMap)
        {
            string targetMapPath = Path.Combine(GetWorkSpace(), targetMap);
            string[] picklist = Directory.GetFiles(targetMapPath);
            foreach (string f in picklist)
            {
                if (Path.GetExtension(Path.Combine(targetMapPath, f)) == ".mms" || Path.GetExtension(Path.Combine(targetMapPath, f)) == ".dpa")
                {
                    String[] fileReadLines = File.ReadAllLines(Path.Combine(targetMapPath, f));
                    foreach (var line in fileReadLines)
                    {
                        MessageBox.Show(line);
                    }
                }
            }
        }
        private void Clone_CloneButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(Path.Combine(GetWorkSpace(), tbClone_targetMap.Text)) == false)
                {
                    Directory.CreateDirectory(Path.Combine(GetWorkSpace(), tbClone_targetMap.Text));
                    CloneMap(tbClone_currentMap.Text, tbClone_targetMap.Text);
                }
                else
                {
                    DialogResult ow = MessageBox.Show("Target map is already exists, overwrite or not?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (ow == DialogResult.Yes)
                    {
                        CloneMap(tbClone_currentMap.Text, tbClone_targetMap.Text);
                    }
                }
                DialogResult dr = MessageBox.Show("Success! Do you want to open the target folde now?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", Path.Combine(GetWorkSpace(), tbClone_targetMap.Text));
                }
                //MapNameRename(tbClone_currentMap.Text, tbClone_targetMap.Text);
            }
            catch
            {
                MessageBox.Show("An invalid path was detected. Please re-enter your path.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TargetMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (tbClone_currentMap.Text != null && tbClone_targetMap.Text.Length == 0)
                tbClone_targetMap.Text = ReleaseAdd(tbClone_currentMap.Text);
        }
        private void Clone_CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
