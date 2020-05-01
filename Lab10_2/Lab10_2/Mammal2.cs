using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab10_2
{
    class Mammal2: Animal2
    {
        public  void Show()
        {
            // base.Show();
            Console.WriteLine($"Я млекопитающее {Name}");
        }
    }
}
