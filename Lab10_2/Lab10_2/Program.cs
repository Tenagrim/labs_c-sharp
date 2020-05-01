using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab10_2
{
    class Program
    {
        //public bool enableVirtual;
        static Random rand = new Random();
        static void Main(string[] args)
        {
            MainMenu();
        }
        static void MainMenu()
        {

            char k = '0';
            bool quit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Лабораторная работа №10 \n\"Наследование и виртуальные функции\" \nВариант №13\n");
                Console.WriteLine("Выбор задачи:\n1) Часть 1\n2) Часть 2\n3) Часть 3\n\n\n0) Выход");
                k = GetKeyPress("", new char[] { '1', '2', '0', '3' });
                switch (k)
                {
                    case '1':
                        Task1();
                        break;
                    case '2':
                        Task2();
                        break;
                    case '3':
                        Task3();
                        break;
                    case '0':
                        quit = true;
                        break;
                }
            } while (!quit);
        }
        static void Task1()
        {
            char k = '0';
            bool quit = false;
            bool enableVirtual = true;
            Animal[] arr = null;
            Animal2[] arr2 = null;

            do
            {
                Console.Clear();
                Console.WriteLine("Задача: записать объекты классов в массив, выполнить просмотр элементов массива");
                Console.WriteLine($"enableVirtual = {enableVirtual}");
                Console.WriteLine("\n\n1) Создать массив\n2) Просмотреть массив \n3) Переключить enableVirtual\n\n\n0) Назад \n\n");
                k = GetKeyPress("", new char[] { '1', '2', '0', '3' });
                switch (k)
                {
                    case '1':
                        Console.Clear();
                        //RandomAnimal();// <--------------------------------------------
                        if (enableVirtual)
                            MakeArr(ref arr);
                        else
                            MakeArr(ref arr2);
                        break;
                    case '2':
                        ShowArr(arr);
                        Pause();
                        break;
                    case '3':
                        enableVirtual = !enableVirtual;
                        break;
                    case '0':
                        quit = true;
                        break;
                }
            } while (!quit);
        }
        static void Task2()
        {
            char k = '0';
            bool quit = false;
            Animal[] arr = null;
            do
            {
                Console.Clear();
                Console.WriteLine("Задача: Реализация запросов");
                Console.WriteLine("\n\n1) Создать массив рандомных животных\n2) Просмотреть массив \n3) Перейти к запросам\n\n\n0) Назад \n\n");
                k = GetKeyPress("", new char[] { '1', '2', '0', '3' });
                switch (k)
                {
                    case '1':
                        Console.Clear();
                        MakeRandomArr(ref arr);
                        break;
                    case '2':
                        ShowArr(arr);
                        Pause();
                        break;
                    case '3':
                        if (arr != null)
                            RequestMenu(arr);
                        else
                        {
                            Console.WriteLine(" Массив пуст");
                            Pause();
                        }
                        break;
                    case '0':
                        quit = true;
                        break;
                }
            } while (!quit);
        }
        static void Task3()
        {
            char k = '0';
            bool quit = false;
            Animal[] arr = null;
            AbstractAnimal[] arr2 = null;
            do
            {
                Console.Clear();
                Console.WriteLine("Задача: использование интерфейсов и абстрактных классов");
                Console.WriteLine("\n\n1) Создать массив элементов абстрактного класса\n2) Просмотреть массив \n3) Вызвать абстрактные методы\n4) Отсортировать массив\n5) Поиск элемента по имени\n6) Клонирование объектов\n\n\n0) Назад \n\n");
                k = GetKeyPress("", new char[] { '1', '2', '0', '3', '4','5','6' });
                switch (k)
                {
                    case '1':
                       // Console.Clear();
                        MakeRandomArr(ref arr, ref arr2);
                        break;
                    case '2':
                        ShowArr(arr);
                        Pause();
                        break;
                    case '3':
                        AbstractShow(arr2);
                        Pause();
                        break;
                    case '4':
                        Sort(arr);
                        Pause();
                        break;
                    case '5':
                        Find(arr);
                        Pause();
                        break;
                    case '6':
                        Clone(arr);
                        Pause();
                        break;
                    case '0':
                        quit = true;
                        break;
                }
            } while (!quit);
        }
        static void Clone(Animal[]arr)
        {
            if (arr == null) { Console.WriteLine("Массив пуст"); return; }
            int n;
            do
                n = GetRightNumber("Введите индекс элемента для клонирования");
            while (n >= arr.Length);

            Animal an = (Animal)arr[n].Clone();
            arr[n].Show();
            Console.WriteLine("============");
            an.Show();
        }
        static void Sort(Animal[] arr)
        {
            if (arr != null)
            {
                Array.Sort(arr);
                Console.WriteLine("Сортировка выполнена");
            }
            else Console.WriteLine("Массив пуст");
        }
        static void Find(Animal[] arr) 
        {
            string str = GetString("Введите имя для поиска");
            Animal an = Array.Find(arr, i => i.Name == str);
            if (an != null)
                an.Show();
            else Console.WriteLine("Элемент не найден");
        }
        static string GetString(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }
        static void AbstractShow(AbstractAnimal[] arr)
        {
            if (arr == null)
            {
                Console.WriteLine("Массив пуст");
                return;
            }
            foreach (var i in arr)
            {
                i.Voice();
                // Console.WriteLine("=========================================");
            }
        }
        static void MakeRandomArr(ref Animal[] arr, ref AbstractAnimal[] arr2)
        {
            MakeRandomArr(ref arr);
            arr2 = new AbstractAnimal[arr.Length];
            for (int i = 0; i < arr2.Length; i++)
                arr2[i] = arr[i];
        }
        static void RequestMenu(Animal[] arr)
        {
            char k = '0';
            bool quit = false;
            //  Animal[] NArr = null;
            do
            {
                Console.Clear();
                Console.WriteLine("Показать список животных по запросу ");
                Console.WriteLine("\n\n1) Показать животных определенного вида\n2) Показать животных старше чем n лет \n3) Показать птиц с размахом крыльев большим чем n см\n4) Посчитать количество животных каждого вида\n\n\n0) Назад \n\n");
                k = GetKeyPress("", new char[] { '1', '2', '0', '3', '4' });
                switch (k)
                {
                    case '1':
                        TypeRequest2(arr);
                        break;
                    case '2':
                        AgeRequest(arr);
                        break;
                    case '3':
                        WidthRequest(arr);
                        break;
                    case '4':
                        CountRequest(arr);
                        break;
                    case '0':
                        quit = true;
                        break;
                }
            } while (!quit);
        }
        static void CountRequest(Animal[] arr)
        {
            int an = 0, mam = 0, art = 0, bird = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] is Artiodactyl)
                    an++;
                else if (arr[i] is Mammal)
                    mam++;
                else if (arr[i] is Bird)
                    art++;
                else if (arr[i] is Animal)
                    bird++;
            }
            Console.WriteLine($"В массиве {an} просто животных, {mam} млекопитающих, {art} парнокопытных и {bird} птиц");
            Pause();

        }
        static void TypeRequest(Animal[] arr)
        {
            Console.Clear();
            char k = '0';
            string type = "Animal";
            Console.WriteLine("Выберите тип животных: \n\n1)Животные \n2)Млекопитающие \n3)Парнокопытные \n4)Птицы\n\n ");
            k = GetKeyPress("", new char[] { '1', '2', '4', '3' });
            switch (k)
            {
                case '1':
                    type = "Lab10_2.Animal";
                    break;
                case '2':
                    type = "Lab10_2.Mammal";
                    break;
                case '3':
                    type = "Lab10_2.Artiodactyl";
                    break;
                case '4':
                    type = "Lab10_2.Bird";
                    break;
            }
            ShowArr(arr, type);
            Pause();
        }
        static void TypeRequest2(Animal[] arr)
        {
            Console.Clear();
            char k = '0';
            Console.WriteLine("Выберите тип животных: \n\n1)Животные \n2)Млекопитающие \n3)Парнокопытные \n4)Птицы\n\n ");
            k = GetKeyPress("", new char[] { '1', '2', '4', '3' });
            switch (k)
            {
                case '1':
                    foreach (var i in arr)
                    {
                        if (i is Animal)
                        {
                            i.Show();
                            Console.WriteLine("===============================================");
                        }
                    }
                    break;
                case '2':
                    foreach (var i in arr)
                    {
                        if (i is Mammal)
                        {
                            i.Show();
                            Console.WriteLine("===============================================");
                        }
                    }
                    break;
                case '3':
                    foreach (var i in arr)
                    {
                        if (i is Artiodactyl)
                        {
                            i.Show();
                            Console.WriteLine("===============================================");
                        }
                    }
                    break;
                case '4':
                    foreach (var i in arr)
                    {
                        if (i is Bird)
                        {
                            i.Show();
                            Console.WriteLine("===============================================");
                        }
                    }
                    break;
            }
            Pause();
        }
        static void AgeRequest(Animal[] arr)
        {
            int n = GetRightNumber("Введите минимальный возраст");

            foreach (var i in arr)
            {
                if (i.Age >= n)
                {
                    i.Show();
                    Console.WriteLine("==================================");
                }
            }
            Pause();
        }
        static void WidthRequest(Animal[] arr)
        {
            int n = GetRightNumber("Введите минимальный размах крыльев");
            foreach (var i in arr)
            {
                if (i is Bird)
                {
                    Bird p = i as Bird;
                    if (p.wingsWidth >= n)
                    {
                        p.Show();
                        Console.WriteLine("==================================");
                    }
                }
            }
            Pause();
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
        static void Pause()
        {
            Console.WriteLine("Для продолжения нажмите любую кнопку ...");
            Console.ReadKey();
        }
        static void MakeArr(ref Animal[] arr)
        {
            int size = GetRightNumber("Введите размер массива");
            arr = new Animal[size];

            for (int i = 0; i < size; i++)
            {
                arr[i] = ChooseClass();
            }
        }
        static void MakeArr(ref Animal2[] arr)
        {
            int size = GetRightNumber("Введите размер массива");
            arr = new Animal2[size];
            byte b = 0;

            for (int i = 0; i < size; i++)
            {
                arr[i] = ChooseClass(b);
            }
        }
        static Animal ChooseClass()
        {
            char k = '0';
            Animal an = null;
            Console.WriteLine("Выберите вид животного: \n1) Животное \n2) Млекопитающее \n3) Парнокопытное\n4) Птица");
            k = GetKeyPress("", new char[] { '1', '2', '3', '4' });
            switch (k)
            {
                case '1':
                    an = new Animal();
                    break;
                case '2':
                    an = new Mammal();
                    break;
                case '3':
                    an = new Artiodactyl();
                    break;
                case '4':
                    an = new Bird();
                    break;
            }
            return an;
        }
        static Animal2 ChooseClass(byte b)
        {
            char k = '0';
            Animal2 an = null;
            Console.WriteLine("Выберите вид животного: \n1) Животное \n2) Млекопитающее \n3) Парнокопытное\n4) Птица");
            k = GetKeyPress("", new char[] { '1', '2', '3', '4' });
            switch (k)
            {
                case '1':
                    an = new Animal2();
                    break;
                case '2':
                    an = new Mammal2();
                    break;
                case '3':
                    an = new Artiodactyl2();
                    break;
                case '4':
                    an = new Bird2();
                    break;
            }
            return an;
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
        static void ShowArr(Animal[] arr)
        {
            if (arr == null) { Console.WriteLine("Массив пуст"); return; }
            if (arr.Length == 0) { Console.WriteLine("Массив пуст"); return; }

            foreach (var i in arr)
            {
                i.Show();
                Console.WriteLine("==================================================");
            }
        }
        static void ShowArr(Animal[] arr, string Type)
        {
            if (arr == null) { Console.WriteLine("Массив пуст"); return; }
            if (arr.Length == 0) { Console.WriteLine("Массив пуст"); return; }

            for (int i = 0; i < arr.Length; i++)
            {
                string n = arr[i].GetType().ToString();
                if (Type == arr[i].GetType().ToString())

                {
                    arr[i].Show();
                    Console.WriteLine("==================================================");
                }
            }
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
    }
}
