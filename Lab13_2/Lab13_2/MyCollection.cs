using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab12_2
{
    class MyCollection<T> :  ICloneable
    {
        private int count;
        private Item<T> head;
        private Item<T> tail;

        public int  Count => count;

        public  IEnumerator GetEnumerator()
        {
            Item<T> tmpItem = new Item<T>();
            tmpItem.Next = head;
            return new MyCollectionEnumenator<T>(tmpItem);
        }
        public virtual void Add(T data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Item<T> item = new Item<T>(data);
            if (head == null)
                head = item;
            else
            {
                tail.Next = item;
                item.Prev = tail;  
            }
            tail = item;
            count++;
        }
        private void Add()
        {
            Item<T> item = new Item<T>();
            if (head == null)
                head = item;
            else
            {
                tail.Next = item;
                item.Prev = tail;  
            }
            tail = item;
            //count++;
        }
        public virtual T this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                    throw new IndexOutOfRangeException();
                Item<T> tmp = head;
                for (int i = 0; i < index; i++)
                    tmp = tmp.Next;
                return tmp.Data;
            }
            set
            {
                if (index >= count)
                    throw new IndexOutOfRangeException();
                 Item<T> tmp =  head;
                for (int i = 0; i < index; i++)
                    tmp =  tmp.Next;
                tmp.Data = value;
            }
        }
        public void RemoveAt(int position)
        {
            if (position >= count || position < 0)
                throw new IndexOutOfRangeException();

             Item<T> tmp =  head;
            for (int i = 0; i < position ; i++)
                tmp =  tmp.Next;
            if (tmp == tail && tmp == head)
            {
                head = null;
                tail = null;
                count = 0;
            }
               else if (tmp == tail)
            {
                tmp.Prev.Next = null;
                tail = tmp.Prev;
            }
            else if (tmp == head)
            {
                head = tmp.Next;
                tmp.Next.Prev = null;
            }
            else 
            {
                tmp.Next.Prev = tmp;
                tmp.Next = tmp.Next.Next;
            }
           
            count--;
        }
        public void Clear()
        {
            count = 0;
            head = null;
            tail = null;
        }

        public object Clone()
        {
            MyCollection<T> clone = new MyCollection<T>();

            foreach (T i in this)
            {
                var ai = i as ICloneable;
                if (ai != null)
                    clone.Add((T)ai.Clone());
                else
                    throw new ArgumentException("Элементы коллекции не являются клонируемыми");
            }
            return clone;
        }
        public override string ToString()
        {
            string str = "";

            foreach (var i in this)
                str += i.ToString() + "\n\n"; 

            return str;
        }
        public bool Find(T key)
        {
            bool done = false;

            foreach (var i in this)
            {
                    if (i.Equals(key))
                    {
                        done = true;
                        return done;
                    }
            }
            return done;
        }

        public MyCollection<T> Copy(MyCollection<T> coll)
        {
            MyCollection<T> copy = new MyCollection<T>();

            foreach (T i in this)
                copy.Add(i);
            return copy;
        }

        public MyCollection()
        {
            count = 0;
            head = null;
            tail = null;
        }
        public MyCollection(int capacity)
        {
            for (int i = 0; i < capacity; i++)
                Add();
        }
        public MyCollection(MyCollection<T> coll)
        {
            foreach (T i in coll)
                Add(i);
        }
    }
    class MyCollectionEnumenator<T> : IEnumerator
    {
        int position = -1;
        Item<T> current;
        public MyCollectionEnumenator(Item<T> item)
        {
            current = item;
        }
        public object Current
        {
            get
            {
                if (position == -1) throw new InvalidOperationException();
                return current.Data;
            }
        }
        public bool MoveNext()
        {
            if (current.Next != null)
            {
                position++;
                current = current.Next;
                return true;
            }
            else return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
    class Item<T>
    {
        public T Data { get; set; }
        public Item<T> Next;// { get; set; };
        public Item<T> Prev;
        public bool empty;

        public Item()
        {
            Data = default(T);
            Next = null;
            Prev = null;
            empty = true;

        }
        public Item(T data)
        {
            if (data != null)
            {
                Data = data;
                empty = false;
            }
            else throw new ArgumentNullException(nameof(data));
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
