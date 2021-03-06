using System;
using System.Collections.Generic;
using System.Linq;
namespace ДискМатЛБ_1
{
    class Program
    {
        static List<int> InsertMass(List<int> a)
        {
            int n;
            bool flag;
            do
            {
                do
                {
                    Console.Write(">>");
                    flag = int.TryParse(Console.ReadLine(), out n);
                    if (!flag) Console.WriteLine("Ошибка! Введите целое число!");
                } while (!flag);
                foreach (int r in a)
                    if (r == n) flag = false;
                if (!flag) Console.WriteLine("Ошибка! Элементы множества не повторяются!");
            } while (!flag);
            a.Add(n);
            return a;
        }
        static void Print(List<int> a)
        {
            bool flag = false;
            Console.Write("{ ");
            foreach (int c in a)
            {
                if (flag) Console.Write(", ");
                else flag = true;
                Console.Write(c);
            }
            Console.WriteLine(" }");
        }
        static void Main(string[] args)
        {

            int numMenu;
            do
            {
                List<int> a = new List<int>();
                List<int> b = new List<int>();
                List<int> set = new List<int>();
                List<int> universum = new List<int>();
                bool flag;
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Выберете номер действия над множеством");
                Console.WriteLine("1.Объединение\n" +
                                  "2.Пересечение\n" +
                                  "3.Разность\n" +
                                  "4.Симметрическая разность\n" +
                                  "5.Отрицание\n" +
                                  "0.Выход");
                Console.WriteLine("--------------------------------------");
                do // Выбор действия
                {
                    Console.Write("Номер: ");
                    flag = int.TryParse(Console.ReadLine(), out numMenu);
                    if (!flag) Console.WriteLine("Error!");
                } while (!flag);
                if (numMenu != 0)
                {
                    int num;
                    do // Создание множества A
                    {
                        Console.Write("Введите кол-во элементов множества A: ");
                        flag = int.TryParse(Console.ReadLine(), out num);
                        if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                    } while (!flag);
                    for (int i = 0; i < num; i++) a = InsertMass(a);
                    if (numMenu != 5)
                    {
                        do // Создание множества B
                        {
                            Console.Write("Введите кол-во элементов множества B: ");
                            flag = int.TryParse(Console.ReadLine(), out num);
                            if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                        } while (!flag);
                        for (int i = 0; i < num; i++) b = InsertMass(b);
                    }
                    else
                    {
                        do // Создание множества B
                        {
                            Console.Write("Введите кол-во элементов множества U: ");
                            flag = int.TryParse(Console.ReadLine(), out num);
                            if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                        } while (!flag);
                        for (int i = 0; i < num; i++) b = InsertMass(b);
                    }
                }
                switch (numMenu)
                {
                    case 1: // Объединение множеств
                        set = a.Union(b).ToList();
                        Print(set);
                        break;
                    case 2: // Пересечение множеств
                        set = a.Intersect(b).ToList();
                        set = set.Distinct().ToList();
                        Print(set);
                        break;
                    case 3: // Разность множеств
                        set = a.Except(b).ToList();
                        //set = set.Distinct().ToList();
                        Print(set);
                        break;
                    case 4: // Симметрическая разность
                        set = a.Except(b).ToList();
                        set = set.Union(b.Except(a).ToList()).ToList();
                        
                        Print(set);
                        break;
                    case 5:
                        set = b.Except(a).ToList();
                        Print(set);
                        break;
                }
                if(numMenu != 0)
                {
                    Console.WriteLine(">>>Нажмте любую клавишу для продожения<<<");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (numMenu != 0);
        }
    }
}
