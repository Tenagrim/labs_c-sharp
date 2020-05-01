using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab10_2
{
    class Animal2
    {
        public int Age { get { return age; } }
        private int age;
        public string Name { get; }
        public void Show()
        {
            Console.WriteLine($"Я просто какое то животное {Name}");
        }
        public Animal2()
        {
            Console.WriteLine("Введите имя животного");
            Name = Console.ReadLine();
            Console.WriteLine("Введите возраст животного");
            bool f = false;
            while (!f)
                f = Int32.TryParse(Console.ReadLine(), out age);

        }
       
    }
}
