/*
    Problem 8. Prime Number Check
    Write an expression that checks if given positive integer number n (n ≤ 100) is prime (i.e. it is divisible 
    without remainder only to itself and 1).
*/

namespace PrimeNumberCheck
{
    using System;

    public class PrimeNumberChecker
    {
        public static void Main()
        {
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());

            if (number > 0)
            {
                if (number == 1)
                {
                    Console.WriteLine(false);
                }
                else
                {
                    int primeCount = 0;
                    bool isPrime = true;

                    for (int i = 1; i < number; i++)
                    {
                        if (number % i == 0)
                        {
                            primeCount++;
                        }
                    }

                    if (primeCount > 2)
                    {
                        isPrime = false;
                    }

                    Console.WriteLine($"{number} is prime? {isPrime}");
                }
            }
        }
    }
}