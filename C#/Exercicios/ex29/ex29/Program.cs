using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite o caminho do arquivo CSV: ");
        string inputPath = Console.ReadLine()!.Trim();

        if (string.IsNullOrEmpty(inputPath) || !File.Exists(inputPath))
        {
            Console.WriteLine("Arquivo não encontrado.");
            return;
        }

        string? inputDir = Path.GetDirectoryName(Path.GetFullPath(inputPath));
        if (inputDir == null)
        {
            Console.WriteLine("Não foi possível determinar o diretório do arquivo.");
            return;
        }

        string outputDir = Path.Combine(inputDir, "out");
        Directory.CreateDirectory(outputDir);
        string outputPath = Path.Combine(outputDir, "summary.csv");

        string[] lines = File.ReadAllLines(inputPath);

        using StreamWriter writer = new StreamWriter(outputPath);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(',');

            if (parts.Length < 3) continue;

            string name = parts[0].Trim();

            if (!decimal.TryParse(parts[1].Trim(), System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal unitPrice))
                continue;

            if (!int.TryParse(parts[2].Trim(), out int quantity))
                continue;

            decimal total = unitPrice * quantity;
            writer.WriteLine($"{name},{total:F2}");
        }

        Console.WriteLine($"Arquivo gerado com sucesso: {outputPath}");
    }
}