using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MToD
{
    using System;
    using System.Linq;



    using System;
    using System.Linq;

    public class RunProgram
    {
        static public void run()
        {
            // Запускаем процесс моделирования
            RunSimulation();
        }

        // Функция для запуска моделирования
        static public void RunSimulation()
        {
            // Размеры словаря для экспериментов
            int[] etaValues = { 16, 32, 64, 128 };
            int numExperiments = 1000;

            Console.WriteLine("Результаты расчетов:");
            Console.WriteLine("Размер словаря | M(Ln) (эксп.) | D(Ln) (эксп.) | СКО (эксп.)        | M(Ln) (теор.) | Отн. погрешность");
            Console.WriteLine(new string('-', 100));

            foreach (int eta in etaValues)
            {
                // Создаем экземпляр моделирования для текущего размера словаря
                Simulation simulation = new Simulation(eta, numExperiments);
                simulation.Run();

                // Получаем результаты моделирования
                var experimentalResults = simulation.GetExperimentalResults();
                var theoreticalResults = simulation.GetTheoreticalResults();

                // Вывод результатов
                Console.WriteLine($"{eta,16} | {experimentalResults.Mean,12:F0} | {experimentalResults.Variance,12:F2} | {experimentalResults.StdDeviation,18:F2} | {theoreticalResults.Mean,12:F0} | {experimentalResults.RelativeError,18:F6}");
            }
        }
    }

    // Класс, представляющий результаты эксперимента
    class ExperimentResults
    {
        public double Mean { get; set; } // Среднее значение (целое число в выводе)
        public double Variance { get; set; } // Дисперсия
        public double StdDeviation { get; set; } // Среднеквадратическое отклонение
        public double RelativeError { get; set; } // Относительная погрешность
    }

    // Класс, представляющий теоретические значения
    class TheoreticalResults
    {
        public double Mean { get; set; } // Теоретическое среднее значение
        public double RelativeError { get; set; } // Теоретическая относительная погрешность
    }

    // Класс для проведения моделирования
    class Simulation
    {
        private readonly int eta; // Размер словаря
        private readonly int numExperiments; // Количество экспериментов
        private readonly int[] lengths; // Результаты длины программы (целые значения)
        private readonly double coefficient = 0.9; // Коэффициент для теоретических расчетов

        public Simulation(int eta, int numExperiments)
        {
            this.eta = eta;
            this.numExperiments = numExperiments;
            this.lengths = new int[numExperiments];
        }

        // Метод для запуска моделирования
        public void Run()
        {
            for (int i = 0; i < numExperiments; i++)
            {
                lengths[i] = SimulateWritingProcess();
            }
        }

        // Метод для проведения одного эксперимента
        private int SimulateWritingProcess()
        {
            Random random = new Random();
            bool[] seen = new bool[eta];
            int coveredCount = 0;
            int attempts = 0;

            while (coveredCount < eta)
            {
                // Случайный выбор элемента
                int pick = random.Next(0, eta);
                attempts++;
                if (!seen[pick])
                {
                    seen[pick] = true;
                    coveredCount++;
                }
            }

            return attempts; // Длина программы в данном эксперименте (целое число)
        }

        // Метод для получения экспериментальных результатов
        public ExperimentResults GetExperimentalResults()
        {
            double mean = GetMean(lengths);
            double variance = GetVariance(lengths, mean);
            double stdDeviation = Math.Sqrt(variance);
            double relativeError = stdDeviation / mean;

            return new ExperimentResults
            {
                Mean = Math.Round(mean), // Приводим к целому для интерпретации
                Variance = variance,
                StdDeviation = stdDeviation,
                RelativeError = relativeError
            };
        }

        // Метод для получения теоретических результатов
        public TheoreticalResults GetTheoreticalResults()
        {
            double mean = coefficient * eta * Math.Log2(eta); // Теоретическое значение
            double relativeError = 1 / (2 * Math.Log2(eta));

            return new TheoreticalResults
            {
                Mean = Math.Round(mean), // Приводим к целому для интерпретации
                RelativeError = relativeError
            };
        }

        // Метод для расчета среднего значения
        private double GetMean(int[] data)
        {
            return data.Average();
        }

        // Метод для расчета дисперсии
        private double GetVariance(int[] data, double mean)
        {
            return data.Select(x => Math.Pow(x - mean, 2)).Average();
        }
    }


}
