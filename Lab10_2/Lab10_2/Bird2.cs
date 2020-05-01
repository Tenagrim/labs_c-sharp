using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab10_2
{
    class Bird2:Animal2
    {
        public int wingsWidth;
        public  void Show()
        {
            //base.Show();
            Console.WriteLine($"Я птица {Name}");
            Console.WriteLine($"Мой размах крыльев: {wingsWidth}");
        }

    }
}
