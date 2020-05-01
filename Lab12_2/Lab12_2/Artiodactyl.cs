using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab10_2
{
    class Artiodactyl : Mammal
    {

        public override void Show()
        {
            //base.Show();
            Console.WriteLine(  $"Я какое то парнокопытное {Name}");
            Console.WriteLine("Мне " + age + " лет");
        }
        public override void Voice()
        {
            Console.WriteLine("Муууу!");
        }
        public override object Clone()
        {
            return new Artiodactyl("Клон " + this.Name, this.age + 1);
        }
        public Artiodactyl(string name, int age) : base(name, age)
        {
            
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Artiodactyl)
            {
                Artiodactyl an = (Artiodactyl)obj;
                if (an.Age == Age && an.Name == Name) return true;
                else return false;
            }
            else return false;
        }
        public Artiodactyl():base()
        {
        }
    }
}
