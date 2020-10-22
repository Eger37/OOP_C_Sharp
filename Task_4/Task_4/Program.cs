//Для роботи з грошима у форматі: гривні, копійки створити структуру
//та функції, що дозволяють:
//a) вводити грошову суму з клавіатури (файлу);
//b) виводити грошову суму на екран (файл);
//c) знаходити суму / різницю двох грошових сум;
//d) переведення грошової суми у копійки та навпаки.
//2
//Створити приклад для демонстрації усіх функціональних
//можливостей.

using System;
using System.Text;
// Підключаємо бібліотеку Linq
using System.Linq;
// Підключаємо простір імен для роботи з файлами
using System.IO;

namespace Task_4
{
    class Money
    {

    }
    class Dates
    {
        private DateTime date;


        // Оголошення властивості з іменем Date
        public DateTime Date
        {
            /* get – аксесор, що використовуєтья для читання значення 
             * з внутрішнього поля класу */
            get
            {
                return date;
            }
            /* set – аксесор, що використовується для запису значення 
             * у внутрішнє поле класу. Аксесор set отримує неявний параметр 
             * value, що містить значення, яке присвоюється властивості */
            private set
            {
                date = value;
            }
        }


        /* Конструктор здійснює ініціалізацію об’єкту класу при його створенні. 
         * Конструктор має таке саме ім’я як і клас */
        public Dates(int y, int m, int d)
        {
            /* Динамічне виділення пам’яті для об’єктів чи інших видів даних 
             * реалізується з допомогою оператора new */
            int[] month30 = new int[] { 4, 6, 9, 11 };
            int[] month31 = new int[] { 1, 3, 5, 6, 7, 8, 10, 12 };
            /* Бінарні && (умовне логічне І) і || (Умовне логічне АБО) оператори.
             * Ці оператори обчислюють правий операнд, тільки якщо це необхідно. */
            if (!((1 > d || d > 30 || !month30.Contains(m)) &&
                (1 > d || d > 31 || !month31.Contains(m)) &&
                (1 > d || d > 29 || m != 2 || y % 4 != 0 || y % 100 != 0 || y % 400 != 0) &&
                (1 > d || d > 28 || m != 2 || y % 4 == 0 || y % 100 == 0 || y % 400 == 0)))
            {
                Date = new DateTime(y, m, d);
            }
            else
            {
                Console.WriteLine("Невірна дата");
                Variable.key = false;
            }
        }

        public string SubtractDates(DateTime value1, DateTime value2)
        {
            int[] res = DateDifference(value1.Subtract(value2).TotalDays);
            return $"{res[0]} year {res[1]} month {res[2]} day";
        }

        private int[] DateDifference(double days)
        {
            double rem = (int)days;
            int year = (int)((days - 30.417) / 365);
            rem -= year * 365;
            int month = (int)(rem / 30.417);
            rem -= month * 30.417;
            int day = (int)(rem + 1);
            return new int[] { year, month, day };
        }

        // Конвертація дати в дні
        public double ToDays(DateTime dateValue)
        {
            return dateValue.Day + (30.417 * dateValue.Month) + (365 * dateValue.Year);
        }

        // Конвертація назад в дату
        public string ToDate(double days)
        {
            int[] res = DateDifference(days);
            return new DateTime(res[0], res[1], res[2]).ToShortDateString();
        }
    }

    public static class Variable
    {
        public static bool key = true;
    }

