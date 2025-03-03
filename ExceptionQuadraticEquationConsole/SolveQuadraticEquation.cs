using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionQuadraticEquationConsole
{
    class SolveQuadraticEquation
    {
        private class InvalideInputException : Exception
        {
            public InvalideInputException() : base()
            { }
            public InvalideInputException(string message) : base(message)
            { }
        }

        private class DiscriminantBelowZero : Exception
        {
            public DiscriminantBelowZero() : base()
            { }
            public DiscriminantBelowZero(string message) : base(message)
            { }
        }
        private int a, b, c, d;
        private enum Severity
        {
            Warning,
            Error
        }

        public SolveQuadraticEquation()
        {
            Console.WriteLine("a * x^2 + b * x + c = 0");
            bool correctFill = false;
            do
            {
                correctFill = FillCoefficient();
            }
            while (!correctFill);
            ShowEquation();
        }
        public SolveQuadraticEquation(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        private bool FillCoefficient()
        {
            Console.WriteLine("Please input the value of coefficient a:");
            string tempCoefficientA = Console.ReadLine();
            Console.WriteLine("Please input the value of coefficient b:");
            string tempCoefficientB = Console.ReadLine();
            Console.WriteLine("Please input the value of coefficient c:");
            string tempCoefficientC = Console.ReadLine();

            bool correctInput;
            try
            {
                correctInput = int.TryParse(tempCoefficientA, out a);
                if (!correctInput) throw new InvalideInputException(tempCoefficientA + " is not a number!");
                if (a == 0) throw new InvalideInputException("Coefficient a can't be 0!");

                correctInput = int.TryParse(tempCoefficientB, out b);
                if (!correctInput) throw new InvalideInputException(tempCoefficientB + " is not a number!");

                correctInput = int.TryParse(tempCoefficientC, out c);
                if (!correctInput) throw new InvalideInputException(tempCoefficientC + " is not a number!");
            }
            catch (InvalideInputException ex)
            {
                ex.Data.Add("a", tempCoefficientA);
                ex.Data.Add("b", tempCoefficientB);
                ex.Data.Add("c", tempCoefficientC);
                FormatData(ex.Message, Severity.Error, ex.Data);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }
        private void FormatData(string message, Severity severity, IDictionary data)
        {
            if (severity == Severity.Error)
            {
                var tempConsoleBackgroundColor = Console.BackgroundColor;
                var tempConsoleForegroundColor = Console.ForegroundColor;

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("--------------------------------------------------");//50 char
                Console.WriteLine(message);
                Console.WriteLine("--------------------------------------------------");//50 char

                foreach (DictionaryEntry item in data)
                {
                    Console.WriteLine(item.Key + "  = " + item.Value);
                }

                Console.BackgroundColor = tempConsoleBackgroundColor;
                Console.ForegroundColor = tempConsoleForegroundColor;
            }
            else
            {
                var tempConsoleBackgroundColor = Console.BackgroundColor;
                var tempConsoleForegroundColor = Console.ForegroundColor;

                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;

                Console.WriteLine("--------------------------------------------------");//50 char
                Console.WriteLine(message);
                Console.WriteLine("--------------------------------------------------");//50 char

                foreach (DictionaryEntry item in data)
                {
                    Console.WriteLine(item.Key + "  = " + item.Value);
                }

                Console.BackgroundColor = tempConsoleBackgroundColor;
                Console.ForegroundColor = tempConsoleForegroundColor;
            }
        }

        public void Solve()
        {
            try
            {
                d = (b * b) - 4 * a * c;
                if (d > 0)
                {
                    double x1, x2;
                    x1 = (-b + Math.Sqrt(d)) / 2 / a;
                    x2 = (-b - Math.Sqrt(d)) / 2 / a;
                    Console.WriteLine("x1 = " + x1 + " x2 = " + x2);
                }
                else if (d == 0)
                {
                    double x = -b / 2 / a;
                    Console.WriteLine("x = " + x);
                }
                else
                {
                    throw new DiscriminantBelowZero("Вещественных значений не найдено");
                }
            }
            catch (DiscriminantBelowZero ex)
            {
                FormatData(ex.Message, Severity.Warning, ex.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowEquation()
        {
            if (a != 0) Console.Write(a + " * x^2");
            if (a != 0 && b != 0) Console.Write(" + ");
            if (b != 0) Console.Write(b + " * x");
            if ((a != 0 || b != 0) && c != 0) Console.Write(" + ");
            if (c != 0) Console.Write(c);
            if (a != 0 || b != 0 || c != 0) Console.Write(" = 0\n");
            else Console.WriteLine("All coefficients are 0");
        }
    }
}
