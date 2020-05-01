using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab11_2
{
    class TestCollections
    {
        public List<Lab10_2.Animal> collection_1_1;
        public List<string> collection_1_2;

        public Dictionary<Lab10_2.Animal, Lab10_2.Bird> collection_2_1;
        public Dictionary<string, Lab10_2.Bird> collection_2_2;

        public TestCollections(int n)
        {
            collection_1_1 = new List<Lab10_2.Animal>(n);
            collection_1_2 = new List<string>(n);
            collection_2_1 = new Dictionary<Lab10_2.Animal, Lab10_2.Bird>(n);
            collection_2_2 = new Dictionary<string, Lab10_2.Bird>(n);
        }
        public TestCollections(List<Lab10_2.Bird> gen)
        {
            collection_1_1 = new List<Lab10_2.Animal>();
            collection_1_2 = new List<string>();
            collection_2_1 = new Dictionary<Lab10_2.Animal, Lab10_2.Bird>();
            collection_2_2 = new Dictionary<string, Lab10_2.Bird>();
            for (int i = 0; i < gen.Count; i++)
            {
                collection_1_1.Add(gen[i].BaseAnimal);
                collection_1_2.Add(gen[i].ToString());
                collection_2_1.Add(gen[i].BaseAnimal, gen[i]);
                collection_2_2.Add(gen[i].ToString(), gen[i]);
            }
        }
        public void Add(Lab10_2.Bird b)
        {
            collection_1_1.Add(b.BaseAnimal);
            collection_1_2.Add(b.ToString());
            collection_2_1.Add(b.BaseAnimal, b);
            collection_2_2.Add(b.ToString(), b);
        }
        public void RemoveAt(int index)
        {
            //TODO: Удаление по сраному ключу - объекту
            collection_2_1.Remove(collection_1_1[index]);
            collection_2_2.Remove(collection_1_2[index]);
            collection_1_1.RemoveAt(index);
            collection_1_2.RemoveAt(index);
        }

    }
}
