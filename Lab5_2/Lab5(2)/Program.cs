// Лаба 5
// Вариант 14 /13


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab5_2_
{
    class Program
    {
        static Random rand = new Random(0);

        static void Main(string[] args)
        {
            bool quit = false;
            char key = '0';

            do
            {
                Console.Clear();
                Console.WriteLine("Практическа работа №5\nФункции и массивы \n");
                Console.WriteLine("1) Работа с одномерными массивами \n" +
                    "2) Работа с двумерными массивами\n" +
                    "3) Работа с рваными массивами\n" +
                    "4) \n" +
                    "5) Выход\n\n");
                key = GetKeyPress("", new char[] { '1', '2', '3', '5', 'X', });
                switch (key)
                {
                    case '1':
                        oneDismArr();
                        break;
                    case '2':
                        twoDismArray();
                        break;
                    case '3':
                        tornArray();
                        break;
                    case '4':

                        break;
                    case '5':
                        quit = true;
                        break;

                    case 'x':
                        test1();

                        break;
                }
            } while (!quit);

        }
        static Char GetKeyPress(String msg, Char[] validChars)
        {
            ConsoleKeyInfo keyPressed;
            bool valid = false;
            do
            {
                Console.Write(msg);
                keyPressed = Console.ReadKey(true);
                // Console.WriteLine();
                if (Array.Exists(validChars, ch => ch.Equals(Char.ToUpper(keyPressed.KeyChar))))
                    valid = true;
            } while (!valid);
            return keyPressed.KeyChar;
        }

        static void oneDismArr()
        {
            bool quit = false;
            int[] arr = new int[0];
            char key = '0';
            do
            {
                Console.Clear();
                Console.WriteLine("Работа с одномерными массивами \n\n");
                Console.WriteLine("1) Создать массив  \n" +
                    "2) Показать массив\n" +
                    "3) Добавить элементы\n" +
                    "4) \n" +
                    "5) Назад\n\n");
                key = GetKeyPress("", new char[] { '1', '2', '3', '5', });
                switch (key)
                {
                    case '1':
                        makeArray(ref arr);
                        break;
                    case '2':
                        printArray(arr);
                        Console.ReadKey();
                        break;
                    case '3':
                        int[] arr2 = new int[0];
                        makeArray(ref arr2);
                        addArray(ref arr, arr2);
                        break;
                    case '4':

                        break;
                    case '5':
                        quit = true;
                        break;
                }
            } while (!quit);
        }
        static void addArray(ref int[] arr1, int[] arr2)
        {
            char manual;
            int[] added = new int[arr1.Length + arr2.Length];
            Console.Clear();
            Console.WriteLine("Добавить в\n1) Начало\n2) Конец");
            manual = GetKeyPress("", new char[] { '1', '2', });
            if (manual == '2')
            {
                arr1.CopyTo(added, 0);
                arr2.CopyTo(added, arr1.Length);
            }
            else
            {
                arr2.CopyTo(added, 0);
                arr1.CopyTo(added, arr2.Length);
            }
            arr1 = added;
        }
        static void makeArray(ref int[] arr)
        {
            // Random rand = new Random(32);
            int size = getSize("Введите количество элементов: ");
            char manual;
            Console.Clear();
            Console.WriteLine("Заполнять вручную?\n1) Да\n2) Нет");
            manual = GetKeyPress("", new char[] { '1', '2', });

            arr = new int[size];

            if (manual == '2')
            {

                for (int i = 0; i < size; i++)
                {
                    arr[i] = rand.Next(-100, 100);
                }
            }
            else
            {
                manualComplete(ref arr);
            }
        }

        static void manualComplete(ref int[] arr)
        {
            bool right;
            Console.Clear();
            Console.WriteLine("Введите " + arr.Length + " элементов: ");
            for (int i = 0; i < arr.Length; i++)
            {
                do
                {
                    right = Int32.TryParse(Console.ReadLine(), out arr[i]);
                    if (!right) Console.WriteLine("Неверный ввод");
                } while (!right);
            }
        }

        static void makeArray(ref int[,] arr)
        {
            // Random rand = new Random(32);
            int rows = getSize("Введите количество строк "); ;
            int columns = getSize("Введите количество столбцов ");

            arr = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    arr[i, j] = rand.Next(10, 99);
                }
            }
        }

        static void makeArray(ref int[][] arr)
        {
            // Random rand = new Random(0);
            int rows = getSize("Введите количество строк: ");
            arr = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                arr[i] = new int[rand.Next(5, 15)];
                for (int j = 0; j < arr[i].Length; j++)
                    arr[i][j] = rand.Next(10, 99);
            }
        }

        static void printArray(int[] arr)
        {
            if (arr.Length == 0) { Console.WriteLine("Массив пуст"); return; }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        static void printArray(int[,] arr)
        {
            if (arr.Length == 0) { Console.WriteLine("Массив пуст"); return; }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void printArray(int[,] arr, int row, int column)
        {
            if (arr.Length == 0) Console.WriteLine("Массив пуст");

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                if (i == row) Console.Write("<");
                Console.WriteLine();
            }
            for (int i = 0; i < column * 3; i++)
                Console.Write(" ");
            Console.Write("^");
        }

        static int getSize(string msg)
        {
            int size;
            bool right;
            do
            {
                Console.Clear();
                Console.WriteLine(msg);
                right = Int32.TryParse(Console.ReadLine(), out size);
            } while (!right);

            return size;
        }

        static void printArray(int[][] arr)
        {
            if (arr.Length == 0) { Console.WriteLine("Массив пуст"); return; }
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void twoDismArray()
        {
            bool quit = false;
            int[,] arr = new int[0, 0];
            char key = '0';
            do
            {
                Console.Clear();
                Console.WriteLine("Работа с двухмерными массивами \n\n");
                Console.WriteLine("1) Создать массив  \n" +
                    "2) Показать массив\n" +
                    "3) \n" +
                    "4) Удалить элементы\n" +
                    "5) Назад\n\n");
                key = GetKeyPress("", new char[] { '1', '2', '4', '5', });
                switch (key)
                {
                    case '1':
                        makeArray(ref arr);
                        break;
                    case '2':
                        printArray(arr);
                        Console.ReadKey();
                        break;
                    case '3':
                        break;
                    case '4':
                        if (arr.Length != 0)
                            deleteElms(ref arr);
                        else { Console.WriteLine("Массив пуст "); Console.ReadKey(); }
                        break;
                    case '5':
                        quit = true;
                        break;
                }
            } while (!quit);
        }
        static void test1()
        {
            ConsoleKeyInfo keyPressed;
            do
            {
                keyPressed = Console.ReadKey(true);

                Console.WriteLine("Нажата клавиша: " + keyPressed.Key);

            } while (keyPressed.KeyChar != 'x');

        }
        static void deleteElms(ref int[,] arr)
        {
            bool quit = false;
            char key = '0';
            int row, column;

            do
            {
                Console.Clear();
                Console.WriteLine("Удаление элементов из двухмерного массива \n\n");
                Console.WriteLine("1) Показать массив  \n" +
                    "2) Удалить строчку \n" +
                    "3) Удалить столбец\n" +
                    "4) Удалить несколько столбцов (задание из варианта 14) \n" +
                    "5) Назад\n" +
                    "6) Удалить несколько строк (задание из варианта 13)\n\n");

                key = GetKeyPress("", new char[] { '1', '2', '3', '4', '5', '6', });
                switch (key)
                {
                    case '1':
                        printArray(arr);
                        Console.ReadKey();
                        break;
                    case '2':
                        choose("Выберите строку для удаления (выбор пр помощи стрелок)", arr, out row, out column);
                        delRow(ref arr, row);
                        Console.Clear();
                        Console.WriteLine("\n");
                        printArray(arr);
                        Console.ReadKey(true);
                        break;
                    case '3':
                        choose("Выберите столбец для удаления (выбор пр помощи стрелок)", arr, out row, out column);
                        delColumn(ref arr, column);
                        Console.Clear();
                        Console.WriteLine("\n");
                        printArray(arr);
                        Console.ReadKey(true);
                        break;
                    case '4':
                        delSome(ref arr);
                        Console.Clear();
                        Console.WriteLine("\n");
                        printArray(arr);
                        Console.ReadKey(true);
                        break;
                    case '5':
                        quit = true;
                        break;
                    case '6':
                        delSomeRows(ref arr);
                        Console.Clear();
                        Console.WriteLine("\n");
                        printArray(arr);
                        Console.ReadKey(true);
                        break;
                }
            } while (!quit);
        }

        static void choose(string msg, int[,] arr, out int R, out int C)
        {
            int row = arr.GetLength(0) - 1;
            int column = arr.GetLength(1) - 1;
            bool finish = false;
            ConsoleKeyInfo keyPressed;
            do
            {

                Console.Clear();
                Console.WriteLine(msg + "\n");
                printArray(arr, row, column);
                keyPressed = Console.ReadKey(true);
                switch (keyPressed.Key)
                {
                    case ConsoleKey.Enter:
                        finish = true;
                        break;

                    case ConsoleKey.UpArrow:
                        if (row > 0)
                            row--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (row < arr.GetLength(0) - 1)
                            row++;
                        break;

                    case ConsoleKey.LeftArrow:
                        if (column > 0)
                            column--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (column < arr.GetLength(1) - 1)
                            column++;
                        break;
                }
            } while (!finish);
            R = row;
            C = column;
            //return 1;
        }
        static void delRow(ref int[,] arr, int n)
        {
            int counter = 0;
            int[,] res = new int[arr.GetLength(0) - 1, arr.GetLength(1)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (i == n) continue;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    res[counter, j] = arr[i, j];
                }
                counter++;
            }
            arr = res;
        }
        static void delColumn(ref int[,] arr, int n)
        {
            int counter = 0;
            int[,] res = new int[arr.GetLength(0), arr.GetLength(1) - 1];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j == n) continue;
                    res[i, counter] = arr[i, j];
                    counter++;
                }
                counter = 0;
            }
            arr = res;
        }

        static void delSome(ref int[,] arr)
        {
            int row, c1, c2, counter = 0;
            //Console.Clear();
            choose("Выберите начальный столбец для удаления (выбор пр помощи стрелок)", arr, out row, out c1);
            choose("Выберите конечный столбец для удаления  (выбор пр помощи стрелок)", arr, out row, out c2);

            if (c1 > c2) { int tmp = c2; c2 = c1; c1 = tmp; }

            int[,] res = new int[arr.GetLength(0), arr.GetLength(1) - (c2 - c1 + 1)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j >= c1 && j <= c2) continue;
                    res[i, counter] = arr[i, j];
                    counter++;
                }
                counter = 0;
            }
            arr = res;
        }
        static void delSomeRows(ref int[,] arr)
        {
            int r1, r2, column, counter = 0;
            //Console.Clear();
            choose("Выберите начальную строку для удаления (выбор пр помощи стрелок)", arr, out r1, out column);
            choose("Выберите конечную строку для удаления  (выбор пр помощи стрелок)", arr, out r2, out column);
            if (r1 > r2) { int tmp = r2; r2 = r1; r1 = tmp; }

            int[,] res = new int[arr.GetLength(0) - (r2 - r1 + 1), arr.GetLength(1)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (i >= r1 && i <= r2) continue;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    res[counter, j] = arr[i, j];
                }
                counter++;
            }
            arr = res;
        }

        static void tornArray()
        {
            bool quit = false;
            int[][] arr = new int[0][];
            char key = '0';
            do
            {
                Console.Clear();
                Console.WriteLine("Работа с рваными массивами \n\n");
                Console.WriteLine("1) Создать массив  \n" +
                    "2) Добавить строку с заданным номером\n" +
                    "3) Добавить строку в начало массива\n" +
                    "4) Удалить строку из конца массива\n" +
                    "5) Назад\n\n");
                printArray(arr);
                key = GetKeyPress("", new char[] { '1', '2', '3', '4', '5', });
                switch (key)
                {
                    case '1':
                        makeArray(ref arr);
                        break;
                    case '2':
                        addNumRow(ref arr);
                        //printArray(arr);
                        //Console.ReadKey();
                        break;
                    case '3':
                        addRow(ref arr);
                        //printArray(arr);
                        //Console.ReadKey();
                        break;
                    case '4':
                        if (arr.Length != 0)
                        {
                            delRow(ref arr);
                            // printArray(arr);
                        }
                        else Console.WriteLine("Массив пуст ");
                        //Console.ReadKey();
                        break;
                    case '5':
                        quit = true;
                        break;
                }
            } while (!quit);
        }

        static void addNumRow(ref int[][] arr)
        {
            bool right = false;
            int n;
            do
            {
                n = getSize("Введите номер строки ");
                if (n >= 0 && n <= arr.Length) right = true;
                else { Console.WriteLine("Неверный ввод. Выход за границы массива "); Console.ReadKey(); }

            } while (!right);

            int[][] res = new int[arr.Length + 1][];
            res[n] = new int[rand.Next(5, 15)];

            for (int i = 0; i < res[n].Length; i++)
                res[n][i] = rand.Next(10, 99);

            for (int i = 0; i < n; i++)
                res[i] = arr[i];

            for (int i = n + 1; i < res.Length; i++)
                res[i] = arr[i - 1];

            arr = res;
        }

        static void addRow(ref int[][] arr)
        {
            // Random rand = new Random();
            int[][] res = new int[arr.Length + 1][];
            for (int i = 0; i < arr.Length; i++)
                res[i + 1] = arr[i];
            res[0] = new int[rand.Next(5, 15)];
            for (int i = 0; i < res[0].Length; i++)
                res[0][i] = rand.Next(10, 99);
            arr = res;
        }

        static void delRow(ref int[][] arr)
        {
            if (arr.Length == 0) return;
            int[][] res = new int[arr.Length - 1][];
            for (int i = 0; i < arr.Length - 1; i++)
                res[i] = arr[i];
            arr = res;
        }
    }
}
