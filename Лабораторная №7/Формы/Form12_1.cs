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
    public partial class Form12_1 : Form
    {
        /////////////Singleton///////////////
        private static readonly Form12_1 instance = new Form12_1();

        public static Form12_1 Instance
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
        static Form12_1()
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



        public Form12_1()
        {
            InitializeComponent();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            this.button1.DoDragDrop(button1, DragDropEffects.Move);
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Cursor = Cursors.Hand;
            this.button1.MouseDown += new MouseEventHandler(this.button1_MouseMove);
        }

        private void splitContainer1_Panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            label1.Text = "Отпустите кнопку";
            label2.Text = "Можете перетащить её сюда";

        }
        private void splitContainer1_Panel2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            label2.Text = "Отпустите кнопку";
            label1.Text = "Можете перетащить её сюда";

        }
        private void splitContainer1_Panel1_DragDrop(object sender, DragEventArgs e)
        {
            label1.Text = "Возьмите кнопку";
            this.button1.Parent = (Panel)sender;
            this.button1.Location = splitContainer1.Panel1.PointToClient(new Point(e.X, e.Y));
        }
        private void splitContainer1_Panel2_DragDrop(object sender, DragEventArgs e)
        {
            label2.Text = "Возьмите кнопку";
            label1.Text = "Можете перетащить её сюда";
            this.button1.Parent = (Panel)sender;
            this.button1.Location = splitContainer1.Panel2.PointToClient(new Point(e.X, e.Y));
        }

        private void splitContainer1_Panel1_DragLeave(object sender, EventArgs e)
        {
            label1.Text = "Можете перетащить её обратно";
        }

        private void splitContainer1_Panel2_DragLeave(object sender, EventArgs e)
        {
            label1.Text = "Можете перетащить её обратно";
        }
    }
}
