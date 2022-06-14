using System;
using System.Drawing;
using System.Windows.Forms;

namespace Курсовая_работа
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
            controller = new Controller();
            Bitmap bt = new Bitmap(1000, 1000);
            DrawAxesAtStart(bt);
            pausebutton.Enabled = false;
            continuebutton.Enabled = false;
            radioButton1.Checked = true;
        }

        ///////////АТРИБУТЫ///////////
        float a, b;
        int k, f = 0;
        Controller controller;
        Pen pen = new Pen(Color.Black, 1.25F);
        Pen pen1 = new Pen(Color.Black);
        Bitmap bt = new Bitmap(1000, 1000);
        //////////////////////////////


        ////////////////////КНОПКИ//////////////////////
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            pen1.Color = colorDialog1.Color;
        }
        private void playbutton_Click(object sender, EventArgs e)
        {
            StartDrawing();
        }
        private void continuebutton_Click(object sender, EventArgs e)
        {
            ContinueDrawing();
        }
        private void pausebutton_Click(object sender, EventArgs e)
        {
            PauseDrawing();
        }
        private void stopbutton_Click(object sender, EventArgs e)
        {
            StopDrawing();
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void lightRedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorizeBackground(0);
        }
        private void lightBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorizeBackground(1);
        }
        private void lightGreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorizeBackground(2);
        }
        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorizeBackground(3);
        }
        private void nightModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorizeBackground(4);
        }
        ///////////////////////////////////////////////////


        //////////////////////МЕТОДЫ///////////////////////
        public void StartDrawing()  //начало отрисовки
        {
            try
            {
                int n = Convert.ToInt32(number.Text); //колво шагов
            }
            catch
            {
                MessageBox.Show("Введите количество шагов!");
                return;
            }
            f = 1;
            toolStripProgressBar1.Value = 0;
            pen1.Width = Convert.ToInt32(toolStripComboBox1.Text);
            pausebutton.Enabled = true;
            //задание начальной координаты
            controller.Model.X = 335;           // <----обращение к данным модели
            controller.Model.Y = 218;
            a = 335; b = 218; k = 0;
            timer1.Interval = -trackBar1.Value;
            timer2.Interval = -trackBar1.Value * Convert.ToInt32(number.Text) / 10;
            timer1.Enabled = true;
            timer2.Enabled = true;
            playbutton.Enabled = false;
            toolStripStatusLabel1.Text = "Процесс выполняется...";
        }

        public void ContinueDrawing()   //продолжить отрисовку
        {
            if (timer1.Enabled == false && pausebutton.Enabled == false)
            {
                pen1.Width = Convert.ToInt32(toolStripComboBox1.Text);
                continuebutton.Enabled = false;
                pausebutton.Enabled = true;
                timer1.Interval = -trackBar1.Value;
                timer1.Enabled = true;
                timer2.Interval = -trackBar1.Value * Convert.ToInt32(number.Text) / 10;
                timer2.Enabled = true;
                toolStripStatusLabel1.Text = "Процесс выполняется...";
            }
        }

        public void PauseDrawing()      //пауза отрисовки
        {
            continuebutton.Enabled = true;
            pausebutton.Enabled = false;
            timer1.Enabled = false;
            timer2.Enabled = false;
            toolStripStatusLabel1.Text = "Пауза";
        }

        public void StopDrawing()       //конец отрисовки, стирание
        {
            f = 0;
            timer1.Enabled = false;
            timer2.Enabled = false;
            pausebutton.Enabled = false;
            continuebutton.Enabled = false;
            Bitmap bt = new Bitmap(1000, 1000);
            pictureBox1.Image = null;
            DrawAxesAtStart(bt);
            playbutton.Enabled = true;
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel1.Text = "Ожидание запуска";
        }

        public void DrawAxes(Bitmap bt)      //отрисовка осей
        {
            pictureBox1.CreateGraphics().DrawLine(pen, 30, 218, 640, 218);
            pictureBox1.CreateGraphics().DrawLine(pen, 335, 30, 335, 406);
            pictureBox1.CreateGraphics().DrawLine(pen, 640, 218, 630, 213);
            pictureBox1.CreateGraphics().DrawLine(pen, 640, 218, 630, 223);
            pictureBox1.CreateGraphics().DrawLine(pen, 335, 30, 330, 40);
            pictureBox1.CreateGraphics().DrawLine(pen, 335, 30, 340, 40);
            int x = 35;
            int y = 38;
            for (int i = 0; i < 13; i++)
            {
                pictureBox1.CreateGraphics().DrawLine(pen, 334, y, 336, y);
                y += 30;
            }
            for (int i = 0; i < 20; i++)
            {
                pictureBox1.CreateGraphics().DrawLine(pen, x, 217, x, 219);
                x += 30;
            }
        }

        public void DrawAxesAtStart(Bitmap bt)      //отрисовка осей перед работой алгоритма
        {
            Graphics g = Graphics.FromImage(bt);
            pictureBox1.Image = bt;
            g.DrawLine(pen, 30, 218, 640, 218);
            g.DrawLine(pen, 335, 30, 335, 406);
            g.DrawLine(pen, 640, 218, 630, 213);
            g.DrawLine(pen, 640, 218, 630, 223);
            g.DrawLine(pen, 335, 30, 330, 40);
            g.DrawLine(pen, 335, 30, 340, 40);
            int x = 35;
            int y = 38;
            for (int i = 0; i < 13; i++)
            {
                g.DrawLine(pen, 334, y, 336, y);
                y += 30;
            }
            for (int i = 0; i < 20; i++)
            {
                g.DrawLine(pen, x, 217, x, 219);
                x += 30;
            }
        }

        public void ColorizeBackground(int i)
        {
            if (f == 0)
            {
                Bitmap bt = new Bitmap(1000, 1000);
                pictureBox1.Image = null;
                if (i == 0)
                {
                    pictureBox1.BackColor = Color.Pink;
                    pen.Color = Color.Black;
                }
                else if (i == 1)
                {
                    pictureBox1.BackColor = Color.LightBlue;
                    pen.Color = Color.Black;
                }
                else if (i == 2)
                {
                    pictureBox1.BackColor = Color.LightGreen;
                    pen.Color = Color.Black;
                }
                else if (i == 3)
                {
                    pictureBox1.BackColor = Color.White;
                    pen.Color = Color.Black;
                }
                else if (i == 4)
                {
                    pictureBox1.BackColor = Color.Black;
                    pen.Color = Color.White;
                }
                DrawAxesAtStart(bt);
            }
            else return;
        }
        ///////////////////////////////////////////////////


        //////////////////////ТАЙМЕРЫ///////////////////////
        private void timer1_Tick(object sender, EventArgs e)    //шаг отрисовки
        {
            if (radioButton1.Checked == true)
                controller.Model.RandomXY();            //< ----обращение к данным модели
            else if (radioButton2.Checked == true)
                controller.Model.RandomXY8();
            pictureBox1.CreateGraphics().DrawLine(pen1, a, b, controller.Model.X, controller.Model.Y);
            a = controller.Model.X;
            b = controller.Model.Y;
            k++;
            if (k == Convert.ToInt32(number.Text))
            {
                timer1.Stop();
                timer2.Stop();
                playbutton.Enabled = true;
                pausebutton.Enabled = false;
                toolStripStatusLabel1.Text = "Готово";
                f = 0;
                toolStripProgressBar1.Value = 100;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)       //прогресс
        {
            toolStripProgressBar1.PerformStep();
        }
        /////////////////////////////////////////////////////


        ////////////////////FACADE WORKING///////////////////
        private void abstractFactoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facade.RunLab5();
        }
        private void chainsOfResponsibilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facade.RunLab7();
        }
        private void treeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facade.RunLab11T();
        }
        private void listViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facade.RunLab11V();
        }
        private void dragAndDropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facade.RunLab12D();
        }
        private void clipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facade.RunLab12C();
        }
        private void textAndClipBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facade.RunLab9();
        }
        private void обработкаИсключенийПреобразованиеТиповToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facade.RunLab1();
        }
        private void commandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facade.RunLab8();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void rotateAndBitmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facade.RunLab14();
        }
        private void linesCurvesBezierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facade.RunLab13();
        }
        /////////////////////////////////////////////////////
    }
}
