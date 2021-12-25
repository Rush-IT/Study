using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_9_OOP
{
    public class TimeArray
    {
        private Time[] arr;
        private int size;
        static public int count = 0;
        public int Size
        {
            get { return size; }
            set
            {
                if (value < 0)
                    size = 0;
                else
                    size = value;
            }
        }
        ~TimeArray()
        {

        }
        public TimeArray()
        {
            arr = new Time[0];
            count++;
        }
        public TimeArray(int size, int h1)
        {
            Size = size;
            arr = new Time[size];
            Time t;
            for (int i = 0; i < Size; i++)
            {
                t = new Time(h1);
                arr[i] = t;
            }
            count++;
        }
        public static int Input(string text)
        {
            bool flag;
            int hs;
            do
            {
                Console.Write(text);
                flag = int.TryParse(Console.ReadLine(), out hs);
                if (hs < 0 || !flag)
                {
                    Console.WriteLine("Ошибка! Число введено не верно!");
                    flag = false;
                }
            } while (!flag);
            return hs;
        }
        public TimeArray(int h)
        {
            Size = h;
            arr = new Time[h];
            Time t;
            int min, hs;
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й временной интервал");
                hs = Input("Введите часы: ");
                min = Input("Введите минуты: ");
                t = new Time(hs, min);
                arr[i] = t;
            }
            count++;
        }
        public TimeArray(int h, int a, int b)
        {
            Size = h;
            arr = new Time[h];
            Time t;
            int min, hs;
            Random rnd;
            rnd = new Random();

            for (int i = 0; i < Size; i++)
            {
                min = rnd.Next(a, b);
                hs = rnd.Next(a, b);
                t = new Time(hs, min);
                arr[i] = t;
            }
            count++;
        }
        public Time this[int index]
        {
            get
            {
                if (index >= 0 && index < Size)
                    return arr[index];
                else
                    return arr[0];
            }
            set
            {
                if (index >= 0 && index < Size)
                    arr[index] = value;
                else
                    arr[0] = value;
            }
        }
        public void Show()
        {
            for (int i = 0; i < Size; i++)
                this[i].Show();
        }

        public int NumberMax()
        {
            Time t = new Time();
            int i_max = 0;
            Time max = this[0];
            for (int i = 1; i < Size; i++)
            {
                if (max < this[i])
                {
                    max = this[i];
                    i_max = i;
                }
            }
            return i_max + 1;
        }
    }
}
