/*
    Problem 5. Sort by string length
    You are given an array of strings. Write a method that sorts the array by the length of its 
    elements (the number of characters composing them).
*/

namespace _05.SortByStringLength
{
    using System;
    using System.Linq;

    public class Sorter
    {
        private static void Main()
        {
            string[] strings = Console.ReadLine().Split(' ');

            var stringsSorted = strings.OrderBy(str => str.Length);

            Console.WriteLine(string.Join(" ", stringsSorted));
        }
    }
}