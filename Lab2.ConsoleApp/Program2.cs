namespace Lab2.ConsoleApp;

static class Program2
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Risk Assessment Survey!");
        Console.WriteLine("Please answer the following questions to help us determine the level of risk in your area.");

        // Questions
        Console.WriteLine("1. Have there been any recent natural disasters in your area? (Yes/No)");
        string q1 = Console.ReadLine().ToLower();
        Console.WriteLine("2. Are there any hazardous materials or waste sites near your area? (Yes/No)");
        string q2 = Console.ReadLine().ToLower();
        Console.WriteLine("3. Is your area prone to crime or violence? (Yes/No)");
        string q3 = Console.ReadLine().ToLower();
        Console.WriteLine("4. Are there any health hazards in your area, such as pollution or disease outbreaks? (Yes/No)");
        string q4 = Console.ReadLine().ToLower();

        // Risk Assessment
        int riskLevel = 0;

        if (q1 == "yes")
            riskLevel += 2;

        if (q2 == "yes")
            riskLevel += 3;

        if (q3 == "yes")
            riskLevel += 4;

        if (q4 == "yes")
            riskLevel += 2;

        Console.WriteLine("Based on your answers, the level of risk in your area is: " + riskLevel);

        // Expert Opinion Assessment
        Console.WriteLine("Please provide your expert opinion on the level of risk in this area (1-10):");
        int expertOpinion = int.Parse(Console.ReadLine());

        // Pairwise Comparison Method
        Console.WriteLine("We will now use the Pairwise Comparison Method to compare your expert opinion with the survey results.");

        double[] weights = { 0.5, 0.3, 0.2, 0.1 };// weights for each question
        double[] surveyResults = { 2, 3, 4, 2 };// survey results for each question
        double[] pairwiseComparison = new double[4];// pairwise comparison results

        for (int i = 0; i < pairwiseComparison.Length; i++)
        {
            pairwiseComparison[i] = expertOpinion / surveyResults[i];
        }

        double weightedSum = 0;

        for (int i = 0; i < weights.Length; i++)
        {
            weightedSum += weights[i] * pairwiseComparison[i];
        }

        Console.WriteLine("Based on the Pairwise Comparison Method, the overall level of risk in your area is: " + weightedSum);
    }
}
