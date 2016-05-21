/* 
    Problem 5. Hexadecimal to binary
    Write a program to convert hexadecimal numbers to binary numbers (directly).
*/

namespace HexadecimalToBinary
{
    using System;

    public class HexToBin
    {
        private static void Main()
        {
            string hexString = Console.ReadLine();
            string binaryString = Convert.ToString(Convert.ToInt32(hexString, 16), 2);

            Console.WriteLine(binaryString);
        }
    }
}