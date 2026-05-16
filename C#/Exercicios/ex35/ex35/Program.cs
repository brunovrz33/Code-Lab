using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<int> Allstudents = new HashSet<int>();

        string[] cursos = { "A", "B", "C" };

        foreach (string curso in cursos)
        {
            Console.Write($"How many students for course {curso}? ");
            int n = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < n; i++)
            {
                int codigo = int.Parse(Console.ReadLine()!);
                Allstudents.Add(codigo);
            }
        }

        Console.WriteLine($"Total students: {Allstudents.Count}");
    }
}