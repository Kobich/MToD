using System;
using System.Text;

namespace MToD
{
    public class MyException : Exception
    {
        public MyException(string str) : base(str) { }
    }

    public class Matrix
    {
        int[,] matrix;
        public int I { get; set; }
        public int J { get; set; }

        // Конструктор
        public Matrix(int i, int j)
        {
            if (i <= 0)
            {
                throw new MyException($"Недопустимое значение i = {i}");
            }
            if (j <= 0)
            {
                throw new MyException($"Недопустимое значение j = {j}");
            }
            I = i;
            J = j;
            matrix = new int[i, j];
        }

        // Индексация
        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= I)
                {
                    throw new MyException($"Неверное значение i = {i}");
                }
                if (j < 0 || j >= J)
                {
                    throw new MyException($"Неверное значение j = {j}");
                }
                return matrix[i, j];
            }
            set
            {
                if (i < 0 || i >= I)
                {
                    throw new MyException($"Неверное значение i = {i}");
                }
                if (j < 0 || j >= J)
                {
                    throw new MyException($"Неверное значение j = {j}");
                }
                matrix[i, j] = value;
            }
        }

        // Оператор сложения матриц
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.I != b.I || a.J != b.J)
            {
                throw new MyException("Размерности матриц a и b разные");
            }

            Matrix c = new Matrix(a.I, a.J);
            for (int i = 0; i < a.I; i++)
            {
                for (int j = 0; j < a.J; j++)
                {
                    c.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
                }
            }
            return c;
        }

        // Оператор вычитания матриц
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.I != b.I || a.J != b.J)
            {
                throw new MyException("Размерности матриц a и b разные");
            }

            Matrix c = new Matrix(a.I, a.J);
            for (int i = 0; i < a.I; i++)
            {
                for (int j = 0; j < a.J; j++)
                {
                    c.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
                }
            }
            return c;
        }

        // Оператор умножения матриц
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.J != b.I)
            {
                throw new MyException("Невозможно умножить матрицы с такими размерностями");
            }

            Matrix c = new Matrix(a.I, b.J);
            for (int i = 0; i < a.I; i++)
            {
                for (int j = 0; j < b.J; j++)
                {
                    for (int k = 0; k < a.J; k++)
                    {
                        c.matrix[i, j] += a.matrix[i, k] * b.matrix[k, j];
                    }
                }
            }

            return c;
        }

        // Оператор сравнения ==
        public static bool operator ==(Matrix a, Matrix b)
        {
            if (a.I != b.I || a.J != b.J)
            {
                return false;
            }

            for (int i = 0; i < a.I; i++)
            {
                for (int j = 0; j < a.J; j++)
                {
                    if (a.matrix[i, j] != b.matrix[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // Оператор !=
        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }

        // Транспонирование матрицы
        public Matrix Transp()
        {
            Matrix transposed = new Matrix(J, I);
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    transposed[j, i] = this[i, j];
                }
            }
            return transposed;
        }

        // Нахождение минимального элемента
        public int Min()
        {
            int minimum = this[0, 0];
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    if (this[i, j] < minimum)
                    {
                        minimum = this[i, j];
                    }
                }
            }
            return minimum;
        }

        // Строковое представление матрицы
        public string Matrix_str()
        {
            StringBuilder str = new StringBuilder("{ ");
            for (int i = 0; i < I; i++)
            {
                str.Append("{ ");
                for (int j = 0; j < J; j++)
                {
                    str.Append(this[i, j] + " ");
                }
                str.Append("}");
            }
            str.Append(" }");
            return str.ToString();
        }

        // Получение элемента
        public int Take_elem(int n, int m)
        {
           
            return this[n, m];
        }

        // Установка элемента
        public void Write_elem(int n, int m, int new_num)
        {
            
            this[n, m] = new_num;
        }

        // Печать матрицы
        public void Show()
        {
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    Console.Write("\t" + this[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


    }
}
