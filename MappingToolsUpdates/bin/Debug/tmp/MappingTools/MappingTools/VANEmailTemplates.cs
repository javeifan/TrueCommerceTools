﻿using System;
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
        public static string interTradeProjectLink = "";
        public static string interTradeProjectLinkDetails = "";
        public static VANEmailTemplates vanEmailTemplates;
        public static string sortedCustIDs = "";
        public static string sortedSuppIDs = "";
        public VANEmailTemplates()
        {
            vanEmailTemplates = this;
            InitializeComponent();
            vanEmailTemplates.cboxCustPrimaryID.SelectedItem = "No Primary EDI ID";
            vanEmailTemplates.cboxSuppPrimaryID.SelectedItem = "No Primary EDI ID";
            if (File.Exists(@"./jsonconfig/MappingTools.VANEmailTemplates+MyConfig.json"))
                LoadSettings();
            else
            {
                CreateSettingsConfig();
                LoadSettings();
            }
            //LoadSettings();

            //Load TemplateType in lbTemplatesType
            DirectoryInfo folder = new DirectoryInfo(templatesPath);
            foreach (FileInfo file in folder.GetFiles("*.xml"))
            {
                if(file.Name!= "OtherTypeWithSuggestions.xml")
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
                        vanEmailTemplates.tbTemplateSuggestion.Text = eachType.InnerText.Replace("[$:USER_NAME]",vanEmailTemplates.tbUserName.Text).Replace("[$:DATETIME]", DateTime.Now.ToString("MM/dd/yyyy"));
                }
            }
            catch
            { 
            
            }
        }
        private static void RefreshGenerateTemplateText(string templateType)
        {
            try
            {
                string generateText = "";
                string templatePath = @"./Templates/" + templateType + ".xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(templatePath);
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
                    generateText += "Email: " + (root.SelectSingleNode("Email")).InnerText;
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
                    vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:MAILBOX]", mailbox).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER]/[$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline)).Replace("[$:PARTNER_NAME]", vanEmailTemplates.tbSuppInfoName.Text).Replace("[$:PARTNER_QUALIFIER]/[$:PARTNER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedSuppIDs, ifmultiline));
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
                    generateText += "Email: " + (root.SelectSingleNode("Email")).InnerText;
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
                }
                else if (templateType == "Intertrade")
                {
                    VANIntertradeDetails _formVANIntertradeDetails = new VANIntertradeDetails();
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
                    MyConfig config = new MyConfig();
                    config = ConfigHandler<MyConfig>.Load();
                    string userName = config.UserName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                    //string userName = Properties.Settings.Default.UserName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                    generateText += "Email: " + consultantName;
                    generateText += "\r\n";
                    generateText += "Subject: " + (root.SelectSingleNode("Subject")).InnerText;
                    generateText += "\r\n";
                    generateText += "\r\n";
                    generateText += (doc.SelectSingleNode("//Template")).InnerText;
                    bool ifmultiline = TemplatesTransFuncs.StringToBool((root.SelectSingleNode("MultiLine")).InnerText);
                    if (interTradeProjectLink != "" && interTradeProjectLinkDetails != "")
                        vanEmailTemplates.tbGenerateTemplate.Text = TemplatesTransFuncs.SubstituteLineFeed(generateText).Replace("[$:CUSTOMER_NAME]", vanEmailTemplates.tbCustInfoName.Text).Replace("[$:CUSTOMER_QUALIFIER] / [$:CUSTOMER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedCustIDs, ifmultiline)).Replace("[$:PARTNER_NAME]", vanEmailTemplates.tbSuppInfoName.Text).Replace("[$:PARTNER_QUALIFIER]/[$:PARTNER_EDI_ID]", TemplatesTransFuncs.ProcessEDIID(sortedSuppIDs, ifmultiline)).Replace("[$:CONSULTANT_NAME]", consultantFirstName).Replace("[$:USER_NAME]", userName).Replace("Project link:\r\n[$:PROJECT_LINK]", "Project link:\r\n" + interTradeProjectLinkDetails);
                    else
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
                    string email = consultantName;
                    string subject = (root.SelectSingleNode("Subject")).InnerText;
                    if (interTradeProjectLink != "" && interTradeProjectLinkDetails != "")
                        TemplatesTransFuncs.SendStrToOutlookForIntertrade(email, subject, vanEmailTemplates.tbGenerateTemplate.Text, interTradeProjectLink, interTradeProjectLinkDetails);
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

        private void UserName_TextChanged(object sender, EventArgs e)
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
            public string UserName { get; set; }
            public string Setting1 { get; set; }
            public string Setting2 { get; set; }
            public string Setting3 { get; set; }
            public override string ToString()
            {
                return $"serName={UserName},Setting1={Setting1},Setting2={Setting2},Setting3={Setting3}";
            }
        }
        public static void LoadSettings()
        {
            MyConfig config = new MyConfig();
            config = ConfigHandler<MyConfig>.Load();
            vanEmailTemplates.tbUserName.Text = config.UserName;
            //vanEmailTemplates.tbUserName.Text = Properties.Settings.Default.UserName;
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
            string[] sArray = vanEmailTemplates.tbCustInfoID.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
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
            string[] sArray = vanEmailTemplates.tbSuppInfoID.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
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
        }

        private void CopySuggestion_Click(object sender, EventArgs e)
        {
            if (vanEmailTemplates.tbTemplateSuggestion.Text.Contains("\""))
            {
                string suggestion = vanEmailTemplates.tbTemplateSuggestion.Text.Split("\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1];
                Clipboard.SetDataObject(suggestion);
            }
            else if(vanEmailTemplates.tbTemplateSuggestion.Text!="")
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
                vanEmailTemplates.lbOtherSuggestions.Items.Add(eachType.Attributes["TypeName"].Value.Replace("---","<->"));
            }
        }
    }
}
