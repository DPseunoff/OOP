using System;
using System.Windows.Forms;

//подключенная библиотека с моделью
using LibModel;

namespace Курсовая_работа
{
    class Controller
    {
        private Model model;
        private View view;
        public Controller()
        {
            model = new Model();
        }
        public Model Model
        {
            get { return model; }
        }
        
        public Form CreateView()
        {
            view = new View();
            return view;
        }

        //Invoker (User)
       // private Calculator calculator = new Calculator();
        public double getResult() { return Model.result; }
        Command command;
        public void Compute(char @operator, double operand1, double operand2)
        {
            command = new ConcreteCommand(@operator, operand1, operand2);
            command.Execute(this.model);
        }
    }
}
