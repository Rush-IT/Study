using System;
using System.Collections.Generic;
using System.Text;

namespace LB_OOP_11
{
    class RandomGenerate
    {
        static Random rand = new Random();
        static public string RandomToString()
        {
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            int length = rand.Next(10, 100);
            string result = "";
            for (int i = 0; i < length; i++)
            {
                result += alpha[rand.Next(26)];
            }
            return result;
        }
        static public Animals RandToAnimals()
        {
            Animals result = new Animals();
            result.Type = RandomToString();
            result.Weight = rand.Next(2000);
            return result;
        }
        static public Animals RandToBirds()
        {
            Birds result = new Birds();
            result.Name = RandomToString();
            result.Type = RandomToString();
            result.Weight = rand.Next(2000);
            return result;
        }
        static public Animals RandToBirds(int r)
        {
            Birds result = new Birds();
            result.Name = RandomToString();
            result.Type = RandomToString();
            result.Weight = rand.Next(2001, 2002);
            return result;
        }
        static public Animals RandToMammals()
        {
            Mammals result = new Mammals();
            result.Name = RandomToString();
            result.Type = RandomToString();
            result.Cover = RandomToString();
            result.Weight = rand.Next(100);
            return result;
        }
        static public Animals RandToArtiodactyls()
        {
            Artiodactyls result = new Artiodactyls();
            result.Name = RandomToString();
            result.Type = RandomToString();
            result.Speed = rand.Next(70);
            result.Cover = RandomToString();
            result.Weight = rand.Next(100);
            return result;
        }
    }
}
