using System;

namespace ЛБ_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            double d_a = 10;
            float f_a = 10;
            double d_b = 0.01;
            float f_b = 0.01f;

            double d_c = Math.Pow(d_a + d_b, 4);
            float f_c = (float)Math.Pow(d_a + d_b, 4);
            Console.WriteLine("double: (a+b)^4 = " + d_c);
            Console.WriteLine("float:  (a+b)^4 = " + f_c);

            double d_d = Math.Pow(d_a, 4);
            float f_d = (float)Math.Pow(d_a, 4);
            Console.WriteLine("double: a^4 = " + d_a);
            Console.WriteLine("float:  a^4 = " + f_a);

            double d_e = 6 * Math.Pow(d_a * d_b, 2);
            float f_e = (float)(6 * Math.Pow(d_a * d_b, 2));
            Console.WriteLine("double: 6*(a*b)^2 = " + d_e);
            Console.WriteLine("float:  6*(a*b)^2 = " + f_e);

            double d_f = Math.Pow(d_b, 4);
            float f_f = (float)Math.Pow(d_b, 4);
            Console.WriteLine("double: b^4 = " + d_b);
            Console.WriteLine("float:  b^4 = " + f_b);

            double d_g = 4 * d_a * Math.Pow(d_b, 3);
            float f_g = (float)(4 * d_a * Math.Pow(d_b, 3));
            Console.WriteLine("double: 4*a*b^3 = " + d_g);
            Console.WriteLine("float:  4*a*b^3 = " + f_g);

            double d_h = 4 * d_b * Math.Pow(d_a, 3);
            float f_h = (float)(4 * d_b * Math.Pow(d_a, 3));
            Console.WriteLine("double: 4*b*a^3 = " + d_h);
            Console.WriteLine("float:  4*b*a^3 = " + f_h);

            double d_R = (d_c -(d_d + d_e + d_f)) / (d_g + d_h);
            float f_R = (float)((d_c - (d_d + d_e + d_f)) / (d_g + d_h));
            Console.WriteLine("double: R = " + d_R);
            Console.WriteLine("float:  R = " + f_R);

        }
    }
}
