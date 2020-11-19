//У двовимірному цілочисельному масиві розміром [m][n] знайти
//елементи які дорівнюють введеному з клавіатури ключу та вивести їх на екран,
//масив заповнюється рандомними числами від 1 до 40. Розмір масиву
//визначається користувачем. Перевіряти коректність введених значень
//розмірності масиву, вивести заповнений масив, всі окремі операції
//(заповнення масиву, пошуку значень) сформувати окремими функціями.
//Додаткову інформацію яку потрібно знайти вказано в індивідуальному
//варіанті 

//9 обчислити суму максимального та мінімального значення в
//кожному стовпчику масиву


using System;
using System.Linq;

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

        public static void SearchForTwoDimensionalArray(int[,] TwoDimensionalArray, int key)
        {
            int a = TwoDimensionalArray.GetLength(0);
            int b = TwoDimensionalArray.GetLength(1);
            bool tr = true;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (TwoDimensionalArray[i, j] == key)
                    {
                        Console.WriteLine($"Ключ найден на позиции: [{i},{j}]");
                        tr = false;
                    }

                }

            }

            if (tr)
            {
                Console.WriteLine("Ключ не найден");
            }

        }

        public static void PrintSpecialTask(int[,] TwoDimensionalArray)
        {
            int a = TwoDimensionalArray.GetLength(0);
            int b = TwoDimensionalArray.GetLength(1);

            for (int i = 0; i < b; i++)
            {
                int min = 41;
                int max = 0;
                for (int j = 0; j < a; j++)
                {
                    if (TwoDimensionalArray[j, i] < min)
                    {
                        min = TwoDimensionalArray[j, i];
                    }
                    if (TwoDimensionalArray[j, i] > max)
                    {
                        max = TwoDimensionalArray[j, i];
                    }

                }
                int sum = min + max;
                Console.WriteLine($"Сумма максимального и минимального значения в {i + 1} столбце: {sum}");

            }
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
            WorkWithArray.SearchForTwoDimensionalArray(RandomArr, key);
            WorkWithArray.PrintSpecialTask(RandomArr);

            //Console.WriteLine($"\na: {DimensionArr[0]}, b: {DimensionArr[1]}");



        }
    }
}
