/*
    Problem 11. Adding polynomials
    Write a method that adds two polynomials.
    Represent them as arrays of their coefficients.
    Example:
    x2 + 5 = 1x2 + 0x + 5 => {5, 0, 1}
*/

namespace AddingPolynominals
{
    using System;

    public class PolynominalAdder
    {
        private static void Main()
        {
            Console.Write("Polynominal size: ");
            int n = int.Parse(Console.ReadLine());
            var firstPolynominalInd = new int[n];
            var secondPolynominalInd = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("P1: ");
                firstPolynominalInd[i] = int.Parse(Console.ReadLine());
                Console.Write("P2: ");
                secondPolynominalInd[i] = int.Parse(Console.ReadLine());
            }

            var result = AddPolynomial(firstPolynominalInd, firstPolynominalInd);

            Console.WriteLine("Result : { " + string.Join(", ", result) + " }");
        }

        private static int[] AddPolynomial(int[] firstPolynominalInd, int[] secondPolynominalInd)
        {
            var result = new int[firstPolynominalInd.Length];

            for (int i = 0; i < firstPolynominalInd.Length; i++)
            {
                result[i] = firstPolynominalInd[i] + secondPolynominalInd[i];
            }

            return result;
        }
    }
}