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
    public partial class SoftwareAboutForm : Form
    {
        public SoftwareAboutForm()
        {
            InitializeComponent();
        }

        private void SoftwareAboutOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
