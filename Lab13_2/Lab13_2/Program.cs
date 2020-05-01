using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Lab10_2;
using Lab12_2;

namespace Lab13_2
{
    delegate void CollectionAction(MyNewNewCollection act);
    delegate void JournalAction(Journal journal);

    class Program
    {
        static Random rand = new Random();
        static bool currentCollIs1 = true;
        static bool currentJourlIs1 = true;

        static MyNewNewCollection collOne = new MyNewNewCollection();
        static MyNewNewCollection collTwo = new MyNewNewCollection();
        static Journal journalOne = new Journal();
        static Journal journalTwo = new Journal();

        static CollectionAction collAct;
        static JournalAction jourAct;

        static void Main(string[] args)
        {
            collOne.CollectionCountChanges += new MyNewCollectionHandler(journalOne.CollectionCountChanged);
            collOne.CollectionReferenceChanges += new MyNewCollectionHandler(journalOne.CollectionReferenceChanged);

            collOne.CollectionReferenceChanges += new MyNewCollectionHandler(journalTwo.CollectionReferenceChanged);
            collTwo.CollectionReferenceChanges += new MyNewCollectionHandler(journalTwo.CollectionReferenceChanged);

            MainMenu();
        }
        static string GetCurrCollNum()
        {
            if (currentCollIs1) return "1";
            else return "2";
        }
        static string GetCurJourlNum()
        {
            if (currentJourlIs1) return "1";
            else return "2";
        }
        static void MainMenu()
        {

            char k = '0';
            bool quit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Лабораторная работа №13 \n\"Программа управляемая событиями\"\n");
                Console.WriteLine("Выбор задачи:\n1) Выбрана коллекция " + GetCurrCollNum() + "\n2) Выбран журнал " + GetCurJourlNum() + "\n3) Редактировать коллецию\n4) Просмотреть коллекцию\n5) Просмотреть журнал\n6) Очистить коллекцию\n7) Очистить журнал\n\n\n0) Выход");
                k = GetKeyPress("", new char[] { '1', '2', '0', '3', '4', '5', '6', '7' });
                switch (k)
                {
                    case '1':
                        currentCollIs1 = !currentCollIs1;
                        break;
                    case '2':
                        currentJourlIs1 = !currentJourlIs1;
                        break;
                    case '3':
                        EditColl();
                        break;
                    case '4':
                        ShowColl();
                        break;
                    case '5':
                        ShowJour();
                        break;
                    case '6':
                        ClearColl();
                        break;
                    case '7':
                        ClearJour();
                        break;
                    case '0':
                        quit = true;
                        break;
                }
            } while (!quit);
        }

        static void EditColl()
        {
            char k = '0';
            bool quit = false;
            do
            {
                Console.Clear();
                // Console.WriteLine("Лабораторная работа №13 \n\"Программа управляемая событиями\"\n");
                Console.WriteLine("Редактирование элементов:\n1) Добавить элемент \n2) Изменить элемент \n3) Удалить элемент\n\n\n0) Назад");
                k = GetKeyPress("", new char[] { '1', '2', '0', '3' });
                switch (k)
                {
                    case '1':
                        collAct = new CollectionAction(AddElement);
                        ApplyActToCollection(collAct);
                        qwe("Элемент добавлен");
                        Pause();
                        
                        break;
                    case '2':
                        
                        collAct = new CollectionAction(ChangeElement);
                        try
                        {
                            ApplyActToCollection(collAct);
                            qwe("Элемент изменен");
                        }
                        catch(IndexOutOfRangeException) { qwe("Не существует элемента на указанной позиции"); }
                        Pause();
                        
                        break;
                    case '3':
                        collAct = new CollectionAction(RemoveElement);
                        try
                        {
                            ApplyActToCollection(collAct);
                            qwe("Элемент удален");

                        }
                        catch (IndexOutOfRangeException) { qwe("Не существует элемента на указанной позиции"); }
                        Pause();
                        
                        break;
                    case '0':
                        quit = true;
                        break;
                }
            } while (!quit);
        }
        static void ShowColl()
        {
            collAct = new CollectionAction(ShowColl);
            ApplyActToCollection(collAct);
            Pause();
        }
        static void ShowColl(MyNewNewCollection coll)
        {
            qwe(coll.ToString());
        }
        static void ShowJour()
        {
            jourAct = new JournalAction(ShowJour);
            ApplyActToJournal(jourAct);
            Pause();
        }

        static void ShowJour(Journal journal)
        {
            qwe(journal.ToString());
        }
        static void ClearColl()
        {
            collAct = new CollectionAction(ClearColl);
            ApplyActToCollection(collAct);
            qwe("Коллекция очищена");
            Pause();
        }
        static void ClearColl(MyNewNewCollection coll)
        {
            coll.Clear();
        }
        static void ClearJour()
        {
            jourAct = new JournalAction(ClearJour);
            ApplyActToJournal(jourAct);
            qwe("Журнал очищен");
            Pause();
        }
        static void ClearJour(Journal journal)
        {
            journal.Clear();
        }
        static void AddElement(MyNewNewCollection coll)
        {
            char k = '0';
            bool quit = false;
            do
            {
                Console.Clear();
                // Console.WriteLine("Лабораторная работа №13 \n\"Программа управляемая событиями\"\n");
                Console.WriteLine("Добавление элементов:\n1) Добавить случайный элемент  \n\n\n0) Назад");
                k = GetKeyPress("", new char[] { '1', '0',  });
                switch (k)
                {
                    case '1':
                        coll.Add(RandomAnimal());
                        quit = true;
                        break;
                    case '2':
                        coll.AddDefault();
                        Pause();
                        quit = true;
                        break;
                    case '0':
                        quit = true;
                        break;
                }
            } while (!quit);
        }
        static void RemoveElement(MyNewNewCollection coll)
        {
            int pos = GetRightNumber("Введете номер удаляемого элемента");
            pos--;
            coll.Remove(pos);
        }
        static void ChangeElement(MyNewNewCollection coll)
        {
            qwe("Заменить указанный элемент на новый случайный");
            int pos = GetRightNumber("Введете номер заменяемого элемента");
            pos--;
            coll[pos] = RandomAnimal();

        }
        static void ApplyActToCollection(CollectionAction act)
        {
            if (currentCollIs1)
                act(collOne);
            else
                act(collTwo);
        }
        static void ApplyActToJournal(JournalAction act)
        {
            if (currentJourlIs1)
                act(journalOne);
            else
                act(journalTwo);
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
        static void MakeRandomArr(ref Animal[] arr)
        {
            int size = GetRightNumber("Введите размер массива");
            arr = new Animal[size];

            for (int i = 0; i < size; i++)
            {
                arr[i] = RandomAnimal();
            }
        }
        static int GetRightNumber(string msg)
        {
            int n = -1;
            while (n <= 0)
            {
                n = GetNumber(msg);
                if (n <= 0) Console.WriteLine("Неверный ввод");
            }
            return n;
        }
        static int GetNumber(string msg)
        {
            bool f = false;
            int n = 0;
            Console.WriteLine(msg);
            while (!f)
            {
                f = Int32.TryParse(Console.ReadLine(), out n);
                if (!f) Console.WriteLine("Неверный ввод");
            }
            return n;
        }
        static void qwe(string str = "")
        {
            Console.WriteLine(str);
        }
        static void Pause()
        {
            Console.WriteLine("\nДля продолжения нажмите любую кнопку ...");
            Console.ReadKey();
        }
        static void Clear(Journal journal)
        {
            journal.Clear();
        }
        private static void ShowCollection(MyNewCollection coll)
        {
            Console.WriteLine(coll);
        }
        static void ShowJournal(Journal journal)
        {
            Console.WriteLine(journal);
        }
        static Animal RandomAnimal()
        {
            Animal an = null;

            string str;
            string[] names = null;
            using (var fin = new StreamReader("names.txt", Encoding.Default))
            {
                str = fin.ReadLine();
                var re = new Regex(" ");
                // str.Remove(str.IndexOf(' '));
                str = re.Replace(str, "");
                names = str.Split(',');
            }
            int n = rand.Next(0, 4);
            switch (n)
            {
                case 0:
                    an = new Animal(names[rand.Next(0, names.Length - 1)], rand.Next(1, 30));
                    break;
                case 1:
                    an = new Mammal(names[rand.Next(0, names.Length - 1)], rand.Next(1, 30));
                    break;
                case 2:
                    an = new Artiodactyl(names[rand.Next(0, names.Length - 1)], rand.Next(1, 30));
                    break;
                case 3:
                    an = new Bird(names[rand.Next(0, names.Length - 1)], rand.Next(1, 10), rand.Next(10, 250));
                    break;
            }
            return an;
        }
    }
}
