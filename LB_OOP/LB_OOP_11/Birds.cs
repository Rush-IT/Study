using System;
using System.Collections.Generic;
using System.Text;

namespace LB_OOP_11
{
    public class Birds : Animals
    {
        string name = "";
        int scope = 0;
        public Animals BaseAnimals
        {
            get => new Animals(type, weight);
        }
        public string Name
        {
            get => name;
            set => name = value;
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
        public override void Show()
        {
            Console.WriteLine($"Вид: {name}");
            Console.WriteLine($"Тип: {Type}");
            Console.WriteLine($"Размах крыла: {scope} см");
            Console.WriteLine($"Вес: {Weight}кг");
        }
    }
}
