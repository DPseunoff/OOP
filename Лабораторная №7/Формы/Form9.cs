using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_работа
{
    public partial class Form9 : Form
    {
        /////////////Singleton///////////////
        private static readonly Form9 instance = new Form9();

        public static Form9 Instance
        {
            get { return instance; }
        }
        private static bool IsShown = false;
        public new void Show()
        {
            if (IsShown)
                base.Show();
            else
            {
                base.Show();
                IsShown = true;
            }
        }
        static Form9()
        {
            Instance.FormClosing += new FormClosingEventHandler(Instance_FormClosing);
        }
        private static void Instance_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            IsShown = false;
            Instance.Hide();
        }
        /////////////Singleton///////////////
        


        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fontDialog1 = new FontDialog();
            if (fontDialog1.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(richTextBox1.Text))
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(richTextBox1.Text))
            {
                this.richTextBox1.Font = new Font(this.richTextBox1.Font.FontFamily, this.trackBar1.Value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(richTextBox1.Text);
            }
            catch { return; }
            richTextBox2.Text = Clipboard.GetText();
            richTextBox2.Font = richTextBox1.Font;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetImage(pictureBox1.Image);
            }
            catch { return; }
            pictureBox2.Image = Clipboard.GetImage();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(richTextBox1.Text))
            {
                richTextBox2.Clear();
            }
            if (pictureBox2.Image != null)
            {
                pictureBox2.Image = null;
            }
        }
    }
}
