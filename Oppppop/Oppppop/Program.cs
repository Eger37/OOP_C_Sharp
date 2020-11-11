
using System;
using System.Runtime.CompilerServices;

namespace Oppppop
{
    class Program
    {
        private static int ndimension()
        {
            Console.WriteLine("Виберіть кількість стопчиків у масиві: ");
            string string1 = Console.ReadLine();
            int n;
            n = Convert.ToInt32(string1);

            return n;
        }

        private static int mdimension()
        {
            Console.WriteLine("Виберіть кількість рядків у масиві: ");
            string string1 = Console.ReadLine();
            int m;
            m = Convert.ToInt32(string1);

            return m;
        }

        private static int[,] massive(int x, int y)
        {
            int[,] array = new int[x, y];  //{ ndimension(), mdimension() } ;
            Random rand = new Random();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    array[i, j] = rand.Next(1, 100);
                }
            }

            Console.WriteLine("Ваш масив згенеровано випадковими числами:");
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(array[i, j] + "   ");
                    //Console.WriteLine("Randk" + array.Rank);
                }
                Console.WriteLine();
            }

            return array;
        }

        private static int key()
        {
            Console.WriteLine("Введіть значення, яке хочете відшукати у масиві: ");
            string str = Console.ReadLine();
            int key = Convert.ToInt32(str);

            return key;
        }

        private static void Search(int[,] array, int find)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i, j] == find)
                    {
                        Console.WriteLine("Елемент знайдено на позиції: " + i, j);
                    }
                    else
                    {
                        Console.WriteLine("Такого елементу не знайдено у Вашому масиві(((");
                    }
                }

            }

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            massive(ndimension(), mdimension());
            int[,] arrayx = massive(ndimension(), mdimension());

            Console.WriteLine("Введіть значення, яке хочете відшукати у масиві: ");
            string str = Console.ReadLine();
            int key = Convert.ToInt32(str);

            Search(arrayx, key);
        }

    }
}