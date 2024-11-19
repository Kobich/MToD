using System;
using System.Linq;

namespace MToD
{
    public class RunProgram
    {
        static public void run()
        {
            RunSimulation();
            string filePath = "C:\\Users\\kopan\\source\\repos\\MToD\\MToD\\MToD_lab11.cs";
            ProgramTextAnalyzer.AnalyzeProgramText(filePath);
            ProgramTextAnalyzer.CompareWithTheoreticalLength(filePath);
        }

        static public void RunSimulation()
        {
            int[] etaValues = { 16, 32, 64, 128 };
            int numExperiments = 1000;

            Console.WriteLine("Результаты расчетов:");
            Console.WriteLine("Размер словаря | M(Ln) (эксп.) | D(Ln) (эксп.) | СКО (эксп.)        | M(Ln) (теор.) | Отн. погрешность");
            Console.WriteLine(new string('-', 100));

            foreach (int eta in etaValues)
            {
                Simulation simulation = new Simulation(eta, numExperiments);
                simulation.Run();

                var exp = simulation.GetExperimentalResults();
                var theo = simulation.GetTheoreticalResults();

                Console.WriteLine($"{eta,16} | {exp.Mean,12:F0} | {exp.Variance,12:F2} | {exp.StdDeviation,18:F2} | {theo.Mean,12:F0} | {exp.RelativeError,18:F6}");
            }
        }
    }

    class ExperimentResults
    {
        public double Mean { get; set; }
        public double Variance { get; set; }
        public double StdDeviation { get; set; }
        public double RelativeError { get; set; }
    }

    class TheoreticalResults
    {
        public double Mean { get; set; }
        public double RelativeError { get; set; }
    }

    class Simulation
    {
        private readonly int eta;
        private readonly int numExperiments;
        private readonly int[] lengths;
        private readonly double coefficient = 0.9;

        public Simulation(int eta, int numExperiments)
        {
            this.eta = eta;
            this.numExperiments = numExperiments;
            this.lengths = new int[numExperiments];
        }

        public void Run()
        {
            Random random = new Random();
            for (int i = 0; i < numExperiments; i++)
            {
                bool[] seen = new bool[eta];
                int covered = 0, attempts = 0;
                while (covered < eta)
                {
                    int pick = random.Next(eta);
                    if (!seen[pick]) { seen[pick] = true; covered++; }
                    attempts++;
                }
                lengths[i] = attempts;
            }
        }

        public ExperimentResults GetExperimentalResults()
        {
            double mean = lengths.Average();
            double variance = lengths.Select(x => Math.Pow(x - mean, 2)).Average();
            double stdDeviation = Math.Sqrt(variance);
            return new ExperimentResults
            {
                Mean = Math.Round(mean),
                Variance = variance,
                StdDeviation = stdDeviation,
                RelativeError = stdDeviation / mean
            };
        }

        public TheoreticalResults GetTheoreticalResults()
        {
            double mean = coefficient * eta * Math.Log2(eta);
            return new TheoreticalResults
            {
                Mean = Math.Round(mean),
                RelativeError = 1 / (2 * Math.Log2(eta))
            };
        }
    }
}
