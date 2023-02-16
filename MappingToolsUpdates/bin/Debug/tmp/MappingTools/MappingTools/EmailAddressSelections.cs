using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using Newtonsoft.Json;
using System.IO;
using System.Resources;
using System.Xml;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MappingTools
{
    /// <summary>
    /// Email Address Format: Olivia Huang <Olivia.Huang@truecommerce.com>; Zoey Zan <Zoey.Zan@truecommerce.com>
    /// </summary>
    public partial class EmailAddressSelections : Form
    {
        private static Point mousePoint = new Point();
        private static string EmailAddrBookXmlPath = @".\EmailAddressBook.xml";

        public EmailAddressSelections()
        {
            InitializeComponent();
            string SendToOrCCTo = WTXDailyEmailHelper.SendToOrCCTo;
            if (File.Exists(EmailAddrBookXmlPath) == false)
                CreateEmailAddrBookXml();
            if (SendToOrCCTo.ToUpper() == "SENDTO")
            {
                int addBookLength = GetAddressStr("SENDTO").Length;
                for (int i = 0; i < addBookLength; i++)
                {
                    string[] itemsArray = GetAddressStr("SENDTO")[i].Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    clEmailAddresses.Items.Add(itemsArray[0], StrToBool(itemsArray[1]));
                }
            }
            else if (SendToOrCCTo.ToUpper() == "CCTO")
            {
                int addBookLength = GetAddressStr("CCTO").Length;
                for (int i = 0; i < addBookLength; i++)
                {
                    string[] itemsArray = GetAddressStr("CCTO")[i].Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    clEmailAddresses.Items.Add(itemsArray[0], StrToBool(itemsArray[1]));
                }
            }
            else if (SendToOrCCTo.ToUpper() == "SPSENDTO")
            {
                int addBookLength = GetAddressStr("SPSENDTO").Length;
                for (int i = 0; i < addBookLength; i++)
                {
                    string[] itemsArray = GetAddressStr("SPSENDTO")[i].Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    clEmailAddresses.Items.Add(itemsArray[0], StrToBool(itemsArray[1]));
                }
            }
            else if (SendToOrCCTo.ToUpper() == "SPCCTO")
            {
                int addBookLength = GetAddressStr("SPCCTO").Length;
                for (int i = 0; i < addBookLength; i++)
                {
                    string[] itemsArray = GetAddressStr("SPCCTO")[i].Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    clEmailAddresses.Items.Add(itemsArray[0], StrToBool(itemsArray[1]));
                }
            }
        }
        private void tbEmailAddrCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmailAddressItems_RightClick(object sender, MouseEventArgs e)
        {
            mousePoint = e.Location;
            if (e.Button == MouseButtons.Right)//判断是否右键点击
            {
                //ContextMenuStrip emailAddrItemMeanStrip = new ContextMenuStrip();
                //Point p = e.Location;//获取点击的位置
                //int index = clEmailAddresses.IndexFromPoint(p);//根据位置获取右键点击项的索引
                try
                {
                    if (e.Button == MouseButtons.Right && clEmailAddresses.IndexFromPoint(e.Location) > -1)
                    {
                        EamilAddrItemMenuStrip.Show(this.clEmailAddresses, e.Location);//鼠标右键按下弹出菜单
                    }
                }
                catch
                {
                }
                //clEmailAddresses.SelectedIndex = index;//设置该索引值对应的项为选定状态
                //checkedListBox1.SetItemChecked(index, true);//如果需要的话这句可以同时设置check状态
            }
        }

        private void EmailAddrItemMenu_Delete(object sender, EventArgs e)
        {
            try
            {
                int index = clEmailAddresses.IndexFromPoint(mousePoint);
                EmailAddrBookXmlDel(clEmailAddresses.Items[index].ToString().Split(" <".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0]);
                string SendToOrCCTo = WTXDailyEmailHelper.SendToOrCCTo;
                if (SendToOrCCTo.ToUpper() == "SENDTO")
                {
                    clEmailAddresses.Items.Clear();
                    int addBookLength = GetAddressStr("SENDTO").Length;
                    for (int i = 0; i < addBookLength; i++)
                    {
                        string[] itemsArray = GetAddressStr("SENDTO")[i].Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        clEmailAddresses.Items.Add(itemsArray[0], StrToBool(itemsArray[1]));
                    }
                }
                else if (SendToOrCCTo.ToUpper() == "CCTO")
                {
                    clEmailAddresses.Items.Clear();
                    int addBookLength = GetAddressStr("CCTO").Length;
                    for (int i = 0; i < addBookLength; i++)
                    {
                        string[] itemsArray = GetAddressStr("CCTO")[i].Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        clEmailAddresses.Items.Add(itemsArray[0], StrToBool(itemsArray[1]));
                    }
                }
                else if (SendToOrCCTo.ToUpper() == "SPSENDTO")
                {
                    clEmailAddresses.Items.Clear();
                    int addBookLength = GetAddressStr("SPSENDTO").Length;
                    for (int i = 0; i < addBookLength; i++)
                    {
                        string[] itemsArray = GetAddressStr("SPSENDTO")[i].Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        clEmailAddresses.Items.Add(itemsArray[0], StrToBool(itemsArray[1]));
                    }
                }
                else if (SendToOrCCTo.ToUpper() == "SPCCTO")
                {
                    clEmailAddresses.Items.Clear();
                    int addBookLength = GetAddressStr("SPCCTO").Length;
                    for (int i = 0; i < addBookLength; i++)
                    {
                        string[] itemsArray = GetAddressStr("SPCCTO")[i].Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        clEmailAddresses.Items.Add(itemsArray[0], StrToBool(itemsArray[1]));
                    }
                }
            }
            catch
            {
            }
        }
        private static string[] GetAddressStr(string stORcc)
        {
            string addressbook = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(EmailAddrBookXmlPath);
            if (stORcc == "SENDTO")
            {
                foreach (XmlElement item in doc.DocumentElement)
                {
                    addressbook += (item.SelectSingleNode("Name")).InnerText + " <" + (item.SelectSingleNode("EmailAddress")).InnerText + ">|" + (item.SelectSingleNode("IfUsedInSendTo")).InnerText + ";";
                }
            }
            else if (stORcc == "CCTO")
            {
                foreach (XmlElement item in doc.DocumentElement)
                {
                    addressbook += (item.SelectSingleNode("Name")).InnerText + " <" + (item.SelectSingleNode("EmailAddress")).InnerText + ">|" + (item.SelectSingleNode("IfUsedInCCTo")).InnerText + ";";
                }
            }
            else if (stORcc == "SPSENDTO")
            {
                foreach (XmlElement item in doc.DocumentElement)
                {
                    addressbook += (item.SelectSingleNode("Name")).InnerText + " <" + (item.SelectSingleNode("EmailAddress")).InnerText + ">|" + (item.SelectSingleNode("IfUsedInSpawnSendTo")).InnerText + ";";
                }
            }
            else if (stORcc == "SPCCTO")
            {
                foreach (XmlElement item in doc.DocumentElement)
                {
                    addressbook += (item.SelectSingleNode("Name")).InnerText + " <" + (item.SelectSingleNode("EmailAddress")).InnerText + ">|" + (item.SelectSingleNode("IfUsedInSpawnCCTo")).InnerText + ";";
                }
            }
            string[] itemsArray = addressbook.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return itemsArray;
        }
        private static bool StrToBool(string value)
        {
            if (value.ToUpper() == "TRUE")
                return true;
            else if (value.ToUpper() == "FALSE")
                return false;
            else
                return false;
        }
        private static void CreateEmailAddrBookXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            XmlElement Addresses = doc.CreateElement("Addresses");
            doc.AppendChild(Addresses);
            doc.Save(EmailAddrBookXmlPath);
        }
        /// <summary>
        /// AddressBookAdd(Name,EmailAddress,ifUsedinSendTo,ifUsedinCCTo)
        /// </summary>
        private static void EmailAddrBookXmlAdd(string name, string address, bool usedInSendTo, bool usedInCCTo, bool usedInSpawnSendTo, bool usedInSpawnCCTo)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(EmailAddrBookXmlPath);
            XmlElement Addresses = doc.DocumentElement;
            XmlElement Address = doc.CreateElement("Address");
            XmlElement Name = doc.CreateElement("Name");
            XmlElement EmailAddress = doc.CreateElement("EmailAddress");
            XmlElement IfUsedInSendTo = doc.CreateElement("IfUsedInSendTo");
            XmlElement IfUsedInCCTo = doc.CreateElement("IfUsedInCCTo");
            XmlElement IfUsedInSpawnSendTo = doc.CreateElement("IfUsedInSpawnSendTo");
            XmlElement IfUsedInSpawnCCTo = doc.CreateElement("IfUsedInSpawnCCTo");
            Name.InnerText = name;
            EmailAddress.InnerText = address;
            IfUsedInSendTo.InnerText = usedInSendTo.ToString();
            IfUsedInCCTo.InnerText = usedInCCTo.ToString();
            IfUsedInSpawnSendTo.InnerText = usedInSpawnSendTo.ToString();
            IfUsedInSpawnCCTo.InnerText = usedInSpawnCCTo.ToString();
            Address.AppendChild(Name);
            Address.AppendChild(EmailAddress);
            Address.AppendChild(IfUsedInSendTo);
            Address.AppendChild(IfUsedInCCTo);
            Address.AppendChild(IfUsedInSpawnSendTo);
            Address.AppendChild(IfUsedInSpawnCCTo);
            Addresses.AppendChild(Address);
            doc.Save(EmailAddrBookXmlPath);
        }
        private static void EmailAddrBookXmlDel(string name)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(EmailAddrBookXmlPath);
                foreach (XmlElement item in doc.DocumentElement)
                {
                    if ((item.SelectSingleNode("Name")).InnerText == name)
                        doc.DocumentElement.RemoveChild(item);
                }
                doc.Save(EmailAddrBookXmlPath);
            }
            catch {}
        }

        private void EmailAddrSelItemChanged(object sender, EventArgs e)
        {
            int index = clEmailAddresses.IndexFromPoint(mousePoint);
            string itemName = clEmailAddresses.Items[index].ToString().Split("<".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0].Trim();
            XmlDocument doc = new XmlDocument();
            doc.Load(EmailAddrBookXmlPath);
            string SendToOrCCTo = WTXDailyEmailHelper.SendToOrCCTo;
            if (SendToOrCCTo.ToUpper() == "SENDTO")
            {
                foreach (XmlElement item in doc.DocumentElement)
                {
                    if ((item.SelectSingleNode("Name")).InnerText == itemName)
                    {
                        if ((item.SelectSingleNode("IfUsedInSendTo")).InnerText.ToUpper() == "TRUE")
                            (item.SelectSingleNode("IfUsedInSendTo")).InnerText = "False";
                        else if ((item.SelectSingleNode("IfUsedInSendTo")).InnerText.ToUpper() == "FALSE")
                            (item.SelectSingleNode("IfUsedInSendTo")).InnerText = "True";
                    }
                }
                doc.Save(EmailAddrBookXmlPath);
            }
            else if (SendToOrCCTo.ToUpper() == "CCTO")
            {
                foreach (XmlElement item in doc.DocumentElement)
                {
                    if ((item.SelectSingleNode("Name")).InnerText == itemName)
                    {
                        if ((item.SelectSingleNode("IfUsedInCCTo")).InnerText.ToUpper() == "TRUE")
                            (item.SelectSingleNode("IfUsedInCCTo")).InnerText = "False";
                        else if ((item.SelectSingleNode("IfUsedInCCTo")).InnerText.ToUpper() == "FALSE")
                            (item.SelectSingleNode("IfUsedInCCTo")).InnerText = "True";
                    }
                }
                doc.Save(EmailAddrBookXmlPath);
            }
            else if (SendToOrCCTo.ToUpper() == "SPSENDTO")
            {
                foreach (XmlElement item in doc.DocumentElement)
                {
                    if ((item.SelectSingleNode("Name")).InnerText == itemName)
                    {
                        if ((item.SelectSingleNode("IfUsedInSpawnSendTo")).InnerText.ToUpper() == "TRUE")
                            (item.SelectSingleNode("IfUsedInSpawnSendTo")).InnerText = "False";
                        else if ((item.SelectSingleNode("IfUsedInSpawnSendTo")).InnerText.ToUpper() == "FALSE")
                            (item.SelectSingleNode("IfUsedInSpawnSendTo")).InnerText = "True";
                    }
                }
                doc.Save(EmailAddrBookXmlPath);
            }
            else if (SendToOrCCTo.ToUpper() == "SPCCTO")
            {
                foreach (XmlElement item in doc.DocumentElement)
                {
                    if ((item.SelectSingleNode("Name")).InnerText == itemName)
                    {
                        if ((item.SelectSingleNode("IfUsedInSpawnCCTo")).InnerText.ToUpper() == "TRUE")
                            (item.SelectSingleNode("IfUsedInSpawnCCTo")).InnerText = "False";
                        else if ((item.SelectSingleNode("IfUsedInSpawnCCTo")).InnerText.ToUpper() == "FALSE")
                            (item.SelectSingleNode("IfUsedInSpawnCCTo")).InnerText = "True";
                    }
                }
                doc.Save(EmailAddrBookXmlPath);
            }
        }

        private void AddEmailAddr_Click(object sender, EventArgs e)
        {
            if (tbAddEmailAddrName.Text.Trim() == null || tbAddEmailAddrName.Text.Trim() == "" || tbAddEmailAddrAddress.Text.Trim() == null || tbAddEmailAddrAddress.Text.Trim() == "")
            {
                MessageBox.Show("Address info can not be empty!");
            }
            else if(tbAddEmailAddrName.Text.Trim().Contains("<") || tbAddEmailAddrName.Text.Trim().Contains(">") || tbAddEmailAddrAddress.Text.Trim().Contains("<") || tbAddEmailAddrAddress.Text.Trim().Contains(">"))
            { 
                MessageBox.Show("Address info must not contain \"<\" or \">\"");
            }
            else
            {
                EmailAddrBookXmlAdd(tbAddEmailAddrName.Text, tbAddEmailAddrAddress.Text, false, false, false, false);
                tbAddEmailAddrName.Clear();
                tbAddEmailAddrAddress.Clear();
                //string SendToOrCCTo = WTXDailyEmailHelper.SendToOrCCTo;
                if (WTXDailyEmailHelper.SendToOrCCTo.ToUpper() == "SENDTO")
                {
                    clEmailAddresses.Items.Clear();
                    int addBookLength = GetAddressStr("SENDTO").Length;
                    for (int i = 0; i < addBookLength; i++)
                    {
                        string[] itemsArray = GetAddressStr("SENDTO")[i].Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        clEmailAddresses.Items.Add(itemsArray[0], StrToBool(itemsArray[1]));
                    }
                }
                else if (WTXDailyEmailHelper.SendToOrCCTo.ToUpper() == "CCTO")
                {
                    clEmailAddresses.Items.Clear();
                    int addBookLength = GetAddressStr("CCTO").Length;
                    for (int i = 0; i < addBookLength; i++)
                    {
                        string[] itemsArray = GetAddressStr("CCTO")[i].Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        clEmailAddresses.Items.Add(itemsArray[0], StrToBool(itemsArray[1]));
                    }
                }
                else if (WTXDailyEmailHelper.SendToOrCCTo.ToUpper() == "SPSENDTO")
                {
                    clEmailAddresses.Items.Clear();
                    int addBookLength = GetAddressStr("SPSENDTO").Length;
                    for (int i = 0; i < addBookLength; i++)
                    {
                        string[] itemsArray = GetAddressStr("SPSENDTO")[i].Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        clEmailAddresses.Items.Add(itemsArray[0], StrToBool(itemsArray[1]));
                    }
                }
                else if (WTXDailyEmailHelper.SendToOrCCTo.ToUpper() == "SPCCTO")
                {
                    clEmailAddresses.Items.Clear();
                    int addBookLength = GetAddressStr("SPCCTO").Length;
                    for (int i = 0; i < addBookLength; i++)
                    {
                        string[] itemsArray = GetAddressStr("SPCCTO")[i].Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        clEmailAddresses.Items.Add(itemsArray[0], StrToBool(itemsArray[1]));
                    }
                }
            }
        }

        private void EmialAddrOK_Click(object sender, EventArgs e)
        {
            //string SendToOrCCTo = WTXDailyEmailHelper.SendToOrCCTo;
            string addrStr = "";
            if (WTXDailyEmailHelper.SendToOrCCTo.ToUpper() == "SENDTO")
            {
                for (int i = 0; i < clEmailAddresses.Items.Count; i++)
                {
                    if (clEmailAddresses.GetItemChecked(i))
                        addrStr += clEmailAddresses.Items[i].ToString() + "; ";
                }
                if (addrStr.EndsWith("; "))
                    addrStr = addrStr.Remove(addrStr.LastIndexOf("; "), 1);
                else { }
                //WTXDailyEmailHelper.EmailAddrSendTo = addrStr;
                WTXDailyEmailHelper.EmailAddressSelectionsClosed(addrStr, "");
                this.Close();
            }
            else if (WTXDailyEmailHelper.SendToOrCCTo.ToUpper() == "CCTO")
            {
                for (int i = 0; i < clEmailAddresses.Items.Count; i++)
                {
                    if (clEmailAddresses.GetItemChecked(i))
                        addrStr += clEmailAddresses.Items[i].ToString() + "; ";
                }
                if (addrStr.EndsWith("; "))
                    addrStr = addrStr.Remove(addrStr.LastIndexOf("; "), 1);
                else { }
                //WTXDailyEmailHelper.EmailAddrCCTo = addrStr;
                WTXDailyEmailHelper.EmailAddressSelectionsClosed("", addrStr);
                this.Close();
            }
            else if (WTXDailyEmailHelper.SendToOrCCTo.ToUpper() == "SPSENDTO")
            {
                for (int i = 0; i < clEmailAddresses.Items.Count; i++)
                {
                    if (clEmailAddresses.GetItemChecked(i))
                        addrStr += clEmailAddresses.Items[i].ToString() + "; ";
                }
                if (addrStr.EndsWith("; "))
                    addrStr = addrStr.Remove(addrStr.LastIndexOf("; "), 1);
                else { }
                //WTXDailyEmailHelper.EmailAddrCCTo = addrStr;
                SpawnDailyEmailHelper.EmailAddressSelectionsClosed(addrStr, "");
                this.Close();
            }
            else if (WTXDailyEmailHelper.SendToOrCCTo.ToUpper() == "SPCCTO")
            {
                for (int i = 0; i < clEmailAddresses.Items.Count; i++)
                {
                    if (clEmailAddresses.GetItemChecked(i))
                        addrStr += clEmailAddresses.Items[i].ToString() + "; ";
                }
                if (addrStr.EndsWith("; "))
                    addrStr = addrStr.Remove(addrStr.LastIndexOf("; "), 1);
                else { }
                //WTXDailyEmailHelper.EmailAddrCCTo = addrStr;
                SpawnDailyEmailHelper.EmailAddressSelectionsClosed("", addrStr);
                this.Close();
            }
        }
    }
}
