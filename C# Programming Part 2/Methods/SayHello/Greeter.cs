/*
    Problem 1. Say Hello
    Write a method that asks the user for his name and prints “Hello, <name>”
    Write a program to test this method. 
*/

namespace SayHello
{
    using System;

    public class Greeter
    {
        private static void Main()
        {
            Console.Write("Please, enter your name: ");
            string name = Console.ReadLine();

            SayHello(name);
        }

        private static void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}.");
        }
    }
}