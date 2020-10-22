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
            kopeyka = 0;
        }
        public Money(ulong coins)
        {
            kopeyka = coins;
        }
        public Money(ulong bill, ulong coins)
        {
            kopeyka = (bill * 100) + coins;
        }

    }
    class Program
    {
        public static void InputMoney()
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
            string TextMoney1;
            string TextMoney2;

            switch (selection)
            {
                case 1:
                    {
                        Console.WriteLine("Ввод из файла");
                        Console.WriteLine("Введите данные в файл в формате \"гривны.копейки, гривны.копейки\"");
                        string PathToFile = "C:/Users/Admin/Desktop/Money.txt";

                        //string text = "kuku";
                        //try
                        //{
                        //    bool AdditionalRecording = false;
                        //    using (StreamWriter sw = new StreamWriter(PathToFile, AdditionalRecording, System.Text.Encoding.Unicode))
                        //    {
                        //        sw.WriteLine(text);
                        //    }
                        //}
                        //catch (Exception e)
                        //{
                        //    Console.WriteLine(e.Message);
                        //}

                        while (true)
                        {
                            if (!File.Exists(PathToFile))
                            {
                                Console.WriteLine("Файл не найден, создайте файл Money.txt на рабочем столе!");
                                Console.WriteLine("Нажмите \"Enter\", если изменили файл");
                                Console.ReadLine();
                                continue;
                            }
                            else
                            {
                                string TextFromFile = File.ReadAllText(PathToFile);
                                if (TextFromFile == "")
                                {
                                    Console.WriteLine($"Файл {Path.GetFileName(PathToFile)} пустой, введите в него данные!");
                                    Console.WriteLine("Нажмите \"Enter\", если изменили файл");
                                    Console.ReadLine();
                                    continue;
                                }
                                try
                                {
                                    string[] TextFromFileArray = TextFromFile.Split(' ');
                                    TextMoney1 = TextFromFileArray[0];
                                    TextMoney2 = TextFromFileArray[1];
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Вы не правильно ввели данные: {ex.Message}");
                                }

                                break;
                            }

                        }
                        Console.WriteLine("Файл принят");

                    }
                    break;

                case 2:
                    {
                        Console.WriteLine("Ввод из консоли");
                        Console.WriteLine("Введите данные в файл в формате \"гривны.копейки, гривны.копейки\"");
                        Console.Write("Ввод: ");
                        string TextFromConsole = Console.ReadLine();

                    }
                    break;
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;


            InputMoney();
            Money cash1 = new Money();
        }
    }
}