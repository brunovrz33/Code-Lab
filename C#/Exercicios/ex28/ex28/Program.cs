using System.IO;
using System;

string path = @"C:\Documentos\test.txt";

StreamReader? sr = null;
try
{
    sr = File.OpenText(path);
    while (!sr.EndOfStream)
    {
        string line = sr.ReadLine()!;
        Console.WriteLine(line);
    }
}
catch (IOException e)
{
    Console.WriteLine("An error occurred: ");
    Console.WriteLine(e.Message);
}
finally
{
    if (sr != null) sr.Close();
}