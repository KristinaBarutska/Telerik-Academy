/*
    Problem 3. Check for a Play Card
    Classical play cards use the following signs to designate the card face: `2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A.
    Write a program that enters a string and prints “yes” if it is a valid card sign or “no” otherwise. Examples:
*/

namespace CheckForPlayCard
{
    using System;
    using System.Collections.Generic;

    public class PlayCardsChecker
    {
        public static void Main()
        {
            Console.Write("Enter car's face : ");
            string card = Console.ReadLine();
            ICollection<string> validCards = new List<string>
            {
                "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
            };
            bool isValidCard = validCards.Contains(card);

            Console.WriteLine($"{card} is valid card ? {isValidCard}");
        }
    }
}