/*
    Problem 2. Binary to decimal
    Write a program to convert binary numbers to their decimal representation. 
*/

namespace BinaryToDecimal
{
    using System;
    using System.Numerics;

    public class BinToDecConvertor
    {
        private static void Main()
        {
            string binaryString = Console.ReadLine();
            BigInteger number = 0;
            int length = binaryString.Length;

            for (int i = 0; i < length; i++)
            {
                if (binaryString[length - i - 1] == '0')
                {
                    continue;
                }

                number += (BigInteger)Math.Pow(2, i);
            }

            Console.WriteLine(number);
        }
    }
}