namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;

    using Cards;
    using Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HandTests
    {
        /* Hand.ToString() tests */

        [TestMethod]
        public void HandToString_ExpectsToReturnAllCardsJoinedInAString()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            };
            var hand = new Hand(cards);
            string expected = "Face: Ace Suit: Spades, Face: Eight Suit: Diamonds";
            string actual = hand.ToString();

            Assert.AreEqual(expected, actual);
        }

        /* End of Hand.ToString() tests */
    }
}