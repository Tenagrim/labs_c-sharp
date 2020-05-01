using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab6_2
{
    class Program
    {
        static Random rnd = new Random(0);
        static void Main(string[] args)
        {
            char k = '0';
            bool quit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Лабораторная работа №6 \"Класс Array. Строки. Класс String \" Вариант №13\n");
                Console.WriteLine("Выбор задачи:\n1)\n2)\n\n\n0) Выход");
                k = GetKeyPress("", new char[] { '1', '2', '0' });
                switch (k)
                {
                    case '1':
                        Task1();
                        break;
                    case '2':
                        Task2();
                        break;
                    case '0':
                        quit = true;
                        break;
                }
            } while (!quit);
        }

        static Char GetKeyPress(String msg, Char[] validChars)
        {
            ConsoleKeyInfo keyPressed;
            bool valid = false;
            Console.Write(msg);
            do
            {
                keyPressed = Console.ReadKey(true);
                // Console.WriteLine();
                if (Array.Exists(validChars, ch => ch.Equals(Char.ToUpper(keyPressed.KeyChar))))
                    valid = true;
            } while (!valid);
            return keyPressed.KeyChar;
        }

        static void Task1()
        {
            bool quit = false;
            char k = '0';
            do
            {
                Console.Clear();
                Console.WriteLine("Тип массива: \n\n1) Одномерный\n2) Двумерный\n3) Рваный\n\n\n0) Назад");
                k = GetKeyPress("", new char[] { '1', '2', '3', '0' });
                switch (k)
                {
                    case '1':
                        OneDismArr();
                        break;
                    case '2':
                        TwoDismArr();
                        break;
                    case '3':
                        TornArr();
                        break;
                    case '0':
                        quit = true;
                        break;
                }

            } while (!quit);
        }

        static void Task2()
        {
            bool quit = false;
            char k = '0';
            string str = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Работа со строками \n\n1) Добавить строку\n2) Вывести строку\n3) Перевернуть слова\n4) Отсортировать слова\n\n\n0) Назад\n\n");
                k = GetKeyPress("", new char[] { '1', '2', '3', '4', '0' });
                switch (k)
                {
                    case '1':
                        AddString(ref str);
                        break;
                    case '2':
                        Console.WriteLine(str);
                        Console.ReadKey();
                        break;
                    case '3':
                        RevWords(ref str);
                        Console.WriteLine(str);
                        Console.ReadKey();
                        break;
                    case '4':
                        SortWords(ref str);
                        Console.WriteLine(str);
                        Console.ReadKey();
                        break;
                    case '0':
                        quit = true;
                        break;
                }

            } while (!quit);
        }
        static void SortWords(ref string str)
        {
            if (IsEmpty(str)) { Console.WriteLine("Строка пуста"); Console.ReadKey(); return; }
            if (CountSentences(str) == 0) { Console.WriteLine("В строке не обнаружено предложений"); Console.ReadKey(); return; }
            string[] sents = SplitSentences(str);
            string[] words;
            char eChar;
            for (int i = 0; i < sents.Length; i++)
            {
                eChar = sents[i][sents[i].Length - 1];
                sents[i] = sents[i].Remove(sents[i].Length - 1, 1);
                words = SplitWords(sents[i]);
                Array.Sort(words, (p, q) => q.CompareTo(p));
                sents[i] = String.Join(" ",words);
                sents[i] += eChar;
            }
            str = String.Join(" ", sents);
        }
        static void RevWords(ref string str)
        {
            if (IsEmpty(str)) { Console.WriteLine("Строка пуста"); Console.ReadKey(); return; }
            if(CountSentences(str)==0) { Console.WriteLine("В строке не обнаружено предложений"); Console.ReadKey(); return; }
            string[] sents = SplitSentences(str);
            char eChar = '\0';
            string[] words;
            for (int i = 0; i < sents.Length; i++)
            {
                words = SplitWords(sents[i]);
                for (int j = 0; j < words.Length; j++)
                {
                    if (CheckChar(new char[] { '.', '!', '?', ':', ',', ';' }, words[j][words[j].Length - 1]))
                    {
                        eChar = words[j][words[j].Length - 1];
                        words[j]= words[j].Remove(words[j].Length - 1, 1);
                    }
                    char[] rev = words[j].ToCharArray();
                    Array.Reverse(rev);
                    words[j] = new string(rev);
                    if (eChar != '\0') { words[j] += eChar; eChar = '\0'; }
                }
                sents[i] = string.Join(" ", words);
            }
            str = string.Join(" ", sents);
        }
        static bool CheckChar(char[] chars, char ch)
        {
            return Array.Exists(chars, c => c == ch);
        }
        static string[] SplitSentences(string str)
        {
            string[] arr = new string[CountSentences(str)];
            int counter = 0;
            char tmpC; string tmpStr="";
            char[] eChars = new char[] { '.', '!', '?'};
            for (int i = 0; i < str.Length; i++)
            {
                tmpC = str[i];
                if (Array.Exists(eChars, ch => ch == tmpC))
                {
                    arr[counter] = tmpStr + tmpC;
                    tmpStr = "";
                    counter++;
                }
                else
                {
                    tmpStr += tmpC;
                }
            }
            return arr;
        }

        static string[] SplitWords(string sentence)
        {
            string[] first = sentence.Split(' ');
            int count = 0;
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != "") count++;
            }
            if (count == 0) return new string[] {"void"};
            if (count == first.Length)
            {
                return first;
            }
            else
            {
                string[] second = new string[count];
                count = 0;
                for (int i = 0; i < first.Length; i++)
                {
                    if (first[i] != "") { second[count] = first[i]; count++; }
                }
                return second;
            }
        }

        static int CountSentences(string str)
        {
            int count = 0;
            char tmp;
            char[] eChars = new char[] { '.', '!', '?' };
            for (int i = 0; i < str.Length; i++)
            {
                tmp = str[i];
                if (Array.Exists(eChars, ch => ch == tmp)) count++;
            }
            return count;
        }

        static void AddString(ref string str)
        {
            bool quit = false;
            char k = '0';
            do
            {
                Console.Clear();
                Console.WriteLine("Добавить строку \n\n1) Ручной ввод\n2) Автозаполнение\n3) Из файла\n\n\n0) Назад");
                k = GetKeyPress("", new char[] { '1', '2', '3', '0' });
                switch (k)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Введите строку");
                        str = Console.ReadLine();
                        quit = true;
                        break;
                    case '2':
                        Console.Clear();
                        MakeString(ref str, GetRightSize("Введите размер строки: "));
                        quit = true;
                        break;
                    case '3':
                        AppendFileInput(ref str);
                        quit = true;
                        break;
                    case '0':
                        quit = true;
                        break;
                }

            } while (!quit);
        }
        static void AppendFileInput(ref string str)
        {
            bool right = false;
            do
            {
                Console.Clear();
                LoadStringFromFile(ref str);
                Console.WriteLine(str+"\n\nПродолжить?\n1) Да\n2) Нет");
                if (GetKeyPress("", new char[] { '1', '2' }) == '1') right = true;
            } while (!right);
        }
        static void LoadStringFromFile(ref string str)
        {
            bool right;
            int ind;
            string[] file_name = File.ReadAllLines("file.txt",Encoding.Default);
            do
            {
                Console.Clear();
                right = true;
                ind = GetRightSize($"Введите номер сохраненной строки(1-{file_name.Length}): ") ;

                if (ind > file_name.Length) { right = false; Console.WriteLine("Нет такой строки");Console.ReadKey(); }
            } while (!right);
            str = file_name[ind - 1];
        }
        static void OneDismArr()
        {
            bool quit = false;
            char[] arr = null;
            char key = '0';
            do
            {
                Console.Clear();
                Console.WriteLine("Работа с одномерными массивами \n\n");
                Console.WriteLine("1) Создать массив  \n" +
                    "2) Показать массив\n" +
                    "3) Удалить из массива все цифры\n" +
                    " \n" +
                    "0) Назад\n\n");
                key = GetKeyPress("", new char[] { '1', '2', '3','0' });
                switch (key)
                {
                    case '1':
                       MakeArray(ref arr);
                        break;
                    case '2':
                        PrintArray(arr);
                        Console.ReadKey();
                        break;
                    case '3':
                        DelNums(ref arr);

                        if (!IsEmpty(arr))
                        {
                            Console.WriteLine("Удалено");
                            Console.ReadKey();
                        }
                        break;
                    case '4':

                        break;
                    case '0':
                        quit = true;
                        break;
                }

            } while (!quit);
        }

        static void TwoDismArr()
        {
            bool quit = false;
            char[,] arr = null;
            char key = '0';
            do
            {
                Console.Clear();
                Console.WriteLine("Работа с двумерными массивами \n\n");
                Console.WriteLine("1) Создать массив  \n" +
                    "2) Показать массив\n" +
                    "3) Удалить из массива все цифры\n" +
                    " \n" +
                    "0) Назад\n\n");
                key = GetKeyPress("", new char[] { '1', '2', '3', '0' });
                switch (key)
                {
                    case '1':
                        MakeArray(ref arr);
                        break;
                    case '2':
                        PrintArray(arr);
                        Console.ReadKey();
                        break;
                    case '3':
                        DelNums(ref arr);
                        if (!IsEmpty(arr))
                        {
                            Console.WriteLine("Удалено");
                            Console.ReadKey();
                        }
                        break;
                    case '4':

                        break;
                    case '0':
                        quit = true;
                        break;
                }
            } while (!quit);
        }

        static void TornArr()
        {
            bool quit = false;
            char[][] arr = null;
            char key = '0';
            do
            {
                Console.Clear();
                Console.WriteLine("Работа с рваными массивами \n\n");
                Console.WriteLine("1) Создать массив  \n" +
                    "2) Показать массив\n" +
                    "3) Удалить из массива все цифры\n" +
                    "4) \n" +
                    "0) Назад\n\n");
                key = GetKeyPress("", new char[] { '1', '2', '3', '5', '0' });
                switch (key)
                {
                    case '1':
                        MakeArray(ref arr);
                        break;
                    case '2':
                        PrintArray(arr);
                        Console.ReadKey();
                        break;
                    case '3':
                        DelNums(ref arr);
                        if (!IsEmpty(arr))
                        {
                            Console.WriteLine("Удалено");
                            Console.ReadKey();
                        }
                        break;
                    case '4':

                        break;
                    case '0':
                        quit = true;
                        break;
                }
            } while (!quit);
        }

        static int GetSize(string msg)
        {
            int size;
            bool right;
            do
            {
                //Console.Clear();
                Console.Write(msg);
                right = Int32.TryParse(Console.ReadLine(), out size);
                if (!right) Console.Write("Неверный ввод\n");
            } while (!right);

            return size;
        }

        static void PrintArray(char[] arr)
        {
            if (IsEmpty(arr)) { Console.WriteLine("Массив пуст"); Console.ReadKey(); return; }
            foreach (char element in arr)
            {
                Console.Write(element);
            }
            Console.WriteLine();
        }

        static void PrintArray(char[,] arr)
        {
            if (IsEmpty(arr)) { Console.WriteLine("Массив пуст"); Console.ReadKey(); return; }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write(arr[i, j]);
                Console.WriteLine();
            }
        }

        static void PrintArray(char[][] arr)
        {
            if (IsEmpty(arr)) { Console.WriteLine("Массив пуст"); Console.ReadKey(); return; }
            for (int i = 0; i < arr.Length; i++)
            {
                PrintArray(arr[i]);
            }
        }

        static void MakeArray(ref char[] arr)
        {
            Console.Clear();
            char k = GetKeyPress("Заполнять массив вручную? \n1) Да\n2) Нет\n\n0) Назад", new char[] { '1', '2', '0' });
            if (k == '1')
            {
                Console.Clear();
                ManualCompletion("Введите массив символов: \n", ref arr,-1);
            }
            else if (k == '2')
            {
                Console.Clear();
                AutoCompletion(GetRightSize("\nВведите размер массива: \n"), ref arr);
            }
        }

        static void MakeArray(ref char[,] arr)
        {
            Console.Clear();
            char k = GetKeyPress("Заполнять массив вручную? \n1) Да\n2) Нет\n\n0) Назад", new char[] { '1', '2', '0' });
            if (k == '1')
            {
                Console.Clear();
                ManualCompletion("Введите массив символов: \n", ref arr);
            }
            else if (k == '2')
            {
                AutoCompletion( ref arr);
            }
        }
        static void MakeArray(ref char[][] arr)
        {
            Console.Clear();
            char k = GetKeyPress("Заполнять массив вручную? \n1) Да\n2) Нет\n\n0) Назад", new char[] { '1', '2', '0' });
            if (k == '1')
            {
                Console.Clear();
                ManualCompletion("Введите массив символов: \n", ref arr);
            }
            else if (k == '2')
            {
                AutoCompletion(ref arr);
            }
        }

        static void ManualCompletion(string msg,ref char[] arr,int sizeBound)
        {
            Console.Write(msg);
            string inp = Console.ReadLine();
            NormString(ref inp, sizeBound);
            arr = inp.ToCharArray();
        }
        static void ManualCompletion(string msg, ref char[,] arr)
        {
            Console.Clear();
            int rows = GetRightSize("Строки: ");
            int columns = GetRightSize("Столбцы: ");
            arr = new char[rows, columns];
            Console.WriteLine();
            char[] tmp = null;

            for (int i = 0; i < rows; i++)
            {
                ManualCompletion($"{i+1}: ", ref tmp, columns);
                for (int j = 0; j < columns; j++)
                    arr[i, j] = tmp[j];
            }
        }

        static void ManualCompletion(string msg, ref char[][] arr)
        {
            Console.Clear();

            int rows = GetRightSize("Строки: ");

            arr = new char[rows][];
            Console.WriteLine();
  
            for (int i = 0; i < rows; i++)
            {
                ManualCompletion($"{i + 1}: ", ref arr[i], -2);
            }
        }

        static void AutoCompletion( ref char[,] arr)
        {
            Console.Clear();

            int rows = GetRightSize("Строки: ");
            int columns = GetRightSize("Столбцы: ");

            arr = new char[rows, columns];
            char[] tmp = null;

            for (int i = 0; i < rows; i++)
            {
                AutoCompletion(columns, ref tmp);
                for (int j = 0; j < columns; j++)
                    arr[i, j] = tmp[j];
            }
        }

        static void AutoCompletion(ref char[][] arr)
        {
            Console.Clear();

            int rows = GetRightSize("Строки: ");
            int f = GetRightSize("Диапазон размеров строк:\nот ");
            int t = GetRightSize("до ");
            if (f > t) { int tmp = f; f = t;t = tmp; }

            arr = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                AutoCompletion(rnd.Next(f,t), ref arr[i]);
            }
        }

        static void AutoCompletion(int size, ref char[] arr)
        {
            arr = new char[size];
            int counter = 0;
            int wordsize = 8;
            int curWord;
            string chars = "abcdefghijklmnopqrstuvwxyz1234567890";
            do
            {
                curWord = rnd.Next(1, wordsize);
                for (int i = 0; i <curWord &&counter<size; i++)
                {
                    arr[counter] = chars[rnd.Next(0, chars.Length)];
                    counter++;
                }

                if (counter < size)
                {
                    arr[counter] = ' ';
                    counter++;
                }

            } while (counter < size);
        }

        static int GetRightSize(string msg)
        {
            bool right = true;
            int tmp;
            do
            {
                right = true;
                tmp = GetSize(msg);
                if (tmp <= 0) { right = false; Console.WriteLine("Неверный ввод"); }
            } while (!right);
            return tmp;
        }

        static void DelNums(ref char[] arr)
        {
            if (IsEmpty(arr)) { Console.WriteLine("Массив пуст");Console.ReadKey(); return; }
            string tmp = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (!IsNumber(arr[i]))
                    tmp += arr[i];
            }
            arr = tmp.ToCharArray();
        }
        static void DelNums(ref char[,] arr)
        {
            if (IsEmpty(arr)) { Console.WriteLine("Массив пуст"); Console.ReadKey(); return; }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                char[] tmp = new char[arr.GetLength(1)];
                for (int j = 0; j < tmp.Length; j++)
                    tmp[j] = arr[i, j];
                DelNums(ref tmp);
                string str = new string(tmp);
                NormString(ref str, arr.GetLength(1));
                for (int j = 0; j < str.Length; j++)
                    arr[i, j] = str[j];
            }
        }
        static void DelNums(ref char[][] arr)
        {
            if (IsEmpty(arr)) { Console.WriteLine("Массив пуст"); Console.ReadKey(); return; }
            for (int i = 0; i < arr.Length; i++)
            {
                DelNums(ref arr[i]);
            }
        }

        static bool IsEmpty(string str)
        {
            if (str == "") return true; else return false;
        }

            static bool IsEmpty(char[] arr)
        {
            if (arr == null)
            {
                return true;
            }
            else if (arr.Length == 0)
            {
                return true;
            }
            return false;
        }
        static bool IsEmpty(char[,] arr)
        {
            if (arr == null)
            {
                return true;
            }
            else if (arr.Length == 0)
            {
                return true;
            }
            return false;
        }
        static bool IsEmpty(char[][] arr)
        {
            if (arr == null)
            {
                return true;
            }
            else if (arr.Length == 0)
            {
                return true;
            }
            return false;
        }
        static bool IsNumber(char c)
        {
            Char[] nums = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            if (Array.Exists(nums, ch => ch == c))
                return true;
            else return false;
        }

        static void NormString(ref string inp, int sizeBound)
        {
            if (sizeBound >= 0)
            {
                if (inp.Length < sizeBound)
                {
                    int l = sizeBound - inp.Length;
                    for (int i = 0; i < l; i++)
                        inp += "_";
                }
                else if (inp.Length > sizeBound)
                {
                    inp = inp.Remove(sizeBound, inp.Length - sizeBound);
                }
            }
        }

        static void MakeString(ref string str, int sizeR )
        {
            string tmp = "";
            int size = sizeR - 1;
            int counter = 0;
            int wordsize = 8;
            int curWord;
            string chars = "abcdefghijklmnopqrstuvwxyz";
            string sChars = ",:;";
            string eChars = "....!?";
            do
            {
                curWord = rnd.Next(1, wordsize);
                for (int i = 0; i < curWord && counter < size; i++)
                {
                    tmp+= chars[rnd.Next(0, chars.Length)];
                    counter++;
                }

                if ( size-counter>=2 && rnd.Next(0,3)==2)
                {
                    tmp += sChars[rnd.Next(0, sChars.Length)];
                    tmp += ' ';
                    counter+=2;
                }
         
                if (counter < size)
                {
                    tmp += ' ';
                    counter++;
                }
            } while (counter < size);
            tmp += eChars[rnd.Next(0, eChars.Length)];
            str = tmp;
        }
    }
}
