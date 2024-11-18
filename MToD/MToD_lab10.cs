using System;
using System.Collections.Generic;
using System.Linq;

namespace MToD
{
    using System;
    using System.Collections.Generic;

    public class TSet<T>
    {
        private HashSet<T> box;

        public TSet()
        {
            this.box = new HashSet<T>();
        }

        public void Clear()
        {
            this.box.Clear();
        }

        public void Insert(T obj)
        {
            this.box.Add(obj);
        }

        public void Delete(T obj)
        {
            this.box.Remove(obj);
        }

        public bool IsEmpty()
        {
            return this.box.Count == 0;
        }

        public bool IsBelong(T obj)
        {
            return this.box.Contains(obj);
        }

        public TSet<T> Union(TSet<T> q)
        {
            TSet<T> res = new TSet<T>();
            foreach (var item in this.box)
            {
                res.Insert(item);
            }
            foreach (var item in q.box)
            {
                res.Insert(item);
            }
            return res;
        }

        public TSet<T> Subtract(TSet<T> q)
        {
            TSet<T> res = new TSet<T>();
            foreach (var item in this.box)
            {
                res.Insert(item);
            }
            foreach (var item in q.box)
            {
                res.Delete(item);
            }
            return res;
        }

        public TSet<T> Intersection(TSet<T> q)
        {
            TSet<T> result = new TSet<T>();
            foreach (var item in q.box)
            {
                if (this.box.Contains(item))
                {
                    result.Insert(item);
                }
            }
            return result;
        }

        public int Count()
        {
            return this.box.Count;
        }

        public T ElementAt(int i)
        {
            if (i < 0 || i >= this.box.Count)
            {
                throw new ArgumentOutOfRangeException($"Index {i} out of range");
            }
            var list = new List<T>(this.box);
            return list[i];
        }
    }


}

public class TFrac
{
    private int numerator;
    private int denumerator;

    public TFrac()
    {
        this.numerator = 0;
        this.denumerator = 1;
    }

    public TFrac(int a, int b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Denominator must not be zero");
        }
        this.numerator = a;
        this.denumerator = b;
        int gcdValue = GCD(this.numerator, this.denumerator);
        this.numerator /= gcdValue;
        this.denumerator /= gcdValue;
    }

    public TFrac(string frac)
    {
        var parts = frac.Split('/');
        if (parts.Length != 2)
        {
            throw new FormatException("Invalid fraction format");
        }
        this.numerator = int.Parse(parts[0]);
        this.denumerator = int.Parse(parts[1]);
        if (this.denumerator == 0)
        {
            throw new ArgumentException("Denominator must not be zero");
        }
    }

    public override bool Equals(object obj)
    {
        if (obj is TFrac other)
        {
            return this.numerator == other.numerator && this.denumerator == other.denumerator;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.numerator, this.denumerator);
    }

    public TFrac Copy()
    {
        return new TFrac(this.numerator, this.denumerator);
    }

    public TFrac Add(TFrac d)
    {
        return new TFrac(this.numerator * d.denumerator + d.numerator * this.denumerator, this.denumerator * d.denumerator);
    }

    public TFrac Multiply(TFrac d)
    {
        return new TFrac(this.numerator * d.numerator, this.denumerator * d.denumerator);
    }

    public TFrac Subtract(TFrac d)
    {
        return new TFrac(this.numerator * d.denumerator - d.numerator * this.denumerator, this.denumerator * d.denumerator);
    }

    public TFrac Divide(TFrac d)
    {
        return new TFrac(this.numerator * d.denumerator, this.denumerator * d.numerator);
    }

    public TFrac Sqrt()
    {
        return new TFrac(this.numerator * this.numerator, this.denumerator * this.denumerator);
    }

    public TFrac Reverse()
    {
        return new TFrac(this.denumerator, this.numerator);
    }

    public TFrac Negate()
    {
        return new TFrac(-this.numerator, this.denumerator);
    }

    public bool IsEqual(TFrac d)
    {
        return this.numerator == d.numerator && this.denumerator == d.denumerator;
    }

    public bool IsGreaterThan(TFrac d)
    {
        return this.numerator * d.denumerator > d.numerator * this.denumerator;
    }

    public double GetNumerator()
    {
        return this.numerator;
    }

    public string GetNumeratorString()
    {
        return this.numerator.ToString();
    }

    public double GetDenominator()
    {
        return this.denumerator;
    }

    public string GetDenominatorString()
    {
        return this.denumerator.ToString();
    }

    public string GetFractionString()
    {
        return $"{this.numerator}/{this.denumerator}";
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
