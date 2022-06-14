using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_работа
{
    // интерфейс фабрик
    public interface AbstractFactory
    {
        AbstractCardA CreateCardA();
        AbstractCardB CreateCardB();
    }
    //фабрика 1 (банк 1)
    class ConcreteBank1 : AbstractFactory
    {
        public AbstractCardA CreateCardA()
        {
            return new ConcreteCardA1();
        }
        public AbstractCardB CreateCardB()
        {
            return new ConcreteCardB1();
        }
    }
    //фабрика 2 (банк 2)
    class ConcreteBank2 : AbstractFactory
    {
        public AbstractCardA CreateCardA()
        {
            return new ConcreteCardA2();
        }
        public AbstractCardB CreateCardB()
        {
            return new ConcreteCardB2();
        }
    }

    //интерфейс для продукта первой фабрики и классы продуктов
    public interface AbstractCardA
    {
        int balance { get; set; }
    }
    class ConcreteCardA1 : AbstractCardA
    {
        public int balance
        {
            get; set;
        }
    }
    class ConcreteCardA2 : AbstractCardA
    {
        public int balance
        {
            get; set;
        }
    }

    //интерфейс для продукта второй фабрики и классы продуктов
    public interface AbstractCardB
    {
        int balance { get; set; }
    }
    class ConcreteCardB1 : AbstractCardB
    {
        public int balance
        {
            get; set;
        }
    }
    class ConcreteCardB2 : AbstractCardB
    {
        public int balance
        {
            get; set;
        }
    }

    class Client
    {
        //первый тип (два банка)
        public AbstractCardA ClientCardA1;
        public AbstractCardA ClientCardA2;

        //второй тип (два банка)
        public AbstractCardB ClientCardB1;
        public AbstractCardB ClientCardB2;

        public Client(AbstractFactory factory1, AbstractFactory factory2)
        {
            this.ClientCardA1 = factory1.CreateCardA();
            this.ClientCardB1 = factory1.CreateCardB();

            this.ClientCardA2 = factory2.CreateCardA();
            this.ClientCardB2 = factory2.CreateCardB();

            this.ClientCardA1.balance = 0;
            this.ClientCardA2.balance = 0;
            this.ClientCardB1.balance = 0;
            this.ClientCardB2.balance = 0;

        }


        //методы переводов между картами банка
        public void transaction_CtoC_tocardA1(int a)
        {
            this.ClientCardA1.balance += a;
            this.ClientCardB1.balance -= a;
        }
        public void transaction_CtoC_tocardA2(int a)
        {
            this.ClientCardA2.balance += a;
            this.ClientCardB2.balance -= a;
        }
        public void transaction_CtoC_tocardB1(int a)
        {
            this.ClientCardB1.balance += a;
            this.ClientCardA1.balance -= a;
        }
        public void transaction_CtoC_tocardB2(int a)
        {
            this.ClientCardB2.balance += a;
            this.ClientCardA2.balance -= a;
        }

        //методы переводов между картами банков
        public void transaction_BtoB_tocardA1(int a)
        {
            this.ClientCardA1.balance += a;
            this.ClientCardA2.balance -= a;
        }
        public void transaction_BtoB_tocardA2(int a)
        {
            this.ClientCardA2.balance += a;
            this.ClientCardA1.balance -= a;
        }
        public void transaction_BtoB_tocardB1(int a)
        {
            this.ClientCardB1.balance += a;
            this.ClientCardB2.balance -= a;
        }
        public void transaction_BtoB_tocardB2(int a)
        {
            this.ClientCardB2.balance += a;
            this.ClientCardB1.balance -= a;
        }
    }
}
