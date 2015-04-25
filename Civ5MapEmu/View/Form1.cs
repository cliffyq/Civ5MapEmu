using System;
using System.Drawing;
using System.Windows.Forms;
using Civ5MapEmu.Model;

namespace Civ5MapEmu.View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int height = int.Parse(HeightTextBox.Text);
            int width = int.Parse(WidthTextBox.Text);
            bool vwrap = vWrapCheckBox.Checked;
            bool hwrap = hWrapCheckBox.Checked;
            Map map = new Map(width,height,hwrap,vwrap);
        }
    }
}
