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
using System.IO;

namespace Task_4
{
    class Money
    {
        private long hrivna;
        private long kopeyka;
        public long Kopeyka
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
        public Money(long coins)
        {
            hrivna = 0;
            kopeyka = coins;
        }
        public Money(long bill, long coins)
        {
            hrivna = bill;
            kopeyka = coins;
            //kopeyka = (bill * 100) + coins;
        }





        public static Money[] InputMoney()
        {
            while (true)
            {
                int selection;
                string TextMoney1 = "";
                string TextMoney2 = "";
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
                            Console.WriteLine("Введите данные в файл в формате \"гривны.копейки, гривны.копейки\"");
                            string PathToFile = "C:/Users/Admin/Desktop/Money.txt";

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
                                        string[] TextFromFileArray = TextFromFile.Split(", ");
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
                            string[] TextFromConsoleArray = TextFromConsole.Split(", ");
                            TextMoney1 = TextFromConsoleArray[0];
                            TextMoney2 = TextFromConsoleArray[1];
                        }
                        break;
                }

                string[] arr1 = TextMoney1.Split('.');
                string[] arr2 = TextMoney2.Split('.');
                try
                {
                    long a1 = Convert.ToInt64(arr1[0]);
                    long a2 = Convert.ToInt64(arr1[1]);
                    long b1 = Convert.ToInt64(arr2[0]);
                    long b2 = Convert.ToInt64(arr2[1]);
                    if (a2 > 99 | a2 < -99)
                    {
                        while (true)
                        {
                            if (a2 < 99 & a2 > -99) { break; }
                            a2 = a2 / 10;

                        }

                    }
                    if (b2 > 99 | b2 < -99)
                    {
                        while (true)
                        {
                            if (b2 < 99 & b2 > -99) { break; }
                            b2 = b2 / 10;
                        }

                    }
                    if (a1 < 0)
                    {
                        a2 *= -1;
                    }
                    if (b1 < 0)
                    {
                        b2 *= -1;
                    }
                    Console.WriteLine($"CASH1    Гривнен: {a1}, копеек: {a2};");
                    Money cash1 = new Money(a1, a2);
                    Money cash2 = new Money(b1, b2);
                    Money[] outputMoneyArr = new Money[2];
                    outputMoneyArr[0] = cash1;
                    outputMoneyArr[1] = cash2;

                    return outputMoneyArr;
                }
                catch
                {
                    Console.WriteLine("Данные введены некорректно");
                    continue;
                }
            }
        }

        public void OutputMoney()
        {
            while (true)
            {
                int selection;
                Console.WriteLine("Выберите тип вывода:\n1 - Вывод в файл;\n2 - Вывод в консоль.");
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
                            Console.WriteLine("Вывод в файл");
                            Console.WriteLine("Вывод: C:/Users/Admin/Desktop/MoneyOut.txt");
                            string PathToFile = "C:/Users/Admin/Desktop/MoneyOut.txt";

                            string OutText = $"Гривнен: {hrivna}, копеек: {kopeyka};";
                            try
                            {
                                bool AdditionalRecording = false;
                                using (StreamWriter sw = new StreamWriter(PathToFile, AdditionalRecording, System.Text.Encoding.Unicode))
                                {
                                    sw.WriteLine(OutText);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        }
                        break;

                    case 2:
                        {
                            string OutText = $"Гривнен: {hrivna}, копеек: {kopeyka};";
                            Console.WriteLine($"Вывод в консоль: {OutText}");
                        }
                        break;

                }
                break;

            }
        }

        public static Money SumMoney(Money a, Money b)
        {
            a.ToCoin();
            b.ToCoin();
            long ab = a.kopeyka + b.kopeyka;
            Money c = new Money(ab);
            a.ToBillAndCoin();
            b.ToBillAndCoin();
            c.ToBillAndCoin();
            return c;
        }

        public static Money DifferenceMoney(Money a, Money b)
        {
            a.ToCoin();
            b.ToCoin();
            long ab = a.kopeyka - b.kopeyka;
            Money c = new Money(ab);
            a.ToBillAndCoin();
            b.ToBillAndCoin();
            c.ToBillAndCoin();
            return c;
        }
        public void ToCoin()
        {
            kopeyka += hrivna * 100;
            hrivna = 0;
        }

        public void ToBillAndCoin()
        {
            hrivna = kopeyka / 100;
            kopeyka = kopeyka % 100;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;


            //InputMoney();
            Money[] MoneyArr = Money.InputMoney();
            Money cash1 = MoneyArr[0];
            Money cash2 = MoneyArr[1];
            Money cash3 = Money.SumMoney(cash1, cash2);
            Money cash4 = Money.DifferenceMoney(cash1, cash2);
            //cash1.ToBillAndCoin();

            cash1.OutputMoney();
            cash2.OutputMoney();
            cash3.OutputMoney();
            cash4.OutputMoney();
            cash1.ToCoin();
            cash1.OutputMoney();
            cash1.ToBillAndCoin();
            cash1.OutputMoney();
        }
    }
}