using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_9_OOP
{
    public class Time
    {
        private int hours;
        private int minutes;
        static public int count = 0;
        public int Hours
        {
            get { return hours; }
            set
            {
                if (value < 0) hours = 0;
                else hours = value;
            }
        }
        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value < 0) minutes = 0;
                else minutes = value;
            }
        }
        public Time()
        {
            hours = 0;
            minutes = 0;
            count++;
        }
        ~Time()
        {
            count--;
        }
        public Time(int h)
        {
            hours = h;
            minutes = 0;
            count++;
        }
        public Time(int h, int m)
        {
            hours = h;
            minutes = m;
            count++;
        }
        public Time Minus(int a)
        {
            int temp = HoursInMinutes(this) - a;
            if (temp < 0)
            {
                return new Time();
            }
            else
            {
                return new Time
                {
                    minutes = IntInTime(temp).Minutes,
                    hours = IntInTime(temp).Hours
                };
            }
        }
        public static int HoursInMinutes(Time t)
        {
            return t.hours * 60 + t.minutes;
        }
        public static Time IntInTime(int a)
        {
            return new Time
            {
                hours = a / 60,
                minutes = a % 60
            };

        }
        public static explicit operator int(Time t)
        {
            return t.hours;
        }
        public static implicit operator bool(Time t)
        {
            return (t.hours == 0 && t.minutes == 0);
        }
        public static Time operator --(Time t)
        {
            int temp = HoursInMinutes(t) - 1;
            if (temp < 0)
            {
                return new Time();
            }
            else
            {
                return new Time
                {
                    minutes = IntInTime(temp).Minutes,
                    hours = IntInTime(temp).Hours
                };
            }
        }
        public static Time operator +(Time t1, Time t2)
        {
            int temp1 = HoursInMinutes(t1);
            int temp2 = HoursInMinutes(t2);
            return new Time
            {
                minutes = IntInTime(temp1 + temp2).Minutes,
                hours = IntInTime(temp1 + temp2).Hours
            };
        }
        public static Time operator +(int a, Time t)
        {
            int temp = t.hours * 60 + t.minutes + a;
            return new Time
            {
                minutes = IntInTime(temp).Minutes,
                hours = IntInTime(temp).Hours
            };
        }
        public static Time operator +(Time t, int a)
        {
            int temp = t.hours * 60 + t.minutes + a;
            return new Time
            {
                minutes = IntInTime(temp).Minutes,
                hours = IntInTime(temp).Hours
            };
        }
        public static bool operator <(Time t1, Time t2)
        {
            int temp1 = HoursInMinutes(t1);
            int temp2 = HoursInMinutes(t2);
            return temp1 < temp2;
        }
        public static bool operator >(Time t1, Time t2)
        {
            int temp1 = HoursInMinutes(t1);
            int temp2 = HoursInMinutes(t2);
            return temp1 > temp2;
        }
        public void Show()
        {
            Console.WriteLine($"{hours}:{minutes}");
        }
    }
}
