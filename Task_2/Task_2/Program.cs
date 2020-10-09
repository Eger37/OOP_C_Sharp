using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
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
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Exception");
            }
        }
    }
}
