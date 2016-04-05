﻿/* 
    Problem 1. Allocate array
    Write a program that allocates array of 20 integers and initializes each 
    element by its index multiplied by 5.
    Print the obtained array on the console. 
*/

namespace AllocateArray
{
    using System;

    public class ArrayAllocation
    {
        private static void Main()
        {
            var numbers = new int[20];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i * 5;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}