using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Task_5
{
    class Program
    {

        private static double[] OpenFileToArr(string PathToFile)
        {
            while (true)
            {
                try
                {
                    if (!File.Exists(PathToFile))
                    {
                        Console.WriteLine($"Файл не найден, создайте файл {PathToFile} - на это рабочем столе!");
                        Console.WriteLine("Нажмите \"Enter\", если готовы снова считывать файл");
                        Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        string textFromFile = File.ReadAllText(PathToFile);
                        textFromFile = Regex.Replace(textFromFile, "\r", " ");
                        textFromFile = Regex.Replace(textFromFile, "\n", " ");
                        textFromFile = Regex.Replace(textFromFile, " {2,}", " ");
                        //Console.WriteLine(textFromFile);
                        //string[] lineArr = textFromFile.Split(Environment.NewLine, ' ');
                        string[] lineArr = textFromFile.Split(new char[] { ' ' });
                        //foreach( string line in lineArr) {
                        //    string[] arrFromLine = line.Split(' ');
                        //    double[] arrFromLineDouble = Array.ConvertAll(arrFromLine, double.Parse);
                        //    Console.WriteLine(string.Join(":", arrFromLineDouble));
                        //}
                        int last = lineArr.Length - 1;
                        lineArr = lineArr[0..last];
                        //Console.WriteLine(string.Join(":", lineArr));

                        //Console.WriteLine("do suda rabotaet");
                        double[] DoubleArr = Array.ConvertAll(lineArr, double.Parse);

                        //Console.WriteLine(string.Join(" ", DoubleArr));

                        return DoubleArr;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("вы не правильно ввели данные в файлах");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private static double[] ChangingArrX(double[] input_arr)
        {
            for (int i = 0; i < input_arr.Length; i++)
            {
                double xi = input_arr[i];
                if ((xi % 7) == 0)
                {
                    xi += 8;
                    input_arr[i] = xi;
                }
            }
            return input_arr;
        }
        private static double[] CreateArrZ(double[] input_arr_x, double[] input_arr_y)
        {
            int lenghtArr;
            if (input_arr_x.Length > input_arr_y.Length)
            {
                lenghtArr = input_arr_y.Length;
            }
            else
            {
                lenghtArr = input_arr_x.Length;
            }
            double[] ArrZ = new double[lenghtArr];

            for (int i = 0; i < lenghtArr; i++)
            {

                double xi = input_arr_x[i];
                double yi = input_arr_y[i];
                //Console.WriteLine(myInts[i]);
                if ((xi % 7) == 0)
                {
                    xi += 8;
                    input_arr_x[i] = xi;
                }
                double zi = (((xi * xi) - (yi * yi)) / 2);
                ArrZ[i] = zi;
            }
            return ArrZ;
        }
        private static void WriteArrToFile(double[] input_arr, string path_to_file = @"C:/Users/Admin/Desktop/z.txt")
        {
            try
            {
                bool AdditionalRecording = false;
                using (StreamWriter sw = new StreamWriter(path_to_file, AdditionalRecording, System.Text.Encoding.Unicode))
                {
                    sw.WriteLine(string.Join(" ", input_arr));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            //Console.InputEncoding = System.Text.Encoding.Unicode;
            //Console.OutputEncoding = System.Text.Encoding.Unicode;
            string path_x = @"C:/Users/Admin/Desktop/x.txt";
            string path_y = @"C:/Users/Admin/Desktop/y.txt";
            string path_z = @"C:/Users/Admin/Desktop/z.txt";

            double[] arr_x = OpenFileToArr(path_x);
            arr_x = ChangingArrX(arr_x);
            double[] arr_y = OpenFileToArr(path_y);
            double[] arr_z = CreateArrZ(arr_x, arr_y);
            WriteArrToFile(arr_z, path_z);






        }

    }
}