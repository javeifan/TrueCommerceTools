using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MappingTools
{
    public partial class VANConsultantDetails : Form
    {
        public static string templateType = "";
        public static VANConsultantDetails vanConsultantDetails;
        public VANConsultantDetails()
        {
            vanConsultantDetails = this;
            this.Text = templateType + " Details";
            InitializeComponent();
        }

        private void InterTradeCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            templateType = "";
        }

        private void InterTradeOK_Click(object sender, EventArgs e)
        {
            if (tbIntertradeConsultant.Text == "")
            {
                MessageBox.Show("Consultant name can not be empty!");
            }
            //else if (tbIntertradeProjectLink.Text != "" && tbIntertradeLinkDetail.Text == "")
            //{
            //    MessageBox.Show("Link Detail can not be null when Project Link exists.");
            //}
            //else if (tbIntertradeProjectLink.Text == "" && tbIntertradeLinkDetail.Text != "")
            //{
            //    MessageBox.Show("Project Link can not be null when Link Detail exists.");
            //}
            else
            {
                VANEmailTemplates.consultantName = tbIntertradeConsultant.Text;
                //VANEmailTemplates.EmailProjectLink = tbIntertradeProjectLink.Text;
                //VANEmailTemplates.EmailProjectLinkDetails = tbIntertradeLinkDetail.Text;
                this.Close();
                templateType = "";
            }
        }

        private void tbIntertradeConsultant_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
