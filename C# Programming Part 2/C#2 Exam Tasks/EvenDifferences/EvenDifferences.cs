namespace EvenDifferences
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class EvenDifferences
    {
        private static long[] sequence;

        public static void Main()
        {
            ReadInput();
            
            PrintResult();
        }

        private static void PrintResult()
        {
            BigInteger sumOfEvenDifferences = 0;

            for (int i = 1; i < sequence.Length; i++)
            {
                long currentDifference = Math.Abs(sequence[i] - sequence[i - 1]);

                if (currentDifference % 2 == 0)
                {
                    sumOfEvenDifferences += currentDifference;
                    i++;
                }
            }

            Console.WriteLine(sumOfEvenDifferences);
        }
        
        private static void ReadInput()
        {
            sequence = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();
        }
    }
}