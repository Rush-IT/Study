using System;

namespace Lab_9_OOP
{
    class Program
    {
        static int Input()
        {
            bool flag;
            int number;
            do
            {
                flag = int.TryParse(Console.ReadLine(), out number);
                if (!flag) Console.WriteLine("Ошибка! Число введено не верно!");
            } while (!flag);
            return number;
        }
        static Time Minus_min(Time t, int a)
        {
            int temp = t.Hours * 60 + t.Minutes - a;
            if (temp < 0)
            {
                return new Time();
            }
            else
            {
                return new Time
                {
                    Minutes = temp % 60,
                    Hours = temp / 60
                };
            }
        }
        static void Main(string[] args)
        {
            //Создание конструктора без параметров
            Time t = new Time();
            Console.Write("Конструктор без параметров: ");
            t.Show();

            //Создание конструктора с пареметром
            Time t1 = new Time(3);
            Console.Write("Конструктор с параметром: ");
            t1.Show();

            //Создание конструктора с параметрами
            Time t2 = new Time(15, 30);
            Console.Write("Конструктор с параметрами: ");
            t2.Show();

            //Приведение типов int и bool
            Console.WriteLine($"Приведение к int:{(int)t2}\nПриведение к bool:{(bool)t2}");

            //Вычетание целого числа из типа Time с использованием внешней функции
            Console.WriteLine("Вычитание внешней функцией");
            Console.WriteLine("Введите число для вычитания");
            int s = Input();
            t2 = Minus_min(t2, s);
            t2.Show();

            //Вычитание целогочисла из типа Time с использованием метода класса
            Console.WriteLine("Вычитание методом класса");
            Console.WriteLine("Введите число для вычитания");
            s = Input();
            t2 = t2.Minus(s);
            t2.Show();

            //Вычитание минут
            Console.WriteLine("Вычитание минут");
            t2--;
            --t2;
            t2.Show();

            //Добавление минут к временному интервалу
            Console.WriteLine("Добавление минут");
            t2 = t2 + 23;
            t2 = 27 + t2;
            t2.Show();

            //Сложения временных интервалов
            Console.WriteLine("Сложение временных интервалов");
            t1 = t2 + t1;
            t1 = t1 + t2;
            t1.Show();

            //Массив без параметров
            Console.WriteLine("Создание массива без параметров");
            TimeArray arr1 = new TimeArray();
            arr1.Show();

            //Массив с параметром
            Console.WriteLine("Создание массива с параметром");
            TimeArray arr2 = new TimeArray(5);
            arr2.Show();

            //Массив с параметрами
            Console.WriteLine("Создание массива с параметрами");
            TimeArray arr3 = new TimeArray(10, 0, 10);
            arr3.Show();

            //Поиск номера максимального элемента
            int min = arr3.NumberMax();
            Console.WriteLine($"Номер максимального элемента равен {min}");
        }
    }
}
