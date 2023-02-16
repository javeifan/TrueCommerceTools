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
    public partial class IntertradeSelection : Form
    {
        public static string templateType = "";
        public static IntertradeSelection intertradeSelection;
        public IntertradeSelection()
        {
            intertradeSelection = this;
            this.Text = templateType + " Details";
            InitializeComponent();
            if (templateType == "Easylink")
            {
                this.laIs832.Visible = false;
                this.checkboxIs832.Visible = false;
            }
            else
            {
                this.laIs832.Visible = true;
                this.checkboxIs832.Visible = true;
            }
        }

        private void btInterTradeSelectCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            templateType = "";
        }

        private void btInterTradeSelectOK_Click(object sender, EventArgs e)
        {
            if (tbCCName.Text == "")
            {
                MessageBox.Show("Consultant name can not be empty!");
            }
            else
            {
                VANEmailTemplates.consultantName = tbCCName.Text;
                VANEmailTemplates.is832 = checkboxIs832.Checked;
                this.Close();
                templateType = "";
            }
        }
    }
}
