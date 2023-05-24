namespace Lab2.ConsoleApp.Models
{
    public class PairwiseComparison
    {
        public Option AlternativeA { get; set; }
        public Option AlternativeB { get; set; }
        public double Score { get; set; }
    }

    public class PairwiseComparisonMatrix
    {
        public List<PairwiseComparison> Comparisons { get; set; } = new();
    }

    public class PairwiseComparisonMethod
    {
        public List<Option> Alternatives { get; set; }= new();
        public PairwiseComparisonMatrix ComparisonMatrix { get; set; }= new();

        public void AddAlternatives(IEnumerable<Option> options)
        {
            Alternatives.AddRange(options);
        }

        public void AddPairwiseComparison(Option alternativeA, Option alternativeB, double score)
        {
            var pair = new PairwiseComparison
            {
                AlternativeA = Alternatives.First(a => a.Id == alternativeA.Id),
                AlternativeB = Alternatives.First(a => a.Id == alternativeB.Id),
                Score = score
            };

            ComparisonMatrix.Comparisons.Add(pair);
        }

        public void CalculateScores()
        {
            foreach (var alternative in Alternatives)
            {
                alternative.Value = 1.0; // Ініціалізуємо значення оцінки альтернативи як 1.0
            }

            const double convergenceThreshold = 0.0001;
            double maxScoreChange;
            int iterationCount = 0;
            const int maxIterations = 1; // Встановлюємо максимальну кількість ітерацій

            do
            {
                maxScoreChange = 0.0;
                foreach (var pair in ComparisonMatrix.Comparisons)
                {
                    double pairwiseRatio = pair.Score;
                    pair.AlternativeA.Value *= pairwiseRatio;
                    pair.AlternativeB.Value /= pairwiseRatio;

                    // Оновлюємо мінімальну можливу оцінку, якщо одна з альтернатив отримала нуль
                    if (pair.AlternativeA.Value == 0)
                    {
                        pair.AlternativeA.Value = 0.0001;
                    }
                    if (pair.AlternativeB.Value == 0)
                    {
                        pair.AlternativeB.Value = 0.0001;
                    }

                    double scoreChange = Math.Abs(pairwiseRatio - 1.0);
                    if (scoreChange > maxScoreChange)
                    {
                        maxScoreChange = scoreChange;
                    }
                }

                iterationCount++;
            } while (maxScoreChange > convergenceThreshold && iterationCount < maxIterations);
        }
    }
}
