/*
    Problem 11. Format number
    Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation.
    Format the output aligned right in 15 symbols.
*/

namespace FormatNumber
{
    public class FormatNumber
    {
        public static void Main()
        {
            int number = 254;
            string numberToHex = number.ToString("X");
            string numberToPercent = number.ToString("P2");
            string numberToScientificNotation = number.ToString("E");

            System.Console.WriteLine(numberToHex.PadLeft(15));
            System.Console.WriteLine(numberToPercent.PadLeft(15));
            System.Console.WriteLine(numberToScientificNotation.PadLeft(15));
        }
    }
}