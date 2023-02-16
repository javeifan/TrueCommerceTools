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
        private static string targetMapPath = "";
        private static string targetMapName = "";
        private static string currentMapName = "";
        public MapClone()
        {
            InitializeComponent();

            if (ConfigurationManager.AppSettings["AdvancedCloneMode"].ToUpper() == "FALSE")
                this.Text = "Clone - Normal Mode";
            else if (ConfigurationManager.AppSettings["AdvancedCloneMode"].ToUpper() == "TRUE")
                this.Text = "Clone - Advanced Mode";

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

                    if (ConfigurationManager.AppSettings["AdvancedCloneMode"].ToUpper() == "TRUE")
                    {
                        targetMapPath = Path.Combine(GetWorkSpace(), tbClone_targetMap.Text);
                        targetMapName = tbClone_targetMap.Text;
                        currentMapName = tbClone_currentMap.Text;
                        if (File.Exists(Path.Combine(targetMapPath, targetMapName + ".mms")))
                        {
                            string mmsData = ReplaceMapNameInMMS(FileToStream(".mms"));
                            File.Delete(Path.Combine(targetMapPath, targetMapName + ".mms"));
                            StreamToFile(mmsData, Path.Combine(targetMapPath, targetMapName + ".mms"));
                        }
                        if (File.Exists(Path.Combine(targetMapPath, targetMapName + ".mopt")))
                        {
                            string mmsData = ReplaceMapNameInMMS(FileToStream(".mopt"));
                            File.Delete(Path.Combine(targetMapPath, targetMapName + ".mopt"));
                            StreamToFile(mmsData, Path.Combine(targetMapPath, targetMapName + ".mopt"));
                        }
                        if (File.Exists(Path.Combine(targetMapPath, targetMapName + ".dpa")))
                        {
                            string mmsData = ReplaceMapNameInMMS(FileToStream(".dpa"));
                            File.Delete(Path.Combine(targetMapPath, targetMapName + ".dpa"));
                            StreamToFile(mmsData, Path.Combine(targetMapPath, targetMapName + ".dpa"));
                        }
                    }
                }
                else
                {
                    DialogResult ow = MessageBox.Show("Target map is already exists, overwrite or not?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (ow == DialogResult.Yes)
                    {
                        CloneMap(tbClone_currentMap.Text, tbClone_targetMap.Text);

                        if (ConfigurationManager.AppSettings["AdvancedCloneMode"].ToUpper() == "TRUE")
                        {
                            targetMapPath = Path.Combine(GetWorkSpace(), tbClone_targetMap.Text);
                            targetMapName = tbClone_targetMap.Text;
                            currentMapName = tbClone_currentMap.Text;
                            if (File.Exists(Path.Combine(targetMapPath, targetMapName + ".mms")))
                            {
                                string mmsData = ReplaceMapNameInMMS(FileToStream(".mms"));
                                File.Delete(Path.Combine(targetMapPath, targetMapName + ".mms"));
                                StreamToFile(mmsData, Path.Combine(targetMapPath, targetMapName + ".mms"));
                            }
                            if (File.Exists(Path.Combine(targetMapPath, targetMapName + ".mopt")))
                            {
                                string mmsData = ReplaceMapNameInMMS(FileToStream(".mopt"));
                                File.Delete(Path.Combine(targetMapPath, targetMapName + ".mopt"));
                                StreamToFile(mmsData, Path.Combine(targetMapPath, targetMapName + ".mopt"));
                            }
                            if (File.Exists(Path.Combine(targetMapPath, targetMapName + ".dpa")))
                            {
                                string mmsData = ReplaceMapNameInMMS(FileToStream(".dpa"));
                                File.Delete(Path.Combine(targetMapPath, targetMapName + ".dpa"));
                                StreamToFile(mmsData, Path.Combine(targetMapPath, targetMapName + ".dpa"));
                            }
                        }
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
                MessageBox.Show("An unknown error occurred!", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// <summary>
        /// 字符串转16进制
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetHexFromChs(string s)
        {
            if ((s.Length % 2) != 0)
            {
                s += " ";//空格
                         //throw new ArgumentException("s is not valid chinese string!");
            }

            System.Text.Encoding chs = System.Text.Encoding.GetEncoding("gb2312");

            byte[] bytes = chs.GetBytes(s);

            string str = "";

            for (int i = 0; i < bytes.Length; i++)
            {
                str += string.Format("{0:X}", bytes[i]);
            }

            return str;
        }

        private static string ReplaceMapNameInMMS(string binary)
        {
            string Processedbinary = "";
            Processedbinary = binary.Replace(RemoveHexSpace(GetHexFromChs(currentMapName.Trim()).ToUpper()), RemoveHexSpace(GetHexFromChs(targetMapName.Trim()).ToUpper()));
            return Processedbinary;
        }
        private static string RemoveHexSpace(string str)
        {
            if (str.EndsWith("20"))
                return str.Substring(0, str.Length - 2);
            else
                return str;
        }

        public static string FileToStream(string suffix)
        {
            try
            {
                //IPdfClassBll pdfClassBll = DataFactory.GetPdfClass();
                FileStream fs = new FileStream(Path.Combine(targetMapPath,targetMapName+suffix), FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                Byte[] byData = br.ReadBytes((int)fs.Length);
                StringBuilder strResult = new StringBuilder(byData.Length * 8);
                string binary = byteToHexStr(byData);
                fs.Close();
                br.Close();

                return binary;
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }
        public static void StreamToFile(string strMMS,string pathMMS)
        {

                byte[] bytes = strToToHexByte(strMMS);
                FileStream fileStream = new FileStream(pathMMS, FileMode.OpenOrCreate, FileAccess.Write);
                fileStream.Write(bytes, 0, bytes.Length);
                BinaryWriter binaryWriter = new BinaryWriter(fileStream);
                binaryWriter.Write(bytes);
                binaryWriter.Close();
                fileStream.Close();

        }
        /// <summary>
        /// 16进制字符串转为文字
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);

            return returnBytes;
        }

    }
}
