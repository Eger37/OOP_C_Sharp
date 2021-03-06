﻿//Для роботи з прямокутниками на площині, створити структуру та
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

                Console.WriteLine("Запишите координаты в файл в формате \"x,y x,y x,y x,y\"");
                Console.WriteLine("Если вводите все четыре координаты, то в правильной очерёдности.");
                Console.WriteLine("Ввод трёх точек не поддерживается");
                Console.WriteLine("\nВыберите тип ввода координат:\n1 - Ввод из файла;\n2 - Ввод из консоли.");
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
            }

        }

        public void OutputCoordinates()
        {
            while (true)
            {
                int selection;
                Console.WriteLine("\nВыберите тип вывода координат\n1 - Вывод в файл;\n2 - Вывод в консоль.");
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
                            Console.WriteLine("Вывод: C:/Users/Admin/Desktop/RectanglesOut.txt");
                            string PathToFile = "C:/Users/Admin/Desktop/RectanglesOut.txt";

                            string OutText = $"Точки: A({coordinate1[0]},{coordinate1[1]}), B({coordinate2[0]},{coordinate2[1]}), C({coordinate3[0]},{coordinate3[1]}),D({coordinate4[0]},{coordinate4[1]});";
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
                            string OutText = $"Точки: A({coordinate1[0]},{coordinate1[1]}), B({coordinate2[0]},{coordinate2[1]}), C({coordinate3[0]},{coordinate3[1]}),D({coordinate4[0]},{coordinate4[1]});";
                            Console.WriteLine($"Вывод в консоль: {OutText}");
                        }
                        break;

                }
                break;

            }
        }


        public (double, double) SidesOfARectangle()
        {
            int x1 = coordinate1[0];
            int x2 = coordinate2[0];
            int x3 = coordinate3[0];
            //int x4 = coordinate4[0];
            int y1 = coordinate1[1];
            int y2 = coordinate2[1];
            int y3 = coordinate3[1];
            //int y4 = coordinate4[1];
            double side1 = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            double side2 = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
            var tuple = (side1, side2);
            return tuple;

        }

        public void AreaOfARectangle()
        {
            //(double, double) tuple = this.SidesOfARectangle();
            var (side1, side2) = this.SidesOfARectangle();
            //double side1 = tuple[0];

            //int x1 = coordinate1[0];
            //int x2 = coordinate2[0];
            //int x3 = coordinate3[0];
            ////int x4 = coordinate4[0];
            //int y1 = coordinate1[1];
            //int y2 = coordinate2[1];
            //int y3 = coordinate3[1];
            ////int y4 = coordinate4[1];
            //double side1 = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            //double side2 = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
            double result = side1 * side2;
            Console.WriteLine($"Area of the rectangle: {result}");
        }

        public void PerimeterOfARectangle()
        {
            var (side1, side2) = this.SidesOfARectangle();
            double result = side1 * 2 + side2 * 2;
            Console.WriteLine($"Perimeter of the rectangle: {result}");
        }

        public void MinRadiusOfARectangle()
        {
            var (side1, side2) = this.SidesOfARectangle();
            double result;
            if (side1 > side2)
            {
                result = side2;

            }
            else
            {
                result = side1;
            }
            Console.WriteLine($"Radius of a circle inscribed in a rectangle: {result}");
        }

        public void MaxRadiusOfARectangle()
        {
            var (side1, side2) = this.SidesOfARectangle();
            double result;
            result = (Math.Sqrt((side1 * side1) + (side2 * side2)) / 2);
            Console.WriteLine($"Radius of a circle circumscribed in a rectangle: { result}");
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            //Rectangles rectangle1 = new Rectangles(new int[] { 3, 4 }, new int[] { 10, 15 }, new int[] { 4, 2 }, new int[] { 4, 2 });
            Rectangles rectangle1 = Rectangles.InputCoordinates();
            rectangle1.OutputCoordinates();
            rectangle1.AreaOfARectangle();
            rectangle1.PerimeterOfARectangle();
            rectangle1.MinRadiusOfARectangle();
            rectangle1.MaxRadiusOfARectangle();

            //rectangle1.Coordinate1[0] = 9;
            //Console.WriteLine(rectangle1.Coordinate1[0]);
            //Console.WriteLine(rectangle1.Coordinate1[1]);
            //Console.WriteLine(rectangle1.Coordinate2[0]);
            //Console.WriteLine(rectangle1.Coordinate2[1]);
            //Console.WriteLine(rectangle1.Coordinate3[0]);
            //Console.WriteLine(rectangle1.Coordinate3[1]);
            //Console.WriteLine(rectangle1.Coordinate4[0]);
            //Console.WriteLine(rectangle1.Coordinate4[1]);

            rectangle1.OutputCoordinates();


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