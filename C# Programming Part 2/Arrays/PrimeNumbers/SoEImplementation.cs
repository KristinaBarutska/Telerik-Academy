/*  
    Problem 15. Prime numbers
    Write a program that finds all prime numbers in the range [1...10 000 000]. 
    Use the Sieve of Eratosthenes algorithm. 
*/

namespace PrimeNumbers
{
    using System;

    public class SoEImplementation
    {
        private static void Main()
        {
            bool[] sieve = MakeSieve(10000000);

            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i])
                {
                    Console.Write("{0} ", i);
                }
            }
        }

        private static bool[] MakeSieve(int max)
        {
            bool[] isPrime = new bool[max];

            for (int i = 0; i < isPrime.Length; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 2; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * 2; j < isPrime.Length; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            return isPrime;
        }
    }
}