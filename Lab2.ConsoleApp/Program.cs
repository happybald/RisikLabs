using Lab2.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Text;
namespace Lab2.ConsoleApp;

class Program
{
    static async Task Main(string[] args)
    {

        await using var context = new EntityContext();
        await context.Database.MigrateAsync();
        var survey = context.Surveys.Include(q => q.Questions).ThenInclude(o => o.Options).First();
        Console.OutputEncoding = Encoding.UTF8;
        foreach (var question in survey.Questions)
        {
            var method = new PairwiseComparisonMethod();
            method.AddAlternatives(question.Options);
            Console.WriteLine($"Питання {question.Text}");
            // Список альтернатив, які потрібно оцінити
            // Проходимо по кожній парі альтернатив і отримуємо оцінки від користувача
            for (int i = 0; i < question.Options.Count; i++)
            {
                for (int j = i + 1; j < question.Options.Count; j++)
                {
                    Console.WriteLine($"Виберіть варіант: ");
                    Console.WriteLine($"1. {question.Options[i].Text} переважає {question.Options[j].Text}");
                    Console.WriteLine($"2. {question.Options[j].Text} переважає {question.Options[i].Text}");
                    Console.WriteLine($"3. {question.Options[i].Text} та {question.Options[j].Text} мають однакову вагу");
                    int choice;
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Incorrect, please try again.");
                    }

                    // Зберігаємо оцінку у словник
                    if (choice == 1)
                    {
                        method.AddPairwiseComparison(question.Options[i], question.Options[j], 5);
                    }
                    else if (choice == 2)
                    {
                        method.AddPairwiseComparison(question.Options[j], question.Options[i], 5);
                    }
                    else if (choice == 3)
                    {
                        method.AddPairwiseComparison(question.Options[i], question.Options[j], 1);
                    }
                }
            }
            // Розрахувати оцінки
            method.CalculateScores();

            foreach (var alternative in method.Alternatives)
            {
                Console.WriteLine($"{alternative.Text}: {alternative.Value}");
            }
            Console.WriteLine($"MVP: {method.Alternatives.MaxBy(v=>v.Value).Text}");

        }
    }
}
