/*
    Problem 6. Binary to hexadecimal
    Write a program to convert binary numbers to hexadecimal numbers (directly).
*/

namespace BinaryToHexadecimal
{
    using System;

    public class BinToHexConvertor
    {
        private static void Main()
        {
            string binaryString = Console.ReadLine();
            string hexString = Convert.ToString(Convert.ToInt32(binaryString, 2), 16);

            Console.WriteLine(hexString.ToUpper());
        }
    }
}