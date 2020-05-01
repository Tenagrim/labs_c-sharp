using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab12_2
{
    class MyList1d 
    {
        private int count;
        private Item1d head;
        private Item1d tail;

        public int Count => count;

        public void Add(string data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Item1d item = new Item1d(data);
            if (head == null)
                head = item;
            else
                tail.Next = item;
            tail = item;
            count++;
        }
        public void RemoveAt(int position)
        {
            if (position >= count || position < 0)
                throw new IndexOutOfRangeException();

            ref Item1d tmp = ref head;
            for (int i = 0; i < position - 1; i++)
                tmp = ref tmp.Next;
            tmp.Next = tmp.Next.Next;
            tail = tmp;
        }

        public string this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                    throw new IndexOutOfRangeException();
                Item1d tmp = head;
                for (int i = 0; i < index; i++)
                    tmp = tmp.Next;
                return tmp.Data;
            }
            set
            {
                if (index >= count)
                    throw new IndexOutOfRangeException();
                ref Item1d tmp = ref head;
                for (int i = 0; i < index; i++)
                    tmp = ref tmp.Next;
                tmp.Data = value;
            }
        }
        public bool AddAfter(string key, string value)
        {
            if (head == null) return false;
            bool done = false;
            Item1d tmp = head;
            Item1d add = new Item1d(value);
            while (tmp != null && !done)
            {
                if (tmp.Data == key)
                {
                    add.Next = tmp.Next;
                    tmp.Next = add;
                    done = true;
                    count++;
                }
                tmp = tmp.Next;
            }


            return done;
        }
        public IEnumerator GetEnumerator()
        {
            Item1d tmpItem = new Item1d();
            tmpItem.Next = head;
            return new MyList1dEnumenator(tmpItem);
        }

        
        public void Clear()
        {
            count = 0;
            head = null;
            tail = null;
        }
        public MyList1d()
        {
            count = 0;
            head = null;
            tail = null;
        }
    }
    class MyList1dEnumenator : IEnumerator
    {
        int position = -1;
        Item1d current;
        public MyList1dEnumenator(Item1d item)
        {
            current = item;
        }
        public object Current
        {
            get
            {
                if (position == -1) throw new InvalidOperationException();
                return current;
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
    class Item1d
    {
        public string Data { get; set; }
        public Item1d Next;// { get; set; };

        public Item1d()
        {
            Data = "";
            Next = null;
        }
        public Item1d(string data)
        {
            if (data != null)
                Data = data;
            else throw new ArgumentNullException(nameof(data));
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
