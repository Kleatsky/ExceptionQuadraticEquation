using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionQuadraticEquationConsole
{
    class FillingInteractionMenu
    {
        private static (int x, int y) cursorPosition = (0, 0);
        private static string[] coefficients = { null, null, null };

        public static (int a, int b, int c) FillInInteractionMenu()
        {
            int a = 0, b = 0, c = 0;
            cursorPosition.x = 4;
            cursorPosition.y = 0;
            ShowMenu();
            Interaction();

            int.TryParse(coefficients[0], out a);
            int.TryParse(coefficients[1], out b);
            int.TryParse(coefficients[2], out c);
            return (a, b, c);
        }
        private static void ShowMenu()
        {
            Console.CursorVisible = false;
            Console.Clear();
            if (!string.IsNullOrEmpty(coefficients[0])) Console.Write(coefficients[0] + " * x^2");
            else Console.Write("a * x^2");
            if (!string.IsNullOrEmpty(coefficients[1]))
            {
                if (coefficients[1][0] != '-')
                    Console.Write(" + " + coefficients[1] + " * x");
                else
                    Console.Write(" - " + coefficients[1].Substring(1) + " * x");
            }
            else Console.Write(" + a * x");
            if (!string.IsNullOrEmpty(coefficients[2]))
            {
                if (coefficients[2][0] != '-')
                    Console.Write(" + " + coefficients[2] + " = 0\n\n");
                else
                    Console.Write(" - " + coefficients[2].Substring(1) + " = 0\n\n");
            }
            else Console.Write(" + c = 0\n\n");



            if (cursorPosition.y == 0) Console.Write(">a: ");
            else Console.Write(" a: ");
            if (coefficients[0] != null) Console.Write(coefficients[0]);
            Console.WriteLine();

            if (cursorPosition.y == 1) Console.Write(">b: ");
            else Console.Write(" b: ");
            if (coefficients[1] != null) Console.Write(coefficients[1]);
            Console.WriteLine();

            if (cursorPosition.y == 2) Console.Write(">c: ");
            else Console.Write(" c: ");
            if (coefficients[2] != null) Console.Write(coefficients[2]);
            Console.WriteLine();
            int offset = string.IsNullOrEmpty(coefficients[cursorPosition.y]) ? 0 : coefficients[cursorPosition.y].Length;
            Console.SetCursorPosition(cursorPosition.x + offset, cursorPosition.y + 2);
        }

        private static void Interaction()
        {
            ConsoleKeyInfo keyInput = Console.ReadKey();
            while (keyInput.Key != ConsoleKey.Enter)
            {
                if (keyInput.Key == ConsoleKey.DownArrow && cursorPosition.y < 2) cursorPosition.y++;
                else if (keyInput.Key == ConsoleKey.UpArrow && cursorPosition.y > 0) cursorPosition.y--;
                else if (keyInput.Key >= ConsoleKey.D0 && keyInput.Key <= ConsoleKey.D9)
                {
                    IncreaseNumber(keyInput.Key - ConsoleKey.D0);
                }
                else if (keyInput.Key >= ConsoleKey.NumPad0 && keyInput.Key <= ConsoleKey.NumPad9)
                {
                    IncreaseNumber(keyInput.Key - ConsoleKey.NumPad0);
                }
                else if (keyInput.Key == ConsoleKey.Backspace)
                {
                    DecreaceNumber();
                }
                else if (keyInput.Key == ConsoleKey.Subtract)
                {
                    if (coefficients[cursorPosition.y] == null)
                        coefficients[cursorPosition.y] = "-";
                }

                ShowMenu();
                keyInput = Console.ReadKey();
            }

        }
        private static void IncreaseNumber(int digit)
        {
            if (coefficients[cursorPosition.y] == null)
            {
                coefficients[cursorPosition.y] = digit.ToString();
            }
            else if (coefficients[cursorPosition.y] == "-")
            {
                if (digit != 0) coefficients[cursorPosition.y] += digit.ToString();
            }
            else if (coefficients[cursorPosition.y].Length < 6)
            {
                if (coefficients[cursorPosition.y] != "0")
                    coefficients[cursorPosition.y] += digit.ToString();
            }
        }
        private static void DecreaceNumber()
        {
            if (coefficients[cursorPosition.y] != null)
            {
                if (coefficients[cursorPosition.y].Length == 1)
                {
                    coefficients[cursorPosition.y] = null;
                }
                else if (coefficients[cursorPosition.y].Length > 1)
                {
                    coefficients[cursorPosition.y] = coefficients[cursorPosition.y].Substring(0, coefficients[cursorPosition.y].Length - 1);
                }
            }
        }
    }
}
