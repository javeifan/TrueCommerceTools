using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Collections.Specialized;

namespace MappingTools
{
    //blog url: https://blog.csdn.net/starlee/article/details/4441150
    class SharePointFileHelper
    {
        // 上传文件
        // 
        // 参数
        // 上传的文件在SharePoint上的位置，要上传的本地文件的路径名，用户名，密码，域
        public static string UploadFile(string strDestUrl, string strFilePathName, string strUserName, string strPassword, string strDomain)
        {
            string strResult = "Success";

            try
            {
                string strFileName = Path.GetFileName(strFilePathName);
                string strCopiedFilePathName = Path.GetTempPath() + strFileName;

                // 将文件拷贝到临时文件夹
                // 目的是可以在文件在被打开状态下还可以上传
                File.Copy(strFilePathName, strCopiedFilePathName, true);

                // 打开拷贝到临时目录下的文件
                FileStream fs = new FileStream(strCopiedFilePathName, FileMode.Open, FileAccess.Read);

                // 读文件
                BinaryReader br = new BinaryReader(fs);
                Byte[] filecontents = br.ReadBytes((int)fs.Length);

                br.Close();
                fs.Close();

                WebClient webclient = CreateWebClient(strUserName, strPassword, strDomain);

                // 上传
                webclient.UploadData(strDestUrl + strFileName, "PUT", filecontents);
            }
            catch (Exception ex)
            {
                strResult = "Failed! " + ex.Message;
            }

            return strResult;
        }

        // 下载文件
        // 
        // 参数
        // 下载的文件在SharePoint上的位置，文件下载后存放的本地文件夹路径，用户名，密码，域
        public static string DownloadFile(string strSourceUrl, string strDestFolder, string strUserName, string strPassword, string strDomain)
        {
            string strResult = "Success";

            try
            {
                WebClient webclient = CreateWebClient(strUserName, strPassword, strDomain);

                // 下载
                Byte[] filecontents = webclient.DownloadData(strSourceUrl);

                string strFileName = Path.GetFileName(strSourceUrl);

                // 创建文件
                FileStream fs = new FileStream(strDestFolder + strFileName, FileMode.Create, FileAccess.Write);
                // 写文件
                fs.Write(filecontents, 0, filecontents.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                strResult = "failed! " + ex.Message;
            }

            return strResult;
        }

        // 创建WebClient
        // 参数：用户名，密码，域（用来登陆SharePoint）
        public static WebClient CreateWebClient(string strUserName, string strPassword, string strDomain)
        {
            WebClient webclient = new WebClient();

            if (String.IsNullOrEmpty(strUserName))
            {
                webclient.UseDefaultCredentials = true;
            }
            else
            {
                NetworkCredential credential = new NetworkCredential(strUserName, strPassword, strDomain);
                webclient.Credentials = credential;
            }

            return webclient;
        }
    }
}