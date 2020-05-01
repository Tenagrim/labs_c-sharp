using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab10_2
{
    class Bird : Animal
    {
        public int wingsWidth;

        public override void Show()
        {
            //base.Show();
            Console.WriteLine($"Я птица {Name}");
            Console.WriteLine("Мне " + age + " лет");
            Console.WriteLine($"Мой размах крыльев: {wingsWidth} см.");
        }
        public override void Voice()
        {
            Console.WriteLine("Цвирк!");
        }
        public override object Clone()
        {
            return new Bird("Клон " + this.Name, this.age + 1, this.wingsWidth);
        }
        public Bird()
        {
            Console.WriteLine("Введите размах крыльев");
            bool f = false;
            while (!f)
                f = Int32.TryParse(Console.ReadLine(), out wingsWidth);
        }
        public Bird(string name, int age, int width) : base(name, age)
        {
            wingsWidth = width;
        }
        public Animal BaseAnimal
        {
            get { return new Animal(Name, Age); }
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode()+wingsWidth.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Bird)
            {
                Bird an = (Bird)obj;
                if (an.Age == Age && an.Name == Name && an.wingsWidth == wingsWidth) return true;
                else return false;
            }
            else return false;
        }

        public override string ToString()
        {
            return Name + " " + Age.ToString() + " " + wingsWidth.ToString();
        }

    }
}
