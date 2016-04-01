/*
    Problem 16. Decimal to Hexadecimal Number
    Using loops write a program that converts an integer number to its hexadecimal representation.
    The input is entered as long. The output should be a variable of type string.
    Do not use the built-in .NET functionality.
*/

namespace DecimalToHexadecimal
{
    using System;

    public class DecToHex
    {
        public static void Main()
        {
            Console.Write("Enter an integer : ");
            long decimalNum = long.Parse(Console.ReadLine());
            string hexNum = string.Empty;
            string character = string.Empty;
            long result = 0;
            long quotient = 1;

            while (quotient != 0)
            {
                result = decimalNum % 16;
                quotient = decimalNum / 16;
                character = DeterminationNumber(result);
                hexNum += character;
                decimalNum = quotient;
            }

            char[] valueChars = hexNum.ToCharArray();
            Array.Reverse(valueChars);

            for (int i = 0; i < hexNum.Length; i++)
            {
                Console.Write("{0}", valueChars[i]);
            }

            Console.WriteLine();
        }

        private static string DeterminationNumber(long number)
        {
            string str = string.Empty;
            switch (number)
            {
                case 10:
                    str = "A";
                    break;
                case 11:
                    str = "B";
                    break;
                case 12:
                    str = "C";
                    break;
                case 13:
                    str = "D";
                    break;
                case 14:
                    str = "E";
                    break;
                case 15:
                    str = "F";
                    break;
                default:
                    str = number.ToString();
                    break;
            }

            return str;
        }
    }
}