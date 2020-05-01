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
        public override void Show(string h)
        {
            // base.Show();
            Console.WriteLine(h+"Я млекопитающее "+ Name);
            Console.WriteLine(h+"Мне " + age + " лет");
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
       
        public Mammal():base()
        {
        }
    }
}
