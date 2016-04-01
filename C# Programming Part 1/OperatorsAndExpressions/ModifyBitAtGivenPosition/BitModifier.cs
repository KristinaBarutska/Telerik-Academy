/*
    Problem 14. Modify a Bit at Given Position
    We are given an integer number n, a bit value v (v=0 or 1) and a position p.
    Write a sequence of operators (a few lines of C# code) that modifies n to hold the value v at the position
    p from the binary representation of n while preserving all other bits in n.
*/

namespace ModifyBitAtGivenPosition
{
    using System;

    public class BitModifier
    {
        public static void Main()
        {
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Position: ");
            int position = int.Parse(Console.ReadLine());
            Console.Write("Bit value: ");
            int value = int.Parse(Console.ReadLine());
                        int[] bits = GetBitsAsArray(number);

            bits[position] = value;

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
    }
}