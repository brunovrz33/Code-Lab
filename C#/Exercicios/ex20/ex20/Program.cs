int n = int.Parse(Console.ReadLine()!);

string[,] matrix = new string[n, n];
for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()!.Split(' ');
    for (int j = 0; j < n; j++)
    {
        matrix[i, j] = input[j];
    }
}
Console.WriteLine("Main Diagonal: ");
for (int i = 0; i < n; i++)
{
    Console.Write(matrix[i, i] + " ");
}
Console.WriteLine();

int countNegative = 0;
for (int i = 0; i < n; i++) {
    for (int j = 0; j < n; j++) {
        if (int.TryParse(matrix[i, j], out int value) && value < 0) {
            countNegative++;
        }
    }
}
Console.WriteLine("Negative Numbers: " + countNegative);