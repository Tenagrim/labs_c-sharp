using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9_2
{
   public class MoneyArray : IEnumerable
    {
        Money[] arr;
        int size;
        public IEnumerator GetEnumerator()
        {
            return arr.GetEnumerator();
        }
        public Money this[int index] 
        {
            get { return arr[index]; }
            set
            {
                if (index >= arr.Length) throw new System.IndexOutOfRangeException();
                arr[index] = value;
            }
        }
        public Money Average() 
        {
            #region oldAverage
            //int nR = 0, nK = 0;
            //if (size != 0) {
            //    foreach (Money n in arr)
            //    {
            //        nR += n.Rubles;
            //        nK += n.Kopeks;
            //    }
            //    nK += nR * 100;
            //    nK /= size;
            //    nR = nK / 100;
            //    nK %= 100;
            //}
            //return new Money(nR, nK);
            #endregion
            Money sum = new Money(0, 0);
            foreach (Money n in arr)
            {
                sum = sum + n;
            }
            return sum / arr.Length;
        }
        public void Add(Money a) 
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = a;
            size++;
        }
        public MoneyArray() 
        {
            arr = new Money[0];
            size = 0;
        }
        public MoneyArray(int newSize) 
        {
            var rand = new Random(0);
            arr = new Money[newSize];
            size = newSize;
            for (int i = 0; i < size; i++) 
            {
                arr[i] = new Money(rand.Next(0, 100), rand.Next(0, 100));
            }
        }
    }

}
        