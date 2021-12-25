using System;
using System.Collections.Generic;
using System.Text;

namespace LB_OOP_11
{
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    public class Animals : IExecutable, IComparable, ICloneable
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        protected int weight = 0;
        protected string type = "";
        public int Weight
        {
            get => weight;
            set => weight = value;
        }
        public string Type
        {
            get => type;
            set => type = value;
        }
        public Animals()
        {
            weight = 0;
            type = "";
        }
        public Animals(string t)
        {
            weight = 0;
            type = t;
        }
        public Animals(string t, int w)
        {
            weight = w;
            type = t;
        }
        public virtual void Show()
        {
            Console.WriteLine($"Тип: {Type}");
            Console.WriteLine($"Вес: {Weight} кг");
        }
        public int CompareTo(object obj)
        {
            Animals temp = obj as Animals;
            if (temp != null)
            {
                if (this.weight > temp.weight) return 1;
                if (this.weight < temp.weight) return -1;
            }
            return 0;
        }
        public Animals ShallowCopy()
        {
            return (Animals)this.MemberwiseClone();
        }
        public object Clone()
        {
            return new Animals("Клон" + this.type, this.weight);
        }
        public override bool Equals(object obj)
        {
            Animals anima = (Animals)obj;
            return this.Type == anima.Type && this.Weight == anima.Weight;

        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
