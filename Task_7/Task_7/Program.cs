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
            TypeOfWeatherAtDay = TypeOfWeather.не_определено;
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

        private static WeatherDays InputDataFromFile()
        {
            WeatherDays arrDaysParams;
            Console.WriteLine("Ввод из файла");
            Console.WriteLine("В первой строчке введите количество дней.");
            Console.WriteLine("В слудующих строчках вводите параметры погоды дня в формате:");
            Console.WriteLine("f1 f2 f3 i s");
            Console.WriteLine("f1 = Средняя температура днём - float");
            Console.WriteLine("f2 = Средняя температура ночью - float");
            Console.WriteLine("f3 = Средняе атмосферное давление - float (мм ртутного столба");
            Console.WriteLine("i = Количество осадков - int (мм/день)");
            Console.WriteLine("s = Тип погоды в этот день - string (ниже примеры типов погоды, вводить это значение необязательно)");
            Console.WriteLine("Типы погоды: не_определено, дождь, кратковременный_дождь, гроза, снег, туман, хмуро, солнечно\n");

            string PathToFile = "D:/OneDrive - ДонНУ/Рабочий стол/Univer/WeatherDays.txt";
            //string PathToFile = "C:/Users/Admin/Desktop/Univer/WeatherDays.txt";
            while (true)
            {
                bool restartRead = false;
                if (!File.Exists(PathToFile))
                {
                    Console.WriteLine($"Файл не найден, создайте файл WeatherDays.txt по пути {PathToFile}");
                    Console.WriteLine("Нажмите \"Enter\", если создали файл");
                    Console.ReadLine();
                    continue;
                }
                int numberOfDays;
                using (StreamReader fileData = new StreamReader(PathToFile))
                {
                    //StreamReader fileData = new StreamReader(PathToFile);
                    string firstLine = fileData.ReadLine();

                    if (firstLine == null)
                    {
                        Console.WriteLine($"Файл {Path.GetFileName(PathToFile)} пустой, введите в него данные!");
                        fileData.Close();
                        Console.WriteLine("Нажмите \"Enter\", если изменили файл");
                        Console.ReadLine();
                        continue;
                    }
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
                    arrDaysParams = new WeatherDays(numberOfDays);
                    int count = 0;
                    while (count != numberOfDays)
                    {
                        string nextLine = fileData.ReadLine();
                        if (nextLine == null)
                        {
                            Console.WriteLine($"В строке {count + 2} пусто");
                            fileData.Close();
                            Console.WriteLine("Нажмите \"Enter\", если исправили строку");
                            Console.ReadLine();
                            restartRead = true;
                            break;
                        }
                        string[] splitLine = nextLine.Split(" ");
                        if (splitLine.Length != 4 & splitLine.Length != 5)
                        {
                            Console.WriteLine($"В строке {count + 2} данные введены неверно");
                            fileData.Close();
                            //Console.WriteLine($"count: {count}, splitLine.Length {splitLine.Length}");
                            Console.WriteLine("Нажмите \"Enter\", если исправили строку");
                            Console.ReadLine();
                            restartRead = true;
                            break;
                        }
                        try
                        {
                            float AverageTemperaturePerDay = float.Parse(splitLine[0], System.Globalization.CultureInfo.InvariantCulture);
                            float AverageTemperatureAtNight = float.Parse(splitLine[1], System.Globalization.CultureInfo.InvariantCulture);
                            float AverageAtmosphericPressure = float.Parse(splitLine[2], System.Globalization.CultureInfo.InvariantCulture);
                            int Precipitation = Convert.ToInt32(splitLine[3]);
                            TypeOfWeather TypeOfWeatherAtDay = TypeOfWeather.не_определено;
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
                        if (restartRead)
                        { break; }
                    }
                    if (restartRead)
                    { continue; }
                }

                break;


            }
            Console.WriteLine("\nФайл принят");
            return arrDaysParams;
        }

        private static WeatherDays InputDataFromConsole()
        {
            WeatherDays arrDaysParams;
            Console.WriteLine("Ввод из консоли");
            int numberOfDays;
            while (true)
            {
                Console.WriteLine("Введите количество дней:");
                string strNumberOfDays = Console.ReadLine();
                try
                {
                    numberOfDays = Convert.ToInt32(strNumberOfDays);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Вы не правильно ввели данные: {ex.Message}");
                    continue;
                }

            }
            arrDaysParams = new WeatherDays(numberOfDays);

            Console.WriteLine("В слудующих строчках вводите параметры погоды дня в формате:");
            Console.WriteLine("f1 f2 f3 i s");
            Console.WriteLine("f1 = Средняя температура днём - float");
            Console.WriteLine("f2 = Средняя температура ночью - float");
            Console.WriteLine("f3 = Средняе атмосферное давление - float (мм ртутного столба");
            Console.WriteLine("i = Количество осадков - int (мм/день)");
            Console.WriteLine("s = Тип погоды в этот день - string (ниже примеры типов погоды, вводить это значение необязательно)");
            Console.WriteLine("Типы погоды: не_определено, дождь, кратковременный_дождь, гроза, снег, туман, хмуро, солнечно\n");

            int count = 0;
            while (count != numberOfDays)
            {
                while (true)
                {
                    Console.WriteLine($"Вводите параметры {count + 1} дня:");
                    string nextLine = Console.ReadLine();
                    string[] splitLine = nextLine.Split(" ");
                    if (splitLine.Length != 4 & splitLine.Length != 5)
                    {
                        Console.WriteLine($"Данные введены неверно");
                        continue;
                    }
                    try
                    {
                        float AverageTemperaturePerDay = float.Parse(splitLine[0], System.Globalization.CultureInfo.InvariantCulture);
                        float AverageTemperatureAtNight = float.Parse(splitLine[1], System.Globalization.CultureInfo.InvariantCulture);
                        float AverageAtmosphericPressure = float.Parse(splitLine[2], System.Globalization.CultureInfo.InvariantCulture);
                        int Precipitation = Convert.ToInt32(splitLine[3]);
                        TypeOfWeather TypeOfWeatherAtDay = TypeOfWeather.не_определено;
                        if (splitLine.Length == 5)
                        {
                            TypeOfWeatherAtDay = (TypeOfWeather)Enum.Parse(typeof(TypeOfWeather), splitLine[4], true);
                        }
                        WeatherParametersDay dayParams = new WeatherParametersDay(AverageTemperaturePerDay, AverageTemperatureAtNight, AverageAtmosphericPressure, Precipitation, TypeOfWeatherAtDay);
                        arrDaysParams.insertDaySettings(count, dayParams);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Данные введены неверно");
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        continue;
                    }


                }
                count++;
            }





            Console.WriteLine("\nФайл принят");
            return arrDaysParams;
        }

        public static WeatherDays InputData()
        {
            bool typeOfInput = ChooseTypeOfInput();
            WeatherDays arrDays;
            if (typeOfInput)
            {
                arrDays = InputDataFromFile();
            }
            else
            {
                arrDays = InputDataFromConsole();
            }
            return arrDays;
        }

        public int NumberOfGloomyDays()
        {
            int nogd = 0;
            int count = 0;
            while (count != ArrWeatherDays.Length)
            {
                WeatherParametersDay day = ArrWeatherDays[count];
                if (day.TypeOfWeatherAtDay == TypeOfWeather.хмуро)
                {
                    nogd++;
                }
                count++;
            }
            return nogd;
        }

        public void PrintNumberOfGloomyDays()
        {
            int nogd = NumberOfGloomyDays();
            Console.WriteLine($"Количество хмурых дней: {nogd}");
        }
        
        public int NumberOfDaysWithRain()
        {
            int nodwr = 0;
            int count = 0;
            while (count != ArrWeatherDays.Length)
            {
                WeatherParametersDay day = ArrWeatherDays[count];
                if (day.TypeOfWeatherAtDay == TypeOfWeather.дождь)
                {
                    nodwr++;
                }
                count++;
            }
            return nodwr;
        }

        public void PrintNumberOfDaysWithRain()
        {
            int nodwr = NumberOfDaysWithRain();
            Console.WriteLine($"Количество дней с дождём: {nodwr}");
        }

        public int NumberOfThunderstormDay()
        {
            int notd = 0;
            int count = 0;
            while (count != ArrWeatherDays.Length)
            {
                WeatherParametersDay day = ArrWeatherDays[count];
                if (day.TypeOfWeatherAtDay == TypeOfWeather.гроза)
                {
                    notd++;
                }
                count++;
            }
            return notd;
        }

        public void PrintNumberOfThunderstormDays()
        {
            int notd = NumberOfThunderstormDay();
            Console.WriteLine($"Количество дней с грозой: {notd}");
        }

        public void PrintTotalDaysWithRainOrThunderstorm()
        {
            int nodwr = NumberOfDaysWithRain();
            int notd = NumberOfThunderstormDay();
            Console.WriteLine($"Общее количество дней с грозой или дождём: {nodwr + notd}");
        }

        public float MinTemperatureAtNights()
        {
            int idx=0;
            int count = 1;
            while (count != ArrWeatherDays.Length)
            {
                WeatherParametersDay day1 = ArrWeatherDays[idx];
                WeatherParametersDay day2 = ArrWeatherDays[count];

                if (day1.AverageTemperatureAtNight > day2.AverageTemperatureAtNight)
                {
                    idx = count;
                }
                count++;
            }
            WeatherParametersDay day = ArrWeatherDays[idx];
            return day.AverageTemperatureAtNight;
        }

        public void PrintMinTemperatureAtNights()
        {
            float mtan = MinTemperatureAtNights();
            Console.WriteLine($"Минимальная температура ночью за месяц: {mtan}");
        }

        
        public float MaxTemperatureAtDays()
        {
            int idx=0;
            int count = 1;
            while (count != ArrWeatherDays.Length)
            {
                WeatherParametersDay day1 = ArrWeatherDays[idx];
                WeatherParametersDay day2 = ArrWeatherDays[count];

                if (day1.AverageTemperatureAtNight < day2.AverageTemperatureAtNight)
                {
                    idx = count;
                }
                count++;
            }
            WeatherParametersDay day = ArrWeatherDays[idx];
            return day.AverageTemperatureAtNight;
        }

        public void PrintMaxTemperatureAtDays()
        {
            float mtad = MaxTemperatureAtDays();
            Console.WriteLine($"Максимальная температура днём за месяц: {mtad}");
        }


        


    }

    class Program
    {
        static void Main(string[] args)
        {
            WeatherDays arrDays = WeatherDays.InputData();
            WeatherParametersDay[] arrParams = arrDays.ArrWeatherDays;
            WeatherParametersDay firstDay = arrParams[0];
            Console.WriteLine();
            firstDay.GetInfo();
            arrDays.PrintNumberOfGloomyDays();
            arrDays.PrintTotalDaysWithRainOrThunderstorm();
            arrDays.PrintMinTemperatureAtNights();
            arrDays.PrintMaxTemperatureAtDays();

            //WeatherParametersDay mondey = new WeatherParametersDay(12, 6, 133, 0);
            //WeatherParametersDay tuesday = new WeatherParametersDay(13, 7, 125, 3, TypeOfWeather.кратковременный_дождь);
            //mondey.GetInfo();
            //tuesday.GetInfo();
        }
    }
}
