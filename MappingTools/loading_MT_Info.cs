using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MappingTools.Properties;
using System.IO;
using System.Xml;

namespace MappingTools
{
    public partial class loading_MT_Info : Form
    {
        public loading_MT_Info()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true);

            InitializeComponent();
            slaVersionNum.Text = MappingToolsCommonFuncs.GetSoftwareVersion();
            string disclaimer = File.ReadAllText(@"Disclaimer.txt");
            slasDisclaimer.Text=( disclaimer);
            MT_version_timer.Start();
        }

        private void MT_version_timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
