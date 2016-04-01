/*
    Problem 10. Odd and Even Product
    You are given n integers (given in a single line, separated by a space).
    Write a program that checks whether the product of the odd elements is equal to the product of the even elements.
    Elements are counted from 1 to n, so the first element is odd, the second is even, etc.
*/

namespace OddAndEvenProduct
{
    using System;
    using System.Linq;

    public class OddAndEvenProduct
    {
        public static void Main()
        {
            Console.Write("Enter n numbers on a single line separated by space : ");
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(n => int.Parse(n))
                .ToArray();
            int oddProduct = CalcOddProduct(numbers);
            int evenProduct = CalcEvenProduct(numbers);

            if (evenProduct == oddProduct)
            {
                Console.WriteLine("yes");
                Console.WriteLine($"product={evenProduct}");
            }
            else
            {
                Console.WriteLine("no");
                Console.WriteLine($"odd_product={oddProduct}");
                Console.WriteLine($"even_product={evenProduct}");
            }
        }

        private static int CalcEvenProduct(int[] numbers)
        {
            int product = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 != 0)
                {
                    product *= numbers[i];
                }
            }

            return product;
        }

        private static int CalcOddProduct(int[] numbers)
        {
            int product = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    product *= numbers[i];
                }
            }

            return product;
        }
    }
}