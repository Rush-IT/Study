using System;
using System.Collections.Generic;
using System.Text;

namespace LB_OOP_10_I
{
    public class Birds : Animals
    {
        string name = "";
        int scope = 0;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Scope
        {
            get => scope; 
            set => scope = value;
        }

        public Birds() : base()
        {
            name = "";
        }
        public Birds(string n, string t, int s, int w) : base(t, w)
        {
            name = n;
            scope = s;
        }
        public bool Sky()
        {
            return Scope > 0;
        }
        public override void Show()
        {
            Console.WriteLine($"Вид: {name}");
            Console.WriteLine($"Тип: {type}");
            Console.WriteLine($"Размах крыла: {scope} см");
            Console.WriteLine($"Вес: {weight}кг");
        }
    }
}
