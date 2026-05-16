using System;
using System.IO;
using System.Collections.Generic;
using ex34.Entities;

HashSet<LogRecord> set = new HashSet<LogRecord>();

Console.Write("Enter file full path: ");
string path = Console.ReadLine()!;

try
{
    using (StreamReader sr = File.OpenText(path))
    {
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine()!;
            string[] fields = line.Split(' ');
            string username = fields[0];
            DateTime instant = DateTime.Parse(fields[1]);
            set.Add(new LogRecord { Username = username, Instant = instant });
        }
        Console.WriteLine("Total users: " + set.Count);
    }

}
catch (IOException e)
{
    Console.WriteLine("An error occurred:");
    Console.WriteLine(e.Message);
}