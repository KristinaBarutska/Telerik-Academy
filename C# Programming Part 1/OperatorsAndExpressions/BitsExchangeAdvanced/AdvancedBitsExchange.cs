/*
    Problem 16.** Bit Exchange (Advanced)
    Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.
    The first and the second sequence of bits may not overlap.
*/

namespace BitsExchangeAdvanced
{
    using System;

    public class AdvancedBitsExchange
    {
        public static void Main()
        {
            Console.Write("Number: ");
            uint number = uint.Parse(Console.ReadLine());
            Console.Write("P: ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Q: ");
            int q = int.Parse(Console.ReadLine());
            Console.Write("K: ");
            int k = int.Parse(Console.ReadLine());
            uint[] bits = GetBitsAsArray(number);

            SwapBits(ref bits, p, q, k);

            int resultNumber = GetNumberFromBitsArray(bits);

            Console.WriteLine($"Result: {resultNumber}");
        }

        private static uint[] GetBitsAsArray(uint number)
        {
            uint[] bits = new uint[32];

            for (int i = bits.Length - 1; i >= 0; i--)
            {
                bits[i] = (number >> i) & 1;
            }

            return bits;
        }

        private static int GetNumberFromBitsArray(uint[] bits)
        {
            Array.Reverse(bits);
            string binaryString = string.Join(string.Empty, bits);
            int number = Convert.ToInt32(binaryString, 2);

            return number;
        }

        private static void SwapBits(ref uint[] bits, int p, int q, int k)
        {
            for (int i = 0; i < k; i++)
            {
                Swap(ref bits[p + i], ref bits[q + i]);
            }           
        }

        private static void Swap(ref uint a, ref uint b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }
    }
}