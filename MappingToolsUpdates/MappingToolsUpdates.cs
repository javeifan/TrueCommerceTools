using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aliyun.OSS;
using Aliyun.OSS.Common;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Diagnostics;
using System.Xml;

namespace MappingToolsUpdates
{
    public partial class MappingToolsUpdates : Form
    {
        private static MappingToolsUpdates mappingtoolUpdates;
        public MappingToolsUpdates()
        {
            mappingtoolUpdates = this;
            InitializeComponent();
            laVersionCompare.Text = "New version "+GetLatestVersion()+" is available. You have "+GetCurrentVersion()+".";
        }
        
        public static void GetObjectProgress(string objectName, string downloadFilename)
        {
            if (File.Exists(objectName))//必须判断要复制的文件是否存在
            {
                File.Copy(objectName, downloadFilename, true);//三个参数分别是源文件路径，存储路径，若存储路径有相同文件是否替换
            }
        }

        private void MappingToolsUpdatesCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MappingToolsUpdatesUpdate_Click(object sender, EventArgs e)
        {
            string filepath = @"\\truecommerce.com\data\TCSGDEV\Departments\Technology\Mapping\Mapping Tools\Updates\";
            string objectName = filepath + GetObjectName();
            string downloadFilename = "tmp/" + GetObjectName();
            try
            {
                if (Directory.Exists("tmp"))
                {
                    GetObjectProgress(objectName, downloadFilename);
                }
                else
                {
                    Directory.CreateDirectory("tmp");
                    GetObjectProgress(objectName, downloadFilename);
                }
                ExtractToDirectory();

                XmlDocument doc = new XmlDocument();
                doc.Load("Update.xml");

                XmlNode fileDel = doc.SelectSingleNode("//FileDelList");
                string[] fileDelList = fileDel.InnerText.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                XmlNode fileCopy = doc.SelectSingleNode("//FileCopyList");
                string[] fileCopyList = fileCopy.InnerText.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                XmlNode directoryUpdate = doc.SelectSingleNode("//DirectoryUpdateList");
                string[] directoryUpdateList = directoryUpdate.InnerText.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                //UpdateRemoveFile(fileDelList, Directory.GetCurrentDirectory());
                UpdateCopy(fileCopyList, Directory.GetCurrentDirectory() + "\\tmp\\MappingTools", Directory.GetCurrentDirectory());
                UpdateDirectory(directoryUpdateList, Directory.GetCurrentDirectory() + "\\tmp\\MappingTools", Directory.GetCurrentDirectory());
                UpdateVersion();
                Directory.Delete("tmp", true);
                File.Delete("Update.xml");
                MessageBox.Show("Software update successful!");
                this.Close();
                
            }
            catch
            { 
            
            }
        }

        private void ExtractToDirectory()
        {
            string target = Directory.GetCurrentDirectory() + "/tmp/";
            ZipFile.ExtractToDirectory("tmp/"+GetObjectName(), target);
        }
        public static string GetCurrentVersion()
        {
            string versionNum = "";
            XmlDocument doc = new XmlDocument();
            doc.Load("MappingToolsVersionDetails.xml");
            XmlNode root = doc.SelectSingleNode("//Version");
            versionNum = root.InnerText;
            return versionNum;
        }
        public static string GetLatestVersion()
        {
            string versionNum = "";
            XmlDocument doc = new XmlDocument();
            doc.Load("Update.xml");
            XmlNode root = doc.SelectSingleNode("//Version");
            versionNum = root.InnerText;
            return versionNum;
        }

        public static string GetObjectName()
        {
            string objectName = "";
            XmlDocument doc = new XmlDocument();
            doc.Load("Update.xml");
            XmlNode root = doc.SelectSingleNode("//ZipName");
            objectName = root.InnerText;
            return objectName;
        }
        public static void UpdateCopy(string[] sArray, string copyFrom, string copyTo)
        {
            foreach (string fileName in sArray)
            {
                string fileToPath = copyTo + @"\" + fileName;
                string fileFromPath = copyFrom + @"\" + fileName;
                bool isrewrite = true; // true=覆盖已存在的同名文件,false则反之
                System.IO.File.Copy(fileFromPath, fileToPath, isrewrite);
            }
        }
        public static void UpdateRemoveFile(string[] sArry,string path)
        {
            foreach(string fileName in sArry)
            {
                if (File.Exists(path + "\\" + fileName))
                    File.Delete(path + "\\" + fileName);
            }
        }
        public static void UpdateDirectory(string[] sArray, string copyFrom, string copyTo)
        {
            foreach(string dir in sArray)
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                foreach (string filename in Directory.GetFiles(copyFrom + "\\" + dir))
                {
                    string fileToPath = copyTo + "\\" + dir + "\\" + filename;
                    string fileFromPath = copyFrom + "\\" + dir + "\\" + filename;
                    bool isrewrite = true; // true=覆盖已存在的同名文件,false则反之
                    //File.Copy(fileFromPath, fileToPath, isrewrite);
                    File.Move(fileFromPath, fileToPath);
                }
            }
        }
        public static void UpdateVersion()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("MappingToolsVersionDetails.xml");
            XmlNode root = doc.SelectSingleNode("//Version");
            root.InnerText = GetLatestVersion();
            doc.Save("MappingToolsVersionDetails.xml");
        }

        private void MappingToolsUpdates_Closed(object sender, FormClosedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"MappingTools.exe");
            }
            catch
            {

            }
        }
    }
}
