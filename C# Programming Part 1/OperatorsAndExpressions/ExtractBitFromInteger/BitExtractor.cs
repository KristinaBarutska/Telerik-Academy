/*
    Problem 12. Extract Bit from Integer
    Write an expression that extracts from given integer n the value of given bit at index p.
*/

namespace ExtractBitFromInteger
{
    using System;

    public class BitExtractor
    {
        public static void Main()
        {
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Position: ");
            int position = int.Parse(Console.ReadLine());
            int resultBit = (number >> position) & 1;

            Console.WriteLine($"The bit on position {position} is {resultBit}");
        }
    }
}