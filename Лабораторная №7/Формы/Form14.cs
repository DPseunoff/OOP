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
    public partial class Form14 : Form
    {
        /////////////Singleton///////////////
        private static readonly Form14 instance = new Form14();

        public static Form14 Instance
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
        static Form14()
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




        private float angle = 0;
        private Bitmap image = null;
        public Form14()
        {
            InitializeComponent();
        }

        //загрузка изображения
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult ofd = this.openFileDialog1.ShowDialog();
            if (ofd == DialogResult.OK)
            {
                try
                {
                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();
                    image = new Bitmap(openFileDialog1.FileName);
                    pictureBox1.Image = (Bitmap)image.Clone();
                }
                catch (Exception) { MessageBox.Show("Файл не подходит"); }
            }
        }
        
        //поворот с помощью битмапа
        public void Rotate(PictureBox p, Bitmap i, int a)
        {
            if (i == null || p.Image == null)
                return;
            if (a == 0)
                i.RotateFlip(RotateFlipType.Rotate90FlipNone);
            if (a == 1)
                i.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox1.Image.Dispose();
            pictureBox1.Image = (Bitmap)image.Clone();

        }

        //поворот скролингом
        public static Image RotateImage(Image img, float rotationAngle)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            gfx.DrawImage(img, new Point(0, 0));
            gfx.Dispose();
            return bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = 0;
            Rotate(pictureBox1, image, a);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = 1;
            Rotate(pictureBox1, image, a);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            angle = -vScrollBar1.Value * 10;
            pictureBox1.Image = null;
            pictureBox1.Image = RotateImage((Image)image, angle);
        }
    }
}