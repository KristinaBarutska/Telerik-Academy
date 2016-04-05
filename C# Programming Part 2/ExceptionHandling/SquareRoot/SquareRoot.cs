/* 
    Problem 1. Square root
    Write a program that reads an integer number and calculates and prints its square root.
    If the number is invalid or negative, print Invalid number.
    In all cases finally print Good bye.
    Use try-catch-finally block. 
*/

namespace SquareRoot
{
    using System;

    public class SquareRoot
    {
        public static void Main()
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                double squareRoot = CalculateSquareRoot(number);

                Console.WriteLine($"The square root of {number} is {squareRoot}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number: The entered format is invalid.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number: The number is too big");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Good bye.");
            }
        }

        private static double CalculateSquareRoot(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Invalid number: The number is negative.");
            }

            return Math.Sqrt(number);
        }
    }
}