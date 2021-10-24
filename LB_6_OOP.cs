using System;

namespace ЛБ_6
{
    class Program
    {
        //Главное Меню
        static int Menu()
        {
            bool flag;
            int numMenu;
            Console.WriteLine("----------Главное меню----------");
            Console.WriteLine("1.Работа с двумерными массивами\n" +
                              "2.Работа со строками\n" +
                              "3.Выход");
            do
            {
                Console.Write(">>");
                flag = int.TryParse(Console.ReadLine(), out numMenu);
                if (!flag) Console.WriteLine("Ошибка! Введите целочисленный тип данных!");
                if (numMenu > 3 && numMenu < 1) Console.WriteLine("Ошибка! Введите действие из списка!");
            } while (!flag);
            if (numMenu != 3) Console.Clear();
            return numMenu;
        }   
        //Меню двумерного массива
        static int TwoArrMenu()
        {
            int numMenu;
            bool flag;
            Console.WriteLine("------------Двумерный массив------------");
            Console.WriteLine("1.Создать массив\n" +
                              "2.Напечатать массив\n" +
                              "3.Удаление первого столбца\n" +
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
        //Ввод элементов двумерного массива вручную
        static int[,] WriteTwoArr(int[,] arr, int n, int m)
        {
            bool flag;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(@"Введите i-ю строку");
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
        //Нахождение минимального элемента
        static int MinTwoArr(int[,] arr)
        {
            int min = arr[0, 0];
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.Length / (arr.GetUpperBound(0) + 1); j++)
                {
                    if (min > arr[i, j]) min = arr[i, j];
                }
            }
            return min;
        }
        //Удаление первого столбца по условию
        static int[,] DelTwoArr(int[,] arr)
        {
            int n = arr.GetUpperBound(0) + 1;
            int m = arr.Length / (arr.GetUpperBound(0) + 1);
            int min = MinTwoArr(arr);
            bool flag = false;
            for(int i = 0; i < n; i++)
            {
                if (min == arr[i, 0]) flag = true;
            }
            if (!flag)
            {
                Console.WriteLine("Удаление совершено безуспешно!");
                return arr;
            }
            int[,] newArr = new int[n, m - 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m-1; j++)
                {
                    newArr[i, j] = arr[i, j + 1];
                }
            }
            Console.WriteLine("Удаление совершено успешно!");
            return newArr;
        }
        //Меню строк
        static int StringMenu()
        {
            int numMenu;
            bool flag;
            Console.WriteLine("------------Двумерный массив------------");
            Console.WriteLine("1.Ввести текст\n" +
                              "2.Напечатать текст\n" +
                              "3.Перевернуть все слова текста\n" +
                              "4.Отсортировать слова по убыванию длин\n" +
                              "5.Назад");
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
        static void PrintString(string str)
        {
            if (str.Length != 0)
                Console.WriteLine(str);
            else
                Console.WriteLine("Строка пуста!");
        }
        static int NumWordString(string str)
        {
            int numWord = 0;
            bool fWord = true;
            foreach(char a in str)
            {
                if (a == ' ') fWord = true;
                else if(a!=' ' && fWord)
                {
                    fWord = false;
                    numWord++;
                }
            }
            return numWord;
        }
        static void WorkString(string str)
        {
            int action;
            do
            {
                action = StringMenu();
                switch (action)
                {
                    case 1:
                        Console.WriteLine("----Создание----");
                        str = CreateString();
                        break;
                    case 2:
                        if (str.Length > 0)
                        {
                            Console.WriteLine("----Вывод----");
                            PrintString(str);
                        }
                        else Console.WriteLine("Строка пустая!");
                        break;
                    case 3:
                        if (str.Length > 0)
                        {
                            Console.WriteLine("----Разворот слов----");
                            str = CopiReversString(str);
                        }
                        else Console.WriteLine("Создайте строку!");
                        break;
                    case 4:
                        if (str.Length > 0)
                        {
                            Console.WriteLine("----Сортировка----");
                            str = MinWordStr(str);
                        }
                        else Console.WriteLine("Создайте строку!");
                        break;
                }
                if (action != 5)
                {
                    Console.WriteLine("\n\t>>>Нажмте любую клавишу для продожения<<<");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (action != 5);
        }
        //Переворачивание слов
        static string ReversWord(string str)
        {
            char[] t = str.ToCharArray();
            Array.Reverse(t);
            return new String(t);
        }
        static string CopiReversString(string str)
        {
            string newStr = "";
            string wordStr = "";
            foreach(char a in str)
            {
                if (a == '.' || a == '!' || a == '?' || a == ' ')
                {
                    newStr += ReversWord(wordStr);
                    newStr += a;
                    wordStr = "";
                }
                else
                {
                    wordStr += a;
                }
            }
            return newStr;
        }
        static string SortString(string str)
        {
            string newStr = "";
            string wordStr = "";
            foreach (char a in str)
            {
                if (a == '.' || a == '!' || a == '?' || a == ' ')
                {
                    newStr += ReversWord(wordStr);
                    newStr += a;
                    wordStr = "";
                }
                else
                {
                    wordStr += a;
                }
            }
            return str;
        }
        static string MinWordStr(string str)
        {
            string wordStr = "";
            int numWord = NumWordString(str);
            string[] arrStr = new string[numWord];
            int[] numLetter = new int[numWord];
            int i = 0;
            foreach (char a in str)
            {
                if ((a == '.' || a == '!' || a == '?' || a == ' ') && wordStr!="")
                {
                    arrStr[i] = wordStr;
                    numLetter[i] = wordStr.Length;
                    wordStr = "";
                    i++;
                }
                else
                {
                    wordStr += a;
                }
            }
            int index;
            string newStr = "";
            foreach(char a in str)
            {
                if ((a == '.' || a == '!' || a == '?' || a == ' ') && wordStr!="")
                {
                    index = minIndexWord(numLetter);
                    numLetter[index] = 100000;
                    newStr += arrStr[index];
                    newStr += a;
                    if (a != ' ') newStr += " ";
                    wordStr = "";
                }
                else
                {
                    wordStr += a;
                }
            }
            return newStr;
        }
        static int minIndexWord(int[] arr)
        {
            int min = arr[0];
            int i_min = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if(min>arr[i])
                {
                    min = arr[i];
                    i_min = i;
                }
            }
            return i_min;
        }
        //Ввод текста
        static string CreateString()
        {
            string str;
            do
            {
                Console.WriteLine("Введите текст");
                str = Console.ReadLine();
            } while (!CheckText(str));
            
            return str;
        }
        static bool CheckText(string str)
        {
            bool fToOffer = true;
            bool fToWord  = true;
            foreach(char a in str)
            {
                if(a != ' ')
                {
                    if (a == '.' || a == '!' || a == '?')
                    {
                        if (!fToOffer) return false;
                        fToOffer = false;
                    }
                    else fToOffer = true;
                    fToWord = true;
                }
                else
                {
                    if (!fToWord) return false;
                    fToWord = false;
                }
            }
            return true;
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
                        int[,] arrTwo = new int[0, 0];
                        WorkTwoArr(arrTwo);
                        break;
                    case 2:
                        string text = "";
                        WorkString(text);
                        break;
                }
            } while (arrAction != 3);
        }
    }
}
