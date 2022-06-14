using System;
using System.Windows.Forms;

namespace Курсовая_работа
{
    public partial class Form8 : Form
    {
        /////////////Singleton///////////////
        private static readonly Form8 instance = new Form8();

        public static Form8 Instance
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
        static Form8()
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


        public Form8()
        {
            InitializeComponent();
        }


        Controller controller = new Controller();
        char @operator;

        private void button1_Click(object sender, EventArgs e)
        {
            @operator = '+';
            try
            {
                controller.Compute(@operator, Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
            }
            catch { MessageBox.Show("Введите оба числа"); }
            textBox3.Text = controller.getResult().ToString();
            label1.Text = "+";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            @operator = '-';
            try
            {
                controller.Compute(@operator, Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
            }
            catch { MessageBox.Show("Введите оба числа"); }
            textBox3.Text = controller.getResult().ToString();
            label1.Text = " -";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            @operator = '*';
            try
            {
                controller.Compute(@operator, Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
            }
            catch { MessageBox.Show("Введите оба числа"); }
            textBox3.Text = controller.getResult().ToString();
            label1.Text = " *";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            @operator = '/';
            try
            {
                controller.Compute(@operator, Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
            }
            catch { MessageBox.Show("Введите оба числа"); }
            textBox3.Text = controller.getResult().ToString();
            label1.Text = " /";
        }
    }
}
