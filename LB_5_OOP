using System;

namespace ЛБ_5
{
    class Program
    {
        //Главное Меню
        static int Menu()
        {
            bool flag;
            int numMenu;
            Console.WriteLine("----------Главное меню----------");
            Console.WriteLine("1.Работа с одномерными массивами\n" +
                              "2.Работа с двумерными массивами\n" +
                              "3.Работа с рваными массивами\n" +
                              "4.Выход");
            do
            {
                Console.Write(">>");
                flag = int.TryParse(Console.ReadLine(), out numMenu);
                if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                if (numMenu > 4 && numMenu < 1) Console.WriteLine("Ошибка! Введите действие из списка!");
            } while (!flag);
            if (numMenu != 4)
            {
                Console.Clear();
            }
            return numMenu;
        }
        //Меню одномерного массива
        static int OneArrMenu()
        {
            int numMenu;
            bool flag;
            Console.WriteLine("-------Одномерный массив-------");
            Console.WriteLine("1.Создать массив\n" +
                              "2.Напечатать массив\n" +
                              "3.Добавить K элементов в массив\n" +
                              "4.Назад");
            do
            {
                Console.Write(">>");
                flag = int.TryParse(Console.ReadLine(), out numMenu);
                if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                if (numMenu > 4 && numMenu < 1) Console.WriteLine("Ошибка! Введите действие из списка!");
            } while (!flag);
            Console.Clear();
            return numMenu;
        }
        //Меню создания
        static int CreateMenu()
        {
            bool flag;
            int numCreate;
            Console.WriteLine("Выберете тип создания массива\n" +
                              "1. Ручной\n" +
                              "2. ДСЧ\n" +
                              "3. Назад");
            do
            {
                flag = int.TryParse(Console.ReadLine(), out numCreate);
                if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных");
            } while (!flag);
            Console.Clear();
            return numCreate;
        }
        //Работа с одномерным массивом
        static void WorkOneArr(int[] arr)
        {
            int action;
            do
            {
                action = OneArrMenu();
                switch (action)
                {
                    case 1:
                        Console.WriteLine("----Создание----");
                        arr = CreateOneArr();
                        break;
                    case 2:
                        if (arr.Length > 0)
                        {
                            Console.WriteLine("----Вывод----");
                            PrintOneArr(arr);
                        }
                        else Console.WriteLine("Массив пуст!");
                        break;
                    case 3:
                        if (arr.Length > 0)
                        {
                            Console.WriteLine("----Добавление----");
                            arr = AddOneArr(arr);
                        }
                        else Console.WriteLine("Создайте массив!");
                        break;
                }
                if (action != 4)
                {
                    Console.WriteLine("\n\t>>>Нажмте любую клавишу для продожения<<<");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (action != 4);
        }
        //Создание одномерного массива
        static int[] CreateOneArr()
        {

            bool flag;//Проверка введенных данных
            int n;    //Кол-во элементовмассива
            do
            {
                Console.WriteLine("Введите кол-во элементов массива: ");
                flag = int.TryParse(Console.ReadLine(), out n);
                if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                if (n <= 0)
                {
                    Console.WriteLine("Ошибка! Введите число больше нуля!");
                    flag = false;
                }
            } while (!flag);
            int[] arr = new int[n];
            int action = CreateMenu();
            if (action == 1) arr = WriteOneArr(arr); //Метод ввода ручками
            else if (action == 2) arr = RandomOneArr(arr); //Метод ввода автоматически
            PrintOneArr(arr);
            return arr;
        }
        //Ввод элементов вручную
        static int[] WriteOneArr(int[] arr)
        {
            bool flag;
            Console.WriteLine("Ввод элементов массива");
            for (int i = 0; i < arr.Length; i++)
            {
                do
                {
                    Console.Write(">>");
                    flag = int.TryParse(Console.ReadLine(), out arr[i]);
                    if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                } while (!flag);
            }
            return arr;
        }
        //Рандомное заполнение массива
        static int[] RandomOneArr(int[] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next() % 10;
            }
            return arr;
        }
        //Вывод одномерного массива
        static void PrintOneArr(int[] arr)
        {
            Console.Write("Одномерный массив:");
            foreach (int i in arr)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine();
        }
        //Добавление элементов в конец массива
        static int[] AddOneArr(int[] arr)
        {
            bool flag;
            int k;
            Console.WriteLine("Введите кол-во элементов для добавления");
            do
            {
                flag = int.TryParse(Console.ReadLine(), out k);
                if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
            } while (!flag);
            Console.WriteLine("Введите элементы");
            for (int i = 1; i <= k; i++)
            {
                Array.Resize(ref arr, arr.Length + 1);
                do
                {
                    Console.Write(">>");
                    flag = int.TryParse(Console.ReadLine(), out arr[arr.Length - 1]);
                    if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                } while (!flag);
            }
            Console.WriteLine("Добавление совершено успешно!");
            return arr;
        }
        //Меню двумерного массива
        static int TwoArrMenu()
        {
            int numMenu;
            bool flag;
            Console.WriteLine("------------Двумерный массив------------");
            Console.WriteLine("1.Создать массив\n" +
                              "2.Напечатать массив\n" +
                              "3.Удаление столбцов в указанном интервале\n" +
                              "4.Назад");
            do
            {
                Console.Write(">>");
                flag = int.TryParse(Console.ReadLine(), out numMenu);
                if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                if (numMenu > 4 && numMenu < 1) Console.WriteLine("Ошибка! Введите действие из списка!");
            } while (!flag);
            Console.Clear();
            return numMenu;
        }
        //Работа с двумерным массивом
        static void WorkTwoArr(int[,] arr)
        {
            int action;
            do
            {
                action = TwoArrMenu();
                switch (action)
                {
                    case 1:
                        Console.WriteLine("----Создание----");
                        arr = CreateTwoArr();
                        break;
                    case 2:
                        if (arr.Length > 0)
                        {
                            Console.WriteLine("----Вывод----");
                            PrintTwoArr(arr);
                        }
                        else Console.WriteLine("Массив пуст!");
                        break;
                    case 3:
                        if (arr.Length > 0)
                        {
                            Console.WriteLine("----Удаление----");
                            arr = DelTwoArr(arr);
                        }
                        else Console.WriteLine("Создайте массив!");
                        break;
                }
                if (action != 4)
                {
                    Console.WriteLine("\n\t>>>Нажмте любую клавишу для продожения<<<");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (action != 4);
        }
        //Создание двумерного массива
        static int[,] CreateTwoArr()
        {
            bool flag;//Проверка введенных данных
            int n;    //Кол-во строк массива
            int m;    //Кол-во столбцов массива
            do
            {
                Console.WriteLine("Введите кол-во строк массива: ");
                flag = int.TryParse(Console.ReadLine(), out n);
                if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                if (n <= 0)
                {
                    Console.WriteLine("Ошибка! Введите число больше нуля!");
                    flag = false;
                }
            } while (!flag);
            do
            {
                Console.WriteLine("Введите кол-во столбцов массива: ");
                flag = int.TryParse(Console.ReadLine(), out m);
                if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                if (m <= 0)
                {
                    Console.WriteLine("Ошибка! Введите число больше нуля!");
                    flag = false;
                }
            } while (!flag);

            int[,] arr = new int[n, m];
            int action = CreateMenu();
            if (action == 1) arr = WriteTwoArr(arr, n, m); //Метод ввода ручками
            else if (action == 2) arr = RandomTwoArr(arr, n, m); //Метод ввода автоматически
            PrintTwoArr(arr);
            return arr;
        }
        //Ввод элементов двумерного массива вручную
        static int[,] WriteTwoArr(int[,] arr, int n, int m)
        {
            bool flag;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    do
                    {
                        Console.Write(">>");
                        flag = int.TryParse(Console.ReadLine(), out arr[i, j]);
                        if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                    } while (!flag);
                }
            }
            return arr;
        }
        //Рандомное заполнение двумерного массива
        static int[,] RandomTwoArr(int[,] arr, int n, int m)
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = rand.Next() % 10;
                }
            }
            return arr;
        }
        //Вывод двумерного массива
        static void PrintTwoArr(int[,] arr)
        {
            Console.WriteLine("Двумерный массив");
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.Length / (arr.GetUpperBound(0) + 1); j++)
                {
                    Console.Write(" " + arr[i, j]);
                }
                Console.WriteLine();
            }
        }
        //Удаление столбцов с K1 до K2
        static int[,] DelTwoArr(int[,] arr)
        {
            int k1, k2;
            int n = arr.GetUpperBound(0) + 1;
            int m = arr.Length / (arr.GetUpperBound(0) + 1);
            bool flag;
            Console.WriteLine("Введите начало интервала для удаления");
            do
            {
                flag = int.TryParse(Console.ReadLine(), out k1);
                if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                else if (k1 <= 0)
                {
                    Console.WriteLine("Ошибка! Введите число больше нуля!");
                    flag = false;
                }
                else if (k1 > m)
                {
                    Console.WriteLine("Ошибка! Введеное значение превышает количество элементов!");
                    flag = false;
                }
            } while (!flag);
            Console.WriteLine("Введите конец интервала для удаления");
            do
            {
                flag = int.TryParse(Console.ReadLine(), out k2);
                if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                else if (k2 <= 0)
                {
                    Console.WriteLine("Ошибка! Введите число больше нуля!");
                    flag = false;
                }
                else if (k2 > m)
                {
                    Console.WriteLine("Ошибка! Введеное значение превышает количество элементов!");
                    flag = false;
                }
            } while (!flag);
            
            int[,] newArr = new int[n, m - (k2 - k1 + 1)];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j < k1 - 1) newArr[i, j] = arr[i, j];
                    else if (j + (k2 - k1 + 1) < m) newArr[i, j] = arr[i, j + (k2 - k1 + 1)];
                }
            }
            Console.WriteLine("Удаление совершено успешно!");
            return newArr;
        }
        //Меню рваного массива
        static int TornArrMenu()
        {
            int numMenu;
            bool flag;
            Console.WriteLine("----------Рваный массив----------");
            Console.WriteLine("1.Создать массив\n" +
                              "2.Напечатать массив\n" +
                              "3.Создание строки в начале массива\n" +
                              "4.Назад");
            do
            {
                Console.Write(">>");
                flag = int.TryParse(Console.ReadLine(), out numMenu);
                if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                if (numMenu > 4 && numMenu < 1)
                {
                    Console.WriteLine("Ошибка! Введите действие из списка!");
                    flag = false;
                }
            } while (!flag);
            Console.Clear();
            return numMenu;
        }
        //Работа с рваным массивом
        static void WorkTornArr(int[][] arr)
        {
            int action;
            do
            {
                action = TornArrMenu();
                switch (action)
                {
                    case 1:
                        Console.WriteLine("----Создание----");
                        arr = CreateTornArr();
                        break;
                    case 2:
                        if (arr.Length > 0)
                        {
                            Console.WriteLine("----Вывод----");
                            PrintTornArr(arr);
                        }
                        else Console.WriteLine("Создайте массив!");
                        break;
                    case 3:
                        if (arr.Length > 0)
                        {
                            Console.WriteLine("----Добавление----");
                            arr = AddTornArr(arr);
                        }
                        else Console.WriteLine("Создайте массив!");
                        break;
                }
                if (action != 4)
                {
                    Console.WriteLine("\n\t>>>Нажмте любую клавишу для продожения<<<");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (action != 4);
        }
        //Создание рваного массива
        static int[][] CreateTornArr()
        {
            bool flag;//Проверка введенных данных
            int n;    //Кол-во строк массива
            int m;    //Кол-во столбцов массива
            do
            {
                Console.WriteLine("Введите кол-во строк массива: ");
                flag = int.TryParse(Console.ReadLine(), out n);
                if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                if (n <= 0)
                {
                    Console.WriteLine("Ошибка! Введите число больше нуля!");
                    flag = false;
                }
            } while (!flag);
            int[][] arr = new int[n][];
            for (int i = 0; i < n; i++)
            {
                do
                {
                    Console.Write("Введите кол-во столбцов " + (i + 1) + "-й строки: ");
                    flag = int.TryParse(Console.ReadLine(), out m);
                    if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                    if (n <= 0)
                    {
                        Console.WriteLine("Ошибка! Введите число больше нуля!");
                        flag = false;
                    }
                } while (!flag);
                arr[i] = new int[m];
            }
            int action = CreateMenu();
            if (action == 1) arr = WriteTornArr(arr); //Метод ввода ручками
            else if (action == 2) arr = RandomTornArr(arr); //Метод ввода автоматически
            PrintTornArr(arr);
            return arr;
        }
        //Ввод элеметов рваного массива вручную
        static int[][] WriteTornArr(int[][] arr)
        {
            bool flag;
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    do
                    {
                        Console.Write(">>");
                        flag = int.TryParse(Console.ReadLine(), out arr[i][j]);
                        if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                    } while (!flag);
                }
            }
            return arr;
        }
        //Рандомное заполнение рваного массива
        static int[][] RandomTornArr(int[][] arr)
        {
            Random rand = new Random();

            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = rand.Next() % 10;
                }
            }
            return arr;
        }
        //Вывод рваного массива
        static void PrintTornArr(int[][] arr)
        {
            Console.WriteLine("Рваный массив");
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(" " + arr[i][j]);
                }
                Console.WriteLine();
            }
        }
        //Добавление строки в начало рваного массива
        static int[][] AddTornArr(int[][] arr)
        {
            int[][] newArr = new int[arr.Length + 1][];
            int m;
            bool flag;
            do
            {
                Console.Write("Введите кол-во элементов в строке: ");
                flag = int.TryParse(Console.ReadLine(), out m);
                if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                if (m <= 0)
                {
                    Console.WriteLine("Ошибка! Введите число больше нуля!");
                    flag = false;
                }
            } while (!flag);
            newArr[0] = new int[m];
            Console.WriteLine("Введите элементы добавленной строки");
            for (int i = 0; i < m; i++)
            {
                do
                {
                    Console.Write(">>");
                    flag = int.TryParse(Console.ReadLine(), out newArr[0][i]);
                    if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                    if (m <= 0)
                    {
                        Console.WriteLine("Ошибка! Введите число больше нуля!");
                        flag = false;
                    }
                } while (!flag);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i + 1] = arr[i];
            }
            Console.WriteLine("Добавление совершено успешно!");
            return newArr;
        }
        static void Main(string[] args)
        {
            int arrAction;
            do
            {
                arrAction = Menu();
                switch (arrAction)
                {
                    case 1:
                        int[] arrOne = new int[0];
                        WorkOneArr(arrOne);
                        break;
                    case 2:
                        int[,] arrTwo = new int[0, 0];
                        WorkTwoArr(arrTwo);
                        break;
                    case 3:
                        int[][] arrTorn = new int[0][];
                        WorkTornArr(arrTorn);
                        break;
                }
            } while (arrAction != 4);
        }
    }
}
