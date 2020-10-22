using System;
using System.IO;
using System.Linq.Expressions;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            string path_x = @"C:/Users/Admin/Desktop/x.txt";
            string path_y = @"C:/Users/Admin/Desktop/y.txt";
            string path_z = @"C:/Users/Admin/Desktop/z.txt";
            try
            {
                string[] x_arr = File.ReadAllText(path_x).Split(",");
                string[] y_arr = File.ReadAllText(path_y).Split(",");
                int[] myIntsX = Array.ConvertAll(x_arr, int.Parse);
                int[] myIntsY = Array.ConvertAll(y_arr, int.Parse);
                int lenghtArr;
                if (myIntsX.Length > myIntsY.Length)
                {
                    lenghtArr = myIntsY.Length;
                }
                else
                {
                    lenghtArr = myIntsX.Length;
                }
                float[] myIntsZ = new float[lenghtArr];

                for (int i = 0; i < lenghtArr; i++)
                {
                    int xi = myIntsX[i];
                    int yi = myIntsY[i];
                    //Console.WriteLine(myInts[i]);
                    if ((xi % 7) == 0)
                    {
                        xi += 8;
                        myIntsX[i] = xi;
                    }
                    float zi = (((xi * xi) - (yi * yi)) / 2);
                    myIntsZ[i] = zi;
                }
                for (int i = 0; i < lenghtArr; i++)
                {
                    Console.WriteLine(myIntsZ[i]);
                }


                bool AdditionalRecording = false;
                using (StreamWriter sw = new StreamWriter(path_z, AdditionalRecording, System.Text.Encoding.Unicode))
                {
                    sw.WriteLine(string.Join(", ", myIntsZ));
                }

            }
            catch
            {
                Console.WriteLine("вы не правильно ввели данные в файлах");
            }





        }

    }
}