using System.Windows.Forms;

namespace Курсовая_работа
{
    public abstract class Worker
    {
        public Worker nextWorker { set; get; } = null;
        public abstract void Request(int option);
    }    
    public class W1: Worker
    {
        private RichTextBox t;
        private PictureBox p;
        public W1 (RichTextBox t, PictureBox p)
        {
            this.t = t;
            this.p = p;
        }
        public override void Request(int option)
        {
            if (option == 1)
            {
                p.Image = Properties.Resources._1_2;
                t.Text = "Оператор 1: Здравствуйте, этот вопрос по моей специальности. Средства внесены";
            }
            else if (nextWorker != null)
            {
                p.Image = Properties.Resources._1_3;
                t.Text = "Оператор 1: Извините, этот вопрос НЕ по моей специальности. Перенавправляю вас...";
                nextWorker.Request(option);
            }
        }
    }
    public class W2 : Worker
    {
        private RichTextBox t;
        private PictureBox p;
        public W2(RichTextBox t, PictureBox p)
        {
            this.t = t;
            this.p = p;
        }
        public override void Request(int option)
        {
            if (option == 2)
            {
                p.Image = Properties.Resources._2_2;
                t.Text = "Оператор 2: Здравствуйте, этот вопрос по моей специальности. Вывод средств совершён.";
            }
            else if (nextWorker != null)
            {
                p.Image = Properties.Resources._2_3;
                t.Text = "Оператор 2: Извините, этот вопрос НЕ по моей специальности. Перенавправляю вас...";
                nextWorker.Request(option);
            }
        }
    }
    public class W3 : Worker
    {
        private RichTextBox t;
        private PictureBox p;
        public W3(RichTextBox t, PictureBox p)
        {
            this.t = t;
            this.p = p;
        }
        public override void Request(int option)
        {
            if (option == 3)
            {
                p.Image = Properties.Resources._3_2;
                t.Text = "Оператор 3: Здравствуйте, этот вопрос по моей специальности. Перевод выполнен.";
            }
            else if (nextWorker != null)
            {
                p.Image = Properties.Resources._3_3;
                t.Text = "Оператор 3: Извините, этот вопрос НЕ по моей специальности. Перенаправляю вас...";
                nextWorker.Request(option);
            }
            //специальный цикл, не обязателен
            else
            {
                p.Image = Properties.Resources._3_3;
                t.Text = "Оператор 3: Извините, данный вопрос в банке не решаем...";
            }
        }
    }
}

