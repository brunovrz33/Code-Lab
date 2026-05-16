namespace ex16;

public static class ConversorDeMoeda
{
    private const double IOF = 0.06;

    public static double Converter(double cotacao, double dolares)
        => cotacao * dolares * (1 + IOF);
}