/*
    Problem 15.* Bits Exchange
    Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
*/

namespace BitsExchange
{
    using System;

    public class ExchangeBits
    {
        public static void Main()
        {
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            int[] bits = GetBitsAsArray(number);

            Swap(ref bits[3], ref bits[24]);
            Swap(ref bits[4], ref bits[25]);
            Swap(ref bits[5], ref bits[26]);

            int resultNumber = GetNumberFromBitsArray(bits);

            Console.WriteLine($"Result: {resultNumber}");
        }

        private static int[] GetBitsAsArray(int number)
        {
            int[] bits = new int[32];

            for (int i = bits.Length - 1; i >= 0; i--)
            {
                bits[i] = (number >> i) & 1;
            }

            return bits;
        }

        private static int GetNumberFromBitsArray(int[] bits)
        {
            Array.Reverse(bits);
            string binaryString = string.Join(string.Empty, bits);
            int number = Convert.ToInt32(binaryString, 2);

            return number;
        }

        private static void Swap(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }
    }
}
