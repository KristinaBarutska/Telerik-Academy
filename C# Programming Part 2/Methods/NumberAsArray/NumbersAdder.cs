/* 
    Problem 8. Number as array
    Write a method that adds two positive integer numbers represented as 
    arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
    Each of the numbers that will be added could have up to 10 000 digits. 
*/

namespace NumberAsArray
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class NumbersAdder
    {
        private static void Main()
        {
            Console.Write("First number: ");
            BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
            Console.Write("Second number: ");
            BigInteger secondNumber = BigInteger.Parse(Console.ReadLine());
            var finalNumber = AddNumbers(firstNumber, secondNumber);

            Console.WriteLine(finalNumber);
        }

        private static string AddNumbers(BigInteger firstNumber, BigInteger secondNumber)
        {
            var firstNumAsArray = ConvertNumberToArray(firstNumber);
            var secondNumAsArray = ConvertNumberToArray(secondNumber);
            var summedNumber = string.Empty;
            BigInteger reminder = 0;

            for (int i = 0; i < secondNumAsArray.Length; i++)
            {
                summedNumber += (((firstNumAsArray[i] + secondNumAsArray[i]) % 10) + reminder).ToString();
                reminder = (firstNumAsArray[i] + secondNumAsArray[i]) / 10;

                if (reminder > 0 && i == secondNumAsArray.Length - 1)
                {
                    summedNumber += reminder;
                }
            }

            return summedNumber;
        }

        private static BigInteger[] ConvertNumberToArray(BigInteger number)
        {
            var result = number
                .ToString()
                .ToCharArray()
                .Select(n => (BigInteger)(n - '0'))
                .ToArray();

            return result;
        }

        private static BigInteger ConvertArrayToNumber(BigInteger[] digits)
        {
            var resultAsString = string.Empty;

            for (int i = 0; i < digits.Length; i++)
            {
                resultAsString += digits[i];
            }

            return BigInteger.Parse(resultAsString);
        }
    }
}