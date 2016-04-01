/*
    Problem 11. Bitwise: Extract Bit #3
    Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer.
    The bits are counted from right to left, starting from bit #0.
    The result of the expression should be either 1 or 0.
*/

namespace ExtractThirdBit
{
    using System;

    public class BitExtractor
    {
        public static void Main()
        {
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            int position = 3;
            int thirdBit = (number >> position) & 1;

            Console.WriteLine($"Third bit: {thirdBit}");
        }
    }
}