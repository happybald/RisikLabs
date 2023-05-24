using Spectre.Console;
using Spectre.Console.Rendering;
using System.Text;
namespace Lab3.ConsoleApp;

abstract class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        AnsiConsole.Write(
        new FigletText("Lab 3")
            .LeftJustified()
            .Color(Color.Red));


        double weight = 30000;

        // Визначення рівнів впливу						
        double[] influence = { 0.05, 0.5, 1, 5, 20 };
        bool isProbability = true;
        double[] probabilityOrCount = { 0.5, 1, 10, 20, 50 };

        double low = 0.01;
        double high = 0.15;

        double lowWeight = Math.Round(weight / 100 * low, 2);
        double highWeight = Math.Round(weight / 100 * high, 2);

        double[] xArray = influence.Select(v => Math.Round(weight / 100 * v, 2)).ToArray();
        double[] yArray = probabilityOrCount;


        double[,] result = new double[xArray.Length, yArray.Length];

        for (int i = 0; i < xArray.Length; i++)
        {
            for (int j = 0; j < yArray.Length; j++)
            {
                if (isProbability)
                    result[i, j] = xArray[i] / 100 * yArray[j];
                else
                    result[i, j] = xArray[i] * yArray[j];

                result[i, j] = Math.Round(result[i, j], 2);
            }
        }


        var table = new Table();
        table.Title = new TableTitle("Визначення рівнів впливу");
        table.AddColumns(Enumerable.Range(1, influence.Length).Select(v => new TableColumn($"{v}")).ToArray());
        table.AddRow(influence.Select(v => $"{v}%").ToArray());
        AnsiConsole.Write(table);

        AnsiConsole.Write("Кількість інцидентів на рік або Ймовірність інциденту?\n");
        AnsiConsole.Write(new Markup("[green]" + (isProbability ? "Ймовірність інциденту" : "Кількість інцидентів") + "[/]\n"));

        table = new Table();
        table.Title = new TableTitle("Рівні ймовірності");
        table.AddColumns(Enumerable.Range(1, probabilityOrCount.Length).Select(v => new TableColumn($"{v}")).ToArray());
        table.AddRow(probabilityOrCount.Select(v => isProbability ? $"{v}%" : $"{v}").ToArray());
        AnsiConsole.Write(table);

        table = new Table();
        table.Title = new TableTitle("Порогові значення низького / середнього / високого ризику");
        table.AddColumns("", "Частка у загальних викидах", "Поріг");
        table.AddRow("Поріг низького ризику", $"{low}%", $"{lowWeight:F2}");
        table.AddRow("Поріг високого ризику", $"{high}%", $"{highWeight:F2}");
        AnsiConsole.Write(table);

        table = new Table();
        table.Title = new TableTitle("Матриця ризиків");
        table.AddColumn("Ймовірність");
        table.AddColumn("Вплив");
        for (int i = 0; i < yArray.Length; i++)
            table.AddColumn($"{i + 1}");

        var rowTexts = new List<IRenderable>();
        rowTexts.Add(new Text(""));
        rowTexts.Add(new Text(""));
        for (int j = 0; j < xArray.Length; j++)
            rowTexts.Add(new Text($"{xArray[j]}"));

        table.AddRow(rowTexts);

        for (int j = 0; j < xArray.Length; j++)
        {
            rowTexts = new List<IRenderable>();
            rowTexts.Add(new Text($"{j + 1}"));
            rowTexts.Add(new Text($"{yArray[j]}"));
            for (int i = 0; i < yArray.Length; i++)
            {
                rowTexts.Add(GetValueCell(result[i, j]));
            }
            table.AddRow(rowTexts);
        }
        AnsiConsole.Write(table);

        Text GetValueCell(double value)
        {
            if (value < lowWeight)
                return new Text($"{value:F2}", new Style(Color.Black, Color.LightGreen));
            if (value < highWeight)
                return new Text($"{value:F2}", new Style(Color.Black, Color.Yellow));

            return new Text($"{value:F2}", new Style(Color.Black, Color.Red1));

        }

        Console.ReadLine();
    }
}
