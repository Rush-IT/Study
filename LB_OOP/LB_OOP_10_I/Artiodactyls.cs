using System;
using System.Collections.Generic;
using System.Text;

namespace LB_OOP_10_I
{
    public class Artiodactyls : Mammals
    {
        int speed = 0;
        public int Speed
        {
            get => speed;
            set => speed = value;
        }

        public Artiodactyls() : base() { }
        public Artiodactyls(int s) : base()
        {
            speed = s;
        }
        public Artiodactyls(string n, string t, int s, int w) : base(n, t, w)
        {
            speed = s;
        }
        public override void Show()
        {
            Console.WriteLine($"Тип: {type}");
            Console.WriteLine($"Скорость: {speed} км/ч");
            Console.WriteLine($"Вес: {weight} кг");
        }
    }
}
