using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab10_2
{
    public abstract class AbstractAnimal
    {
        public abstract void Voice();
    }
    class AnimalComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Animal an1 = (Animal)x;
            Animal an2 = (Animal)y;
            return String.Compare(an1.Name, an2.Name);
        }
    }
    class Animal : AbstractAnimal, IComparable, ICloneable
    {
        public int Age { get { return age; } }
        public int age;
        public string Name { get; }
        public virtual void Show() 
        {
            Console.WriteLine($"Я просто какое то животное {Name}");
            Console.WriteLine("Мне " + age + " лет");
        }

        public int CompareTo(object obj)
        {

            Animal an = (Animal)obj;

           // return this.age - an.age;

            return String.Compare(this.Name, an.Name);
        }

        public virtual object Clone()
        {
            return new Animal("Клон" + this.Name, this.age + 1);
        }

        public override void Voice()
        {
            Console.WriteLine("Абстрактное \"РРрррРрр!!\"");
        }

        public override bool Equals(object obj)
        {
            if (obj is Animal)
            {
                Animal an = (Animal)obj;
                return an.Age == Age && an.Name == Name;
            }
            else return false;
        }


        public Animal() 
        {
            Console.WriteLine("Введите имя животного");
            Name = Console.ReadLine();
            Console.WriteLine("Введите возраст животного");
            bool f = false;
            while (!f)
                f = Int32.TryParse(Console.ReadLine(), out age);
        }
        public Animal(string name, int age)
        {
            Name = name;
            this.age = age;
        }
    }
}
