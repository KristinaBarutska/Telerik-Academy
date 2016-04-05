/*
    Problem 7. One system to any other
    Write a program to convert from any numeral system of given base s to any 
    other numeral system of base d (2 ≤ s, d ≤ 16). 
*/

namespace OneSystemToAnyOther
{
    using System;
    using System.Numerics;

    public class NumeralSystemConvertor
    {
        private static void Main()
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            int firstSystem = int.Parse(Console.ReadLine());
            int secondSystem = int.Parse(Console.ReadLine());
            string result = ConverToAnyOther(ConvertToDecimal(number, firstSystem), secondSystem);

            Console.WriteLine($"Result : {result}");
        }

        private static string ConverToAnyOther(BigInteger number, int secondSystem)
        {
            char[] hexLetters = { 'A', 'B', 'C', 'D', 'E', 'F' };
            long digit = 0;
            string result = string.Empty;

            while (number > 0)
            {
                digit = (long)number % secondSystem;

                if (digit >= 10)
                {
                    result = hexLetters[digit - 10] + result;
                }
                else
                {
                    result = digit + result;
                }

                number /= secondSystem;
            }

            return result;
        }

        private static BigInteger ConvertToDecimal(BigInteger number, int firstSystem)
        {
            BigInteger result = 0;
            char[] numberAsCharArr = number.ToString().ToCharArray();

            Array.Reverse(numberAsCharArr);

            for (int i = 0; i < numberAsCharArr.Length; i++)
            {
                result += (numberAsCharArr[i] - '0') * (BigInteger)Math.Pow(firstSystem, i);
            }

            return result;
        }
    }
}