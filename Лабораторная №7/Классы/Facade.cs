using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace Курсовая_работа
{
    class Facade

    {
        static Lab_1 lab1 = new Lab_1();
        static Lab_5 lab5 = new Lab_5();
        static Lab_7 lab7 = new Lab_7();
        static Lab_8 lab8 = new Lab_8();
        static Lab_9 lab9 = new Lab_9();
        static Lab_11T lab11T = new Lab_11T();
        static Lab_11V lab11V = new Lab_11V();
        static Lab_12D lab12D = new Lab_12D();
        static Lab_12C lab12C = new Lab_12C();
        static Lab_13 lab13 = new Lab_13();
        static Lab_14 lab14 = new Lab_14();

        public static void RunLab1() { lab1.Run(); }
        public static void RunLab5() { lab5.Run(); }
        public static void RunLab7() { lab7.Run(); }
        public static void RunLab8() { lab8.Run(); }
        public static void RunLab9() { lab9.Run(); }
        public static void RunLab11T() { lab11T.Run(); }
        public static void RunLab11V() { lab11V.Run(); }
        public static void RunLab12D() { lab12D.Run(); }
        public static void RunLab12C() { lab12C.Run(); }
        public static void RunLab13() { lab13.Run(); }
        public static void RunLab14() { lab14.Run(); }

    }

    internal class Lab_1
    {
        public void Run()
        {
            string FName = "Лабораторная №1";
            string str = "C:\\Users\\pseun\\OneDrive\\Рабочий стол\\Лабы 3 сем\\ИСРППС\\Лабораторная №1\\Лабораторная №1\\bin\\Debug\\netcoreapp3.1";
            ProcessStartInfo stInfo = new ProcessStartInfo(str + "\\" + FName + ".exe");
            stInfo.CreateNoWindow = true;
            Process proc = new Process();
            proc.StartInfo = stInfo;
            try
            {
                proc.Start();
                //Ждем, пока запущен процесс
                proc.WaitForExit();
            }
            catch (System.ComponentModel.Win32Exception exc)
            {
                MessageBox.Show(exc.Message, "Win32Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ObjectDisposedException exc)
            {
                MessageBox.Show(exc.Message, "DisposedException", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException exc)
            {
                MessageBox.Show(exc.Message, "OperationException", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    internal class Lab_5
    {
        public void Run()
        {
            Form5 f = Form5.Instance;
            f.Show();
        }
    }
    internal class Lab_11T
    {
        public void Run()
        {
            Form11_1 f = Form11_1.Instance;
            f.Show();
        }
    }
    internal class Lab_7
    {
        public void Run()
        {
            Form7 f = Form7.Instance;
            f.Show();
        }
    }
    internal class Lab_8
    {
        public void Run()
        {
            Form8 f = Form8.Instance;
            f.Show();
        }
    }


    internal class Lab_9
    {
        public void Run()
        {
            Form9 f = Form9.Instance;
            f.Show();
        }
    }

    internal class Lab_11V
    {
        public void Run()
        {
            Form11_2 f = Form11_2.Instance;
            f.Show();
        }
    }
    internal class Lab_12D
    {
        public void Run()
        {
            Form12_1 f = Form12_1.Instance;
            f.Show();
        }
    }
    internal class Lab_12C
    {
        public void Run()
        {
            Form12_2 f = Form12_2.Instance;
            f.Show();
        }
    }
    internal class Lab_13
    {
        public void Run()
        {
            Form13 f = Form13.Instance;
            f.Show();
        }
    }
    internal class Lab_14
    {
        public void Run()
        {
            Form14 f = Form14.Instance;
            f.Show();
        }
    }
}
