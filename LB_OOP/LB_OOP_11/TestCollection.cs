using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace LB_OOP_11
{
    public class TestCollection
    {
        public Queue<Animals> firstKey;
        public Queue<string> firstString;
        public SortedDictionary<Animals, Birds> secondKey;
        public SortedDictionary<string, Birds> secondString;
        public Queue<Birds> thirdKey;
        public Birds last;
        public Birds midle;
        public int size;
        public TestCollection()
        {
            firstKey = new Queue<Animals>();
            firstString = new Queue<string>();
            thirdKey = new Queue<Birds>();
            secondKey = new SortedDictionary<Animals, Birds>();
            secondString = new SortedDictionary<string, Birds>();
            Birds last = new Birds();
            Birds midle = new Birds();
            size = 0;
        }
        public void Add(int capasity)
        {
            int num = 0;
            while (num != capasity)
            {
                Birds birds = (Birds)RandomGenerate.RandToBirds();
                Animals anima = birds.BaseAnimals;
                if (!secondString.ContainsKey(anima.Type) && !secondKey.ContainsKey(anima))
                {
                    firstKey.Enqueue(anima);
                    firstString.Enqueue(anima.Type);
                    secondKey.Add(anima, birds);
                    secondString.Add(anima.Type, birds);
                    thirdKey.Enqueue(birds);
                    if (num == (capasity / 2)) midle = birds;
                    if (num == (capasity - 1)) last = birds;
                    num++;
                }
            }
            size = capasity;
        }
        public void Del(int numberDel)
        {
            int num = 0;
            Queue<Birds> thirdKeyCopy = new Queue<Birds>();
            thirdKeyCopy = thirdKey;
            while (num != size)
            {
                if (num == ((size - numberDel) / 2)) midle = thirdKeyCopy.Peek();
                if (num == (size - numberDel - 1)) last = thirdKeyCopy.Peek();
                thirdKeyCopy.Dequeue();
                num++;
            }
            num = 0;
            while (num != numberDel)
            {
                firstKey.Dequeue();
                firstString.Dequeue();
                secondKey.Remove(firstKey.Peek());
                secondString.Remove(firstString.Peek());
                thirdKey.Dequeue();
            }
            size -= numberDel;
        }
        public void TimeConll()
        {
            Stopwatch time = new Stopwatch();
            bool isFound;
            Birds _third_first = (Birds)thirdKey.Peek().ShallowCopy();
            Birds _third_last = (Birds)last.ShallowCopy();
            Birds _third_midle = (Birds)midle.ShallowCopy();
            Birds _third_not = (Birds)RandomGenerate.RandToBirds(200);

            //-----------------------------------------
            Console.WriteLine("Работа с Queue<Animals>");
            //-----------------------------------------
            time.Start(); isFound = firstKey.Contains(_third_first); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Первый элемент найден за      {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Первый элемент не найден");

            time.Restart(); isFound = firstKey.Contains(_third_last.BaseAnimals); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Последний элемент найден за   {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Последний элемент не найден");

            time.Restart(); isFound = firstKey.Contains(_third_midle); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Центральный элемент найден за {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Центральный элемент не найден");

            time.Restart(); isFound = firstKey.Contains(_third_not); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Несуществующий элемент найден за {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Несуществующий элемент не найден");

            //-----------------------------------------
            Console.WriteLine("\nРабота с Queue<string>");
            //-----------------------------------------
            time.Restart(); isFound = firstString.Contains(_third_first.Type); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Первый элемент найден за     {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Первый элемент не найден");

            time.Restart(); isFound = firstString.Contains(_third_last.Type); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Последний элемент найден за  {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Последний элемент не найден");

            time.Restart(); isFound = firstString.Contains(_third_midle.Type); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Центральный элемент найден за {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Центральный элемент не найден");

            time.Restart(); isFound = firstString.Contains(_third_not.BaseAnimals.Type); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Несуществующий элемент найден за {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Несуществующий элемент не найден");

            //-----------------------------------------
            Console.WriteLine("\nРабота с SortedDictionary<Animals, Birds> Key");
            //-----------------------------------------

            time.Restart(); isFound = secondKey.ContainsKey(_third_first.BaseAnimals); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Первый элемент найден за      {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Первый элемент не найден");

            time.Restart(); isFound = secondKey.ContainsKey(_third_last.BaseAnimals); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Последний элемент найден за   {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Последний элемент не найден");

            time.Restart(); isFound = secondKey.ContainsKey(_third_midle.BaseAnimals); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Центральный элемент найден за {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Центральный элемент не найден");

            time.Restart(); isFound = secondKey.ContainsKey(_third_not.BaseAnimals); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Несуществующий элемент найден за {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Несуществующий элемент не найден");

            //-----------------------------------------
            Console.WriteLine("\nРабота с SortedDictionary<Animals, Birds> Value");
            //-----------------------------------------

            time.Restart(); isFound = secondKey.ContainsValue(_third_first); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Первый элемент найден за      {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Первый элемент не найден");

            time.Restart(); isFound = secondKey.ContainsValue(_third_last); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Последний элемент найден за   {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Последний элемент не найден");

            time.Restart(); isFound = secondKey.ContainsValue(_third_midle); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Центральный элемент найден за {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Центральный элемент не найден");

            time.Restart(); isFound = secondKey.ContainsValue(_third_not); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Несуществующий элемент найден за {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Несуществующий элемент не найден");

            //-----------------------------------------
            Console.WriteLine("\nРабота с SortedDictionary<string, Birds> Key");
            //-----------------------------------------
            time.Start(); isFound = secondString.ContainsKey(_third_first.Type); time.Restart();
            if (isFound)
            {
                Console.WriteLine($"Первый элемент найден за      {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Первый элемент не найден");

            time.Restart(); isFound = secondString.ContainsKey(_third_last.Type); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Последний элемент найден за   {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Последний элемент не найден");

            time.Restart(); isFound = secondString.ContainsKey(_third_midle.Type); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Центральный элемент найден за {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Центральный элемент не найден");

            time.Restart(); isFound = secondString.ContainsKey(_third_not.BaseAnimals.Type); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Несуществующий элемент найден за {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Несуществующий элемент не найден");
            //-----------------------------------------
            Console.WriteLine("\nРабота с SortedDictionary<string, Birds> Value");
            //-----------------------------------------
            time.Start(); isFound = secondString.ContainsValue(_third_first); time.Restart();
            if (isFound)
            {
                Console.WriteLine($"Первый элемент найден за      {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Первый элемент не найден");

            time.Restart(); isFound = secondString.ContainsValue(_third_last); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Последний элемент найден за   {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Последний элемент не найден");

            time.Restart(); isFound = secondString.ContainsValue(_third_midle); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Центральный элемент найден за {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Центральный элемент не найден");

            time.Restart(); isFound = secondString.ContainsValue(_third_not); time.Stop();
            if (isFound)
            {
                Console.WriteLine($"Несуществующий элемент найден за {time.ElapsedTicks} тик");
                isFound = false;
            }
            else Console.WriteLine("Несуществующий элемент не найден");
            //-----------------------------------------
        }
    }
}
