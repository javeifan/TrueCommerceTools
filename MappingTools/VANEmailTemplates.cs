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
using System.Xml;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;
using System.Threading;

namespace MappingTools
{
    public partial class VANEmailTemplates : Form
    {

        public string templatesPath = "Templates/";
        public string OtherTypeWithSuggestionsPath = "Templates/OtherTypeWithSuggestions.xml";
        public static string consultantName = "";
        public static string EmailProjectLink = "";
        public static string EmailProjectLinkDetails = "";
        public static VANEmailTemplates vanEmailTemplates;
        public static string sortedCustIDs = "";
        public static string sortedSuppIDs = "";
        public static bool is832 = false;

        public VANEmailTemplates()
        {
            vanEmailTemplates = this;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true);
            vanEmailTemplates = this;
            InitializeComponent();
            vanEmailTemplates.cboxCustPrimaryID.SelectedItem = "No Primary EDI ID";
            vanEmailTemplates.cboxSuppPrimaryID.SelectedItem = "No Primary EDI ID";

            //Load TemplateType in lbTemplatesType
            DirectoryInfo folder = new DirectoryInfo(templatesPath);
            foreach (FileInfo file in folder.GetFiles("*.xml"))
            {
                if (file.Name != "OtherTypeWithSuggestions.xml")
                    lbTemplatesType.Items.Add(file.Name.Remove(file.Name.LastIndexOf(".")));
            }
            LoadOtherTypes(OtherTypeWithSuggestionsPath);
        }

