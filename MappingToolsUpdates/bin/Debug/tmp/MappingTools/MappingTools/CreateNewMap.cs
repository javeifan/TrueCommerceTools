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
    public partial class CreateNewMap : Form
    {
        public CreateNewMap()
        {
            InitializeComponent();
            checkedListBox1.Items.Add("NEW");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] sarry = { };
            textBox1.Text = "";
        }
    }
}
