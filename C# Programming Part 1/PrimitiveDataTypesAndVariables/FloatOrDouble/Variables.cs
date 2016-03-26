/*
    Problem 2. Float or Double?
    Which of the following values can be assigned to a variable of type float and which to a variable 
    of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?
    Write a program to assign the numbers in variables and print them to ensure no precision is lost.
*/

namespace FloatOrDouble
{
    using System;

    public class Variables
    {
        public static void Main()
        {
            double firstDouble = 34.567839023;
            float firstFloat = 12.345f;
            double secondDouble = 12.345;
            double thirdDouble = 8923.1234857;
            float secondFloat = 3456.091f;
            double fourthDouble = 3456.091;

            Console.WriteLine($"{firstDouble}\n{firstFloat}\n{secondDouble}\n{secondFloat}\n{thirdDouble}\n{fourthDouble}");
        }
    }
}