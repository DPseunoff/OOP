using System;
using System.Windows.Forms;

namespace Курсовая_работа
{
    public partial class Form7 : Form
    {

        /////////////Singleton///////////////
        private static readonly Form7 instance = new Form7();

        public static Form7 Instance
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
        static Form7()
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



        public void Action1() 
        {
            pictureBox1.Image = Properties.Resources._1_2;
        }
        public Form7()
        {
            if (MessageBox.Show("Вы звоните в банк, хотите продолжить?", "Звонок", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                InitializeComponent();
            }
            else
            {
                MessageBox.Show("Спасибо за звонок", "Звонок", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = Properties.Resources._1_2;
        }
        public void WorkersOn(int option)
        {
            Worker w1 = new W1(richTextBox2, pictureBox1);
            Worker w2 = new W2(richTextBox3, pictureBox2);
            Worker w3 = new W3(richTextBox4, pictureBox3);
            w1.nextWorker = w2;
            w2.nextWorker = w3;
            w1.Request(option);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            WorkersOn(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WorkersOn(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkersOn(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WorkersOn(4);
        }
    }
}
