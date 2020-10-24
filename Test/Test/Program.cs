using System;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] words = { "noob", "friend" };
            //string[] massiv = { "I", "friend", "am", "a", "noob", "guy" };
            //massiv = massiv.Except(words).ToArray();
            //foreach (var word in massiv)
            //    Console.WriteLine(word);

            string[] lineArr = { "24", "4", "4" ,"4 ", "4 ", " 5", "6", "7", "842", "9", "9", "88,2", "4", "4", "5",  "7", "6", "7", "9", "9" };

            double[] DoubleArr = Array.ConvertAll(lineArr, double.Parse);
            Console.WriteLine(string.Join(" ", DoubleArr));
            //double[] arr1 = { 2.3, 4.2, 4.55 };
            //double[] arr2 = { 5.3, 5.2, 5.55 };
            //double[] arr3 = { 3, 3, 3 };
            //var sum = arr1.Concat(arr2);
            //sum = sum.Concat(arr3);
            //double[] arr4 = sum.ToArray();
            //Console.WriteLine(string.Join(" ",arr4));
            //Console.WriteLine(sum);
        }
    }
}
