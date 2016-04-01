/*
    Problem 1. Exchange If Greater
    Write an if-statement that takes two double variables a and b and exchanges their values if the 
    first one is greater than the second one. As a result print the values a and b, separated by a space.
*/

namespace ExchangeIfGreater
{
    using System;

    public class ExchangeIfGreater
    {
        public static void Main()
        {
            Console.Write("First number: ");
            double firstNumber = double.Parse(Console.ReadLine());
            Console.Write("Second number: ");
            double secondNumber = double.Parse(Console.ReadLine());

            if (firstNumber > secondNumber)
            {
                Swap(ref firstNumber, ref secondNumber);
            }

            Console.WriteLine(firstNumber + " " + secondNumber);
        }

        private static void Swap(ref double firstNumber, ref double secondNumber)
        {
            double valueHolder = firstNumber;
            firstNumber = secondNumber;
            secondNumber = valueHolder;
        }
    }
}