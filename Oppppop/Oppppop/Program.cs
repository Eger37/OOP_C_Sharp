using System;

namespace Oppppop
{
    class Program
    {
        class coordinates
        {
            private double[] x;

            public double[] pointx
            {
                get
                {
                    return x;
                }

                set
                {
                    x = value;
                }
            }

            private double[] y;

            public double[] pointy
            {
                get
                {
                    return y;
                }

                set
                {
                    y = value;
                }
            }
        }

        private static int choice(int num)
        {
            Console.WriteLine("Як ви хочете заповнити дані місяця 'Листопад'? \n 1 - заповнювати самостійно (вручну); \n 2 - згенерувати усі дані рандомно; \n - отримати дані із файлу. \n Ваша цифра:");

            if (num == 1)
            {

            }

            else if (num == 2)
            {

            }

            else if (num == 3)
            {

            }

            else
            {
                Console.WriteLine("Перевірте правильність вводу даних. Повинні бути цифри лише 1, 2 чи 3!");
            }

            return num;
        }

        enum WeatherTypes { Sunny, Thunder, Not_Defined, Rain, Short_Rain, Snowy, Foggy, Cloudy }


        public class WeatherParametersDay
        {
            double avtpDay;
            double avtpNight;
            double avPressure;
            double Precipitaton;
            string WeatherType;

            public WeatherParametersDay(double avtpDay, double avtpNight, double avPressure, double Precipitaton, string WeatherType)
            {
                avtpDay = Convert.ToDouble(avtpDay);
                avtpNight = Convert.ToDouble(avtpNight);
                avPressure = Convert.ToDouble(avPressure);
                Precipitaton = Convert.ToDouble(Precipitaton);
                WeatherType = Convert.ToString(WeatherType);
            }

            public void Output()
            {
                Console.WriteLine($"Середня температура вдень: {avtpDay},\nCередня температура вночі: {avtpNight}, \nCередній тиск: {avPressure}, \nКількість опадів: {Precipitaton}, \nТип погоди: {WeatherType} ");
            }

        }

        private static int Days()
        {
            int CountDays = 0;
            Console.WriteLine("Виберіть потрібну кількість днів для заповнення у місяці 'Листопад': ");
            while (true)
            {
                try
                {
                    string days = Console.ReadLine();
                    int Days = Convert.ToInt32(days);
                    CountDays += Days;
                    break;

                }

                catch
                {
                    Console.WriteLine("Введіть цифру (кількість днів)!");
                    continue;
                }
            }
            return CountDays;
        }

        private static void Output(int a)
        {
            // WeatherParametersDay[] days = WeatherParametersDay[a];
        }
        private static string[,] array(int a)
        {
            string[,] array = new string[a, 5];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    //array[i,j]=
                }
            }

            return array;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Output(Days());


        }
    }
}