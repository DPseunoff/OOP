using System;
using LibModel;

namespace Курсовая_работа
{
    interface Command
    {
        void Execute(Model model);
    }
    class ConcreteCommand : Command
    {
        Char @operator;
        double operand1, operand2;
        public ConcreteCommand(char @operator, double operand1, double operand2)
        {
            this.@operator = @operator;
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        public void Execute(Model model)
        {
            model.Operation(@operator, operand1, operand2);
        }
    }
}
