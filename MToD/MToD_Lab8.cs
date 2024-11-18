using System;
using System.Collections.Generic;
using System.Text;

namespace MToD
{
    public abstract class TProc<T> where T : new()
    {
        public EOperation Operation;
        public EFunction Function;
        public T Lop_Res, Rop;

        public TProc()
        {
            Operation = EOperation.None;
            Function = EFunction.None;
            Lop_Res = new T();
            Rop = new T();
        }
        public TProc(T lop_res, T rop)
        {
            Operation = EOperation.None;
            Function = EFunction.None;
            Lop_Res = lop_res;
            Rop = rop;
        }

        public void ProcessorClear()
        {
            Operation = EOperation.None;
            Function = EFunction.None;
            Lop_Res = new T();
            Rop = new T();
        }

        public void OperationClear()
        {
            Operation = EOperation.None;
        }

        public void OperationRun()
        {
            switch (Operation)
            {
                case EOperation.Add:
                    {
                        Lop_Res = (dynamic)Lop_Res + (dynamic)Rop;
                        break;
                    }
                case EOperation.Sub:
                    {
                        Lop_Res = (dynamic)Lop_Res - (dynamic)Rop;
                        break;
                    }
                case EOperation.Mul:
                    {
                        Lop_Res = (dynamic)Lop_Res * (dynamic)Rop;
                        break;
                    }
                case EOperation.Div:
                    {
                        Lop_Res = (dynamic)Lop_Res / (dynamic)Rop;
                        break;
                    }
            }
        }
        public void OperationSet(int newop)
        {
            if (Enum.IsDefined(typeof(EOperation), newop))
            {
                Operation = (EOperation)newop;
            }
            else
            {
                throw new ArgumentException("Invalid operation value.");
            }
        }

        public EOperation OperationGet()
        {
            return this.Operation;
        }

        public void FunctionClear()
        {
            Function = EFunction.None;
        }

        public void FunctionRun()
        {
            switch (Function)
            {
                case EFunction.Rev:
                    {
                        if (Rop.GetType().GetMethod("Rev")?.Invoke(Rop, null) == null)
                        {
                            Rop = 1 / (dynamic)Rop;
                        }
                        else Rop = (T)Rop.GetType().GetMethod("Rev")?.Invoke(Rop, null);
                        break;
                    }
                case EFunction.Sqr:
                    {
                        if (Rop.GetType().GetMethod("Sqr")?.Invoke(Rop, null) == null)
                        {
                            Rop = (dynamic)Rop * (dynamic)Rop;
                        }
                        else Rop = (T)Rop.GetType().GetMethod("Sqr")?.Invoke(Rop, null);
                        break;
                    }
            }
        }

        public void FunctionSet(int newfunc)
        {
            if (Enum.IsDefined(typeof(EFunction), newfunc))
            {
                Function = (EFunction)newfunc;
            }
            else
            {
                throw new ArgumentException("Invalid function value.");
            }
        }

        public EFunction FunctionGet()
        {
            return this.Function;
        }

        public void Lop_Res_Set(T newlopres)
        {
            Lop_Res = newlopres;
        }

        public void Rop_Set(T newrop)
        {
            Rop = newrop;
        }

        public void ReSet()
        {
            Lop_Res = new T();
            Rop = new T();
        }

        public string RetLop_Res()
        {
            object str = Lop_Res.GetType().GetMethod("Show")?.Invoke(Lop_Res, null) ??
Lop_Res;
            return str.ToString();
        }

        public T RetTLop_Res()
        {
            object str = Lop_Res.GetType().GetMethod("Copy")?.Invoke(null, new object[] {
Lop_Res }) ?? Lop_Res;
            return (T)str;
        }

        public string RetRop()
        {
            object str = Rop.GetType().GetMethod("Show")?.Invoke(Rop, null) ?? Rop;
            return str.ToString();
        }

        public T RetTRop()
        {
            object str = Rop.GetType().GetMethod("Copy")?.Invoke(null, new object[] { Rop }) ?? Rop;
            return (T)str;
        }

        public override bool Equals(object obj)
        {
            if (((this.Lop_Res.Equals(((TProc<T>)obj).Lop_Res))) &&
                (this.Rop.Equals(((TProc<T>)obj).Rop)))
            {
                return true;
            }
            else return false;
        }
    }

    public class Proc<T> : TProc<T> where T : new()
    {
        public Proc() : base()
        {}
        public Proc(T lop_res, T rop) : base(lop_res, rop)
        {}
    }

    public enum EOperation
    {
        None,
        Add,
        Sub,
        Mul,
        Div
    }

    public enum EFunction
    {
        None,
        Rev,
        Sqr
    }

    public class Frac
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        // Конструктор по умолчанию
        public Frac()
        {
            Numerator = 0;
            Denominator = 1;
        }

        // Конструктор с параметрами
        public Frac(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        // Метод для сокращения дроби
        private void Simplify()
        {
            int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator /= gcd;
            Denominator /= gcd;
            if (Denominator < 0) // Переносим знак в числитель
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        // НОД для сокращения дроби
        private int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);

        // Операции сложения, вычитания, умножения и деления
        public static Frac operator +(Frac a, Frac b) =>
            new Frac(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);

        public static Frac operator -(Frac a, Frac b) =>
            new Frac(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);

        public static Frac operator *(Frac a, Frac b) =>
            new Frac(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

        public static Frac operator /(Frac a, Frac b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return new Frac(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        // Метод для возврата обратной дроби
        public Frac Rev() => new Frac(Denominator, Numerator);

        // Метод возведения в квадрат
        public Frac Sqr() => new Frac(Numerator * Numerator, Denominator * Denominator);

        // Переопределение Equals для сравнения
        public override bool Equals(object obj) =>
            obj is Frac frac && Numerator == frac.Numerator && Denominator == frac.Denominator;

        public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

        public override string ToString() => $"{Numerator}/{Denominator}";
    }

}

