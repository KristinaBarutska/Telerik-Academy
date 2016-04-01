/*
    Problem 4. Print a Deck of 52 Cards
    Write a program that generates and prints all possible cards from a standard deck of 52 cards 
    (without the jokers). The cards should be printed using the classical notation (like 5 of spades,
    A of hearts, 9 of clubs; and K of diamonds).
    The card faces should start from 2 to A.
    Print each card face in its four possible suits: clubs, diamonds, hearts and spades. 
    Use 2 nested for-loops and a switch-case statement.
*/

namespace PrintDeck
{
    using System;

    public class DeckPrinter
    {
        public static void Main()
        {
            char[] suits = { '\u2660', '\u2665', '\u2666', '\u2663' };
            string[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            for (int i = 0; i < faces.Length; i++)
            {
                for (int j = 0; j < suits.Length; j++)
                {
                    string currentFace = faces[i];
                    char currentSuit = suits[j];
                    Console.WriteLine($"{currentFace}{currentSuit}");
                }
            }
        }
    }
}