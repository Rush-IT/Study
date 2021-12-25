using System;
using System.Collections.Generic;
using System.Text;

namespace LB_OOP_11
{
    public class Mammals : Animals
    {
        string name = "";
        string cover = "";
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Cover
        {
            get => cover;
            set => cover = value;
        }
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

        public override void Show()
        {
            Console.WriteLine($"Вид: {name}");
            Console.WriteLine($"Тип: {Type}");
            Console.WriteLine($"Вес: {Weight} кг");
            if (cover != "") Console.WriteLine($"{cover} покров");
        }

    }
}
