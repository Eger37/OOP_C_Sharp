//Для роботи з прямокутниками на площині, створити структуру та
//функції, що дозволяють:
//a) вводити координати прямокутника з клавіатури (файлу);
//b) виводити координати прямокутника на екран (файл);
//c) знаходити площу / периметр прямокутника;
//d) радіусів вписаної та описаної окружностей.
//Створити приклад для демонстрації усіх функціональних
//можливостей.


using System;
using System.Text;
using System.IO;

namespace Task_4
{
    class Rectangles
    {
        private int[] coordinate1;
        private int[] coordinate2;
        private int[] coordinate3;
        private int[] coordinate4;

        public int[] Coordinate1
        {
            get
            {
                return coordinate1;
            }
            private set
            {
                coordinate1 = value;
            }
        }
        public int[] Coordinate2
        {
            get
            {
                return coordinate2;
            }
            private set
            {
                coordinate1 = value;
            }
        }
        public int[] Coordinate3
        {
            get
            {
                return coordinate3;
            }
            private set
            {
                coordinate1 = value;
            }
        }
        public int[] Coordinate4
        {
            get
            {
                return coordinate4;
            }
            private set
            {
                coordinate1 = value;
            }
        }

        public Rectangles()
        {
            coordinate1 = new int[] { 0, 0 };
            coordinate2 = new int[] { 0, 0 };
            coordinate3 = new int[] { 0, 0 };
            coordinate4 = new int[] { 0, 0 };
        }
        public Rectangles(int[] c)
        {
            coordinate1 = new int[] { 0, 0 };
            coordinate2 = new int[] { 0, c[1] };
            coordinate3 = c;
            coordinate4 = new int[] { c[0], 0 };
        }
        public Rectangles(int[] a, int[] c)
        {
            coordinate1 = a;
            coordinate2 = new int[] { a[0], c[1] };
            coordinate3 = c;
            coordinate4 = new int[] { c[0], a[1] };
        }

        public Rectangles(int[] a, int[] b, int[] c, int[] d)
        {
            if (a[0] == b[0] & a[1] == d[1] & c[0] == d[0] & b[1] == c[1])
            {
                coordinate1 = a;
                coordinate2 = b;
                coordinate3 = c;
                coordinate4 = d;
            }
            else
            {
                Console.WriteLine("Координаты введены неправильно, строю прямоугольник за вас");
                coordinate1 = a;
                coordinate2 = new int[] { a[0], c[1] };
                coordinate3 = c;
                coordinate4 = new int[] { c[0], a[1] };
            }

        }

