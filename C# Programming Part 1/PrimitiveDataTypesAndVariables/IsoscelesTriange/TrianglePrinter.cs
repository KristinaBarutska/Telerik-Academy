/*
    Problem 8. Isosceles Triangle
    Write a program that prints an isosceles triangle of 9 copyright symbols ©, something like this:
       ©
    
      © ©
    
     ©   ©
    
    © © © ©
*/

namespace IsoscelesTriange
{
    using System;
    using System.Text;

    public class TrianglePrinter
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            char copyrightSymbol = '\u00a9';

            PrintTriangle(copyrightSymbol);
        }

        private static void PrintTriangle(char symbol)
        {
            Console.WriteLine(symbol.ToString().PadLeft(4));
            Console.WriteLine((symbol + " " + symbol).PadLeft(5));
            Console.WriteLine((symbol + "   " + symbol).PadLeft(6));
            Console.WriteLine("{0} {1} {2} {3}", symbol, symbol, symbol, symbol);
        }
    }
}