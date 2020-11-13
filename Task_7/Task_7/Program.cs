//Завдання № 7.Робота з enum та масивами об’єктів (10 балів)

//Використовуючи enum та масиви вирішіть задачу про стан погоди в
//минулому році. Тип погоди за день повинен мати наступні можливі значення
//(enum): не визначено(не було внесена інформація); дощ; короткочасний дощ;
//гроза; сніг; туман; похмуро; сонячно.

//Інформація про погоду за день повинна
//зберігатися в об’єкті класа WeatherParametersDay та містить наступну
//інформацію: середня температура вдень, середня температура вночі, середній
//атмосферний тиск, кількість опадів (мм/день), тип погоди за день.

//Інформація про погоду за період повинна зберігатися в об’єкті класа
//WeatherDays та повинна містити масив об’єктів класа WeatherParametersDay в
//кількості (кількість днів в відповідному місяці), що відповідає варіанту. Дані
//повинні зчитуватися з файлу або вводитися з клавіатури. Інформацію яку
//необхідно додатково знайти вказано в індивідуальному варіанті. 

//9 Розглядати жовтень місяць, розрахувати кількість похмурих днів у
//місяці та загальну кількість днів коли був дощ або гроза,
//мінімальну температуру вночі та максимальну температуру вдень
//за місяць

using System;
using System.Text;
using System.IO;

namespace Task_7
{
    enum TypeOfWeather : byte
    {
        не_определено = 1,
        дождь,
        кратковременный_дождь,
        гроза,
        снег,
        туман,
        хмуро,
        солнечно
    }
    class WeatherParametersDay
    {
        //autoProperty
        public float AverageTemperaturePerDay { get; private set; }
        public float AverageTemperatureAtNight { get; private set; }
        public float AverageAtmosphericPressure { get; private set; }
        public int Precipitation { get; private set; }
        public TypeOfWeather TypeOfWeatherAtDay { get; private set; }

        public WeatherParametersDay(float td, float tn, float ap, int pr) // constuctor
        {
            AverageTemperaturePerDay = td;
            AverageTemperatureAtNight = tn;
            AverageAtmosphericPressure = ap;
            Precipitation = pr;
        }
        public WeatherParametersDay(float td, float tn, float ap, int pr, TypeOfWeather tow) // constuctor
        {
            AverageTemperaturePerDay = td;
            AverageTemperatureAtNight = tn;
            AverageAtmosphericPressure = ap;
            Precipitation = pr;
            TypeOfWeatherAtDay = tow;
        }

        public void GetInfo()
        {
            Console.WriteLine($"AverageTemperaturePerDay: {AverageTemperaturePerDay};\nAverageTemperatureAtNight: {AverageTemperatureAtNight};\n" +
                $"AverageAtmosphericPressure: {AverageAtmosphericPressure};\nPrecipitation: {Precipitation};\n" +
                $"TypeOfWeatherAtDay: {TypeOfWeatherAtDay};\n");
        }


    }

