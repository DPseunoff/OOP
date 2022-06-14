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
    public partial class Form5 : Form
    {
        /////////////Singleton///////////////
        private static readonly Form5 instance = new Form5();

        public static Form5 Instance
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
        static Form5()
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


        Client client;
        public Form5()
        {
            AbstractFactory SberBank = new ConcreteBank1();
            AbstractFactory TinkOff = new ConcreteBank2();
            Client client = new Client(SberBank, TinkOff);
            this.client = client;
            InitializeComponent();
            refresh();
            label16.Text = "Тип: " + client.ClientCardA1.GetType().Name;
            label17.Text = "Тип: " + client.ClientCardB1.GetType().Name;
            label18.Text = "Тип: " + client.ClientCardA2.GetType().Name;
            label19.Text = "Тип: " + client.ClientCardB2.GetType().Name;
        }
        public void refresh()
        {
            textBox1.Text = client.ClientCardA1.balance.ToString();
            textBox2.Text = client.ClientCardB1.balance.ToString();
            textBox3.Text = client.ClientCardA2.balance.ToString();
            textBox4.Text = client.ClientCardB2.balance.ToString();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                client.ClientCardA1.balance += Convert.ToInt32(textBox5.Text);
                refresh();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                client.ClientCardA2.balance += Convert.ToInt32(textBox6.Text);
                refresh();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                client.ClientCardB1.balance += Convert.ToInt32(textBox7.Text);
                refresh();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                client.ClientCardB2.balance += Convert.ToInt32(textBox8.Text);
                refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                client.transaction_BtoB_tocardA2(Convert.ToInt32(textBox9.Text));
                refresh();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                client.transaction_BtoB_tocardA1(Convert.ToInt32(textBox9.Text));
                refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                client.transaction_BtoB_tocardB2(Convert.ToInt32(textBox9.Text));
                refresh();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                client.transaction_BtoB_tocardB1(Convert.ToInt32(textBox9.Text));
                refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                client.transaction_CtoC_tocardB1(Convert.ToInt32(textBox9.Text));
                refresh();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                client.transaction_CtoC_tocardA1(Convert.ToInt32(textBox9.Text));
                refresh();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                client.transaction_CtoC_tocardB2(Convert.ToInt32(textBox9.Text));
                refresh();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                client.transaction_CtoC_tocardA2(Convert.ToInt32(textBox9.Text));
                refresh();
            }
        }
    }
}
