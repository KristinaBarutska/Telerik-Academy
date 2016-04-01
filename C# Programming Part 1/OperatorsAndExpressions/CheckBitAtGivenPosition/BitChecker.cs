/*
    Problem 13. Check a Bit at Given Position
    Write a Boolean expression that returns if the bit at position p (counting from 0, starting 
    from the right) in given integer number n, has value of 1.
*/

namespace CheckBitAtGivenPosition
{
    using System;

    public class BitChecker
    {
        public static void Main()
        {
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Position: ");
            int position = int.Parse(Console.ReadLine());
            bool isOne = ((number >> position) & 1) == 1;

            Console.WriteLine($"Is the bit on position {position} == 1 ? {isOne}");
        }
    }
}