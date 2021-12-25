using System;
namespace LB_OOP_11
{
    class Program
    {
        static int Input(string text)
        {
            int num;
            bool check;
            do
            {
                Console.Write(text);
                check = int.TryParse(Console.ReadLine(), out num);
                if (!check) Console.WriteLine("Ошибка! Введите целое число!");
            } while (!check);
            return num;
        }
        static void Main(string[] args)
        {
            TestCollection collection = new TestCollection();
            int menu;
            do
            {
                menu = Input("1. Создать коллекцию\n" +
                             //"2. Удалить элементы из коллекции\n" +
                             "2. Вывести результат анализа\n" +
                             "3. Выход\n");
                switch (menu)
                {
                    case 1:
                        int size = Input("Введите величину коллекции: ");
                        collection.Add(size);
                        break;
                    case 0:
                        //collection.Del(1000);
                        break;
                    case 2:
                        collection.TimeConll();
                        break;
                }
            } while (menu != 3);

        }
    }
}
