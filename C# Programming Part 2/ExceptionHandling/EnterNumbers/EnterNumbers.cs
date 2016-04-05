/*
    Problem 2. Enter numbers
    Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end].
    If an invalid number or non-number text is entered, the method should throw an exception.
    Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100 
*/

namespace EnterNumbers
{
    using System;

    public class EnterNumbers
    {
        public static void Main()
        {
            int[] numbers = new int[10];

            for (int i = 0; i < 10; i++)
            {
                int number = ReadNumbers(1, 99);
                numbers[i] = number;
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static int ReadNumbers(int start, int end)
        {
            try
            {
                int input = int.Parse(Console.ReadLine());

                if (input < start || input > end)
                {
                    throw new ArgumentOutOfRangeException("The entered number is less than teh start number or " +
                                                          "greater than the end number.");
                }

                return input;
            }
            catch (OverflowException)
            {
                Console.WriteLine("The entered number is too big or too small.");
                throw;
            }
            catch (ArgumentOutOfRangeException aoor)
            {
                Console.WriteLine(aoor.Message);
                throw;
            }
            catch (FormatException fe)
            {
                Console.WriteLine("The input is not in the correct format.", fe.Message);
                throw;
            }
        }
    }
}