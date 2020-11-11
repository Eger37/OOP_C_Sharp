using System;

namespace Task_6
{
    class WorkWithArray
    {
        public static int[] InputDimensionOfArray()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите размерность массива через запятую \"a,b\": ");
                    string StrInput = Console.ReadLine();
                    string[] StrArrayInput = StrInput.Split(',');
                    //int a = Int32.Parse(StrArrayInput[0]);
                    int a = Convert.ToInt32(StrArrayInput[0]);
                    int b = Convert.ToInt32(StrArrayInput[1]);
                    int[] DimensionIntArr = new int[] { a, b };
                    return DimensionIntArr;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы не правильно ввели размерность\n");
                    continue;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Вы не правильно ввели размерность\n");
                    continue;
                }
            }

        }
        public static int InputKeyForSearch()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите ключ для поиска в формате int32: ");
                    string StrInput = Console.ReadLine();
                    int key = Convert.ToInt32(StrInput);
                    //Console.WriteLine(key);
                    return key;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы не правильно ввели искомое число\n");
                    continue;
                }
            }

        }
        public static int[,] GenerateRandomArray(int[] DimensionIntArr)
        {
            int a = DimensionIntArr[0];
            int b = DimensionIntArr[1];
            int[,] RandomArray = new int[a, b];

            Random rand = new Random();
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    int c = rand.Next(1, 41);
                    RandomArray[i, j] = c;
                    //if (c == 40)
                    //{
                    //    Console.WriteLine(RandomArray[i, j]);
                    //}

                }
            }
            return RandomArray;
        }
        public static void PrintTwoDimensionalArray(int[,] RandomArray)
        {
            int a = RandomArray.GetLength(0);
            int b = RandomArray.GetLength(1);
            Console.Write("[");
            for (int i = 0; i < a; i++)
            {
                Console.Write("[");
                for (int j = 0; j < b; j++)
                {
                    Console.Write(RandomArray[i, j]);
                    if (j < b - 1) { Console.Write(", "); }

                }
                Console.Write("]");
                if (i < a - 1) { Console.Write(",\n"); }
            }
            Console.Write("]\n");
            return;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {


            int[] DimensionArr = WorkWithArray.InputDimensionOfArray();
            int[,] RandomArr = WorkWithArray.GenerateRandomArray(DimensionArr);
            WorkWithArray.PrintTwoDimensionalArray(RandomArr);
            int key = WorkWithArray.InputKeyForSearch();

            Console.WriteLine($"\na: {DimensionArr[0]}, b: {DimensionArr[1]}");



        }
    }
}