        public static Rectangles InputCoordinates()
        {

            while (true)
            {
                int selection;
                string TextCoordinates = "";
                Console.WriteLine("Выберите тип ввода:\n1 - Ввод из файла;\n2 - Ввод из консоли.");
                //choose
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
                            Console.WriteLine("Запишите координаты в файл в формате \"x,y x,y x,y x,y\"");
                            Console.WriteLine("Если вводите все четыре координаты, то в правильной очерёдности.");
                            Console.WriteLine("Ввод трёх координат не поддерживается");

                            //Console.WriteLine("Можете ввести 1, 2, 3 или все четыре координаты, но в правильной очерёдности");
                            string PathToFile = "C:/Users/Admin/Desktop/Coordinates.txt";

                            while (true)
                            {
                                if (!File.Exists(PathToFile))
                                {
                                    Console.WriteLine("Файл не найден, создайте файл Coordinates.txt на рабочем столе!");
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
                                        string[] TextFromFileArray = TextFromFile.Split(" ");
                                        if (TextFromFileArray.Length == 1)
                                        {
                                            string c = TextFromFileArray[0];
                                            string[] stringDots = c.Split(",");
                                            int[] intDots = Array.ConvertAll(stringDots, int.Parse);

                                            return new Rectangles(intDots);
                                        }
                                        if (TextFromFileArray.Length == 2)
                                        {
                                            string a = TextFromFileArray[0];
                                            string[] stringDotsA = a.Split(",");
                                            int[] intDotsA = Array.ConvertAll(stringDotsA, int.Parse);
                                            string c = TextFromFileArray[1];
                                            string[] stringDotsC = c.Split(",");
                                            int[] intDotsC = Array.ConvertAll(stringDotsC, int.Parse);

                                            return new Rectangles(intDotsA, intDotsC);
                                        }
                                        if (TextFromFileArray.Length == 3)
                                        {
                                            Console.WriteLine($"Ввод трёх координат не поддерживается!");
                                            Console.WriteLine("Нажмите \"Enter\", если изменили файл");
                                            Console.ReadLine();
                                            continue;
                                        }
                                        if (TextFromFileArray.Length == 4)
                                        {
                                            string a = TextFromFileArray[0];
                                            string[] stringDotsA = a.Split(",");
                                            int[] intDotsA = Array.ConvertAll(stringDotsA, int.Parse);
                                            string b = TextFromFileArray[1];
                                            string[] stringDotsB = b.Split(",");
                                            int[] intDotsB = Array.ConvertAll(stringDotsB, int.Parse);
                                            string c = TextFromFileArray[2];
                                            string[] stringDotsC = c.Split(",");
                                            int[] intDotsC = Array.ConvertAll(stringDotsC, int.Parse);
                                            string d = TextFromFileArray[3];
                                            string[] stringDotsD = d.Split(",");
                                            int[] intDotsD = Array.ConvertAll(stringDotsD, int.Parse);

                                            return new Rectangles(intDotsA, intDotsB, intDotsC, intDotsD);
                                        }
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
                            Console.WriteLine("Запишите координаты в файл в формате \"x,y x,y x,y x,y\"");
                            Console.WriteLine("Если вводите все четыре координаты, то в правильной очерёдности.");
                            Console.WriteLine("Ввод трёх координат не поддерживается");
                            Console.Write("Ввод: ");
                            string TextFromConsole = Console.ReadLine();
                            try
                            {
                                string[] TextFromConsoleArray = TextFromConsole.Split(" ");

                                if (TextFromConsoleArray.Length == 1)
                                {
                                    string c = TextFromConsoleArray[0];
                                    string[] stringDots = c.Split(",");
                                    int[] intDots = Array.ConvertAll(stringDots, int.Parse);

                                    return new Rectangles(intDots);
                                }
                                if (TextFromConsoleArray.Length == 2)
                                {
                                    string a = TextFromConsoleArray[0];
                                    string[] stringDotsA = a.Split(",");
                                    int[] intDotsA = Array.ConvertAll(stringDotsA, int.Parse);
                                    string c = TextFromConsoleArray[1];
                                    string[] stringDotsC = c.Split(",");
                                    int[] intDotsC = Array.ConvertAll(stringDotsC, int.Parse);

                                    return new Rectangles(intDotsA, intDotsC);
                                }
                                if (TextFromConsoleArray.Length == 3)
                                {
                                    Console.WriteLine($"Ввод трёх координат не поддерживается!");
                                    Console.WriteLine("Нажмите \"Enter\", если изменили файл");
                                    Console.ReadLine();
                                    continue;
                                }
                                if (TextFromConsoleArray.Length == 4)
                                {
                                    string a = TextFromConsoleArray[0];
                                    string[] stringDotsA = a.Split(",");
                                    int[] intDotsA = Array.ConvertAll(stringDotsA, int.Parse);
                                    string b = TextFromConsoleArray[1];
                                    string[] stringDotsB = b.Split(",");
                                    int[] intDotsB = Array.ConvertAll(stringDotsB, int.Parse);
                                    string c = TextFromConsoleArray[2];
                                    string[] stringDotsC = c.Split(",");
                                    int[] intDotsC = Array.ConvertAll(stringDotsC, int.Parse);
                                    string d = TextFromConsoleArray[3];
                                    string[] stringDotsD = d.Split(",");
                                    int[] intDotsD = Array.ConvertAll(stringDotsD, int.Parse);

                                    return new Rectangles(intDotsA, intDotsB, intDotsC, intDotsD);
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Вы не правильно ввели данные: {ex.Message}");
                            }
                        }
                        break;
                }

                //string[] arr1 = TextMoney1.Split('.');
                //string[] arr2 = TextMoney2.Split('.');
                //try
                //{
                //    long a1 = Convert.ToInt64(arr1[0]);
                //    long a2 = Convert.ToInt64(arr1[1]);
                //    long b1 = Convert.ToInt64(arr2[0]);
                //    long b2 = Convert.ToInt64(arr2[1]);
                //    if (a2 > 99 | a2 < -99)
                //    {
                //        while (true)
                //        {
                //            if (a2 < 99 & a2 > -99) { break; }
                //            a2 = a2 / 10;

                //        }

                //    }
                //    if (b2 > 99 | b2 < -99)
                //    {
                //        while (true)
                //        {
                //            if (b2 < 99 & b2 > -99) { break; }
                //            b2 = b2 / 10;
                //        }

                //    }
                //    if (a1 < 0)
                //    {
                //        a2 *= -1;
                //    }
                //    if (b1 < 0)
                //    {
                //        b2 *= -1;
                //    }
                //    Console.WriteLine($"CASH1    Гривнен: {a1}, копеек: {a2};");
                //    Money cash1 = new Money(a1, a2);
                //    Money cash2 = new Money(b1, b2);
                //    Money[] outputMoneyArr = new Money[2];
                //    outputMoneyArr[0] = cash1;
                //    outputMoneyArr[1] = cash2;

                //    return outputMoneyArr;
                //}
                //catch
                //{
                //    Console.WriteLine("Данные введены некорректно");
                //    continue;
                //}
            }

        }


        //public static Money[] InputMoney()
        //{
        //    while (true)
        //    {
        //        int selection;
        //        string TextMoney1 = "";
        //        string TextMoney2 = "";
        //        Console.WriteLine("Выберите тип ввода:\n1 - Ввод из файла;\n2 - Ввод из консоли.");
        //        while (true)
        //        {
        //            try
        //            {
        //                Console.Write("Вы ввели: ");
        //                selection = Convert.ToInt32(Console.ReadLine());
        //                if (selection == 1 || selection == 2)
        //                {
        //                    break;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Такого варианта нет!");
        //                }
        //            }
        //            catch (FormatException ex)
        //            {
        //                Console.WriteLine(ex.Message);
        //            }
        //        }

        //        switch (selection)
        //        {
        //            case 1:
        //                {
        //                    Console.WriteLine("Ввод из файла");
        //                    Console.WriteLine("Введите данные в файл в формате \"гривны.копейки, гривны.копейки\"");
        //                    string PathToFile = "C:/Users/Admin/Desktop/Money.txt";

        //                    while (true)
        //                    {
        //                        if (!File.Exists(PathToFile))
        //                        {
        //                            Console.WriteLine("Файл не найден, создайте файл Money.txt на рабочем столе!");
        //                            Console.WriteLine("Нажмите \"Enter\", если изменили файл");
        //                            Console.ReadLine();
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            string TextFromFile = File.ReadAllText(PathToFile);
        //                            if (TextFromFile == "")
        //                            {
        //                                Console.WriteLine($"Файл {Path.GetFileName(PathToFile)} пустой, введите в него данные!");
        //                                Console.WriteLine("Нажмите \"Enter\", если изменили файл");
        //                                Console.ReadLine();
        //                                continue;
        //                            }
        //                            try
        //                            {
        //                                string[] TextFromFileArray = TextFromFile.Split(", ");
        //                                TextMoney1 = TextFromFileArray[0];
        //                                TextMoney2 = TextFromFileArray[1];
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                Console.WriteLine($"Вы не правильно ввели данные: {ex.Message}");
        //                            }

        //                            break;
        //                        }

        //                    }
        //                    Console.WriteLine("Файл принят");

        //                }
        //                break;

        //            case 2:
        //                {
        //                    Console.WriteLine("Ввод из консоли");
        //                    Console.WriteLine("Введите данные в файл в формате \"гривны.копейки, гривны.копейки\"");
        //                    Console.Write("Ввод: ");
        //                    string TextFromConsole = Console.ReadLine();
        //                    string[] TextFromConsoleArray = TextFromConsole.Split(", ");
        //                    TextMoney1 = TextFromConsoleArray[0];
        //                    TextMoney2 = TextFromConsoleArray[1];
        //                }
        //                break;
        //        }

        //        string[] arr1 = TextMoney1.Split('.');
        //        string[] arr2 = TextMoney2.Split('.');
        //        try
        //        {
        //            long a1 = Convert.ToInt64(arr1[0]);
        //            long a2 = Convert.ToInt64(arr1[1]);
        //            long b1 = Convert.ToInt64(arr2[0]);
        //            long b2 = Convert.ToInt64(arr2[1]);
        //            if (a2 > 99 | a2 < -99)
        //            {
        //                while (true)
        //                {
        //                    if (a2 < 99 & a2 > -99) { break; }
        //                    a2 = a2 / 10;

        //                }

        //            }
        //            if (b2 > 99 | b2 < -99)
        //            {
        //                while (true)
        //                {
        //                    if (b2 < 99 & b2 > -99) { break; }
        //                    b2 = b2 / 10;
        //                }

        //            }
        //            if (a1 < 0)
        //            {
        //                a2 *= -1;
        //            }
        //            if (b1 < 0)
        //            {
        //                b2 *= -1;
        //            }
        //            Console.WriteLine($"CASH1    Гривнен: {a1}, копеек: {a2};");
        //            Money cash1 = new Money(a1, a2);
        //            Money cash2 = new Money(b1, b2);
        //            Money[] outputMoneyArr = new Money[2];
        //            outputMoneyArr[0] = cash1;
        //            outputMoneyArr[1] = cash2;

        //            return outputMoneyArr;
        //        }
        //        catch
        //        {
        //            Console.WriteLine("Данные введены некорректно");
        //            continue;
        //        }
        //    }
        //}







        //public static Money[] InputMoney()
        //{
        //    while (true)
        //    {
        //        int selection;
        //        string TextMoney1 = "";
        //        string TextMoney2 = "";
        //        Console.WriteLine("Выберите тип ввода:\n1 - Ввод из файла;\n2 - Ввод из консоли.");
        //        while (true)
        //        {
        //            try
        //            {
        //                Console.Write("Вы ввели: ");
        //                selection = Convert.ToInt32(Console.ReadLine());
        //                if (selection == 1 || selection == 2)
        //                {
        //                    break;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Такого варианта нет!");
        //                }
        //            }
        //            catch (FormatException ex)
        //            {
        //                Console.WriteLine(ex.Message);
        //            }
        //        }

        //        switch (selection)
        //        {
        //            case 1:
        //                {
        //                    Console.WriteLine("Ввод из файла");
        //                    Console.WriteLine("Введите данные в файл в формате \"гривны.копейки, гривны.копейки\"");
        //                    string PathToFile = "C:/Users/Admin/Desktop/Money.txt";

        //                    while (true)
        //                    {
        //                        if (!File.Exists(PathToFile))
        //                        {
        //                            Console.WriteLine("Файл не найден, создайте файл Money.txt на рабочем столе!");
        //                            Console.WriteLine("Нажмите \"Enter\", если изменили файл");
        //                            Console.ReadLine();
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            string TextFromFile = File.ReadAllText(PathToFile);
        //                            if (TextFromFile == "")
        //                            {
        //                                Console.WriteLine($"Файл {Path.GetFileName(PathToFile)} пустой, введите в него данные!");
        //                                Console.WriteLine("Нажмите \"Enter\", если изменили файл");
        //                                Console.ReadLine();
        //                                continue;
        //                            }
        //                            try
        //                            {
        //                                string[] TextFromFileArray = TextFromFile.Split(", ");
        //                                TextMoney1 = TextFromFileArray[0];
        //                                TextMoney2 = TextFromFileArray[1];
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                Console.WriteLine($"Вы не правильно ввели данные: {ex.Message}");
        //                            }

        //                            break;
        //                        }

        //                    }
        //                    Console.WriteLine("Файл принят");

        //                }
        //                break;

        //            case 2:
        //                {
        //                    Console.WriteLine("Ввод из консоли");
        //                    Console.WriteLine("Введите данные в файл в формате \"гривны.копейки, гривны.копейки\"");
        //                    Console.Write("Ввод: ");
        //                    string TextFromConsole = Console.ReadLine();
        //                    string[] TextFromConsoleArray = TextFromConsole.Split(", ");
        //                    TextMoney1 = TextFromConsoleArray[0];
        //                    TextMoney2 = TextFromConsoleArray[1];
        //                }
        //                break;
        //        }

        //        string[] arr1 = TextMoney1.Split('.');
        //        string[] arr2 = TextMoney2.Split('.');
        //        try
        //        {
        //            long a1 = Convert.ToInt64(arr1[0]);
        //            long a2 = Convert.ToInt64(arr1[1]);
        //            long b1 = Convert.ToInt64(arr2[0]);
        //            long b2 = Convert.ToInt64(arr2[1]);
        //            if (a2 > 99 | a2 < -99)
        //            {
        //                while (true)
        //                {
        //                    if (a2 < 99 & a2 > -99) { break; }
        //                    a2 = a2 / 10;

        //                }

        //            }
        //            if (b2 > 99 | b2 < -99)
        //            {
        //                while (true)
        //                {
        //                    if (b2 < 99 & b2 > -99) { break; }
        //                    b2 = b2 / 10;
        //                }

        //            }
        //            if (a1 < 0)
        //            {
        //                a2 *= -1;
        //            }
        //            if (b1 < 0)
        //            {
        //                b2 *= -1;
        //            }
        //            //Console.WriteLine($"CASH1    Гривнен: {a1}, копеек: {a2};");
        //            Money cash1 = new Money(a1, a2);
        //            Money cash2 = new Money(b1, b2);
        //            Money[] outputMoneyArr = new Money[2];
        //            outputMoneyArr[0] = cash1;
        //            outputMoneyArr[1] = cash2;

        //            return outputMoneyArr;
        //        }
        //        catch
        //        {
        //            Console.WriteLine("Данные введены некорректно");
        //            continue;
        //        }
        //    }
        //}

        //public void OutputMoney()
        //{
        //    while (true)
        //    {
        //        int selection;
        //        Console.WriteLine("Выберите тип вывода:\n1 - Вывод в файл;\n2 - Вывод в консоль.");
        //        while (true)
        //        {
        //            try
        //            {
        //                Console.Write("Вы ввели: ");
        //                selection = Convert.ToInt32(Console.ReadLine());
        //                if (selection == 1 || selection == 2)
        //                {
        //                    break;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Такого варианта нет!");
        //                }
        //            }
        //            catch (FormatException ex)
        //            {
        //                Console.WriteLine(ex.Message);
        //            }
        //        }

        //        switch (selection)
        //        {
        //            case 1:
        //                {
        //                    Console.WriteLine("Вывод в файл");
        //                    Console.WriteLine("Вывод: C:/Users/Admin/Desktop/MoneyOut.txt");
        //                    string PathToFile = "C:/Users/Admin/Desktop/MoneyOut.txt";

        //                    string OutText = $"Гривнен: {hrivna}, копеек: {kopeyka};";
        //                    try
        //                    {
        //                        bool AdditionalRecording = false;
        //                        using (StreamWriter sw = new StreamWriter(PathToFile, AdditionalRecording, System.Text.Encoding.Unicode))
        //                        {
        //                            sw.WriteLine(OutText);
        //                        }
        //                    }
        //                    catch (Exception e)
        //                    {
        //                        Console.WriteLine(e.Message);
        //                    }

        //                }
        //                break;

        //            case 2:
        //                {
        //                    string OutText = $"Гривнен: {hrivna}, копеек: {kopeyka};";
        //                    Console.WriteLine($"Вывод в консоль: {OutText}");
        //                }
        //                break;

        //        }
        //        break;

        //    }
        //}

        //public static Money SumMoney(Money a, Money b)
        //{
        //    a.ToCoin();
        //    b.ToCoin();
        //    long ab = a.kopeyka + b.kopeyka;
        //    Money c = new Money(ab);
        //    a.ToBillAndCoin();
        //    b.ToBillAndCoin();
        //    c.ToBillAndCoin();
        //    return c;
        //}

        //public static Money DifferenceMoney(Money a, Money b)
        //{
        //    a.ToCoin();
        //    b.ToCoin();
        //    long ab = a.kopeyka - b.kopeyka;
        //    Money c = new Money(ab);
        //    a.ToBillAndCoin();
        //    b.ToBillAndCoin();
        //    c.ToBillAndCoin();
        //    return c;
        //}
        //public void ToCoin()
        //{
        //    kopeyka += hrivna * 100;
        //    hrivna = 0;
        //}

        //public void ToBillAndCoin()
        //{
        //    hrivna = kopeyka / 100;
        //    kopeyka = kopeyka % 100;
        //}
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            //Rectangles rectangle1 = new Rectangles(new int[] { 3, 4 }, new int[] { 10, 15 }, new int[] { 4, 2 }, new int[] { 4, 2 });
            Rectangles rectangle1 = Rectangles.InputCoordinates();
            Console.WriteLine(rectangle1.Coordinate1[0]);
            Console.WriteLine(rectangle1.Coordinate1[1]);
            Console.WriteLine(rectangle1.Coordinate2[0]);
            Console.WriteLine(rectangle1.Coordinate2[1]);
            Console.WriteLine(rectangle1.Coordinate3[0]);
            Console.WriteLine(rectangle1.Coordinate3[1]);
            Console.WriteLine(rectangle1.Coordinate4[0]);
            Console.WriteLine(rectangle1.Coordinate4[1]);



            ////InputMoney();
            //Money[] MoneyArr = Money.InputMoney();
            //Money cash1 = MoneyArr[0];
            //Money cash2 = MoneyArr[1];
            //Money cash3 = Money.SumMoney(cash1, cash2);
            //Money cash4 = Money.DifferenceMoney(cash1, cash2);
            ////cash1.ToBillAndCoin();

            //cash1.OutputMoney();
            //cash2.OutputMoney();
            //cash3.OutputMoney();
            //cash4.OutputMoney();
            //cash1.ToCoin();
            //cash1.OutputMoney();
            //cash1.ToBillAndCoin();
            //cash1.OutputMoney();
        }
    }
}