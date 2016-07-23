namespace Poker.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker.Cards;

    [TestClass]
    public class CardTests
    {
        /* Card.ToString() tests */
        [TestMethod]
        public void CardToString_ExpectsToReturnFaceAndSuitString()
        {
            var card = new Card(CardFace.Eight, CardSuit.Diamonds);
            string expected = "Face: Eight Suit: Diamonds";
            string actual = card.ToString();

            Assert.AreEqual(expected, actual);
        }

        /* End of Card.ToString() tests */
    }
}