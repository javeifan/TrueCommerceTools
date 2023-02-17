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
using System.Windows.Documents;

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
                string userName = TemplatesTransFuncs.GetUserFullName();
                if (userName.Contains("."))
                    userName = userName.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                else if (userName.Contains(" "))
                    userName = userName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                string mailtrailertext = config.MailTrailer;
                int n = mailtrailertext.Length;
                for (int i = n - 1; i >= 0; i--)
                {
                    if (mailtrailertext[i] == '\r' || mailtrailertext[i] == '\n')
                    {
                        config.MailTrailer = config.MailTrailer.Remove(i + 1, n - i - 1);
                        config.MailTrailer += userName;
                        break;
                    }
                }
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
            //if (UpdateUtilityForSpawnIssuesRecord.DownloadIssuesRecord())
            //{
            //    string issueRecord = "";
            //    issueRecord = ReadSpawnIssueCasesRecord(SpawnIssueCasesRecordPath).Trim();
            //    string[] sArrayIssueRecord = issueRecord.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            //    foreach (string eachIssueCase in sArrayIssueRecord)
            //    {
            //        cblIssuesRecord.Items.Add(eachIssueCase);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Network ERROR! Can not download Issues Record from server.");
            //}
        }
        private void ShowInOutLook_Click(object sender, EventArgs e)
        {
            string issueRecord = "";

            foreach (string issueCase in cblIssuesRecord.CheckedItems)
            {
                issueRecord += issueCase + "\r\n";
            }
            if (tbInputMailMsg.Text.Contains("[i") || tbInputMailMsg.Text.Contains("[I") || cblIssuesRecord.CheckedItems.Count > 0)
                tbSuggestSubjectName.Text = "Closed Cases( Issues included, pls read.) -" + DateTime.Now.ToString("yyyy.MM.dd");
            /*if (UpdateUtilityForSpawnIssuesRecord.DownloadIssuesRecord())
            {
                issueRecord = ReadSpawnIssueCasesRecord(SpawnIssueCasesRecordPath).Trim();
                if (tbInputMailMsg.Text.Contains("[i") || tbInputMailMsg.Text.Contains("[I"))
                    tbSuggestSubjectName.Text = "Closed Cases( Issues included, pls read.) -" + DateTime.Now.ToString("yyyy.MM.dd");

                if (issueRecord != null && issueRecord != "")
                {
                    DialogResult dr = MessageBox.Show("The system detected some unresolved issues in server. Do you need to add them to the email?", "Issues Record Found!", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        tbSuggestSubjectName.Text = "Closed Cases( Issues included, pls read.) -" + DateTime.Now.ToString("yyyy.MM.dd");
                    }
                    else if (dr == DialogResult.No)
                    {
                        issueRecord = "";
                    }
                }
            }*/
            issueRecord = issueRecord.Trim();

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

                #region preprocess text in tbInputMailMsg(daily cases)
                string processedValue = MessagePreprocess(issueRecord + "\r\n" + tbInputMailMsg.Text,"daily");
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
                #endregion

                #region preprocess text in tbInputQA 
                string processValueQA = MessagePreprocess(tbInputQA.Text,"QA");//gfan 23/02/17
                content += processValueQA;
                content += emptyLine;//gfan 23/02/17
                #endregion

                mailItem.HTMLBody = content;
                mailItem.Display();
                mailItem = null;
                olApp = null;
                tbSuggestSubjectName.Text = "Closed Cases - " + DateTime.Now.ToString("yyyy.MM.dd");

            }
            catch (Exception)
            {
                MessageBox.Show("Failed to find the required mailbox client!");//failed to find the required message in daily cases
            }
        }
        private static string StylizeLine(string str)
        {
            string stylizeLine = "<p class=\"MsoListParagraph\" style=\"margin-left:0in\"><span style=\"color:black\">" + str + "</span></p>";
            return stylizeLine;
        }
        private static string StylizeCaseLine(string str)
        {
            string stylizeCaseLine = "<p class=\"MsoListParagraph\" style=\"margin-left:45.0pt;text-indent:-.25in;mso-list:l0 level1 lfo2\"><!--[if !supportLists]--><span style=\"font-family:Symbol;mso-fareast-font-family:Symbol;mso-bidi-font-family:Symbol;color:black\"><span style=\"mso-list:Ignore\">·<span style=\"font:11.0pt &quot;Calibri&quot;\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><!--[endif]--><span style=\"color:black\">Case # " + str + "<o:p></o:p></span></p>";
            return stylizeCaseLine;
        }
        private static string StylizeDuplicateQALine(string str)//gfan 23/02/17 
        {
            //turn the case to red to show it's duplicate
            string stylizeCaseLine = "<p class=\"MsoListParagraph\" style=\"margin-left:45.0pt;text-indent:-.25in;mso-list:l0 level1 lfo2\"><span style=\"font-family:Symbol;mso-fareast-font-family:Symbol;mso-bidi-font-family:Symbol;color:red\"><span style=\"mso-list:Ignore\">·<span style=\"font:11.0pt &quot;Calibri&quot;\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><!--[endif]--><span style=\"color:black\">Case # " + str + "<o:p></o:p></span></p>";
            return stylizeCaseLine;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="messageType">"daily" or "QA"</param>
        /// <returns></returns>
        private static string MessagePreprocess(string inputValue, string messageType)
        {
            string finalOut = "";
            string dailyIssueRecord = "";
            string emptyLine = "<p><span style=\"color:black\"><o:p>&nbsp;</o:p></span></p>";
            if (inputValue.EndsWith("\r\n"))
                inputValue.Remove(inputValue.LastIndexOf("\r\n"), 1);
            if (messageType == "daily")//gfan process daily cases and QA separately
            {
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
                        if (eachCase.StartsWith("[") && eachCase.Contains("||") == false)
                        {
                            finalOut += StylizeCaseLine(RemovePrefix(eachCase).Trim());
                            dailyIssueRecord += eachCase.Trim() + "\r\n";
                        }
                        else if (eachCase.StartsWith("[") && eachCase.Contains("||") == true)
                        {
                            string _Issue = eachCase.Split("||".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                            string _Reason = eachCase.Split("||".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1];
                            finalOut += StylizeCaseLine(RemovePrefix(_Issue).Trim());
                            dailyIssueRecord += eachCase.Trim() + "\r\n";
                            finalOut += "<p class=\"MsoListParagraph\" style=\"margin-left:45.0pt\"><span style=\"color:red\">" + _Reason + "</span><span style=\"font-family:DengXian;color:red;mso-fareast-language:ZH-CN\"><o:p></o:p></span></p>";
                        }
                    }

                    ClearSpawnIssueCasesRecord("./SpawnDailyIssueCasesRecord.txt");
                    WriteSpawnIssueCasesRecord("./SpawnDailyIssueCasesRecord.txt", dailyIssueRecord.Trim());
                    //UpdateUtilityForSpawnIssuesRecord.UploadIssuesRecord(dailyIssueRecord.Trim());
                    ClearSpawnIssueCasesRecord("./SpawnDailyIssueCasesRecord.txt");

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
                    MessageBox.Show("Daily Cases Input Message Error!");
                }
            }
            else if (messageType == "QA")//gfan added QA process 23/02/17
            {
                try
                {
                    string[] QAArray = inputValue.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    int countLines = 0;//three categories of QA is split by "||"
                    finalOut += StylizeLine("QA failed:");
                    HashSet<string> caseSet = new HashSet<string>();
                    foreach (string eachLine in QAArray)
                    {
                        if (eachLine.StartsWith("||"))
                        {
                            countLines++;
                            if (countLines == 1)
                            {
                                finalOut += StylizeLine("QA In Testing");
                                finalOut += emptyLine;
                            }else if (countLines == 2)
                            {
                                finalOut += StylizeLine("QA Not Started:");
                                finalOut += emptyLine;
                            }
                        }
                        else
                        {
                            Regex regNum = new Regex("^[0-9]*");
                            string caseID = regNum.Match(eachLine).Value;
                            if (!caseSet.Contains(caseID))
                            {
                                finalOut += StylizeDuplicateQALine(eachLine);
                            }
                            else
                            {
                                caseSet.Add(caseID);
                                finalOut += StylizeCaseLine(eachLine);
                            }
                        }
                    }
                }
                catch { MessageBox.Show("QA Input Message Error"); }

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

        private void IssueRecordSelectAll_CheckChanged(object sender, EventArgs e)
        {
            if (cbIssueRecordSelectAll.CheckState == CheckState.Checked)
            {
                for (int i = 0; i < cblIssuesRecord.Items.Count; i++)
                {
                    cblIssuesRecord.SetItemCheckState(i, CheckState.Checked);

                }
            }
            else
            {
                for (int i = 0; i < cblIssuesRecord.Items.Count; i++)
                {
                    cblIssuesRecord.SetItemCheckState(i, CheckState.Unchecked);

                }
            }
        }

        private void SpawnDailyEmailHelper_Closing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists("SpawnDailyIssueCasesRecord.txt"))
                File.Delete("SpawnDailyIssueCasesRecord.txt");
        }

        private void SpawnSendToContacts_Click(object sender, EventArgs e)
        {
            WTXDailyEmailHelper.SendToOrCCTo = "SPSENDTO";
            EmailAddressSelections form_EmailAddressSelections = new EmailAddressSelections();
            form_EmailAddressSelections.ShowDialog();
        }

        private void SpawnCcToContacts_Click(object sender, EventArgs e)
        {
            WTXDailyEmailHelper.SendToOrCCTo = "SPCCTO";
            EmailAddressSelections form_EmailAddressSelections = new EmailAddressSelections();
            form_EmailAddressSelections.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}