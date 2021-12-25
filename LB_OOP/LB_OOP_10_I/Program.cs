using System;
using System.Collections.Generic;

namespace LB_OOP_10_I
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 6;
            IExecutable[] zoo = new IExecutable[size];
            zoo[0] = new Animals("Млекопитающие", 50);
            zoo[1] = new Birds("Воробей", "Воробьинообразный", 0, 1);
            zoo[2] = new Mammals("Ёж", "Насекомоядные", "Игольчатый", 15);
            zoo[3] = new Artiodactyls("Кабан", "Парнокопытные", 6, 70);
            zoo[4] = new Birds("Ястреб", "Хищник", 100, 1);
            zoo[5] = new Birds("Коршун", "Хищник", 50, 2);
            int count = 0;
            foreach (var item in zoo)
            {
                item.Show();
                Birds m = item as Birds;
                if (m != null) count++;
                Console.WriteLine("----------");
            }
            
            Console.WriteLine($"Количество объектов класса Birds равно {count}");
            Console.WriteLine("----------");

            Console.WriteLine("Могут ли летать птицы?");
            foreach (var item in zoo)
            {
                Birds m = item as Birds;
                if (m != null)
                {
                    if (m.Sky()) Console.WriteLine($"{m.Name} может летать");
                    else Console.WriteLine($"{m.Name} не способен летать");
                }
            } 
            
            Console.WriteLine("----------");
            Console.WriteLine("Наименование всех птиц в зоопарке:");
            foreach (var item in zoo)
            {
                Birds m = item as Birds;
                if (m != null) Console.WriteLine($"{m.Name}");
            }
            Console.WriteLine("----------");
            Animals[] animalArr = new Animals[size];
            for (int i = 0; i < size; i++)
            {
                animalArr[i] = (Animals)zoo[i];
            }

            Array.Sort(animalArr, new SortByWeight());
            Animals a = new Animals();
            Console.WriteLine("\nСортировка по весу:");
            
            foreach (var item in animalArr)
            {
                Console.WriteLine($"{item.Type} весит {item.Weight}");
            }
            Console.WriteLine("----------");

            Console.WriteLine("\nПоверхостное клонирование:");
            Birds animal = new Birds("Ястреб", "Птица", 10, 10);
            Animals animalCopy = animal.ShallowCopy();
            animalCopy.Type = "Насекомоядные";
            animalCopy.Weight = 5;
            animal.Show();
            Console.WriteLine("\nГлубокое клонирование:");
            Animals animal1 = new Animals("Птицы", 2);
            Animals animal1Copy = (Animals)animal1.Clone();
            animal1Copy.Type = "Насекомоядные";
            animal1.Show();
        }
    }
}
