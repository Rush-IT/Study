using System;

namespace ЛБ_3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            double a = Math.PI/5;
            double b = Math.PI;
            double s_n = 0 , s_e = 0;
            double e = 0.0001;
            int k = 10;
            int n = 20;
            double d = (b - a) / k;
            double c;
            for (double x = a; x <= b; x+=d)
            {
                Console.Write("X=" + x + "\t");
                double y = (1.0 / 4.0) * (Math.Pow(x, 2) - Math.Pow(Math.PI, 2) / 3.0); ;
                
                Console.Write("Y=" + y + "\t");
                for (int j = 1; j < n; j++)
                {
                    s_n += Math.Pow(-1, j) * (Math.Cos(j * x) / Math.Pow(j, 2));
                }
                Console.Write("SN=" + s_n + "\t");
                int i = 1;
                do
                {
                    c = Math.Pow(-1, i) * (Math.Cos(i * x) / Math.Pow(i, 2));
                    s_e += c;
                    i++;
                } while (Math.Abs(c) > e);
                Console.WriteLine("SE=" + s_e);
                s_n = 0;
                s_e = 0;
            }
            
        }
    }
}
