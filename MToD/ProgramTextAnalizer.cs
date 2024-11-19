using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MToD
{

        public static class ProgramTextAnalyzer
        {
            // Метод для сравнения фактической и теоретической длины программы
            public static void CompareWithTheoreticalLength(string filePath)
            {
                try
                {
                    var programLines = File.ReadAllLines(filePath);

                    // Фильтруем строки: удаляем пустые строки и комментарии
                    var filteredLines = programLines
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .Where(line => !line.Trim().StartsWith("//"))
                        .ToList();

                    // Считаем уникальные операнды (слова, переменные, операторы)
                    var uniqueOperands = new HashSet<string>();
                    foreach (var line in filteredLines)
                    {
                        var words = line.Split(new[] { ' ', '\t', '(', ')', '{', '}', ';', ',', '.', '=' },
                            StringSplitOptions.RemoveEmptyEntries);
                        foreach (var word in words)
                        {
                            uniqueOperands.Add(word);
                        }
                    }

                    int eta = uniqueOperands.Count; // Размер словаря (η)

                    // Подсчитываем фактическую длину программы, считая только операнды
                    int programLength = filteredLines.Sum(line => line.Split(new[] { ' ', '\t', '(', ')', '{', '}', ';', ',', '.', '=' },
                            StringSplitOptions.RemoveEmptyEntries).Length);

                    // Рассчитанная теоретическая длина программы (по формуле)
                    double theoreticalLength = 0.9 * eta * Math.Log2(eta);

                    // Вывод результатов
                    Console.WriteLine("\nСравнение фактической и теоретической длины программы:");
                    Console.WriteLine($"Размер словаря (η): {eta}");
                    Console.WriteLine($"Фактическая длина программы (в операндах): {programLength}");
                    Console.WriteLine($"Рассчитанная теоретическая длина программы: {Math.Round(theoreticalLength)}");
                    Console.WriteLine($"Разница (фактическая - теоретическая): {programLength - Math.Round(theoreticalLength)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка анализа текста программы: {ex.Message}");
                }
            }

            // Метод для анализа текста программы (выводит статистику по операндам)
            public static void AnalyzeProgramText(string filePath)
            {
                try
                {
                    var programLines = File.ReadAllLines(filePath);

                    // Подсчитываем общее количество строк
                    int totalLines = programLines.Length;

                    // Фильтруем строки: удаляем пустые строки и комментарии
                    var filteredLines = programLines
                        .Where(line => !string.IsNullOrWhiteSpace(line)) // Исключаем пустые строки
                        .Where(line => !line.Trim().StartsWith("//")) // Исключаем комментарии
                        .ToList();

                    // Находим уникальные операнды
                    var uniqueOperands = new HashSet<string>();
                    foreach (var line in filteredLines)
                    {
                        var words = line.Split(new[] { ' ', '\t', '(', ')', '{', '}', ';', ',', '.', '=' },
                            StringSplitOptions.RemoveEmptyEntries);
                        foreach (var word in words)
                        {
                            uniqueOperands.Add(word);
                        }
                    }

                    // Подсчет длины программы в операндах
                    int programLength = filteredLines.Sum(line => line.Split(new[] { ' ', '\t', '(', ')', '{', '}', ';', ',', '.', '=' },
                            StringSplitOptions.RemoveEmptyEntries).Length);

                    // Вывод результатов
                    Console.WriteLine("Анализ текста программы:");
                    Console.WriteLine($"Общее количество строк: {totalLines}");
                    Console.WriteLine($"Количество строк кода (без комментариев и пустых): {filteredLines.Count}");
                    Console.WriteLine($"Количество уникальных операндов (слова, операторы, переменные): {uniqueOperands.Count}");
                    Console.WriteLine($"Фактическая длина программы (в операндах): {programLength}");

                    // Для справки выводим уникальные операнды
                    Console.WriteLine("\nУникальные операнды программы:");
                    foreach (var operand in uniqueOperands)
                    {
                        Console.WriteLine(operand);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка анализа текста программы: {ex.Message}");
                }
            }
        }
    }

