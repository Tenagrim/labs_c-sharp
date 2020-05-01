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
        public override void Show(string h)
        {
            //base.Show();
            Console.WriteLine(h+"Я какое то парнокопытное "+ Name);
            Console.WriteLine(h + "Мне " + age + " лет");
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
        public Artiodactyl():base()
        {
        }
    }
}
