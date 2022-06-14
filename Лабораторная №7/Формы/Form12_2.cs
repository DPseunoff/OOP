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
    delegate double GetDistance(int x1, int y1, int x2, int y2);

    public partial class Form12_2 : Form
    {
        /////////////Singleton///////////////
        private static readonly Form12_2 instance = new Form12_2();

        public static Form12_2 Instance
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
        static Form12_2()
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







        //прямоугольник области
        private Rectangle clip = new Rectangle(0, 0, 100, 100);
        public Form12_2()
        {
            InitializeComponent();
        }

        //загрузка исходной картинки
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult ofd = this.openFileDialog1.ShowDialog();
            if (ofd == DialogResult.OK)
            {
                try
                {
                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                }
                catch (Exception) { MessageBox.Show("Файл не подходит"); }
            }
        }
        //сохранение обрезанной картинки
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.saveFileDialog1.ShowDialog();
            switch (dr)
            {
                case DialogResult.OK:
                    try
                    {
                        Bitmap bt = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                        pictureBox2.DrawToBitmap(bt, pictureBox2.ClientRectangle);
                    }
                    catch (InvalidOperationException exc)
                    {
                        MessageBox.Show(exc.Message, "Error");
                        return;
                    }
                    break;
            }
        }

        //создание картинки-клипа
        private Image ClipImage(Image orig, Rectangle clip)
        {
            Bitmap bt = new Bitmap(clip.Width, clip.Height);
            using (Graphics g = Graphics.FromImage(bt))
            {
                g.DrawImage(orig, new Rectangle(0, 0, clip.Width, clip.Height), clip, GraphicsUnit.Pixel);
            }
            return (Image)bt;
        }

        //отрисовка клипа
        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
                pictureBox2.Image = ClipImage(pictureBox1.Image, clip) ;
        }

        //использование прямоугольника мышью
        GetDistance getDistance = (x1, y1, x2, y2) => Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        int distRect = 10;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //изменение размера
                if (getDistance(e.Location.X, e.Location.Y, clip.Left, clip.Top) <= distRect)
                {
                    clip.Width = Math.Abs(clip.Width + clip.X - e.Location.X);
                    clip.Height = Math.Abs(clip.Height + clip.Y - e.Location.Y);
                    clip.X = e.Location.X;
                    clip.Y = e.Location.Y;
                }
                else if (getDistance(e.Location.X, e.Location.Y, clip.Right, clip.Top) <= distRect)
                {
                    clip.Width = Math.Abs(e.Location.X - clip.X);
                    clip.Height = Math.Abs(clip.Height + clip.Y - e.Location.Y);
                    clip.Y = e.Location.Y;
                }
                else if (getDistance(e.Location.X, e.Location.Y, clip.Left, clip.Bottom) <= distRect)
                {
                    clip.Width = Math.Abs(clip.Width + clip.X - e.Location.X);
                    clip.Height = Math.Abs(e.Location.Y - clip.Y);
                    clip.X = e.Location.X;
                }
                else if (getDistance(e.Location.X, e.Location.Y, clip.Right, clip.Bottom) <= distRect)
                {
                    clip.Height = Math.Abs(e.Location.Y - clip.Y);
                    clip.Width = Math.Abs(e.Location.X - clip.X);
                }


                //меняем положение
                else if (clip.Contains(e.Location))
                {
                    clip.X = e.Location.X - (clip.Width / 2);
                    clip.Y = e.Location.Y - (clip.Height / 2);
                }
            }
            this.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Red, clip);
        }
    }
}
