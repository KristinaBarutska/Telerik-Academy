/*
    Problem 2. Random numbers
    Write a program that generates and prints to the console 10 random values in the range [100, 200]. 
*/

namespace RandomGenerator
{
    using System;

    public class RandomGenerator
    {
        private static void Main()
        {
            var rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                var currentNumber = rnd.Next(100, 201);
                Console.Write($"{currentNumber} ");
            }

            Console.WriteLine();
        }
    }
}