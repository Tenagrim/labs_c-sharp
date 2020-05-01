using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9_2
{
   public class Money
    {
        private int rubles;
        private int kopeks;
        static public int moneyCount;

        public int Rubles 
        {
            get { return rubles; }
        }
        public int Kopeks 
        {
            get { return kopeks; }
        }
        #region staticOperators
        public static Money operator /(Money a, int b)
        {
            if (b < 0) throw new ArgumentException();
            int nK = a.rubles*100 + a.kopeks;
            nK = nK/ b;
            Money c = new Money(0, nK); ;
            return c;
        }
        public static Money operator +(Money a, Money b)
        {
            int nR = a.rubles + b.rubles;
            int nK = a.kopeks + b.kopeks;
            if (nK >= 100) { nR += nK / 100; nK = nK % 100; }
            return new Money(nR, nK);
        }
        public static Money operator -(Money a, Money b)
        {
            if (a < b) throw new NegativeValueException();
            int nR = a.rubles - b.rubles;
            int nK = a.kopeks - b.kopeks;
            if (nK < 0) { nR -= nK / 100 + 1; nK += 100; }
            return new Money(nR, nK);
        }
        public static bool operator >(Money a, Money b)
        {
            return a.kopeks + a.rubles * 100 > b.kopeks + b.Rubles * 100;
        }
        public static bool operator <(Money a, Money b)
        {
            return a.kopeks + a.rubles * 100 < b.kopeks + b.Rubles * 100;
        }
        public static bool operator >=(Money a, Money b)
        {
            return a.kopeks + a.rubles * 100 >= b.kopeks + b.Rubles * 100; 
        }
        public static bool operator <=(Money a, Money b)
        {
            return a.kopeks + a.rubles * 100 <= b.kopeks + b.Rubles * 100;
        }
        public static Money operator ++(Money a) 
        {
            int nR = a.rubles;
            int nK = a.kopeks + 1;
            if (nK >= 100) { nR++;nK = nK % 100; }
            return new Money(nR, nK);
        }
        public static Money operator --(Money a)
        {
            if (a.IsEmpty()) return a;
            int nR = a.rubles;
            int nK = a.kopeks - 1;
            if (nK <0) { nR--; nK += 100; }
            return new Money(nR, nK);
        }
        public static explicit operator int(Money a) 
        {
            return a.Rubles;
        }
        public static implicit operator bool(Money a)
        {
            return !a.IsEmpty();
        }

        public static Money operator +(Money a, int b)
        {
            int nR = a.rubles ;
            int nK = a.kopeks + b;
            if (nK >= 100) { nR += nK / 100; nK = nK % 100; }
            return new Money(nR, nK);
        }
        public static Money operator -(Money a, int b)
        {
            int nR = a.rubles ;
            int nK = a.kopeks - b;
            if (nK < 0) { nR -= nK / 100 + 1; nK += 100; }
            if (nK + nR * 100 < 0) throw new NegativeValueException();
            return new Money(nR, nK);
        }
        public static Money operator +(int n, Money b)
        {
            int n1 = b.kopeks + b.rubles * 100;
            int n2 = n+n1;
            //if (nK >= 100) { nR += nK / 100; nK = nK % 100; }
            return new Money(n2/100, n2%100);
        }
        public static Money operator -(int n, Money b)
        {
            int n1 = b.kopeks + b.rubles * 100;
            int n2 = n - n1;
            if (n2 < 0) throw new NegativeValueException();
            //if (nK >= 100) { nR += nK / 100; nK = nK % 100; }
            return new Money(n2 / 100, n2 % 100);
        }
        #endregion
        public Money Sum(Money b) 
        {
            int nR = this.rubles + b.rubles;
            int nK = this.kopeks + b.kopeks;
            if (nK > 100) { nR += nK / 100; nK = nK % 100; }
            return new Money(nR, nK);
        }

        public bool IsEmpty() 
        {
            return rubles * 100 + kopeks <= 0;
        }
        public Money Sub(Money b) 
        {
            if (this < b) throw new NegativeValueException();
            int nR = this.rubles - b.rubles;
            int nK = this.kopeks - b.kopeks;
            if (nK < 0) { nR -= nK / 100 + 1; nK += 100; }
            return new Money(nR, nK);
        }

        public Money(int R, int K) 
        {
            if (K > 100) { R += K / 100; K %= 100; }
            rubles = R;
            kopeks = K;
            moneyCount++;
        }
    }
    public class NegativeValueException : Exception 
    {
    }
}
