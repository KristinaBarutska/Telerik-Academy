/*
    Problem 4. Hexadecimal to decimal
    Write a program to convert hexadecimal numbers to their decimal representation.
*/

namespace HexadecimalToDecimal
{
    using System;
    using System.Numerics;

    public class HexToDecConvertor
    {
        private static void Main()
        {
            string hexString = Console.ReadLine();
            BigInteger number = 0;
            long count = hexString.Length - 1;

            for (int i = 0; i < hexString.Length; i++)
            {
                BigInteger temp = 0;

                switch (hexString[i])
                {
                    case 'A': temp = 10;
                        break;
                    case 'B': temp = 11;
                        break;
                    case 'C': temp = 12;
                        break;
                    case 'D': temp = 13;
                        break;
                    case 'E': temp = 14;
                        break;
                    case 'F': temp = 15;
                        break;
                    default: temp = -48 + (BigInteger)hexString[i];
                        break;
                }

                number += temp * (BigInteger)Math.Pow(16, count);
                count--;
            }

            Console.WriteLine(number);
        }
    }
}