using System;

namespace ЛБ_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<<Задача №1>>");
            int n, m;
            bool flag;
            do
            {
                Console.Write("Введите значение n: ");
                flag = int.TryParse(Console.ReadLine(), out n);
                if (!flag) Console.WriteLine("Введено не верное значение!\nПопробуйте снова");
            } while (!flag);
            do
            {
                Console.Write("Введите значение m: ");
                flag = int.TryParse(Console.ReadLine(), out m);
                if (!flag) Console.WriteLine("Введено не верное значение!\nПопробуйте снова");
            } while (!flag);
            Console.WriteLine("n = " + (int)n + "\nm = " + (int)m);
            //(1)\\
            int R1 = n++ * --m;
            Console.WriteLine("n++ * --m = " + (int)R1);
            Console.WriteLine("n = " + (int)n + "\nm = " + (int)m);
            //(2)\\
            bool R2 = n-- < m++;
            Console.WriteLine("n-- < m++ = " + (bool)R2);
            Console.WriteLine("n = " + (int)n + "\nm = " + (int)m);
            //(3)\\
            bool R3 = --n > --m;
            Console.WriteLine("--n > --m = " + (bool)R3);
            Console.WriteLine("n = " + (int)n + "\nm = " + (int)m);
            //(4)\\
            double x;
            do
            {
                Console.WriteLine("Введите значение x: ");
                flag = double.TryParse(Console.ReadLine(), out x);
                if (!flag) Console.WriteLine("Введено не верное значение!\nПопробуйте снова");
                if (x == 0)
                {
                    Console.WriteLine("Ошибка!\nПри данном занчении произойдет деление на ноль!\nПопробуйте снова");
                    flag = false;
                }
            } while (!flag);
            double value = Math.Pow(Math.Abs(x + 1), 0.25) + Math.Pow(x, -2);
            Console.WriteLine("(|x+1|)^(1/4)+(1/x^2) = " + value);
        }
    }
}
