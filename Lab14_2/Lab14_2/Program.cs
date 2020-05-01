using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Lab10_2;

namespace Lab14_2
{
    class Section
    {
        public List<Animal> animals;
        public string sectionName;

        public Section(List<Animal> animals, string name)
        {
            this.animals = animals;
            sectionName = name;
        }
    }
    class Program
    {
        static List<Section> Zoo = new List<Section>();
        static Random rand = new Random();
        static bool created = false;
        static bool doByLinq = true;
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
                Console.WriteLine("Лабораторная работа №14 \n\"LINQ to Objects\" \nВариант №13\n");
                Console.WriteLine("Выбор задачи:\n1) Заполнение вручную (зачем оно вообще?)\n2) Заполнить автоматически\n3) Просмотреть всю структуру\n4) Перейти к запросам\n\n\n0) Выход");
                k = GetKeyPress("", new char[] { '1', '2', '0', '3', '4' });
                switch (k)
                {
                    case '1':
                        ManualComplition();
                        break;
                    case '2':
                        Autocomplition();
                        break;
                    case '3':
                        Console.Clear();
                        ShowZoo();
                        Pause();
                        break;
                    case '4':
                        Reqests();
                        break;
                    case '0':
                        quit = true;
                        break;
                }
            } while (!quit);
        }
        static void Reqests()
        {
            if (!created) { qwe("Сначала создайте структуру"); Pause(); return; }

            char k = '0';
            bool quit = false;

            do
            {
                Console.Clear();
                // Console.WriteLine("Лабораторная работа №14 \n\"LINQ to Objects\" \nВариант №13\n");
                Console.WriteLine("Запросы:\n1) Запрос 1 (Выборка): Все животные с именами на \" \"\n2) Запрос 2 (Агрегация): Средний возраст животных в секциии\n3) Запрос 3 (Группировка): Группировка парнокопытных всех секций младше N лет\n4) Запрос 4 (Счетчик): Количество птиц с размахом крыльев больше N\n5) Запрос 5 (Операции над множествами): Посчитать птиц и млекопитающих\n\n6) Использовать LinQ: " + doByLinq.ToString() + " \n\n\n0) Назад");
                k = GetKeyPress("", new char[] { '1', '2', '0', '3', '4', '5', '6' });
                switch (k)
                {
                    case '1':
                        Request1();
                        break;
                    case '2':
                        Request2();
                        break;
                    case '3':
                        Request3();
                        break;
                    case '4':
                        Request4();
                        break;
                    case '5':
                        Request5();
                        break;
                    case '6':
                        doByLinq = !doByLinq;
                        break;
                    case '0':
                        quit = true;
                        break;
                }
            } while (!quit);
        }
        static void Request1()
        {
            if (doByLinq)
                Request1L();
            else
                Request1R();
        }
        static void Request2()
        {
            if (doByLinq)
                Request2L();
            else
                Request2R();
        }
        static void Request3()
        {
            if (doByLinq)
                Request3L();
            else
                Request3R();
        }
        static void Request4()
        {
            if (doByLinq)
                Request4L();
            else
                Request4R();
        }

        static void Request5()
        {
            if (doByLinq)
                Request5L();
            else
                Request5R();
        }
        static void Request1R()
        {
            string str = Getstring("Введите начало имени");

            var selected = Zoo.SelectMany(sect => sect.animals.Where(an => an.Name.StartsWith(str)).Select(x => x));

            bool f = false;
            foreach (var i in selected)
            {
                f = true;
                i.Show();
                Console.WriteLine();
            }
            if (!f)
            {
                qwe("Таких животных не найдено");
            }

            Pause();
        }
        static void Request2R()
        {
            qwe("Список секций: \n");
            foreach (var s in Zoo)
                qwe(s.sectionName);
            qwe("\n");
            string str = Getstring("Введите название секции");

            var sectS = Zoo.Where(S => S.sectionName == str).Select(s => s);

            if (sectS.Count() == 0)
            {
                qwe("Не найдена указанная секция");
                Pause();
                return;
            }

            Section sect = (Section)sectS.First();

            var aver = sect.animals.Select(an => an.Age).Average();

            if (aver == 0)
                qwe("Cекция пуста");
            else
                qwe("Средний возраст животных: " + aver);

            Pause();
        }
        static void Request3R()
        {
            int bound = GetNumber("Введите максимальный возрас в группировке");

            var group = Zoo.SelectMany(sect => sect.animals.Where(an => an is Artiodactyl).Where(ag => ag.age <= bound)).GroupBy(ag => ag.age);

            if (group.Count() == 0) { qwe("Группировка пуста"); Pause(); return; }
            qwe("");
            qwe("================");
            foreach (var i in group)
            {
                qwe("Возраст: " + i.Key.ToString() + "\n");
                foreach (var s in i)
                {
                    s.Show();
                    qwe("");
                }
                qwe("================");
            }

            Pause();
        } 
    
        static void Request4R()
        {
            int bound = GetNumber("Введите размах крыльев");

            var count = Zoo.SelectMany(sect => sect.animals.Where(an => an is Bird).Where(b => (b as Bird).wingsWidth >= bound)).Select(s => s).Count();
                
                (from sect in Zoo
                         from an in sect.animals
                         where an is Bird
                         where (an as Bird).wingsWidth > bound
                         select an).Count();
            qwe("Количество птиц с размахом крыльев больше " + bound + " см.: " + count);
            Pause();
        }
        static void Request5R()
        {

            var count = Zoo.SelectMany(sect => sect.animals.Where(an => an is Mammal)).Select(d => d).
                Union(Zoo.SelectMany(sect => sect.animals.Where(an => an is Bird)).Select(d => d)).Count();

            qwe("Количество птиц и млекопитающих: " + count);
            Pause();

        }

        static void Request5L()
        {

            var count = (from sect in Zoo
                         from an in sect.animals
                         where an is Mammal
                         select an).
                   Union(from sect in Zoo
                         from an in sect.animals
                         where an is Bird
                         select an).Count();

            qwe("Количество птиц и млекопитающих: " + count);
            Pause();

        }
            static void Request4L()
        {
            int bound = GetNumber("Введите размах крыльев");

            var count = (from sect in Zoo
                         from an in sect.animals
                         where an is Bird
                         where (an as Bird).wingsWidth > bound
                         select an).Count();
            qwe("Количество птиц с размахом крыльев больше " + bound + " см.: " + count);
            Pause();
        }
        static void Request3L()
        {
            int bound = GetNumber("Введите максимальный возрас в группировке");

            var group = from sect in Zoo
                        from an in sect.animals
                        where an is Artiodactyl
                        where an.age <= 5
                        group an by an.age;

            if (group.Count() == 0) { qwe("Группировка пуста"); Pause(); return; }
            qwe("");
            qwe("================");
            foreach (var i in group)
            {
                qwe("Возраст: " + i.Key.ToString() + "\n");
                foreach (var s in i)
                {
                    s.Show();
                    qwe("");
                }
                qwe("================");
            }

            Pause();
        }
            static string Getstring(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }
        static void Request2L()
        {
            qwe("Список секций: \n");
            foreach (var s in Zoo)
                qwe(s.sectionName);
            qwe("\n");
            string str = Getstring("Введите название секции");

            var sectS = from s in Zoo
                       where s.sectionName == str
                       select s;
            if (sectS.Count() == 0)
            {
                qwe("Не найдена указанная секция");
                Pause();
                return;
            }

            Section sect = (Section)sectS.First();

            var aver = (from an in sect.animals
                        select an.age).Average();
            if (aver == 0)
                qwe("Cекция пуста");
            else
                qwe("Средний возраст животных: " + aver);


            Pause();
        }
        static void Request1L()
        {
            string str = Getstring("Введите начало имени");
            //bool f = false;
            //foreach (Section i in Zoo) {
            //    var selected = i.animals.Where(t => t.Name.StartsWith("В"));
            //    if (selected.Count() != 0)
            //    {
            //        Console.WriteLine("Секция: " + i.sectionName + "\n");
            //        foreach (Animal c in selected)
            //        {
            //            f = true;                        
            //            c.Show("   ");
            //            Console.WriteLine();
            //        }
            //    }
            //}


            var selected = from sect in Zoo
                           from an in sect.animals
                           where an.Name.StartsWith(str)
                           select an;
            bool f = false;
            foreach (var i in selected)
            {
                f = true;
                i.Show();
                Console.WriteLine();
            }
            if (!f)
            {
                qwe("Таких животных не найдено");
            }

            Pause();
        }
        static void qwe(string msg)
        {
            Console.WriteLine(msg);
        }
        static void ManualComplition()
        {
            Console.WriteLine("Пожалуйста, не надо");
            Pause();
        }
        static void Autocomplition()
        {
            created = true;
            Zoo.Clear();
            int size = GetRightNumber("Введите количество секций");
            for (int i = 0; i < size; i++)
            {
                Zoo.Add(MakeRandomSection());
            }
            Pause();
        }

        static void ShowZoo()
        {
            foreach (Section i in Zoo)
            {
                Console.WriteLine("=================================================\n");
                ShowSection(i, " ");
                Console.WriteLine("=================================================\n");
            }
        }

        static void ShowSection(Section s, string h)
        {
            Console.WriteLine(h + "Секция " + s.sectionName);
            string H = "     ";
            for (int i = 0; i < s.animals.Count; i++)
            {
                Console.WriteLine();
                s.animals[i].Show(H + h);

            }
        }

        static void ShowAnimal(Animal an, string h)
        {
            string H = "     ";
            an.Show(H + h);
        }

        static string RandomSName()
        {
            string str;
            string[] names = null;
            using (var fin = new StreamReader("namesS.txt", Encoding.Default))
            {
                str = fin.ReadToEnd();
                names = str.Split('\n');
            }
            str = names[rand.Next(0, names.Count())];

            return str.Remove(str.Length - 1);
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
        static Section MakeRandomSection()
        {
            int randSize = rand.Next(3, 25);
            List<Animal> an = new List<Animal>();
            for (int i = 0; i < randSize; i++)
                an.Add(RandomAnimal());
            return new Section(an, RandomSName());
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
        static void Pause()
        {
            Console.WriteLine("\nДля продолжения нажмите любую кнопку ...");
            Console.ReadKey();
        }

    }
}
