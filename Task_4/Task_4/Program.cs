//Для роботи з грошима у форматі: гривні, копійки створити структуру
//та функції, що дозволяють:
//a) вводити грошову суму з клавіатури (файлу);
//b) виводити грошову суму на екран (файл);
//c) знаходити суму / різницю двох грошових сум;
//d) переведення грошової суми у копійки та навпаки.
//2
//Створити приклад для демонстрації усіх функціональних
//можливостей.

using System;
using System.Text;
using System.Linq;
using System.IO;

namespace Task_4
{
    class Money
    {
        private ulong hrivna;
        public ulong Hrivna
        {
            get
            {
                return hrivna;
            }
            private set
            {
                hrivna = value;
            }
        }

        private ulong kopeyka;
        public ulong Kopeyka
        {
            get
            {
                return kopeyka;
            }
            private set
            {
                kopeyka = value;
            }
        }

        public Money()
        {
            hrivna = 0;
            kopeyka = 0;
        }
        public Money(ulong bill)
        {
            hrivna = bill;
            kopeyka = 0;
        }
        public Money(ulong bill, ulong coins)
        {
            hrivna = bill;
            kopeyka = coins;
        }



        public void InputMoney()
        {
            int selection;

            Console.WriteLine("Выберите тип ввода:\n1 - Ввод из файла;\n2 - Ввод из консоли.");
            while (true)
            {
                try
                {
                    Console.Write("Вы ввели: ");
                    selection = Convert.ToInt32(Console.ReadLine());
                    if (selection == 1 || selection == 2)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Такого варианта нет!");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            switch (selection)
            {
                case 1:
                    {
                        Console.WriteLine("Ввод из файла");
                    }
                    break;

                case 2:
                    {
                        Console.WriteLine("Ввод из консоли");
                    }
                    break;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;


            InputMoney();
            Money cash1 = new Money();
        }
    }
}