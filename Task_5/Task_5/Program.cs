using System;
using System.IO;
using System.Linq.Expressions;

namespace Task_5
{
    class Arrays
    {
        public static void Start()
        {
            string path_x = @"C:/Users/Admin/Desktop/x.txt";
            string path_y = @"C:/Users/Admin/Desktop/y.txt";
            string path_z = @"C:/Users/Admin/Desktop/z.txt";
            try
            {
                string[] x_arr = File.ReadAllText(path_x).Split(",");
                string[] y_arr = File.ReadAllText(path_y).Split(",");
                float[] myX = Array.ConvertAll(x_arr, float.Parse);
                float[] myY = Array.ConvertAll(y_arr, float.Parse);
                int lenghtArr;
                if (myX.Length > myY.Length)
                {
                    lenghtArr = myY.Length;
                }
                else
                {
                    lenghtArr = myX.Length;
                }
                float[] myIntsZ = new float[lenghtArr];

                for (int i = 0; i < lenghtArr; i++)
                {
                    float xi = myX[i];
                    float yi = myY[i];
                    //Console.WriteLine(myInts[i]);
                    if ((xi % 7) == 0)
                    {
                        xi += 8;
                        myX[i] = xi;
                    }
                    float zi = (((xi * xi) - (yi * yi)) / 2);
                    myIntsZ[i] = zi;
                }
                for (int i = 0; i < lenghtArr; i++)
                {
                    //Console.WriteLine(myIntsZ[i]);
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
    class Program
    {

        private static double[] OpenFileToArr(string PathToFile)
        {

            return double[3];
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            string path_x = @"C:/Users/Admin/Desktop/x.txt";
            string path_y = @"C:/Users/Admin/Desktop/y.txt";
            string path_z = @"C:/Users/Admin/Desktop/z.txt";

            Arrays.Start();





        }

    }
}