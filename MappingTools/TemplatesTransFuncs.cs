using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.IO;
using System.Xml;

namespace MappingTools
{
    class TemplatesTransFuncs
    {
        /// <summary>
        /// 将"[$$:BR]"转换为"\r\n"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SubstituteLineFeed(string str)
        {
            string processedValue = "";
            processedValue = str.Replace("[$$:BR]", "\r\n");
            return processedValue;
        }
        /// <summary>
        /// 将输入的EDI ID转换为所需格式（如果ifMultiLine为true，则以换行为分隔）
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ifMultiLine"></param>
        /// <returns></returns>
        public static string ProcessEDIID(string str, bool ifMultiLine)
        {
            string processedStr = "";
            if (ifMultiLine == true)
            {
                string[] sArray = str.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string eachCustID in sArray)
                {
                    if (IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains('\t'))
                    {
                        processedStr += eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + "/ " + eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "\r\n";
                    }
                    else if (IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains(" "))
                    {
                        processedStr += eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + "/ " + eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "\r\n";
                    }
                    else
                    {
                        //processedStr += "/ " + eachCustID.Trim(new char[] { '\t' }).Trim() + "\r\n"; 
                        //没有Qual的EDI ID将不再需要被获取
                    }
                }
                return processedStr;
            }
            else
            {
                string[] sArray = str.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string eachCustID in sArray)
                {
                    if (IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains('\t'))
                    {
                        processedStr += eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + "/ " + eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "; ";
                    }
                    else if (IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains(" "))
                    {
                        processedStr += eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + "/ " + eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "; ";
                    }
                    else
                    {
                        //processedStr += " / " + eachCustID.Trim(new char[] { '\t' }).Trim() + " ";
                        //没有Qual的EDI ID将不再需要被获取
                    }
                }
                if (processedStr.EndsWith("; "))
                    processedStr = processedStr.Trim(new char[] { ';', ' ' });
                return processedStr;
            }
        }
        /// <summary>
        /// 相比于ProcessEDIID，"/"前后增加了空格
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ifMultiLine"></param>
        /// <returns></returns>
        public static string ProcessEDIIDForInterTrade(string str, bool ifMultiLine)
        {
            string processedStr = "";
            if (ifMultiLine == true)
            {
                string[] sArray = str.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string eachCustID in sArray)
                {
                    if (IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains('\t'))
                    {
                        processedStr += eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + " / " + eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "\r\n";
                    }
                    else if (IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains(" "))
                    {
                        processedStr += eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + " / " + eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "\r\n";
                    }
                    else
                    {
                        //processedStr += "/ " + eachCustID.Trim(new char[] { '\t' }).Trim() + "\r\n"; 
                        //没有Qual的EDI ID将不再需要被获取
                    }
                }
                return processedStr;
            }
            else
            {
                string[] sArray = str.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string eachCustID in sArray)
                {
                    if (IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains('\t'))
                    {
                        processedStr += eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + " / " + eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "; ";
                    }
                    else if (IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains(" "))
                    {
                        processedStr += eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + " / " + eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "; ";
                    }
                    else
                    {
                        //processedStr += " / " + eachCustID.Trim(new char[] { '\t' }).Trim() + " ";
                        //没有Qual的EDI ID将不再需要被获取
                    }
                }
                if (processedStr.EndsWith("; "))
                    processedStr = processedStr.Trim(new char[] { ';', ' ' });
                return processedStr;
            }
        }
        /// <summary>
        /// For special format "Qual=[$:CUSTOMER_QUALIFIER] ID=[$:CUSTOMER_EDI_ID]"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ProcessEDIIDWithPrefix(string str)
        {
            string processedStr = "";
            string[] sArray = str.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string eachCustID in sArray)
            {
                if (IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains('\t'))
                {
                    processedStr += "Qual =" + eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + " ID=" + eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "; ";
                }
                else if (IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains(" "))
                {
                    processedStr += "Qual =" + eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + " ID=" + eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "; ";
                }
            }
            if (processedStr.EndsWith("; "))
                processedStr = processedStr.Trim(new char[] { ';', ' ' });
            return processedStr;
        }
        /// <summary>
        /// For special format "Qualifer [$:CUSTOMER_QUALIFIER] ID [$:CUSTOMER_EDI_ID]"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ProcessEDIIDWithPrefixNoEqualSign(string str)
        {
            string processedStr = "";
            string[] sArray = str.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string eachCustID in sArray)
            {
                if (IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains('\t'))
                {
                    processedStr += "Qual " + eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + " ID " + eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "; ";
                }
                else if (IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains(" "))
                {
                    processedStr += "Qual " + eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + " ID " + eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "; ";
                }
            }
            if (processedStr.EndsWith("; "))
                processedStr = processedStr.Trim(new char[] { ';', ' ' });
            return processedStr;
        }
        /// <summary>
        /// 将Qual/ EDI ID 转变为EDI ID+Qual(ie: 12/ 123 to 12312)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string QualIDToIDQual(string str)
        {
            string outStr = "";
            string[] sArray = str.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string eachCustID in sArray)
            {
                if (TemplatesTransFuncs.IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains('\t'))
                {
                    outStr += eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + "; ";
                }
                else if (IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains(" "))
                {
                    outStr += eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + "; ";
                }
                else
                {
                    //outStr += eachCustID.Trim(new char[] { '\t' }).Trim() + " ";
                    //没有Qual的EDI ID将不再需要被获取
                }
            }
            if (outStr.EndsWith("; "))
                outStr = outStr.Trim(new char[] { ';', ' ' });
            return outStr.Trim();
        }
        /// <summary>
        /// 判断是否以数字或者中文或者英文字符开头
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IfStartsWithCharacter(string str)
        {
            Regex regChina = new Regex("^[^\x00-\xFF]");
            Regex regNum = new Regex("^[0-9]");
            Regex regChar = new Regex("^[a-z]");
            Regex regDChar = new Regex("^[A-Z]");
            if (regNum.IsMatch(str) || regChina.IsMatch(str) || regChar.IsMatch(str) || regDChar.IsMatch(str))
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 将字符串转变为布尔值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool StringToBool(string str)
        {
            if (str.ToUpper() == "TRUE")
                return true;
            else
                return false;
        }
        /// <summary>
        /// 移除最后的"\r\n"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveTerminator(string str)
        {
            if (str.EndsWith("\r\n"))
                str = str.Remove(str.LastIndexOf("\r\n"), 1);
            return str;
        }
        /// <summary>
        /// 检查EDI ID是否符合规范
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckEdiID(string str)
        {
            int count = 0;
            string[] sArray = str.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string eachCustID in sArray)
            {
                if (IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains('\t'))
                {
                    count += 1;
                }
                else if (IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains(" "))
                {
                    count += 1;
                }
            }
            if (count > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 将文本发送至Outlook
        /// </summary>
        /// <param name="sendTo"></param>
        /// <param name="subject"></param>
        /// <param name="mailBody"></param>
        public static void SendStrToOutlook(string sendTo, string subject, string mailBody)
        {
            Outlook.Application olApp = new Outlook.Application();
            Outlook.MailItem mailItem = (Outlook.MailItem)olApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.To = sendTo;
            //mailItem.CC = tbMailCCTo.Text;
            mailItem.Subject = subject;
            mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
            string content = "";
            content += ConvertToHTMLFormat(RemoveEmailAndSubject(mailBody));
            mailItem.HTMLBody = content;
            mailItem.Display();
            mailItem = null;
            olApp = null;
        }
        public static void SendStrToOutlookForIntertrade(string sendTo, string subject, string mailBody,string ccnames)
        {
            Outlook.Application olApp = new Outlook.Application();
            Outlook.MailItem mailItem = (Outlook.MailItem)olApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.To = sendTo;
            //mailItem.CC = tbMailCCTo.Text;
            mailItem.Subject = subject;
            mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
            mailItem.CC = ccnames;
            string content = "";
            content += ConvertToHTMLFormat(RemoveEmailAndSubject(mailBody));
            mailItem.HTMLBody = content;
            mailItem.Display();
            mailItem = null;
            olApp = null;
        }
        public static void SendStrToOutlookForICC(string sendTo, string subject, string mailBody, string link, string linkDetail)
        {
            Outlook.Application olApp = new Outlook.Application();
            Outlook.MailItem mailItem = (Outlook.MailItem)olApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.To = sendTo;
            mailItem.Subject = subject;
            mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
            string content = "";
            content += ConvertToHTMLFormatForICC(RemoveEmailAndSubject(mailBody), link, linkDetail);
            mailItem.HTMLBody = content;
            mailItem.Display();
            mailItem = null;
            olApp = null;
        }
        public static void SendStrToOutlookForCommport(string sendTo, string subject, string mailBody, string link, string linkDetail)
        {
            Outlook.Application olApp = new Outlook.Application();
            Outlook.MailItem mailItem = (Outlook.MailItem)olApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.To = sendTo;
            mailItem.Subject = subject;
            mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
            string content = "";
            content += ConvertToHTMLFormatForCommport(RemoveEmailAndSubject(mailBody), link, linkDetail);
            mailItem.HTMLBody = content;
            mailItem.Display();
            mailItem = null;
            olApp = null;
        }
        /// <summary>
        /// 移除文本前面包含Email和Subject的三行数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveEmailAndSubject(string str)
        {
            str = str.Remove(0, str.IndexOf("\r\n") + 1);
            str = str.Remove(0, str.IndexOf("\r\n") + 1);
            str = str.Remove(0, str.IndexOf("\r\n") + 1);
            return str;
        }
        public static string ConvertToHTMLFormat(string str)
        {
            string emptyLine = "<p class=\"MsoNormal\"><o:p>&nbsp;</o:p></p>";
            //string styleLine = "<style>p{ margin:0 auto;font-family:Calibri;color:black;font-size:11.0pt}</style>";
            string formatedStr = "";
            //string[] sArray = str.Split("\r\n\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] sArray = Regex.Split(str, "\r\n\r\n", RegexOptions.IgnoreCase);
            foreach (string eachLine in sArray)
            {
                if (eachLine.Contains("\r\n"))
                {
                    string[] lines = eachLine.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        formatedStr += StylizeLine(line);
                    }
                }
                else
                {
                    formatedStr += StylizeLine(eachLine);
                }
                formatedStr += emptyLine;
            }
            StreamReader sr = new StreamReader(@"VANTemplateEmialFormat.html");
            string htmlToStr = sr.ReadToEnd();
            htmlToStr=htmlToStr.Replace("<p></p>",formatedStr);
            return htmlToStr;
        }
        public static string ConvertToHTMLFormatForIntertrade(string str,string link,string linkDetail)
        {
            string emptyLine = "<p class=\"MsoNormal\"><o:p>&nbsp;</o:p></p>";
            //string styleLine = "<style>p{ margin:0 auto;font-family:Calibri;color:black;font-size:11.0pt}</style>";
            string formatedStr = "";
            //string[] sArray = str.Split("\r\n\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] sArray = Regex.Split(str, "\r\n\r\n", RegexOptions.IgnoreCase);
            foreach (string eachLine in sArray)
            {
                if (eachLine.Contains("\r\n"))
                {
                    string[] lines = eachLine.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        formatedStr += StylizeLine(line);
                    }
                }
                else
                {
                    formatedStr += StylizeLine(eachLine);
                }
                formatedStr += emptyLine;
            }
            StreamReader sr = new StreamReader(@"VANTemplateEmialFormat.html");
            string htmlToStr = sr.ReadToEnd();
            htmlToStr = htmlToStr.Replace("<p></p>", formatedStr).Replace("<p class=\"MsoNormal\">" + link + "<o:p></o:p></p>","<p class=\"MsoNormal\"><a href=\""+linkDetail+"\">"+link+"</a></p>");
            return htmlToStr;
        }
        public static string ConvertToHTMLFormatForICC(string str, string link, string linkDetail)
        {
            string emptyLine = "<p class=\"MsoNormal\"><o:p>&nbsp;</o:p></p>";
            string formatedStr = "";
            string[] sArray = Regex.Split(str, "\r\n\r\n", RegexOptions.IgnoreCase);
            foreach (string eachLine in sArray)
            {
                if (eachLine.Contains("\r\n"))
                {
                    string[] lines = eachLine.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        formatedStr += StylizeLine(line);
                    }
                }
                else
                {
                    formatedStr += StylizeLine(eachLine);
                }
                formatedStr += emptyLine;
            }
            StreamReader sr = new StreamReader(@"VANTemplateEmialFormat.html");
            string htmlToStr = sr.ReadToEnd();
            htmlToStr = htmlToStr.Replace("<p></p>", formatedStr).Replace(link, "<a href=\"" + linkDetail + "\">" + link + "</a>");
            return htmlToStr;
        }
        public static string ConvertToHTMLFormatForCommport(string str, string link, string linkDetail)
        {
            string emptyLine = "<p class=\"MsoNormal\"><o:p>&nbsp;</o:p></p>";
            string formatedStr = "";
            string[] sArray = Regex.Split(str, "\r\n\r\n", RegexOptions.IgnoreCase);
            foreach (string eachLine in sArray)
            {
                if (eachLine.Contains("\r\n"))
                {
                    string[] lines = eachLine.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        formatedStr += StylizeLine(line);
                    }
                }
                else
                {
                    formatedStr += StylizeLine(eachLine);
                }
                formatedStr += emptyLine;
            }
            StreamReader sr = new StreamReader(@"VANTemplateEmialFormat.html");
            string htmlToStr = sr.ReadToEnd();
            htmlToStr = htmlToStr.Replace("<p></p>", formatedStr).Replace(link, "<a href=\"" + linkDetail + "\">" + link + "</a>");
            return htmlToStr;
        }
        public static string StylizeLine(string str)
        { 
            str = "<p class=\"MsoNormal\">"+str+"<o:p></o:p></p>";
            
            return str;
        }
        public static string GetUserFullName()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("MappingToolsVersionDetails.xml");
            XmlNode root = doc.SelectSingleNode("//UserName");
            string userName = root.InnerText;
            return userName;
        }
        public static string GetFirstUserName()
        {
            string userName = GetUserFullName();
            string firstUserName = "";
            if (userName.Contains("."))
                firstUserName = userName.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
            else if (userName.Contains(" "))
                firstUserName = userName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
            else
                firstUserName = userName;
            return firstUserName;
        }
    }

}
