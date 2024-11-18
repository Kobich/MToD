using System;

namespace MToD
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание экземпляров множества дробей
            TSet<TFrac> setA = new TSet<TFrac>();
            TSet<TFrac> setB = new TSet<TFrac>();

            // Добавление элементов в множество A
            setA.Insert(new TFrac(1, 2));
            setA.Insert(new TFrac(3, 4));

            // Добавление элементов в множество B
            setB.Insert(new TFrac(3, 4));
            setB.Insert(new TFrac(5, 8));

            // Вывод множества A
            Console.WriteLine("Множество A:");
            PrintSet(setA);

            // Вывод множества B
            Console.WriteLine("Множество B:");
            PrintSet(setB);

            // Объединение множеств A и B
            TSet<TFrac> unionSet = setA.Union(setB);
            Console.WriteLine("\nОбъединение A и B:");
            PrintSet(unionSet);

            // Пересечение множеств A и B
            TSet<TFrac> intersectionSet = setA.Intersection(setB);
            Console.WriteLine("\nПересечение A и B:");
            PrintSet(intersectionSet);

            // Разность множеств A и B
            TSet<TFrac> differenceSet = setA.Subtract(setB);
            Console.WriteLine("\nРазность A - B:");
            PrintSet(differenceSet);

            // Проверка принадлежности элемента в множестве A
            TFrac frac = new TFrac(1, 2);
            Console.WriteLine($"\nЭлемент {frac.GetFractionString()} принадлежит множеству A: {setA.IsBelong(frac)}");

            // Очистка множества A и проверка на пустоту
            setA.Clear();
            Console.WriteLine("\nМножество A после очистки:");
            Console.WriteLine($"Пустое: {setA.IsEmpty()}");
        }

        // Метод для вывода элементов множества
        static void PrintSet(TSet<TFrac> set)
        {
            for (int i = 0; i < set.Count(); i++)
            {
                Console.Write(set.ElementAt(i).GetFractionString() + " ");
            }
            Console.WriteLine();
        }
    }

    // Здесь должны быть определения классов TSet и TFrac
}
