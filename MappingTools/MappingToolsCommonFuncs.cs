using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.IO;
using System.Security;
using System.Security.Cryptography;

namespace MappingTools
{
    class MappingToolsCommonFuncs
    {
        public static string GetSoftwareVersion()
        {
            string versionNum = "";
            XmlDocument doc = new XmlDocument();
            doc.Load("MappingToolsVersionDetails.xml");
            XmlNode root = doc.SelectSingleNode("//Version");
            versionNum = root.InnerText;
            return versionNum;
        }
        public static void SetSoftwareUserName(string newUserName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("MappingToolsVersionDetails.xml");
            XmlNode root = doc.SelectSingleNode("//UserName");
            root.InnerText = newUserName;
            doc.Save("MappingToolsVersionDetails.xml");
        }
        public static string GetSoftwareUserName()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("MappingToolsVersionDetails.xml");
            XmlNode root = doc.SelectSingleNode("//UserName");
            return root.InnerText;
        }

        public static string GetVersionNumFromServer()
        {
            string versionNum = "";
            //      \Update.xml    \MappingTools.zip
            string filepath = @"\\truecommerce.com\data\TCSGDEV\Departments\Technology\Mapping\Mapping Tools\Updates\";
            XmlDocument newUpdate = new XmlDocument();
            newUpdate.Load(filepath + "Update.xml");
            XmlNode versionnode = newUpdate.SelectSingleNode("//Version");
            versionNum = versionnode.InnerText;
            newUpdate.Save("Update.xml");
            return versionNum;
        }
        
        public static void SharePointPwdSave(string pwd)
        {
            // Data to protect. Convert a string to a byte[] using Encoding.UTF8.GetBytes().
            byte[] plaintext = Encoding.UTF8.GetBytes(pwd);

            // Generate additional entropy (will be used as the Initialization vector)
            byte[] entropy = new byte[20];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(entropy);
            }
            byte[] ciphertext = ProtectedData.Protect(plaintext, entropy, DataProtectionScope.CurrentUser);

            if (File.Exists("ciphertext"))
                File.Delete("ciphertext");
            FileStream plaintextfs = new FileStream("ciphertext", FileMode.Create);
            plaintextfs.Write(ciphertext, 0, ciphertext.Length);
            plaintextfs.Dispose();

            if (File.Exists("entropy"))
                File.Delete("entropy");
            FileStream entropyfs = new FileStream("entropy", FileMode.Create);
            entropyfs.Write(entropy, 0, entropy.Length);
            entropyfs.Dispose();
        }
        public static string SharePointPwdLoad(byte[] ciphertext, byte[] entropy)
        {
            try
            {
                byte[] plaintext = ProtectedData.Unprotect(ciphertext, entropy, DataProtectionScope.CurrentUser);
                string pwdStr = System.Text.Encoding.Default.GetString(plaintext);
                return pwdStr;
            }
            catch (CryptographicException e)
            {
                return null;
            }
        }
        public static byte[] FileContent(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    byte[] buffur = new byte[fs.Length];
                    fs.Read(buffur, 0, (int)fs.Length);
                    return buffur;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
