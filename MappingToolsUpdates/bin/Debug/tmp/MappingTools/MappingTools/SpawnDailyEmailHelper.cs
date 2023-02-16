using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace MappingTools
{
    public partial class SpawnDailyEmailHelper : Form
    {
        public static string SendToOrCCTo = "";
        public string SpawnIssueCasesRecordPath = "./SpawnDailyIssueCasesRecord.txt";
        public static SpawnDailyEmailHelper spawndailyEmailForm;
        public SpawnDailyEmailHelper()
        {
            spawndailyEmailForm = this;
            InitializeComponent();
            tbSuggestSubjectName.Text = "Closed Cases - " + DateTime.Now.ToString("yyyy.MM.dd");

            MyConfig config = new MyConfig();
            config = new MyConfig();
            if (File.Exists(@"jsonconfig/MappingTools.SpawnDailyEmailHelper+MyConfig.json"))
            {
                config = ConfigHandler<MyConfig>.Load();
                tbSayHi.Text = config.SayHiTo;
                tbMailSendTo.Text = config.MailSendTo;
                tbMailCCTo.Text = config.MailCCTo;
                tbMailTrailer.Text = config.MailTrailer;
            }
            else
            {
                config.SayHiTo = "";
                config.MailTrailer = "";
                config.MailSendTo = "";
                config.MailCCTo = "";
                tbSayHi.Text = "";
                tbMailSendTo.Text = "";
                tbMailCCTo.Text = "";
                tbMailTrailer.Text = "";
                ConfigHandler<MyConfig>.Save(config);
            }
        }
        private void ShowInOutLook_Click(object sender, EventArgs e)
        {
            string issueRecord = ReadSpawnIssueCasesRecord(SpawnIssueCasesRecordPath).Trim();
            if (tbInputMailMsg.Text.Contains("[i") || tbInputMailMsg.Text.Contains("[I"))
                tbSuggestSubjectName.Text = "Closed Cases( Issues included, pls read.) -" + DateTime.Now.ToString("yyyy.MM.dd");
            if (issueRecord != null && issueRecord != "")
            {
                DialogResult dr = MessageBox.Show("The system detected some unresolved issues. Do you need to add them to the email?", "Issues Record Found!", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    tbSuggestSubjectName.Text = "Closed Cases( Issues included, pls read.) -" + DateTime.Now.ToString("yyyy.MM.dd");
                }
                else if (dr == DialogResult.No)
                {
                    issueRecord = "";
                }
            }
            //string emptyLine = "<p class=\"MsoListParagraph\" style=\"margin-left:45.0pt\"><span style=\"color:#1F497D\"><o:p>&nbsp;</o:p></span></p>";
            string emptyLine = "<p><span style=\"color:black\"><o:p>&nbsp;</o:p></span></p>";
            try
            {
                Outlook.Application olApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)olApp.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.To = tbMailSendTo.Text;
                mailItem.CC = tbMailCCTo.Text;
                mailItem.Subject = tbSuggestSubjectName.Text;
                mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
                string content = "<style>p{ margin:0 auto;font-family:\"Calibri\",sans-serif;font-size:11.0pt;color:black}</style>";
                content += StylizeLine("Hi " + tbSayHi.Text + ",");
                content += emptyLine;
                string processedValue = MessagePreprocess(issueRecord+"\r\n"+tbInputMailMsg.Text);
                content += processedValue;
                content += emptyLine;
                string[] msgTrailerArray = Regex.Split(tbMailTrailer.Text, "\r\n", RegexOptions.IgnoreCase);
                foreach (string eachTrailerLine in msgTrailerArray)
                {
                    if (eachTrailerLine == "" | eachTrailerLine == null)
                        content += emptyLine;
                    else
                        content += StylizeLine(eachTrailerLine);
                }

                mailItem.HTMLBody = content;
                mailItem.Display();
                mailItem = null;
                olApp = null;
                tbSuggestSubjectName.Text = "Closed Cases - " + DateTime.Now.ToString("yyyy.MM.dd");
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to find the required mailbox client!");
            }
        }
        private static string StylizeLine(string str)
        { 
            string stylizeLine = "<p class=\"MsoListParagraph\" style=\"margin-left:0in\"><span style=\"color:black\">"+str+"</span></p>";
            return stylizeLine;
        }
        private static string StylizeCaseLine(string str)
        {
            string stylizeCaseLine = "<p class=\"MsoListParagraph\" style=\"margin-left:45.0pt;text-indent:-.25in;mso-list:l0 level1 lfo2\"><!--[if !supportLists]--><span style=\"font-family:Symbol;mso-fareast-font-family:Symbol;mso-bidi-font-family:Symbol;color:black\"><span style=\"mso-list:Ignore\">·<span style=\"font:11.0pt &quot;Calibri&quot;\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><!--[endif]--><span style=\"color:black\">Case # " + str + "<o:p></o:p></span></p>";
            return stylizeCaseLine;
        }
        private static string MessagePreprocess(string inputValue)
        {
            string finalOut = "";
            string dailyIssueRecord = "";
            string emptyLine = "<p><span style=\"color:black\"><o:p>&nbsp;</o:p></span></p>";
            if (inputValue.EndsWith("\r\n"))
                inputValue.Remove(inputValue.LastIndexOf("\r\n"), 1);
            try
            {
                //string[] casesArray = Regex.Split(inputValue,"\r\n", RegexOptions.IgnoreCase);
                string[] casesArray = inputValue.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < casesArray.Length; i++)
                {
                    if (casesArray[i].StartsWith("["))
                    {
                        finalOut += StylizeLine("Issue:");
                        break;
                    }

                }
                foreach (string eachCase in casesArray)
                {
                    if (eachCase.StartsWith("[")&&eachCase.Contains("||")==false)
                    {
                        finalOut += StylizeCaseLine(RemovePrefix(eachCase).Trim());
                        dailyIssueRecord += eachCase.Trim()+"\r\n";
                    }
                    else if (eachCase.StartsWith("[") && eachCase.Contains("||") == true)
                    {
                        string _Issue = eachCase.Split("||".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                        string _Reason = eachCase.Split("||".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1];
                        finalOut += StylizeCaseLine(RemovePrefix(_Issue).Trim());
                        dailyIssueRecord += eachCase.Trim() + "\r\n";
                        finalOut += "<p class=\"MsoListParagraph\" style=\"margin-left:45.0pt\"><span style=\"color:red\">"+_Reason+"</span><span style=\"font-family:DengXian;color:red;mso-fareast-language:ZH-CN\"><o:p></o:p></span></p>";
                    }
                }

                    ClearSpawnIssueCasesRecord("./SpawnDailyIssueCasesRecord.txt");
                WriteSpawnIssueCasesRecord("./SpawnDailyIssueCasesRecord.txt", dailyIssueRecord.Trim()); ;


                for (int i = 0; i < casesArray.Length; i++)
                {
                    if (casesArray[i].StartsWith("["))
                    {
                        finalOut += emptyLine;
                        break;
                    }

                }
                for (int i = 0; i < casesArray.Length; i++)
                {
                    if (IfStartsWithNum(casesArray[i].Substring(0, 9)))
                    {
                        //finalOut += emptyLine;
                        finalOut += StylizeLine("Deployment succeeded/Cases closed:");
                        break;
                    }

                }
                foreach (string eachCase in casesArray)
                {
                    if (IfStartsWithNum(eachCase.Substring(0, 9)))
                        finalOut += StylizeCaseLine(eachCase.Trim());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Input Message Error!");
            }

            return finalOut;
        }
        /// <summary>
        /// 移除new case前方括号以及其中内容
        /// </summary>
        /// <param name="caseWithPrefix"></param>
        /// <returns></returns>
        private static string RemovePrefix(string caseWithPrefix)
        {
            int fp = caseWithPrefix.IndexOf("]");
            string output = caseWithPrefix.Substring(fp + 1, caseWithPrefix.Length - fp - 1);
            return output;
        }
        /// <summary>
        /// 移除字符串末尾的换行符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string RemoveTerminator(string str)
        {
            if (str.EndsWith("\r\n"))
                str = str.Remove(str.LastIndexOf("\r\n"), 1);
            return str;
        }
        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool IfStartsWithNum(string str)
        {
            Regex regChina = new Regex("^[^\x00-\xFF]");
            Regex regNum = new Regex("^[0-9]");
            Regex regChar = new Regex("^[a-z]");
            Regex regDChar = new Regex("^[A-Z]");
            if (regNum.IsMatch(str))
            {
                return true;
            }
            else
                return false;
        }
        public class ConfigHandler<T>
            where T : class
        {
            const string SAVE_PATH = "jsonconfig/";
            static T config;
            private ConfigHandler()
            {

            }
            private static string GetSavePath()
            {
                if (!Directory.Exists(SAVE_PATH))
                {
                    Directory.CreateDirectory(SAVE_PATH);
                }
                return $"{SAVE_PATH}{typeof(T).ToString()}.json";
            }
            public static void Save(T _config)
            {
                config = _config;
                string json = JsonConvert.SerializeObject(_config);
                try
                {
                    using (var sw = new StreamWriter(GetSavePath()))
                    {
                        sw.WriteAsync(json);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            public static T Load()
            {
                if (config == null)
                {
                    string json = "";
                    try
                    {
                        using (var sr = new StreamReader(GetSavePath()))
                        {
                            json = sr.ReadToEnd();
                            if (json != "")
                            {
                                config = JsonConvert.DeserializeObject<T>(json);
                            }
                            else
                            {
                                config = null;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        config = null;
                    }
                }
                return config;
            }

        }
        class MyConfig
        {
            public string SayHiTo { get; set; }
            public string MailTrailer { get; set; }
            public string MailSendTo { get; set; }
            public string MailCCTo { get; set; }
            public override string ToString()
            {
                return $"SayHiTo={SayHiTo},MailTrailer={MailTrailer},MailSendTo={MailSendTo},MailCCTo={MailCCTo}";
            }
        }
        private void SayHi_TextChanged(object sender, EventArgs e)
        {
            MyConfig config = new MyConfig();
            config = new MyConfig();
            config = ConfigHandler<MyConfig>.Load();
            config.SayHiTo = tbSayHi.Text;
            ConfigHandler<MyConfig>.Save(config);
        }
        private void tbMailSendTo_TextChanged(object sender, EventArgs e)
        {
            MyConfig config = new MyConfig();
            config = new MyConfig();
            config = ConfigHandler<MyConfig>.Load();
            config.MailSendTo = tbMailSendTo.Text;
            ConfigHandler<MyConfig>.Save(config);
        }

        private void tbMailCCTo_TextChanged(object sender, EventArgs e)
        {
            MyConfig config = new MyConfig();
            config = new MyConfig();
            config = ConfigHandler<MyConfig>.Load();
            config.MailCCTo = tbMailCCTo.Text;
            ConfigHandler<MyConfig>.Save(config);
        }
        private void tbMailTrailer_TextChanged(object sender, EventArgs e)
        {
            MyConfig config = new MyConfig();
            config = new MyConfig();
            config = ConfigHandler<MyConfig>.Load();
            config.MailTrailer = tbMailTrailer.Text;
            ConfigHandler<MyConfig>.Save(config);
        }
        private void btSpawnEmialHelperCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SpawnSendToContects_Click(object sender, EventArgs e)
        {
            WTXDailyEmailHelper.SendToOrCCTo = "SPSENDTO";
            EmailAddressSelections form_EmailAddressSelections = new EmailAddressSelections();
            form_EmailAddressSelections.ShowDialog();
        }

        private void SpawnCcToContects_Click(object sender, EventArgs e)
        {
            WTXDailyEmailHelper.SendToOrCCTo = "SPCCTO";
            EmailAddressSelections form_EmailAddressSelections = new EmailAddressSelections();
            form_EmailAddressSelections.ShowDialog();
        }
        public static void EmailAddressSelectionsClosed(string sendToStr, string ccToStr)
        {
            MyConfig config = new MyConfig();
            config = ConfigHandler<MyConfig>.Load();
            if (sendToStr != "")
            {
                config.MailSendTo = sendToStr;
                SpawnDailyEmailHelper.spawndailyEmailForm.tbMailSendTo.Text = sendToStr;
            }
            else if (ccToStr != "")
            {
                config.MailCCTo = ccToStr.Trim();
                SpawnDailyEmailHelper.spawndailyEmailForm.tbMailCCTo.Text = ccToStr;
            }
        }
        public static string ReadSpawnIssueCasesRecord(string path)
        {
            StreamReader fs = new StreamReader(path, Encoding.Default);
            string fullRecord = fs.ReadToEnd();
            fs.Close();
            return fullRecord;
        }
        public static void ClearSpawnIssueCasesRecord(string path)
        {
            File.Delete(path);
        }
        public static void WriteSpawnIssueCasesRecord(string path, string issues)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            byte[] data = System.Text.Encoding.Default.GetBytes(issues);
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }
    }
}