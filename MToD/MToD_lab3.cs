using System;

namespace MToD
{
    public class MTod_lab3
    {
        
        public static int MaxNumber(int a, int b, int c)
        {
            if (a > b)
                if (a > c)
                    return a;
                else
                    return c;
            else if (b > c)
                return b;
            else
                return c;
        }

        public static double MultOfOddInd(double[,] mas)
        {
            double result = 1;
            for (int i = 0; i < mas.GetLength(0); i++)
                for (int j = 0; j < mas.GetLength(1); j++)
                    if ((i + j) % 2 == 0)
                        result *= mas[i, j];
            return result;
        }
        public static double MinElemDiag(double[,] mas)
        {
            double result = float.MaxValue;
            for (int i = 0; i < mas.GetLength(0); i++)
                for (int j = 0; j < mas.GetLength(1); j++)
                    if (i == j || i > j)
                        if (mas[i, j] < result)
                            result = mas[i, j];
            return result;
        }

    }
}
