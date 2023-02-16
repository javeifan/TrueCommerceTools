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

namespace MappingToolsUpdates
{
    public partial class MappingToolsUpdates : Form
    {

        public MappingToolsUpdates()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DownloadOSSobject();
        }
        public static void DownloadOSSobject()
        {
            var endpoint = "oss-cn-beijing.aliyuncs.com";
            var accessKeyId = "LTAI4G2mJFYYaAqXTHscExaB";
            var accessKeySecret = "VllS3bsoXxm7Svt23M8MmeDiga6CXX";
            var bucketName = "mappingtools";
            // objectName 表示您在下载文件时需要指定的文件名称，如abc/efg/123.jpg。
            var objectName = "MappingTools/Updates/Update.xml";
            var downloadFilename = "Update.xml";
            // 创建OssClient实例。
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
            try
            {
                // 下载文件到流。OssObject 包含了文件的各种信息，如文件所在的存储空间、文件名、元信息以及一个输入流。
                var obj = client.GetObject(bucketName, objectName);
                using (var requestStream = obj.Content)
                {
                    byte[] buf = new byte[1024];
                    var fs = File.Open(downloadFilename, FileMode.OpenOrCreate);
                    var len = 0;
                    // 通过输入流将文件的内容读取到文件或者内存中。
                    while ((len = requestStream.Read(buf, 0, 1024)) != 0)
                    {
                        fs.Write(buf, 0, len);
                    }
                    fs.Close();
                }
                MessageBox.Show("Get object succeeded");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get object failed. {0}", ex.Message);
            }
            
        }
        public static void UploadOSSobject()
        {
            var endpoint = "oss-cn-beijing.aliyuncs.com";
            var accessKeyId = "LTAI4G2mJFYYaAqXTHscExaB";
            var accessKeySecret = "VllS3bsoXxm7Svt23M8MmeDiga6CXX";
            var bucketName = "mappingtools";
            var objectName = "MappingTools/Updates/Aliyun.OSS.xml";
            var objectContent = "More than just cloud2.";
            // 创建OssClient实例。
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
            try
            {
                byte[] binaryData = Encoding.ASCII.GetBytes(objectContent);
                MemoryStream requestContent = new MemoryStream(binaryData);
                // 上传文件。
                client.PutObject(bucketName, objectName, requestContent);
                MessageBox.Show("Put object succeeded");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Put object failed, {0}", ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ExtractToDirectory();
        }
        private void ExtractToDirectory()
        {
            string target = Directory.GetCurrentDirectory() + "/test2/";
            ZipFile.ExtractToDirectory(@"D:\123.zip", target);
        }
    }
}
