using System;
using System.Linq;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string PathToFile = "D:/OneDrive - ДонНУ/Рабочий стол/Univer/WeatherDays.txt";
          //string PathToFile = "C:/Users/Admin/Desktop/Univer/WeatherDays.txt";

            if (!File.Exists(PathToFile))
            {
                Console.WriteLine("Файл не найден, создайте файл WeatherDays.txt в папке Univer на рабочем столе!");
                Console.WriteLine("Нажмите \"Enter\", если создали файл");
                Console.ReadLine();
            }
            StreamReader fileData = new StreamReader(PathToFile);
            string s1 = fileData.ReadLine();
            Console.WriteLine(s1);
        }
    }
}
