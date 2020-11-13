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

namespace Task_7
{
    enum TypeOfWeather : byte
    {
        не_визначено,
        дощ,
        короткочасний_дощ,
        гроза,
        сніг,
        туман,
        похмуро,
        сонячно
    }
    class WeatherParametersDay
    {
        public float AverageTemperaturePerDay { get; private set; }
        public float AverageTemperatureAtNight { get; private set; }
        public int AverageAtmosphericPressure { get; private set; }
        public int Precipitation { get; private set; }
        public TypeOfWeather TypeOfWeatherAtDay { get; private set; }

    }

    class WeatherDays
    {
        private WeatherParametersDay[] ArrWeatherDays = new WeatherParametersDay[31];

    }

    class Program
    {
        enum Days : byte
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        enum Time : byte
        {
            Morning = 1,
            Afternoon,
            Evening,
            Night
        }


        static void Main(string[] args)
        {
            Days day = Days.Friday;
            Console.WriteLine((byte)day);
        }
    }
}
