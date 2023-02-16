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
    public partial class VANIntertradeDetails : Form
    {
        public VANIntertradeDetails()
        {
            InitializeComponent();
        }

        private void InterTradeCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InterTradeOK_Click(object sender, EventArgs e)
        {
            if (tbIntertradeConsultant.Text == "")
            {
                MessageBox.Show("Consultant name can not be empty!");
            }
            else if (tbIntertradeProjectLink.Text != "" && tbIntertradeLinkDetail.Text == "")
            {
                MessageBox.Show("Link Detail can not be null when Project Link exists.");
            }
            else if (tbIntertradeProjectLink.Text == "" && tbIntertradeLinkDetail.Text != "")
            {
                MessageBox.Show("Project Link can not be null when Link Detail exists.");
            }
            else
            {
                VANEmailTemplates.consultantName = tbIntertradeConsultant.Text;
                VANEmailTemplates.interTradeProjectLink = tbIntertradeProjectLink.Text;
                VANEmailTemplates.interTradeProjectLinkDetails = tbIntertradeLinkDetail.Text;
                this.Close();
            }
        }
    }
}
