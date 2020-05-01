using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab10_2;
using Lab12_2;

namespace Lab13_2
{
    class JournalEntry
    {
        public string Name { get; set; }
        public string TypeEvent { get; set; }
        public string NameEvent { get; set; }
        public Animal Object { get; set; }

        public JournalEntry(string name, string type, string nameEvent, Animal Object)
        {
            Name = name;
            TypeEvent = type;
            NameEvent = nameEvent;
            this.Object = Object;
        }

        public JournalEntry(Animal Object, int num)
        {
            Name = "MyNewCollection";
            TypeEvent = "Изменение количества элементов";
            NameEvent = "Добавление элемента не по умолчанию";
            this.Object = Object;
        }
        public JournalEntry()
        {
            Name = "MyNewCollection";
            TypeEvent = "Изменение количества элементов";
            NameEvent = "Добавление элемента по умолчанию";
            Object = new Animal();
        }

        public override string ToString()
        {
            return "\nНазвание класса: " +
                Name + "\nТип события: " +
                TypeEvent + "\nНаименование события: " + NameEvent +
                "\n\nСобытие произошло с элементом \n" + Object + "\n";
        }
    }
}
