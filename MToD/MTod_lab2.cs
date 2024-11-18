using System;

namespace MToD
{
    public class MTod_lab2
    {
        // Поиск минимума из трёх чисел
        public static int min(int a, int b, int c)
        {
            int result;
            if (a < b) result = a;
            else result = b;
            if (c < result) result = c;
            return result;
        }
        public static double sum(double[,] A)
        {
            double sum = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += A[i, j];
                    }
                }
            }
            return sum;
        }
        public static double max(double[,] A)
        {
            double max = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (i >= j && max < A[i, j])
                    {
                        max = A[i, j];
                    }
                }
            }
            return max;
        }
    }
    }
