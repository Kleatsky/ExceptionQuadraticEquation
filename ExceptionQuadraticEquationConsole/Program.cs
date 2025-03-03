namespace ExceptionQuadraticEquationConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (int a, int b, int c) coefficients = FillingInteractionMenu.FillInInteractionMenu();
            SolveQuadraticEquation solveQuadraticEquation = new 
                SolveQuadraticEquation(coefficients.a, coefficients.b, coefficients.c);
            solveQuadraticEquation.ShowEquation();
            solveQuadraticEquation.Solve();
            //SolveQuadraticEquation solveQuadraticEquation = new SolveQuadraticEquation();
            //int a;
            //int.TryParse("-2",out a);
            //Console.WriteLine(a);

            Console.WriteLine("Hello, World!");
        }
    }
}
