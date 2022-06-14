using System;
using System.Drawing;
using System.Windows.Forms;

namespace Курсовая_работа
{
    public partial class Form13 : Form
    {

        /////////////Singleton///////////////
        private static readonly Form13 instance = new Form13();

        public static Form13 Instance
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
        static Form13()
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

        ColorDialog clrdlg = new ColorDialog();
        Pen p;
        //параметры рисованных объектов
        Point[,] line = new Point[200, 2];
        int line_rec = 0;

        Point[,] poly = new Point[200, 200];
        int[] poly_p = new int[200];
        int poly_rec = 0;

        int[,] ell = new int[200, 4];
        bool[] ell_f = new bool[200];
        int ell_rec = 0;

        Point[,] bez = new Point[200, 4];
        int bez_p = 0;
        int bez_rec = 0;

        int type = 0;
        bool is_drawing = false;
        Graphics g;

        //создание делегата для патерна Delegate
        delegate void AddDelegate(MouseEventArgs e);
        private AddDelegate operation;

        public Form13()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            clrdlg.Color = Color.Black;
            p = new Pen(clrdlg.Color, 2.0f);
            panel2.BackColor = clrdlg.Color;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Draw();
        }


        //метод отрисовки всего
        public void Draw()
        {
            g = panel1.CreateGraphics();
            g.Clear(Color.White);
            //отрисовка линий
            for (int i = 0; i < line_rec; i++)
                g.DrawLine(p, line[i, 0], line[i, 1]);
            //отрисовка кривых
            for (int i = 0; i < poly_rec; i++)
            {
                for (int j = 0; j + 1 < poly_p[i]; j++)
                    g.DrawLine(p, poly[i, j], poly[i, j + 1]);
            }
            //отрисовка элипсов и их заполнение
            for (int i = 0; i < ell_rec; i++)
            {
                if (ell_f[i] == true)
                    g.FillEllipse(new SolidBrush(clrdlg.Color), ell[i, 0] - ell[i, 2], ell[i, 1] - ell[i, 3], 2 * ell[i, 2], 2 * ell[i, 3]);
                else g.DrawEllipse(p, ell[i, 0] - ell[i, 2], ell[i, 1] - ell[i, 3], 2 * ell[i, 2], 2 * ell[i, 3]);
            }
            //отрисовка кривых Безье
            for (int i = 0; i < bez_rec; i++)
            {
                g.DrawBezier(p, bez[i, 0], bez[i, 1], bez[i, 2], bez[i, 3]);
            }

        }


        //методы начала отрисовки фигур (используются с Delegate паттерном)
        public void StartDrawLine(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && is_drawing == false)
            {
                if (type == 0 && line_rec < 200)
                {
                    is_drawing = true;
                    line_rec++;
                    line[line_rec - 1, 0] = new Point(e.X, e.Y);//(e.X-110, e.Y-10);
                    line[line_rec - 1, 1] = new Point(e.X, e.Y);
                    Draw();
                }
            }
        }
        public void StartDrawCurve(MouseEventArgs e)
        {
            if (is_drawing == false && poly_rec < 100)
            {
                is_drawing = true;
                poly_rec++;
                poly_p[poly_rec - 1] = 2;
                poly[poly_rec - 1, 0] = new Point(e.X, e.Y);
                poly[poly_rec - 1, poly_p[poly_rec - 1] - 1] = new Point(e.X, e.Y);
                Draw();
            }
            else if (is_drawing == true)
            {
                if (e.Button == MouseButtons.Right)
                    is_drawing = false;
                if (e.Button == MouseButtons.Left)
                {
                    if (poly_p[poly_rec - 1] < 200)
                    {
                        poly[poly_rec - 1, poly_p[poly_rec - 1] - 1] = new Point(e.X, e.Y);
                        poly_p[poly_rec - 1]++;
                        poly[poly_rec - 1, poly_p[poly_rec - 1] - 1] = new Point(e.X, e.Y);
                    }
                    else is_drawing = false;
                }
            }
        }
        public void StartDrawEllipse(MouseEventArgs e)
        {
            if (is_drawing == false && ell_rec < 100)
            {
                is_drawing = true;
                ell_rec++;
                ell_f[ell_rec - 1] = checkBox1.Checked;
                ell[ell_rec - 1, 0] = e.X;
                ell[ell_rec - 1, 1] = e.Y;
                ell[ell_rec - 1, 2] = 10;
                ell[ell_rec - 1, 3] = 10;
                Draw();
            }
            else if (is_drawing == true)
            {
                is_drawing = false;
            }
        }
        public void StartDrawBezier(MouseEventArgs e)
        {
            if (is_drawing == false && bez_rec < 100)
            {
                is_drawing = true;
                bez_rec++;
                bez[bez_rec - 1, 0] = new Point(e.X, e.Y);
                bez[bez_rec - 1, 1] = new Point(e.X + 10, e.Y + 25);
                bez[bez_rec - 1, 2] = new Point(e.X + 25, e.Y + 10);
                bez[bez_rec - 1, 3] = new Point(e.X, e.Y);
                bez_p = 1;
                Draw();
            }
            else if (is_drawing == true)
            {
                bez[bez_rec - 1, bez_p] = new Point(e.X, e.Y);
                bez_p++;
                if (bez_p == 4) { is_drawing = false; bez_p = 0; }
                Draw();
            }
        } 




        //начало рисования кривой, Безье или Эллипса
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            this.operation(e);
        }
        //процесс рисования прямой, пока ЛКМ зажата
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.operation(e);
        }


        //наведение координат
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_drawing)
            {
                if (type == 0)
                {
                    line[line_rec - 1, 1] = new Point(e.X, e.Y);
                    Draw();
                }
                if (type == 1)
                {
                    poly[poly_rec - 1, poly_p[poly_rec - 1] - 1] = new Point(e.X, e.Y);
                    Draw();
                }
                if (type == 2)
                {
                    ell[ell_rec - 1, 2] = Math.Abs(ell[ell_rec - 1, 0] - e.X);
                    ell[ell_rec - 1, 3] = Math.Abs(ell[ell_rec - 1, 1] - e.Y);
                    Draw();
                }
                if (type == 3)
                {
                    bez[bez_rec - 1, bez_p] = new Point(e.X, e.Y);
                    Draw();
                }
            }
        }
        //окончание процесса рисования (ЛКМ отпущена)
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (is_drawing)
            {
                if (type == 0)
                {
                    is_drawing = false;
                }
            }
        }


        //что рисуем (используется паттерн Delegate)
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Enabled == true)
            {
                this.operation = StartDrawLine;
                type = 0;
            }
            is_drawing = false;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Enabled == true)
            {
                this.operation = StartDrawCurve;
                type = 1;
            }
            is_drawing = false;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Enabled == true)
            {
                this.operation = StartDrawBezier;
                type = 3;
            }
            is_drawing = false;
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Enabled == true)
            {
                this.operation = StartDrawEllipse;
                type = 2;
            }
            is_drawing = false;
        }


        //стереть
        private void button1_Click(object sender, EventArgs e)
        {
            line_rec = 0;
            poly_rec = 0;
            ell_rec = 0;
            bez_rec = 0;
            is_drawing = false;
            Draw();
        }

        //выбор цвета
        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            clrdlg.ShowDialog();
            p = new Pen(clrdlg.Color, 2.0f);
            panel2.BackColor = clrdlg.Color;
            Draw();
        }
    }
}
