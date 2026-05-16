using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Enter file full path: ");
        string caminho = Console.ReadLine()!;

        Dictionary<string, int> votos = new Dictionary<string, int>();

        foreach (string linha in File.ReadAllLines(caminho))
        {
            if (string.IsNullOrWhiteSpace(linha)) continue;

            int ultimaVirgula = linha.LastIndexOf(',');
            string candidato = linha.Substring(0, ultimaVirgula).Trim();
            int quantidade = int.Parse(linha.Substring(ultimaVirgula + 1).Trim());

            if (votos.ContainsKey(candidato))
                votos[candidato] += quantidade;
            else
                votos[candidato] = quantidade;
        }

        foreach (var par in votos)
            Console.WriteLine($"{par.Key}: {par.Value}");
    }
}