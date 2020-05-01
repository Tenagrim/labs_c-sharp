using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab10_2;
using Lab12_2;

namespace Lab13_2
{
    public delegate void MyNewCollectionHandler(object sender, MyNewNewCollectionEventArgs args);
    class MyNewNewCollection : MyNewCollection
    {
        public event MyNewCollectionHandler CollectionCountChanges;
        public event MyNewCollectionHandler CollectionReferenceChanges;

        public void OnCollectionCountChanges(object sender, MyNewNewCollectionEventArgs args)
        {
            if (CollectionCountChanges != null)
                CollectionCountChanges(sender, args);
        }
        public void OnCollectionReferencechanges(object sender, MyNewNewCollectionEventArgs args)
        {
            if (CollectionReferenceChanges != null)
                CollectionReferenceChanges(sender, args);
        }

        public override void Add(Animal[] arr)
        {

            OnCollectionCountChanges(this, new MyNewNewCollectionEventArgs("MyNewCollection", "Изменение количества элементов", "Добавление массива", arr[0]));
            base.Add(arr);
        }

        public override void AddDefault()
        {
            OnCollectionCountChanges(this, new MyNewNewCollectionEventArgs());
            base.AddDefault();
        }
        public override void Add(Animal item)
        {
            OnCollectionCountChanges(this, new MyNewNewCollectionEventArgs(item));
            base.Add(item);
        }
        public override bool Remove(int index)
        {
            OnCollectionCountChanges(this, new MyNewNewCollectionEventArgs("MyNewCollection", "Изменение количества элементов", "Удаление элемента", this[index]));
            return base.Remove(index);
        }

        public override Animal this[int index]
        {
            get => base[index];
            set
            {
                OnCollectionReferencechanges(this, new MyNewNewCollectionEventArgs("MyNewCollection", "Изменение количества элементов", "Изменение элемента", this[index]));
                base[index] = value;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
