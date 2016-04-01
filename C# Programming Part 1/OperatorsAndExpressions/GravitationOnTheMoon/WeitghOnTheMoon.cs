/*
    Problem 2. Gravitation on the Moon
    The gravitational field of the Moon is approximately 17% of that on the Earth.
    Write a program that calculates the weight of a man on the moon by a given weight on the Earth.
*/

namespace GravitationOnTheMoon
{
    using System;

    public class WeitghOnTheMoon
    {
        public static void Main()
        {
            Console.Write("Your normal weight : ");
            double normalWeight = double.Parse(Console.ReadLine());
            double weightOnTheMoon = normalWeight * 0.17;

            Console.WriteLine($"Your weight on the Moon : {weightOnTheMoon}");
        }
    }
}