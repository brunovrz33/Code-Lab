namespace ex14
{
    internal class Aluno
    {
        public string Nome;
        public double Nota1;
        public double Nota2;
        public double Nota3;

        public double CalcularNotaFinal()
        {
            return Nota1 + Nota2 + Nota3;
        }

        public string VerificarAprovacao()
        {
            if (CalcularNotaFinal() >= 60.0)
            {
                return "APROVADO";
            }
            else
            {
                return "REPROVADO";
            }
        }

        public double PontosFaltando()
        {
            if (CalcularNotaFinal() >= 60.0)
            {
                return 0.0;
            }
            else
            {
                return 60.0 - CalcularNotaFinal();
            }
        }
    }
}