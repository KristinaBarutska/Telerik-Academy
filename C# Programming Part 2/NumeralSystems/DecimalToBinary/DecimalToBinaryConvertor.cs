/* 
    Problem 1. Decimal to binary
    Write a program to convert decimal numbers to their binary representation. 
*/

namespace DecimalToBinary
{
    using System;
    using System.Numerics;

    public class DecimalToBinaryConvertor
    {
        private static void Main()
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            string binaryString = string.Empty;
            BigInteger reminder = 0;

            while (number > 0)
            {
                reminder = number % 2;
                number /= 2;
                binaryString = reminder.ToString() + binaryString;
            }

            Console.WriteLine(binaryString);
        }
    }
}