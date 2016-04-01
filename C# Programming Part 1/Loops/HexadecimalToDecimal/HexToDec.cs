/*
    Problem 15. Hexadecimal to Decimal Number
    Using loops write a program that converts a hexadecimal integer number to its decimal form.
    The input is entered as string. The output should be a variable of type long.
    Do not use the built-in .NET functionality.
*/

namespace HexadecimalToDecimal
{
    using System;

    public class HexToDec
    {
        public static void Main()
        {
            Console.Write("Enter hexadecimal integer : ");
            string hexadecimal = Console.ReadLine();
            int num = 0;
            long hexNum = 0;
            long degree = hexadecimal.Length - 1;

            for (int i = 0; i < hexadecimal.Length; i++)
            {
                char ch = hexadecimal[i];
                switch (ch.ToString())
                {
                    case "A":
                        num = 10;
                        break;
                    case "B":
                        num = 11;
                        break;
                    case "C":
                        num = 12;
                        break;
                    case "D":
                        num = 13;
                        break;
                    case "E":
                        num = 14;
                        break;
                    case "F":
                        num = 15;
                        break;
                    default:
                        num = Convert.ToInt32(ch.ToString());
                        break;
                }

                hexNum += num * (long)Math.Pow(16, degree);
                degree--;
            }

            Console.WriteLine(hexNum);
        }
    }
}