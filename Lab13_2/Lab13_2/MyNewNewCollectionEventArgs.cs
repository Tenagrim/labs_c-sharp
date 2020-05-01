using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab12_2;
using Lab10_2;


namespace Lab13_2
{
    public class MyNewNewCollectionEventArgs: EventArgs
    {
        public string NameCollections { get; private set; }
        public string TypeEvent { get; private set; }
        public string NameEvent { get; private set; }
        public Animal Object { get; private set; }

        public MyNewNewCollectionEventArgs(string name, string type, string nameEvent, Animal obj)
        {
            NameCollections = name;
            TypeEvent = type;
            NameEvent = nameEvent;
            Object = obj;
        }
        public MyNewNewCollectionEventArgs(Animal obj)
        {
            NameCollections = "MyNewCollection";
            TypeEvent = "Изменение количества элементов";
            NameEvent = "Добавление элемента ";
            Object = obj;
        }
        public MyNewNewCollectionEventArgs()
        {
            NameCollections = "MyNewCollection";
            TypeEvent = "Изменение количества элементов";
            NameEvent = "Добавление элемента по умолчанию";
            Object = new Animal();
        }
        public override string ToString()
        {
            return "Название класса: " + NameCollections + "\nТип события: " + TypeEvent + "\nНаименование события: " + NameEvent + "\n\nСобытие произошло с элементом \n" + Object + "\n";
        }
    }
}
