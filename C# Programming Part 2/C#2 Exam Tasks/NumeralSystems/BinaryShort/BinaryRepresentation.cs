/*
    Problem 8. Binary short
    Write a program that shows the binary representation of given 16-bit signed 
    integer number (the C# type short). 
*/

namespace BinaryShort
{
    using System;

    public class BinaryRepresentation
    {
        private static void Main()
        {
            short number = short.Parse(Console.ReadLine());
            int[] bitRepresentation = new int[16];

            for (int i = 0; i < 16; i++)
            {
                bitRepresentation[i] = (number >> i) & 1;
            }

            Array.Reverse(bitRepresentation);

            Console.WriteLine(string.Join(string.Empty, bitRepresentation));
        }
    }
}