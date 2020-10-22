using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            double b;
            long c;

            while (true)
            {
                try
                {
                    Console.Write("Введите переменную типа int: ");
                    a = Convert.ToInt32(Console.ReadLine());

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format Exception");
                    Console.WriteLine("Ведите корректные данные!");
                }

            }
            while (true)
            {
                try
                {
                    Console.Write("Введите переменную типа double: ");
                    b = Convert.ToDouble(Console.ReadLine());

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format Exception");
                    Console.WriteLine("Ведите корректные данные!");
                }

            }
            while (true)
            {
                try
                {
                    Console.Write("Введите переменную типа long: ");
                    c = Convert.ToInt64(Console.ReadLine());



                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format Exception");
                    Console.WriteLine("Ведите корректные данные!");
                }

            }
            Console.Write($"a = {a}; b = {b}; с = {c}");

        }
    }
}
