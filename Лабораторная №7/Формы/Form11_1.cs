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
    public partial class Form11_1 : Form
    {
        /////////////Singleton///////////////
        private static readonly Form11_1 instance = new Form11_1();

        public static Form11_1 Instance
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
        static Form11_1()
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

        public Form11_1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                treeView1.Nodes.Add(textBox1.Text);
                label5.Text = treeView1.GetNodeCount(true).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && textBox1.Text != "")
            {
                treeView1.SelectedNode.Nodes.Add(textBox1.Text);
                label5.Text = treeView1.GetNodeCount(true).ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeView1.GetNodeCount(true) != 0)
            {
                label2.Text = "";
                label4.Text = "";
                treeView1.SelectedNode.Remove();
                label5.Text = treeView1.GetNodeCount(true).ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (treeView1.GetNodeCount(true) != 0)
            { 
                treeView1.Nodes.Clear();
                label5.Text = treeView1.GetNodeCount(true).ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                treeView1.SelectedNode.Text = textBox1.Text;
                label2.Text = treeView1.SelectedNode.Text;
                label4.Text = treeView1.SelectedNode.FullPath;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            label2.Text = treeView1.SelectedNode.Text;
            label4.Text = treeView1.SelectedNode.FullPath;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (treeView1.GetNodeCount(true) != 0)
                treeView1.SelectedNode.Toggle();
            
        }

        private void Form11_1_Load(object sender, EventArgs e)
        {

        }
    }
}