    class Program
    {
        private static int[] DateTransformation(string text)
        {
            int[] res = new int[3];
            string[] textSplit = text.Split("/");
            for (int i = 0; i < textSplit.Length; i++)
            {
                try
                {
                    res[i] = Convert.ToInt32(textSplit[i]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Не можна прочитати файл: {ex.Message}");
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            int choice;
            // Просимо користувача обрати тип введення даних
            Console.WriteLine("Оберіть тип введеня:\n1. З консолі\n2. З файлу");
            while (true)
            {
                try
                {
                    Console.Write("Ваша відповідь: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1 || choice == 2)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Оберіть один із двох варіантів!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            /* Оператор вибору switch забезпечує багатонаправлене розгалуження 
             * програми. Цей оператор дозволяє зробити вибір серед декількох 
             * альтернативних варіантів подальшого виконання програми */
            switch (choice)
            {
                // Введення даних вручну
                case 1:
                    Console.WriteLine("Ви обрали з консолі");
                    Console.Write("Введіть першу дату у форматі yyyy/MM/dd: ");
                    int[] arr1 = DateTransformation(Console.ReadLine());
                    Console.Write("Введіть другу дату у форматі yyyy/MM/dd: ");
                    int[] arr2 = DateTransformation(Console.ReadLine());

                    Dates dateClass1 = new Dates(arr1[0], arr1[1], arr1[2]);
                    Dates dateClass2 = new Dates(arr2[0], arr2[1], arr2[2]);

                    if (!Variable.key)
                    {
                        return;
                    }

                    DateTime getDate1 = dateClass1.Date;
                    DateTime getDate2 = dateClass2.Date;

                    double getDateToDays1 = dateClass1.ToDays(getDate1);
                    double getDateToDays2 = dateClass2.ToDays(getDate2);

                    Console.WriteLine($"Перша дата: {getDate1.ToShortDateString()}");
                    Console.WriteLine($"Друга дата: {getDate2.ToShortDateString()}");

                    Console.WriteLine($"Різниця двох дат: {dateClass1.SubtractDates(getDate1, getDate2)}");
                    Console.WriteLine($"Конвертація першої дати в дні: {getDateToDays1:f0}");
                    Console.WriteLine($"Конвертація назад в дату: {dateClass1.ToDate(getDateToDays1)}");
                    Console.WriteLine($"Конвертація другої дати в дні: {getDateToDays2:f0}");
                    Console.WriteLine($"Конвертація назад в дату: {dateClass2.ToDate(getDateToDays2)}");
                    // Вказує на закінчення блоку
                    break;
                // Отримання даних з файлу
                case 2:
                    {
                        Console.WriteLine("Ви обрали з файлу");
                        // Змінна для зберігання шляху до файлу
                        string pathDates = @"/Users/hryniuk.a/Projects/Task_4/Dates.txt";
                        // Перевірка на існування файла та чи не пустий він
                        if (!File.Exists(pathDates))
                        {
                            Console.WriteLine($"Файл {Path.GetFileName(pathDates)} не існує");
                            return;
                        }
                        else
                        {
                            if (new FileInfo(pathDates).Length == 0)
                            {
                                Console.WriteLine($"Файл {Path.GetFileName(pathDates)} пустий");
                                return;
                            }
                        }

                        using StreamReader sr = new StreamReader(pathDates);
                        int[] arr3 = DateTransformation(sr.ReadLine());
                        int[] arr4 = DateTransformation(sr.ReadLine());
                        Dates dateClass3 = new Dates(arr3[0], arr3[1], arr3[2]);
                        Dates dateClass4 = new Dates(arr4[0], arr4[1], arr4[2]);

                        if (!Variable.key)
                        {
                            return;
                        }

                        DateTime getDate3 = dateClass3.Date;
                        DateTime getDate4 = dateClass4.Date;

                        double getDateToDays3 = dateClass3.ToDays(getDate3);
                        double getDateToDays4 = dateClass4.ToDays(getDate4);

                        Console.WriteLine($"Перша дата: {getDate3.ToShortDateString()}");
                        Console.WriteLine($"Друга дата: {getDate4.ToShortDateString()}");

                        Console.WriteLine($"Різниця двох дат: {dateClass3.SubtractDates(getDate3, getDate4)}");
                        Console.WriteLine($"Конвертація першої дати в дні: {getDateToDays3:f0}");
                        Console.WriteLine($"Конвертація назад в дату: {dateClass3.ToDate(getDateToDays3)}");
                        Console.WriteLine($"Конвертація другої дати в дні: {getDateToDays4:f0}");
                        Console.WriteLine($"Конвертація назад в дату: {dateClass4.ToDate(getDateToDays4)}");
                    }
                    break;
                // Блок (гілка) default не є обов’язковою
                default:
                    break;
            }
        }
    }
}