using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите переменную типа int: ");
                    int a = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Введите переменную типа double: ");
                    double b = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Введите переменную типа long: ");
                    long c = Convert.ToInt64(Console.ReadLine());

                    Console.Write($"a = {a}; b = {b}; с = {c}");

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format Exception");
                    Console.WriteLine("Ведите корректные данные!");
                }
            }


        }
    }
}
