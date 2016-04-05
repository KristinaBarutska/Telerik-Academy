/* 
    Problem 3. Decimal to hexadecimal
    Write a program to convert decimal numbers to their hexadecimal representation. 
*/

namespace DecimalToHexadecimal
{
    using System;
    using System.Numerics;

    public class DecToHexConvertor
    {
        private static void Main()
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            string hexString = string.Empty;

            while (number != 0)
            {
                if (number % 16 < 10)
                {
                    hexString = (number % 16) + hexString;
                }
                else
                {
                    string temp = string.Empty;

                    switch ((long)number % 16)
                    {
                        case 10: temp = "A";
                            break;
                        case 11: temp = "B";
                            break;
                        case 12: temp = "C";
                            break;
                        case 13: temp = "D";
                            break;
                        case 14: temp = "E";
                            break;
                        case 15: temp = "F";
                            break;
                    }

                    hexString = temp + hexString;
                }

                number /= 16;
            }

            Console.WriteLine(hexString);
        }
    }
}