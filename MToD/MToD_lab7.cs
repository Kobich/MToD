using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MToD
{

    public enum MemoryState
    {
        Off,
        On  
    }


    public class TMemory<T>
    {
        private T FNumber;
        private MemoryState FState;

        public TMemory()
        {
            FState = MemoryState.Off;
        }

        public void Store(T number)
        {
            if (number == null)
            {
                throw new ArgumentNullException(nameof(number), "Cannot store null in memory.");
            }
            FNumber = number;
            FState = MemoryState.On;
        }

        public void Add(T number)
        {
            if (FState == MemoryState.Off)
            {
                throw new InvalidOperationException("Memory is off.");
            }

            if (number == null) // Проверка на null при добавлении
            {
                throw new ArgumentNullException(nameof(number), "Cannot add null to memory.");
            }

            dynamic a = FNumber;
            dynamic b = number;
            FNumber = a + b;
        }

        public void Clear()
        {
            FNumber = default(T);
            FState = MemoryState.Off;
        }

        public T GetNumber()
        {
            if (FState == MemoryState.Off)
            {
                throw new InvalidOperationException("Memory is off.");
            }

            return FNumber;
        }

        public MemoryState GetMemoryState()
        {
            return FState;
        }
    }























    public class Fraction
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        
        public static Fraction operator +(Fraction a, Fraction b)
        {
            int newNumerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int newDenominator = a.Denominator * b.Denominator;
            return new Fraction(newNumerator, newDenominator).Reduce();
        }

        
        public Fraction Reduce()
        {
            int gcd = GCD(Numerator, Denominator);
            return new Fraction(Numerator / gcd, Denominator / gcd);
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

        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
            {
                return this.Numerator * other.Denominator == this.Denominator * other.Numerator;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Numerator.GetHashCode() ^ Denominator.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }

}
