using System;

namespace LibModel
{
    public class Model
    {
        private float x, y;
        Random random = new Random();
        public float X
        {
            set { x = value; }
            get { return x; }
        }
        public float Y
        {
            set { y = value; }
            get { return y; }
        }
        public void RandomXY()
        {

            double r = random.Next(0, 4);
            if (r == 0) x += 10;
            else if (r == 1) x -= 10;
            else if (r == 2) y += 10;
            else if (r == 3) y -= 10;

        }
        public void RandomXY8()
        {
            int choice = random.Next(0, 8);
            if (choice == 0)
            {
                x += 10;
            }
            else if (choice == 1)
            {
                x -= 10;
            }
            else if (choice == 2)
            {
                y += 10;
            }
            else if (choice == 3)
            {
                y -= 10;
            }
            else if (choice == 4)
            {
                x += 10;
                y += 10;
            }
            else if (choice == 5)
            {
                x -= 10;
                y += 10;
            }
            else if (choice == 6)
            {
                x -= 10;
                y -= 10;
            }
            else if (choice == 7)
            {
                x += 10;
                y -= 10;
            }
        }


        ///////////////////////////////
        public double result, Operand1, Operand2;
        public char @Operator;
        public void Operation(char @operator, double operand1, double operand2)
        {
            this.Operator = @operator;
            this.Operand1 = operand1;
            this.Operand2 = operand2;

            switch (@operator)
            {
                case '+':
                    result = operand1 + operand2;
                    break;
                case '-':
                    result = operand1 - operand2;
                    break;
                case '*':
                    result = operand1 * operand2;
                    break;
                case '/':
                    if (operand2 != 0)
                        result = operand1 / operand2;
                    break;
            }
        }
    }
}
