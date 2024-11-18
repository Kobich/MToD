using System;

public class LabWork
{
    // Функция, которая преобразует строку s в целое число в системе счисления с основанием b
    public static int StringToInt(string s, int b)
    {
        int result = 0;
        int power = 1; // начнем с младшего разряда (единицы)

        // Проходим по строке справа налево
        for (int i = s.Length - 1;
            i >= 0;
            i--)
        {
            int digitValue;

            // Если символ - это цифра ('0' - '9')
            if (char.IsDigit(s[i]))
            {
                digitValue = s[i] - '0';
            }
            // Если символ - это буква (например, для оснований больше 10, 'A' - 'F' для шестнадцатеричной системы)
            else if (char.IsLetter(s[i]))
            {
                digitValue = char.ToUpper(s[i]) - 'A' + 10;
            }
            else
            {
                throw new ArgumentException("Недопустимый символ в строке.");
            }

            // Проверка, что символ не превышает допустимое значение для данной системы счисления
            if (digitValue >= b)
            {
                throw new ArgumentException("Символ превышает допустимое значение для данного основания.");
            }

            // Добавляем значение к результату с учётом разряда
            result += digitValue * power;
            power *= b;
        }

        return result;
    }


    // Функция для поиска максимального значения в массиве и его индекса
    public static (int maxValue, int maxIndex) MaxValueAndIndex(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("Массив не должен быть пустым.");
        }

        int maxValue = array[0];
        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > maxValue)
            {
                maxValue = array[i];
                maxIndex = i;
            }
        }
        return (maxValue, maxIndex);
    }

    // Функция для поиска максимального нечётного элемента с нечётным индексом
    public static int MaxOddValueWithOddIndex(int[] array, out int index)
    {
        index = -1;
        int maxValue = int.MinValue;

        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("Массив не должен быть пустым.");
        }

        for (int i = 1; i < array.Length; i += 2)
        {
            if (array[i] % 2 != 0 && array[i] > maxValue)
            {
                maxValue = array[i];
                index = i;
            }
        }

        return maxValue == int.MinValue ? 0 : maxValue;
    }
}