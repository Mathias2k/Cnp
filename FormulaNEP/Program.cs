namespace NEP
{
    /// <summary>
    /// combinações - C n,p
    /// FORMULA: n!/p!*(n-p)!
    /// </summary>
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("C n,p\n");

            Console.Write("Número total de combinações:");
            int combinacoes = int.Parse(s: Console.ReadLine());
            Console.Write("Número de tomadas:");
            int tomadas = int.Parse(s: Console.ReadLine());

            await Task.Run(() =>
            {
                decimal resultadoNEP = 1 / NEP(combinacoes, tomadas) ;
                Console.WriteLine($"\nProbabilidade de acerto é de {Math.Round(resultadoNEP,12)}%");
            });

            Console.WriteLine("\nPress any key to continue...:");
            Console.ReadLine();

            await Main();
        }
        private static long Factorial(int number, int? anula)
        {
            long fact;

            if (anula.HasValue)
                if (number == anula.Value)
                    return 1;

            fact = number;
            for (int i = number - 1; i >= 1; i--)
            {
                if (anula.HasValue)
                    if (i == anula.Value)
                        return fact;
                fact *= i;
            }

            return fact;
        }
        private static decimal NEP(int n, int p)
        {
            decimal resultadoNEP;

            resultadoNEP = Factorial(n, n - p)
                            / Factorial(p, anula: null) * Factorial(n - p, n - p);

            return resultadoNEP;
        }
    }
}