    class WeatherDays
    {
        private WeatherParametersDay[] arrWeatherDays;
        public WeatherParametersDay[] ArrWeatherDays
        {
            get { return arrWeatherDays; }
            private set
            {
                arrWeatherDays = value;
            }
        }
        WeatherDays()
        {
            ArrWeatherDays = new WeatherParametersDay[0];
        }
        WeatherDays(int daysNumber)
        {
            ArrWeatherDays = new WeatherParametersDay[daysNumber];
        }
        private static bool ChooseTypeOfInput()
        {
            int intSelection;
            Console.WriteLine("\nВыберите тип ввода данных:\n1 - Ввод из файла;\n2 - Ввод из консоли.");
            // 1 = true = Ввод из файла; 2 = false = Ввод из консоли
            while (true)
            {
                try
                {
                    Console.Write("Вы ввели: ");
                    intSelection = Convert.ToInt32(Console.ReadLine());
                    if (intSelection == 1 || intSelection == 2)
                    {
                        if (intSelection == 1) { return true; }
                        else { return false; }
                        //break;
                    }
                    else
                    {
                        Console.WriteLine("Такого варианта нет!");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void insertDaySettings(int idx, WeatherParametersDay wpd)
        {
            arrWeatherDays[idx] = wpd;
        }

        public static void InputDataFromFile()
        {
            Console.WriteLine("Ввод из файла");
            Console.WriteLine("В первой строчке введите количество дней.");
            Console.WriteLine("В слудующих строчках вводите параметры погоды в день в формате:");
            Console.WriteLine("f1 f2 f3 i s");
            Console.WriteLine("f1 = Средняя температура днём - float");
            Console.WriteLine("f2 = Средняя температура ночью - float");
            Console.WriteLine("f3 = Средняе атмосферное давление - float (мм ртутного столба");
            Console.WriteLine("i = Количество осадков - int (мм/день)");
            Console.WriteLine("s = Тип погоды в этот день - string (ниже примеры типов погоды, вводить это значение необязательно)");
            Console.WriteLine("Типы погоды: не_определено, дождь, кратковременный_дождь, гроза, снег, туман, хмуро, солнечно\n");

            bool restartRead = false;
            string PathToFile = "D:/OneDrive - ДонНУ/Рабочий стол/Univer/WeatherDays.txt";
            //string PathToFile = "C:/Users/Admin/Desktop/Univer/WeatherDays.txt";
            while (true)
            {
                if (!File.Exists(PathToFile))
                {
                    Console.WriteLine($"Файл не найден, создайте файл WeatherDays.txt по пути {PathToFile}");
                    Console.WriteLine("Нажмите \"Enter\", если создали файл");
                    Console.ReadLine();
                    continue;
                }
                int numberOfDays;
                StreamReader fileData = new StreamReader(PathToFile);
                string firstLine = fileData.ReadLine();

                if (firstLine == null)
                {
                    Console.WriteLine($"Файл {Path.GetFileName(PathToFile)} пустой, введите в него данные!");
                    fileData.Close();
                    Console.WriteLine("Нажмите \"Enter\", если изменили файл");
                    Console.ReadLine();
                    continue;
                }
                fileData = new StreamReader(PathToFile);
                try
                { numberOfDays = Convert.ToInt32(firstLine); }
                catch (Exception ex)
                {
                    Console.WriteLine($"Вы не правильно ввели данные: {ex.Message}");
                    fileData.Close();
                    Console.WriteLine("Нажмите \"Enter\", если изменили файл");
                    Console.ReadLine();
                    continue;
                }
                fileData = new StreamReader(PathToFile);
                WeatherDays arrDaysParams = new WeatherDays(numberOfDays);
                int count = 0;
                while (count != numberOfDays)
                {
                    string nextLine = fileData.ReadLine();
                    string[] splitLine = nextLine.Split(" ");
                    if (splitLine.Length != 4 || splitLine.Length != 5)
                    {
                        Console.WriteLine($"В строке {count + 2} данные введены неверно");
                        fileData.Close();
                        Console.WriteLine("Нажмите \"Enter\", если исправили строку");
                        Console.ReadLine();
                        restartRead = true;
                        break;
                    }
                    try
                    {
                        numberOfDays = Convert.ToInt32(firstLine);
                        float AverageTemperaturePerDay = float.Parse(splitLine[0], System.Globalization.CultureInfo.InvariantCulture);
                        float AverageTemperatureAtNight = float.Parse(splitLine[1], System.Globalization.CultureInfo.InvariantCulture);
                        float AverageAtmosphericPressure = float.Parse(splitLine[2], System.Globalization.CultureInfo.InvariantCulture);
                        int Precipitation = Convert.ToInt32(splitLine[3]);
                        TypeOfWeather TypeOfWeatherAtDay = 0;
                        if (splitLine.Length == 5)
                        {
                            TypeOfWeatherAtDay = (TypeOfWeather)Enum.Parse(typeof(TypeOfWeather), splitLine[4], true);
                        }
                        WeatherParametersDay dayParams = new WeatherParametersDay(AverageTemperaturePerDay, AverageTemperatureAtNight, AverageAtmosphericPressure, Precipitation, TypeOfWeatherAtDay);
                        arrDaysParams.insertDaySettings(count, dayParams);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"В строке {count + 2} данные введены неверно");
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        fileData.Close();
                        Console.WriteLine("Нажмите \"Enter\", если исправили строку");
                        Console.ReadLine();
                        restartRead = true;
                        break;
                    }

                    count++;
                }
                if (restartRead)
                { continue; }
                break;


            }
            Console.WriteLine("\nФайл принят");
        }

        public static WeatherDays InputData()
        {
            bool typeOfInput = ChooseTypeOfInput();


            return new WeatherDays(31);
        }



        //public static Rectangles InputCoordinates()
        //{

        //    while (true)
        //    {
        //        int selection;

        //        Console.WriteLine("Запишите координаты в файл в формате \"x,y x,y x,y x,y\"");
        //        Console.WriteLine("Если вводите все четыре координаты, то в правильной очерёдности.");
        //        Console.WriteLine("Ввод трёх точек не поддерживается");
        //        Console.WriteLine("\nВыберите тип ввода координат:\n1 - Ввод из файла;\n2 - Ввод из консоли.");

        //        switch (selection)
        //        {
        //            case 1:
        //                {
        //                    Console.WriteLine("Ввод из файла");

        //                    //Console.WriteLine("Можете ввести 1, 2, 3 или все четыре координаты, но в правильной очерёдности");
        //                    string PathToFile = "C:/Users/Admin/Desktop/Coordinates.txt";

        //                    while (true)
        //                    {
        //                        if (!File.Exists(PathToFile))
        //                        {
        //                            Console.WriteLine("Файл не найден, создайте файл Coordinates.txt на рабочем столе!");
        //                            Console.WriteLine("Нажмите \"Enter\", если изменили файл");
        //                            Console.ReadLine();
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            string TextFromFile = File.ReadAllText(PathToFile);
        //                            if (TextFromFile == "")
        //                            {
        //                                Console.WriteLine($"Файл {Path.GetFileName(PathToFile)} пустой, введите в него данные!");
        //                                Console.WriteLine("Нажмите \"Enter\", если изменили файл");
        //                                Console.ReadLine();
        //                                continue;
        //                            }
        //                            try
        //                            {
        //                                string[] TextFromFileArray = TextFromFile.Split(" ");
        //                                if (TextFromFileArray.Length == 1)
        //                                {
        //                                    string c = TextFromFileArray[0];
        //                                    string[] stringDots = c.Split(",");
        //                                    int[] intDots = Array.ConvertAll(stringDots, int.Parse);

        //                                    return new Rectangles(intDots);
        //                                }
        //                                if (TextFromFileArray.Length == 2)
        //                                {
        //                                    string a = TextFromFileArray[0];
        //                                    string[] stringDotsA = a.Split(",");
        //                                    int[] intDotsA = Array.ConvertAll(stringDotsA, int.Parse);
        //                                    string c = TextFromFileArray[1];
        //                                    string[] stringDotsC = c.Split(",");
        //                                    int[] intDotsC = Array.ConvertAll(stringDotsC, int.Parse);

        //                                    return new Rectangles(intDotsA, intDotsC);
        //                                }
        //                                if (TextFromFileArray.Length == 3)
        //                                {
        //                                    Console.WriteLine($"Ввод трёх координат не поддерживается!");
        //                                    Console.WriteLine("Нажмите \"Enter\", если изменили файл");
        //                                    Console.ReadLine();
        //                                    continue;
        //                                }
        //                                if (TextFromFileArray.Length == 4)
        //                                {
        //                                    string a = TextFromFileArray[0];
        //                                    string[] stringDotsA = a.Split(",");
        //                                    int[] intDotsA = Array.ConvertAll(stringDotsA, int.Parse);
        //                                    string b = TextFromFileArray[1];
        //                                    string[] stringDotsB = b.Split(",");
        //                                    int[] intDotsB = Array.ConvertAll(stringDotsB, int.Parse);
        //                                    string c = TextFromFileArray[2];
        //                                    string[] stringDotsC = c.Split(",");
        //                                    int[] intDotsC = Array.ConvertAll(stringDotsC, int.Parse);
        //                                    string d = TextFromFileArray[3];
        //                                    string[] stringDotsD = d.Split(",");
        //                                    int[] intDotsD = Array.ConvertAll(stringDotsD, int.Parse);

        //                                    return new Rectangles(intDotsA, intDotsB, intDotsC, intDotsD);
        //                                }
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                Console.WriteLine($"Вы не правильно ввели данные: {ex.Message}");
        //                            }

        //                            break;
        //                        }

        //                    }
        //                    Console.WriteLine("Файл принят");

        //                }
        //                break;

        //            case 2:
        //                {
        //                    Console.WriteLine("Ввод из консоли");
        //                    Console.Write("Ввод: ");
        //                    string TextFromConsole = Console.ReadLine();
        //                    try
        //                    {
        //                        string[] TextFromConsoleArray = TextFromConsole.Split(" ");

        //                        if (TextFromConsoleArray.Length == 1)
        //                        {
        //                            string c = TextFromConsoleArray[0];
        //                            string[] stringDots = c.Split(",");
        //                            int[] intDots = Array.ConvertAll(stringDots, int.Parse);

        //                            return new Rectangles(intDots);
        //                        }
        //                        if (TextFromConsoleArray.Length == 2)
        //                        {
        //                            string a = TextFromConsoleArray[0];
        //                            string[] stringDotsA = a.Split(",");
        //                            int[] intDotsA = Array.ConvertAll(stringDotsA, int.Parse);
        //                            string c = TextFromConsoleArray[1];
        //                            string[] stringDotsC = c.Split(",");
        //                            int[] intDotsC = Array.ConvertAll(stringDotsC, int.Parse);

        //                            return new Rectangles(intDotsA, intDotsC);
        //                        }
        //                        if (TextFromConsoleArray.Length == 3)
        //                        {
        //                            Console.WriteLine($"Ввод трёх координат не поддерживается!");
        //                            Console.WriteLine("Нажмите \"Enter\", если изменили файл");
        //                            Console.ReadLine();
        //                            continue;
        //                        }
        //                        if (TextFromConsoleArray.Length == 4)
        //                        {
        //                            string a = TextFromConsoleArray[0];
        //                            string[] stringDotsA = a.Split(",");
        //                            int[] intDotsA = Array.ConvertAll(stringDotsA, int.Parse);
        //                            string b = TextFromConsoleArray[1];
        //                            string[] stringDotsB = b.Split(",");
        //                            int[] intDotsB = Array.ConvertAll(stringDotsB, int.Parse);
        //                            string c = TextFromConsoleArray[2];
        //                            string[] stringDotsC = c.Split(",");
        //                            int[] intDotsC = Array.ConvertAll(stringDotsC, int.Parse);
        //                            string d = TextFromConsoleArray[3];
        //                            string[] stringDotsD = d.Split(",");
        //                            int[] intDotsD = Array.ConvertAll(stringDotsD, int.Parse);

        //                            return new Rectangles(intDotsA, intDotsB, intDotsC, intDotsD);
        //                        }

        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Console.WriteLine($"Вы не правильно ввели данные: {ex.Message}");
        //                    }
        //                }
        //                break;
        //        }
        //    }

        //}


    }

    class Program
    {



        static void Main(string[] args)
        {
            WeatherDays.InputDataFromFile();




            //WeatherParametersDay mondey = new WeatherParametersDay(12, 6, 133, 0);
            //WeatherParametersDay tuesday = new WeatherParametersDay(13, 7, 125, 3, TypeOfWeather.кратковременный_дождь);
            //mondey.GetInfo();
            //tuesday.GetInfo();
        }
    }
}
