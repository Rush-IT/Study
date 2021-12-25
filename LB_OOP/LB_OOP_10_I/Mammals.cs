using System;
using System.Collections.Generic;
using System.Text;

namespace LB_OOP_10_I
{
    public class Mammals : Animals
    {
        string name = "";
        string cover = "";
        public Mammals() : base()
        {
            name = "";
            cover = "";
        }
        public Mammals(string n, string t, int w) : base(t, w)
        {
            name = n;
            cover = "";
        }
        public Mammals(string n, string t, string c, int w) : base(t, w)
        {
            name = n;
            cover = c;
        }
        public override void Light()
        {
            
        }
        public override void Show()
        {
            Console.WriteLine($"Вид: {name}");
            Console.WriteLine($"Тип: {type}");
            Console.WriteLine($"Вес: {weight} кг");
            if (cover != "") Console.WriteLine($"{cover} покров");
        }
    }
}
