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
    public partial class FacadeForm : Form
    {
        public FacadeForm()
        {
            InitializeComponent();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Facade.RunLab7();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            Facade.RunLab12D();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Facade.RunLab11T();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Facade.RunLab11V();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Facade.RunLab5();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Facade.RunLab13();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Facade.RunLab12C();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Facade.RunLab14();
        }
    }
}
