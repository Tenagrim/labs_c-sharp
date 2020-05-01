using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab10_2
{
    class Mammal :Animal
    {
        public override void Show()
        {
            // base.Show();
            Console.WriteLine($"Я млекопитающее {Name}");
            Console.WriteLine("Мне " + age + " лет");
        }
        public override string ToString()
        {
            string str = "";
            str += ($"Я млекопитающее {Name}\n");
            str += ("Мне " + age + " лет\n");
            return str;
        }
        public override void Voice()
        {
            Console.WriteLine("Конкретное \"РрРРррРр!!\"");
        }
        public override object Clone()
        {
            return new Mammal("Клон " + this.Name, this.age + 1);
        }
        public Mammal(string name, int age) : base(name, age)
        {
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Mammal)
            {
                Mammal an = (Mammal)obj;
                if (an.Age == Age && an.Name == Name) return true;
                else return false;
            }
            else return false;
        }

        public Mammal():base()
        {
        }
    }
}
