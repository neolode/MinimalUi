using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Maximum = monospaceProgressBar1.MaxValue;
            numericUpDown1.Value = monospaceProgressBar1.Value;
            //vScrollBar1.Maximum = this.Height;
            //vScrollBar1.Value = this.Height;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            monospaceProgressBar1.Value = (int)numericUpDown1.Value;
        }

        private void monospaceButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //if (this.Height < vScrollBar1.Maximum)
            //    vScrollBar1.Value = this.Height;
            //else
            //    vScrollBar1.Value = vScrollBar1.Maximum;
        }
    }
}