        private void TemplatesSelectedTypeChanged(object sender, EventArgs e)
        {
            try
            {

                RefreshGenerateTemplateText(lbTemplatesType.SelectedItem.ToString());
                lbOtherSuggestions.SelectedItem = null;
            }
            catch
            {
            }
        }
        private void OtherSuggestionsChanged(object sender, EventArgs e)
        {
            try
            {

                RefreshSuggestionForOtherType(lbOtherSuggestions.SelectedItem.ToString());
                lbTemplatesType.SelectedItem = null;
            }
            catch
            {
            }
        }
        private static void RefreshSuggestionForOtherType(string otherSuggestionType)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(vanEmailTemplates.OtherTypeWithSuggestionsPath);
                XmlNode root = doc.SelectSingleNode("//Type");
                foreach (XmlNode eachType in root.ChildNodes)
                {
                    if (otherSuggestionType == eachType.Attributes["TypeName"].Value.Replace("---", "<->"))
                        vanEmailTemplates.tbTemplateSuggestion.Text = eachType.InnerText.Replace("[$:USER_NAME]", TemplatesTransFuncs.GetFirstUserName()).Replace("[$:DATETIME]", DateTime.Now.ToString("MM/dd/yyyy"));
                }
                vanEmailTemplates.tbGenerateTemplate.Clear();
            }
            catch
            {

            }
        }
        /// <summary>
        /// trigger when a template is clicked
        /// </summary>
        /// <param name="templateType"></param>
        private static void RefreshGenerateTemplateText(string templateType)
        {
            try
            {
                #region load xml
                string generateText = "";
                string templatePath = @"./Templates/" + templateType + ".xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(templatePath);
                #endregion
                #region parse xml Non-global part
                XmlNode root = doc.SelectSingleNode("//Header");
                if (templateType == "B2B Gateway")
                {
                    generateText += "Email: " + (root.SelectSingleNode("Email")).InnerText;
                    generateText += "\r\n";
                    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                    generateText += "\r\n";
                    generateText += "\r\n";
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);
                    if (IfMultipleIDs(sortedCustIDs))
                        generateText = generateText.Replace("Please add customer’s ID", "Please add customer’s IDs");
                    vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER]/[$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline));
                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                else if (templateType == "E Com")
                {
                    generateText += "Email: " + (root.SelectSingleNode("Email")).InnerText;
                    generateText += "\r\n";
                    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                    generateText += "\r\n";
                    generateText += "\r\n";
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);
                    if (IfMultipleIDs(sortedCustIDs))
                        generateText = generateText.Replace("customer’s ID", "customer’s IDs").Replace("(AS2 name)", "(AS2 names)").Replace("ID ", "IDs ").Replace("AS2 name ", "AS2 names ");
                    vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_EDI_ID][$:CUSTOMER_QUALIFIER]", TemplatesTransFuncs.QualIDToIDQual(sortedCustIDs)).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER]/ [$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline));
                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                else if (templateType == "Easylink")
                {
                    consultantName = "";
                    //Gfan 2023/2/9
                    VANConsultantDetails _formVANIntertradeDetails = new VANConsultantDetails();
                    _formVANIntertradeDetails.ShowDialog();
                    //Gfan 2023/2/9
                    string consultantFirstName = "";
                    try
                    {
                        consultantFirstName = consultantName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                    }
                    catch
                    {
                        consultantFirstName = "";
                    }
                    //using the user name in <MappingToolsVersionDetails.xml>
                    string userName = TemplatesTransFuncs.GetUserFullName();
                    if (userName.Contains("."))
                        userName = userName.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                    else if (userName.Contains(" "))
                        userName = userName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];

                    generateText += "Email: " + (root.SelectSingleNode("Email")).InnerText;
                    generateText += "\r\n";
                    generateText += "CC: " + consultantName;
                    generateText += "\r\n";
                    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                    generateText += "\r\n";
                    generateText += "\r\n";
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    if (IfMultipleIDs(sortedCustIDs))
                        generateText = generateText.Replace("[$:CUSTOMER_NAME] (EDI ID:", "[$:CUSTOMER_NAME] (EDI IDs:");
                    if (IfMultipleIDs(sortedSuppIDs))
                        generateText = generateText.Replace("[$:PARTNER_NAME] (EDI ID:", "[$:PARTNER_NAME] (EDI IDs:");
                    vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("Qual=[$:CUSTOMER_QUALIFIER] ID=[$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIIDWithPrefix(sortedCustIDs)).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:PARTNER_NAME]", vanEmailTemplates.tbSuppInfoName.Text).Replace("Qual=[$:PARTNER_QUALIFIER] ID=[$:PARTNER_EDI_ID]", TemplatesTransFuncs.ProcessEDIIDWithPrefix(sortedSuppIDs));
                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                else if (templateType == "GXSNewSetup")
                {
                    generateText += "Email: " + (root.SelectSingleNode("Email")).InnerText;
                    generateText += "\r\n";
                    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                    generateText += "\r\n";
                    generateText += "\r\n";
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    string mailbox = (root.SelectSingleNode("MAILBOX")).InnerText;
                    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);
                    if (IfMultipleIDs(sortedCustIDs))
                        generateText = generateText.Replace("the following EDI ID", "the following EDI IDs").Replace("ID Needing Defined", "IDs Needing Defined");
                    vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:MAILBOX]", mailbox).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER]/[$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline));
                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                else if (templateType == "GXSPartnerRelationship")
                {
                    generateText += "Email: " + (root.SelectSingleNode("Email")).InnerText;
                    generateText += "\r\n";
                    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                    generateText += "\r\n";
                    generateText += "\r\n";
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    string mailbox = (root.SelectSingleNode("MAILBOX")).InnerText;
                    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);
                    if (IfMultipleIDs(sortedCustIDs))
                        generateText = generateText.Replace("TrueCommerce ID:", "TrueCommerce IDs:");
                    if (IfMultipleIDs(sortedSuppIDs))
                        generateText = generateText.Replace("Partner ID:", "Partner IDs:");
                    if (vanEmailTemplates.tbSuppInfoName.Text.Trim() == "Home Depot")
                    {
                        string extraIDs = "Home Depot (Non-Merchandise) 14/072271711USAP\r\n14 / 072271711USQA\r\n14 / 072271711CAOLD\r\n14 / 072271711USSO\r\n14 / 072271711USAC\r\n\r\n";
                        vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:MAILBOX]", mailbox).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER]/[$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline)).Replace("[$:PARTNER_NAME]", vanEmailTemplates.tbSuppInfoName.Text).Replace("[$:PARTNER_QUALIFIER]/[$:PARTNER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedSuppIDs, ifmultiline)).Replace("[$:IF_HOME_DEPOT]", extraIDs);
                    }
                    else
                    {
                        vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:MAILBOX]", mailbox).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER]/[$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline)).Replace("[$:PARTNER_NAME]", vanEmailTemplates.tbSuppInfoName.Text).Replace("[$:PARTNER_QUALIFIER]/[$:PARTNER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedSuppIDs, ifmultiline)).Replace("[$:IF_HOME_DEPOT]", "");
                    }
                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                else if (templateType == "HP MHT")
                {
                    generateText += "Email: " + (root.SelectSingleNode("Email")).InnerText;
                    generateText += "\r\n";
                    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                    generateText += "\r\n";
                    generateText += "\r\n";
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);
                    vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER]/ [$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline)).Replace("[$:PARTNER_NAME]", vanEmailTemplates.tbSuppInfoName.Text).Replace("[$:PARTNER_QUALIFIER]/ [$:PARTNER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedSuppIDs, ifmultiline));
                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                else if (templateType == "ICC")
                {
                    //Gfan 2023/2/9
                    VANConsultantDetails _formVANIntertradeDetails = new VANConsultantDetails();
                    _formVANIntertradeDetails.ShowDialog();
                    //Gfan 2023/2/9
                    generateText += "Email: " + (root.SelectSingleNode("Email")).InnerText;
                    generateText += "\r\n";
                    generateText += "CC: " + consultantName;//Gfan updated 2023/2/9
                    generateText += "\r\n";
                    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                    generateText += "\r\n";
                    generateText += "\r\n";
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    string pushName = (root.SelectSingleNode("PushName")).InnerText;
                    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);
                    if (IfMultipleIDs(sortedCustIDs))
                        generateText = generateText.Replace("[$:CUSTOMER_NAME] (EDI ID:", "[$:CUSTOMER_NAME] (EDI IDs:");
                    if (IfMultipleIDs(sortedSuppIDs))
                        generateText = generateText.Replace("[$:PARTNER_NAME] (EDI ID:", "[$:PARTNER_NAME] (EDI IDs:");
                    vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("Qual=[$:CUSTOMER_QUALIFIER] ID=[$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIIDWithPrefix(sortedCustIDs)).Replace("[$:PARTNER_NAME]", vanEmailTemplates.tbSuppInfoName.Text).Replace("Qual=[$:PARTNER_QUALIFIER] ID=[$:PARTNER_EDI_ID]", TemplatesTransFuncs.ProcessEDIIDWithPrefix(sortedSuppIDs)).Replace("[$:PUSH_NAME]", pushName);
                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                //else if (templateType == "ICC")
                //{
                //    consultantName = "";
                //    EmailProjectLink = "";
                //    EmailProjectLinkDetails = "";
                //    VANConsultantDetails.templateType = "ICC";
                //    VANConsultantDetails _formVANIntertradeDetails = new VANConsultantDetails();
                //    _formVANIntertradeDetails.ShowDialog();
                //    string consultantFirstName = "";
                //    try
                //    {
                //        consultantFirstName = consultantName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                //    }
                //    catch
                //    {
                //        consultantFirstName = "";
                //    }
                //    //using the user name in <MappingToolsVersionDetails.xml>
                //    string userName = TemplatesTransFuncs.GetUserFullName();
                //    if (userName.Contains("."))
                //        userName = userName.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                //    else if (userName.Contains(" "))
                //        userName = userName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                //    generateText += "Email: " + consultantName;
                //    generateText += "\r\n";
                //    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                //    generateText += "\r\n";
                //    generateText += "\r\n";
                //    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                //    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);
                //    if (EmailProjectLink != "" && EmailProjectLinkDetails != "")
                //        vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER] / [$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline)).Replace("[$:PARTNER_NAME]", vanEmailTemplates.tbSuppInfoName.Text).Replace("[$:PARTNER_QUALIFIER]/[$:PARTNER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedSuppIDs, ifmultiline)).Replace("[$:CONSULTANT_NAME]", consultantFirstName).Replace("[$:USER_NAME]", userName).Replace("Project: [$:PROJECT_LINK]\r\n\r\n", "Project: " + EmailProjectLink+"\r\n\r\n").Replace("---", "<->");
                //    else
                //        vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER] / [$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline)).Replace("[$:PARTNER_NAME]", vanEmailTemplates.tbSuppInfoName.Text).Replace("[$:PARTNER_QUALIFIER]/[$:PARTNER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedSuppIDs, ifmultiline)).Replace("[$:CONSULTANT_NAME]", consultantFirstName).Replace("[$:USER_NAME]", userName).Replace("Project: [$:PROJECT_LINK]\r\n\r\n", "").Replace("---", "<->");
                //    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                //}
                else if (templateType == "Commport")
                {
                    consultantName = "";
                    EmailProjectLink = "";
                    EmailProjectLinkDetails = "";
                    VANConsultantDetails.templateType = "Commport";
                    VANConsultantDetails _formVANIntertradeDetails = new VANConsultantDetails();
                    _formVANIntertradeDetails.ShowDialog();
                    string consultantFirstName = "";
                    try
                    {
                        consultantFirstName = consultantName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                    }
                    catch
                    {
                        consultantFirstName = "";
                    }
                    //using the user name in <MappingToolsVersionDetails.xml>
                    string userName = TemplatesTransFuncs.GetUserFullName();
                    if (userName.Contains("."))
                        userName = userName.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                    else if (userName.Contains(" "))
                        userName = userName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                    /*MyConfig config = new MyConfig();
                    config = ConfigHandler<MyConfig>.Load();
                    string userName = config.UserName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];*/
                    //string userName = Properties.Settings.Default.UserName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                    generateText += "Email: " + consultantName;
                    generateText += "\r\n";
                    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                    generateText += "\r\n";
                    generateText += "\r\n";
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);
                    if (EmailProjectLink != "" && EmailProjectLinkDetails != "")
                        vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER] / [$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline)).Replace("[$:PARTNER_NAME]", vanEmailTemplates.tbSuppInfoName.Text).Replace("[$:PARTNER_QUALIFIER]/[$:PARTNER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedSuppIDs, ifmultiline)).Replace("[$:CONSULTANT_NAME]", consultantFirstName).Replace("[$:USER_NAME]", userName).Replace("Project link:\r\n[$:PROJECT_LINK]", "Project link:\r\n" + EmailProjectLink);
                    else
                        vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER] / [$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline)).Replace("[$:PARTNER_NAME]", vanEmailTemplates.tbSuppInfoName.Text).Replace("[$:PARTNER_QUALIFIER]/[$:PARTNER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedSuppIDs, ifmultiline)).Replace("[$:CONSULTANT_NAME]", consultantFirstName).Replace("[$:USER_NAME]", userName).Replace("Project link:\r\n[$:PROJECT_LINK]\r\n\r\n", "");
                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                else if (templateType == "IConnect")
                {
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText);
                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                else if (templateType == "Inovis")
                {
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    string psn = (root.SelectSingleNode("PSN")).InnerText;
                    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);
                    if (IfMultipleIDs(sortedCustIDs))
                        generateText = generateText.Replace("Subject: Assign EDI ID", "Subject: Assign EDI IDs").Replace("Description: Please confirm this ID", "Description: Please confirm IDs").Replace("belongs to PSN:", "belong to PSN:");
                    vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_QUALIFIER]/[$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline)).Replace("[$:PSN]", psn);
                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                else if (templateType == "Intertrade")
                {
                    string template832fix = "";
                    consultantName = "";
                    EmailProjectLink = "";
                    EmailProjectLinkDetails = "";
                    IntertradeSelection.templateType = "Intertrade";
                    IntertradeSelection _formIntertradeSelection = new IntertradeSelection();
                    _formIntertradeSelection.ShowDialog();

                    if (is832)
                    {
                        template832fix = "832/Template";
                        root = doc.SelectSingleNode("//Template832/Header");
                    }
                    string consultantFirstName = "";
                    try
                    {
                        consultantFirstName = consultantName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                    }
                    catch
                    {
                        consultantFirstName = "";
                    }
                    //using the user name in <MappingToolsVersionDetails.xml>
                    string userName = TemplatesTransFuncs.GetUserFullName();
                    if (userName.Contains("."))
                        userName = userName.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                    else if (userName.Contains(" "))
                        userName = userName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                    /*MyConfig config = new MyConfig();
                    config = ConfigHandler<MyConfig>.Load();
                    string userName = config.UserName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];*/
                    //string userName = Properties.Settings.Default.UserName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                    generateText += "Email: " + (root.SelectSingleNode("Email")).InnerText;
                    generateText += "\r\n";
                    generateText += "CC: " + consultantName;
                    generateText += "\r\n";
                    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                    generateText += "\r\n";
                    generateText += "\r\n";
                    generateText += (doc.SelectSingleNode("//Template" + template832fix)).InnerText;
                    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);

                    vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER] / [$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline)).Replace("[$:PARTNER_NAME]", vanEmailTemplates.tbSuppInfoName.Text).Replace("[$:PARTNER_QUALIFIER]/[$:PARTNER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedSuppIDs, ifmultiline)).Replace("[$:CONSULTANT_NAME]", consultantFirstName).Replace("[$:USER_NAME]", userName).Replace("Project link:\r\n[$:PROJECT_LINK]\r\n\r\n", "");
                    
                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                else if (templateType == "Kleinschmidt")
                {
                    generateText += "Email: " + (root.SelectSingleNode("Email")).InnerText;
                    generateText += "\r\n";
                    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                    generateText += "\r\n";
                    generateText += "\r\n";
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);
                    if (IfMultipleIDs(sortedCustIDs))
                        generateText = generateText.Replace("Please add customer’s ID", "Please add customer’s IDs");
                    vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER]/[$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline));
                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                else if (templateType == "Loren")
                {
                    generateText += "Email: " + (root.SelectSingleNode("Email")).InnerText;
                    generateText += "\r\n";
                    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                    generateText += "\r\n";
                    generateText += "\r\n";
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);
                    if (IfMultipleIDs(sortedCustIDs))
                        generateText = generateText.Replace("Please add customer’s ID", "Please add customer’s IDs");
                    vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("Qualifer [$:CUSTOMER_QUALIFIER] ID [$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIIDWithPrefixNoEqualSign(sortedCustIDs));
                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                else if (templateType == "NuBridges")
                {
                    generateText += "Email: " + (root.SelectSingleNode("Email")).InnerText;
                    generateText += "\r\n";
                    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                    generateText += "\r\n";
                    generateText += "\r\n";
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);
                    if (IfMultipleIDs(sortedCustIDs))
                        generateText = generateText.Replace("Please verify that ID", "Please verify that IDs").Replace("is added to TrueCommerce AS2 interconnect for", "are added to TrueCommerce AS2 interconnect for");
                    vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER]/[$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline));
                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                else if (templateType == "SoftShare")
                {
                    generateText += "Email: " + (root.SelectSingleNode("Email")).InnerText;
                    generateText += "\r\n";
                    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                    generateText += "\r\n";
                    generateText += "\r\n";
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);
                    if (IfMultipleIDs(sortedCustIDs))
                        generateText = generateText.Replace("Please add the new customer [$:CUSTOMER_NAME] ID", "Please add the new customer [$:CUSTOMER_NAME] IDs");
                    vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER]/ [$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline));
                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                else if(templateType == "CovalentWorks")
                {
                    generateText += "Email: " + (root.SelectSingleNode("Email")).InnerText;
                    generateText += "\r\n";
                    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                    generateText += "\r\n";
                    generateText += "\r\n";
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);
                    if (IfMultipleIDs(sortedCustIDs))
                        generateText = generateText.Replace("Please add the new customer [$:CUSTOMER_NAME] ID", "Please add the new customer [$:CUSTOMER_NAME] IDs");

                    vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER]/[$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline)).Replace("[$:PARTNER_NAME]", vanEmailTemplates.tbSuppInfoName.Text).Replace("[$:PARTNER_QUALIFIER]/[$:PARTNER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedSuppIDs, ifmultiline));

                    vanEmailTemplates.tbTemplateSuggestion.Text = (root.SelectSingleNode("Suggestion")).InnerText;
                }
                #endregion
                #region global change for all template
                string userName1 = TemplatesTransFuncs.GetUserFullName();// GFan  2023/02/06
                DateTime today = DateTime.Today;
                string date = today.Year+"/"+today.Month+"/"+today.Day;
                vanEmailTemplates.tbGenerateTemplate.Text = vanEmailTemplates.tbGenerateTemplate.Text.Replace("[$:USER_NAME]",userName1 );
                vanEmailTemplates.tbTemplateSuggestion.Text = vanEmailTemplates.tbTemplateSuggestion.Text.Replace("[$:USER_NAME]", userName1);
                vanEmailTemplates.tbGenerateTemplate.Text = vanEmailTemplates.tbGenerateTemplate.Text.Replace("[$:TODAY]", date);
                vanEmailTemplates.tbTemplateSuggestion.Text = vanEmailTemplates.tbTemplateSuggestion.Text.Replace("[$:TODAY]", date);// GFan  2023/02/06
                #endregion
            }
            catch
            {
                MessageBox.Show("Somthing wrong with /Templates/" + templateType + ".xml, pls check.");
            }
        }

        private void VANTemplateClearAll_Click(object sender, EventArgs e)
        {
            vanEmailTemplates.tbCustInfoName.Clear();
            vanEmailTemplates.tbCustInfoID.Clear();
            vanEmailTemplates.tbSuppInfoName.Clear();
            vanEmailTemplates.tbSuppInfoID.Clear();
            vanEmailTemplates.tbGenerateTemplate.Clear();
            vanEmailTemplates.tbTemplateSuggestion.Clear();
        }

        private void VanTemplateShowInOutlook_Click(object sender, EventArgs e)
        {
            if (vanEmailTemplates.tbGenerateTemplate.Text != null && vanEmailTemplates.tbGenerateTemplate.Text != "" && vanEmailTemplates.tbGenerateTemplate.Text.StartsWith("Email"))
            {
                //vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.RemoveEmailAndSubject(vanEmailTemplates.tbGenerateTemplate.Text);
                string templateType = lbTemplatesType.SelectedItem.ToString();
                string templatePath = @"./Templates/" + templateType + ".xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(templatePath);
                if (templateType == "Intertrade")
                {
                    XmlNode root = doc.SelectSingleNode("//Header");
                    string email = (root.SelectSingleNode("Email")).InnerText;
                    string ccnames = consultantName;
                    string subject = (root.SelectSingleNode("Subject")).InnerText;
                    TemplatesTransFuncs.SendStrToOutlookForIntertrade(email, subject, vanEmailTemplates.tbGenerateTemplate.Text, ccnames);
                }
                else if (templateType == "Easylink")
                {
                    XmlNode root = doc.SelectSingleNode("//Header");
                    string email = (root.SelectSingleNode("Email")).InnerText;
                    string ccnames = consultantName;
                    string subject = (root.SelectSingleNode("Subject")).InnerText;
                    TemplatesTransFuncs.SendStrToOutlookForIntertrade(email, subject, vanEmailTemplates.tbGenerateTemplate.Text, ccnames);
                }
                else if (templateType == "ICC")
                {
                    //gfan 2023/2/9
                    XmlNode root = doc.SelectSingleNode("//Header");
                    string email = (root.SelectSingleNode("Email")).InnerText;
                    string ccnames = consultantName;
                    string subject = (root.SelectSingleNode("Subject")).InnerText;
                    TemplatesTransFuncs.SendStrToOutlookForIntertrade(email, subject, vanEmailTemplates.tbGenerateTemplate.Text, ccnames);
                    //gfan 2023/2/9
                }
                else if (templateType == "Commport")
                {
                    XmlNode root = doc.SelectSingleNode("//Header");
                    string email = consultantName;
                    string subject = (root.SelectSingleNode("Subject")).InnerText;
                    if (EmailProjectLink != "" && EmailProjectLinkDetails != "")
                        TemplatesTransFuncs.SendStrToOutlookForCommport(email, subject, vanEmailTemplates.tbGenerateTemplate.Text, EmailProjectLink, EmailProjectLinkDetails);
                    else
                        TemplatesTransFuncs.SendStrToOutlook(email, subject, vanEmailTemplates.tbGenerateTemplate.Text);
                }
                else
                {
                    XmlNode root = doc.SelectSingleNode("//Header");
                    string email = (root.SelectSingleNode("Email")).InnerText;
                    string subject = (root.SelectSingleNode("Subject")).InnerText;
                    TemplatesTransFuncs.SendStrToOutlook(email, subject, vanEmailTemplates.tbGenerateTemplate.Text);
                }
            }
        }

        /*private void UserName_TextChanged(object sender, EventArgs e)
        {
            MyConfig config = new MyConfig();
            config = new MyConfig();
            config.UserName = tbUserName.Text;
            config.Setting1 = "";
            config.Setting2 = "";
            config.Setting3 = "";
            ConfigHandler<MyConfig>.Save(config);
            //Properties.Settings.Default.UserName = tbUserName.Text;
            //Properties.Settings.Default.Save();
        }*/
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
            public string UserName { get; set; }
            public string Setting1 { get; set; }
            public string Setting2 { get; set; }
            public string Setting3 { get; set; }
            public override string ToString()
            {
                return $"serName={UserName},Setting1={Setting1},Setting2={Setting2},Setting3={Setting3}";
            }
        }
        public static void CreateSettingsConfig()
        {
            MyConfig config = new MyConfig();
            config = new MyConfig();
            config.UserName = "";
            config.Setting1 = "";
            config.Setting2 = "";
            config.Setting3 = "";
            ConfigHandler<MyConfig>.Save(config);
        }

        private void CustIDInfo_TextChanged(object sender, EventArgs e)
        {
            sortedCustIDs = vanEmailTemplates.tbCustInfoID.Text;
            vanEmailTemplates.cboxCustPrimaryID.Items.Clear();
            vanEmailTemplates.cboxCustPrimaryID.Items.Add("No Primary EDI ID");
            vanEmailTemplates.cboxCustPrimaryID.SelectedItem = "No Primary EDI ID";
            string[] sArray = vanEmailTemplates.tbCustInfoID.Text.Trim('/').Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string eachCustID in sArray)
            {
                if (TemplatesTransFuncs.IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains('\t'))
                {
                    vanEmailTemplates.cboxCustPrimaryID.Items.Add(eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + " " + eachCustID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1]);
                }
                else if (TemplatesTransFuncs.IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains(" "))
                {
                    vanEmailTemplates.cboxCustPrimaryID.Items.Add(eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + " " + eachCustID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1]);
                }
                else if (TemplatesTransFuncs.IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains("/"))
                {
                    vanEmailTemplates.cboxCustPrimaryID.Items.Add(eachCustID.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + " " + eachCustID.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1]);
                }
                else
                {
                    //processedStr += " / " + eachCustID.Trim(new char[] { '\t' }).Trim() + " ";
                    //没有Qual的EDI ID将不再需要被获取
                }
            }
            try
            {
                vanEmailTemplates.cboxCustPrimaryID.SelectedIndex = 1;
            }
            catch
            {

            }
        }

        private void SuppIDInfo_TextChanged(object sender, EventArgs e)
        {
            sortedSuppIDs = vanEmailTemplates.tbSuppInfoID.Text;
            vanEmailTemplates.cboxSuppPrimaryID.Items.Clear();
            vanEmailTemplates.cboxSuppPrimaryID.Items.Add("No Primary EDI ID");
            vanEmailTemplates.cboxSuppPrimaryID.SelectedItem = "No Primary EDI ID";
            string[] sArray = vanEmailTemplates.tbSuppInfoID.Text.Trim('/').Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string eachID in sArray)
            {
                if (TemplatesTransFuncs.IfStartsWithCharacter(eachID.Trim().Substring(0, 1)) && eachID.Trim().Contains('\t'))
                {
                    vanEmailTemplates.cboxSuppPrimaryID.Items.Add(eachID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + " " + eachID.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1]);
                }
                else if (TemplatesTransFuncs.IfStartsWithCharacter(eachID.Trim().Substring(0, 1)) && eachID.Trim().Contains(" "))
                {
                    vanEmailTemplates.cboxSuppPrimaryID.Items.Add(eachID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + " " + eachID.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1]);
                }
                else if (TemplatesTransFuncs.IfStartsWithCharacter(eachID.Trim().Substring(0, 1)) && eachID.Trim().Contains("/"))
                {
                    vanEmailTemplates.cboxSuppPrimaryID.Items.Add(eachID.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + " " + eachID.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1]);
                }
                else
                {
                    //processedStr += " / " + eachCustID.Trim(new char[] { '\t' }).Trim() + " ";
                    //没有Qual的EDI ID将不再需要被获取
                }
            }
            try
            {
                vanEmailTemplates.cboxSuppPrimaryID.SelectedIndex = 1;
            }
            catch
            {

            }
        }

        private void CustPrimaryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string custEDIIDNewSort = "";
            if (cboxCustPrimaryID.SelectedItem.ToString() != "No Primary EDI ID")
            {
                custEDIIDNewSort += cboxCustPrimaryID.SelectedItem.ToString().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + "\t" + cboxCustPrimaryID.SelectedItem.ToString().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "\r\n";
                foreach (string item in cboxCustPrimaryID.Items)
                {
                    if (item != cboxCustPrimaryID.SelectedItem.ToString() && item != "No Primary EDI ID")
                        custEDIIDNewSort += item.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + "\t" + item.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "\r\n";
                }
            }
            else
            {
                sortedCustIDs = vanEmailTemplates.tbCustInfoID.Text;
            }

            if (custEDIIDNewSort.EndsWith("\r\n"))
                sortedCustIDs = custEDIIDNewSort.Trim();

            if (lbTemplatesType.SelectedIndex > -1)
                RefreshGenerateTemplateText(lbTemplatesType.SelectedItem.ToString());

        }

        private void SuppPrimaryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string suppEDIIDNewSort = "";
            if (cboxSuppPrimaryID.SelectedItem.ToString() != "No Primary EDI ID")
            {
                suppEDIIDNewSort += cboxSuppPrimaryID.SelectedItem.ToString().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + "\t" + cboxSuppPrimaryID.SelectedItem.ToString().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "\r\n";
                foreach (string item in cboxSuppPrimaryID.Items)
                {
                    if (item != cboxSuppPrimaryID.SelectedItem.ToString() && item != "No Primary EDI ID")
                        suppEDIIDNewSort += item.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0] + "\t" + item.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1] + "\r\n";
                }
            }
            else
            {
                sortedSuppIDs = vanEmailTemplates.tbSuppInfoID.Text;
            }

            if (suppEDIIDNewSort.EndsWith("\r\n"))
                sortedSuppIDs = suppEDIIDNewSort.Trim();

            if (lbTemplatesType.SelectedIndex > -1)
                RefreshGenerateTemplateText(lbTemplatesType.SelectedItem.ToString());
        }

        private void CustName_TextChanged(object sender, EventArgs e)
        {
            if (lbTemplatesType.SelectedIndex > -1)
                RefreshGenerateTemplateText(lbTemplatesType.SelectedItem.ToString());
        }

        private void SuppName_TextChanged(object sender, EventArgs e)
        {
            if (lbTemplatesType.SelectedIndex > -1)
                RefreshGenerateTemplateText(lbTemplatesType.SelectedItem.ToString());
        }

        private void CustID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            vanEmailTemplates.tbCustInfoID.Clear();
        }

        private void SuppID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            vanEmailTemplates.tbSuppInfoID.Clear();
        }
        public static bool IfMultipleIDs(string str)
        {
            int count = 0;
            string[] sArray = str.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string eachCustID in sArray)
            {
                if (TemplatesTransFuncs.IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains('\t'))
                {
                    count += 1;
                }
                else if (TemplatesTransFuncs.IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains(" "))
                {
                    count += 1;
                }
                else if (TemplatesTransFuncs.IfStartsWithCharacter(eachCustID.Trim().Substring(0, 1)) && eachCustID.Trim().Contains("/"))
                {
                    count += 1;
                }
                else
                {
                    //processedStr += " / " + eachCustID.Trim(new char[] { '\t' }).Trim() + " ";
                    //没有Qual的EDI ID将不再需要被获取
                }
            }
            if (count > 1)
                return true;
            else
                return false;
        }

        private void VANEmailTemplates_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.ifVANEmailTemplatesOpened = false;
            mainForm.NormalMainForm();
        }

        private void CopySuggestion_Click(object sender, EventArgs e)
        {
            if (vanEmailTemplates.tbTemplateSuggestion.Text.Contains("\""))
            {
                string suggestion = vanEmailTemplates.tbTemplateSuggestion.Text.Split("\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1];
                Clipboard.SetDataObject(suggestion);
            }
            else if (vanEmailTemplates.tbTemplateSuggestion.Text != "")
                Clipboard.SetDataObject(vanEmailTemplates.tbTemplateSuggestion.Text);
        }

        private void CustName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            vanEmailTemplates.tbCustInfoName.Clear();
        }

        private void SuppName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            vanEmailTemplates.tbSuppInfoName.Clear();
        }
        private static void LoadOtherTypes(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode root = doc.SelectSingleNode("//Type");
            foreach (XmlNode eachType in root.ChildNodes)
            {
                vanEmailTemplates.lbOtherSuggestions.Items.Add(eachType.Attributes["TypeName"].Value.Replace("---", "<->"));
            }
        }

        private void TemplateEdit_LinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Path.Combine(Directory.GetCurrentDirectory() + "\\Templates"));
        }

        private void VANEmailTemplates_Load(object sender, EventArgs e)
        {
            mainForm.MinimizeMainForm();
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            this.TopMost = false;
        }
    }
}
