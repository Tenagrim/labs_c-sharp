using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab10_2;
using Lab12_2;

namespace Lab13_2
{
    class MyNewCollection: MyCollection<Animal>
    {

        public MyNewCollection() : base() { }

        public MyNewCollection(int cap) : base(cap) { }

        public virtual bool Remove(int index)
        {
            int c = Count;
            RemoveAt(index);
            if (c > Count) return true;
            else return false;
        }

        public override void Add(Animal item)
        {
            base.Add(item);
        }

        public virtual void Add(Animal[] arr)
        {
            foreach (Animal it in arr)
            {
                base.Add(it);
            }
        }

        public virtual void AddDefault()
        {
            base.Add(new Animal());
        }

        public override Animal this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                base[index] = value;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
