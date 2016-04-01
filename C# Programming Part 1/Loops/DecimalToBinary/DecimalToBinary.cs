/*
    Problem 14. Decimal to Binary Number
    Using loops write a program that converts an integer number to its binary representation.
    The input is entered as long. The output should be a variable of type string.
    Do not use the built-in .NET functionality.
*/

namespace DecimalToBinary
{
    using System;

    public class DecimalToBinary
    {
        public static void Main()
        {
            Console.Write("Enter an integer : ");
            long decimalNum = long.Parse(Console.ReadLine());
            string binary = string.Empty;
            long result = 0;
            long quotient = 1;

            while (quotient != 0)
            {
                result = decimalNum % 2;
                quotient = decimalNum / 2;
                binary += result.ToString();
                decimalNum = quotient;
            }

            char[] valueChars = binary.ToCharArray();
            Array.Reverse(valueChars);

            for (int i = 0; i < binary.Length; i++)
            {
                Console.Write("{0}", valueChars[i]);
            }
        }
    }
}