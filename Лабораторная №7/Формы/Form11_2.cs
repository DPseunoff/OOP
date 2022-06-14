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
    public partial class Form11_2 : Form
    {
        /////////////Singleton///////////////
        private static readonly Form11_2 instance = new Form11_2();

        public static Form11_2 Instance
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
        static Form11_2()
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


        public Form11_2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                ListViewItem i = new ListViewItem(textBox1.Text);
                i.SubItems.Add(textBox2.Text);
                listView1.Items.Add(i);
                
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
                listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
    }
}
