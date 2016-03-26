/*
    Problem 12. Null Values Arithmetic
    Create a program that assigns null values to an integer and to a double variable.
    Try to print these variables at the console.
    Try to add some number or the null literal to these variables and print the result.
*/

namespace NullValueArithmetic
{
    using System;

    public class NullValueArithmetic
    {
        public static void Main()
        {
            int? nullableInt = null;
            double? nullableDouble = null;

            Console.WriteLine(nullableInt + " " + nullableDouble);
            Console.WriteLine(nullableDouble + 5);
            Console.WriteLine(nullableInt + null);
        }
    }
}