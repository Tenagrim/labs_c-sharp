using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab12_2
{
    class MyList2d
    {
        private int count;
        private Item2d head;
        private Item2d tail;

        public int Count => count;
        public void Add(double data)
        {

            Item2d item = new Item2d(data);
            if (head == null)
                head = item;
            else
            {
                tail.Next = item;
                item.Prev = tail;  //                 <------------------------------------
            }
            tail = item;
            count++;
        }
        public void AddFirst(double data)
        {
            Item2d item = new Item2d(data);
            if (head == null)
                head = item;
            else
            {
                head.Prev = item;
                item.Next = head;  //                 <------------------------------------
            }
            head = item;
            count++;
        }

            public IEnumerator GetEnumerator()
        {
            Item2d tmpItem = new Item2d();
            tmpItem.Next = head;
            return new MyList2dEnumenator(tmpItem);
        }
        public void RemoveAt(int position)
        {
            if (position >= count || position < 0)
                throw new IndexOutOfRangeException();

            ref Item2d tmp = ref head;
            for (int i = 0; i < position - 1; i++)
                tmp = ref tmp.Next;
            tmp.Next = tmp.Next.Next;
            if (position != 0)
                tmp.Next.Prev = tmp;  //                          <-------------------------
            else
                tmp.Next.Prev = null;
            count--;
        }

        public bool DelNegatives()
        {
            bool done = false;
            Item2d tmp = head;
            while (tmp != null)
            {
                if (tmp.Data < 0)
                {
                    if (tmp.Prev != null)
                        tmp.Prev.Next = tmp.Next;
                    if (tmp.Next != null)
                        tmp.Next.Prev = tmp.Prev;
                    done = true;
                    if (tmp == head)
                        head = tmp.Next;
                    if (tmp == tail)
                        tail = tmp.Prev;
                }
                tmp = tmp.Next;
            }
            return done;
        }

        public void Clear()
        {
            count = 0;
            head = null;
            tail = null;
        }
        public MyList2d()
        {
            count = 0;
            head = null;
            tail = null;
        }


    }

    class MyList2dEnumenator : IEnumerator
    {
        int position = -1;
        Item2d current;
        public MyList2dEnumenator(Item2d item)
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

    class Item2d
    {
        public double Data { get; set; }
        public Item2d Next;// { get; set; };
        public Item2d Prev;

        public Item2d()
        {
            Data = 0;
            Next = null;
        }
        public Item2d(double data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
