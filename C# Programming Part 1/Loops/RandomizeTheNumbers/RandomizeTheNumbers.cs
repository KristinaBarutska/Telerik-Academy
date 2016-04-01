/*
    Problem 12.* Randomize the Numbers 1…N
    Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.
*/

namespace RandomizeTheNumbers
{
    using System;
    using System.Collections.Generic;

    public class RandomizeTheNumbers
    {
        public static void Main()
        {
            Console.Write("n : ");
            int n = int.Parse(Console.ReadLine());
            Random randomNumber = new Random();
            IList<int> numbers = new List<int>();

            while (numbers.Count < n)
            {
                for (int i = 1; i <= n; i++)
                {
                    int currentRandom = randomNumber.Next(1, n + 1);

                    if (!numbers.Contains(currentRandom))
                    {
                        numbers.Add(currentRandom);
                    }
                }
            }

            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}