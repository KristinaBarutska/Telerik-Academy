namespace Poker.Tests
{
    using System.Collections.Generic;

    using Cards;
    using Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PokerHandsCheckerTests
    {
        /* PokerHandsChecker.IsValidHand() tests */
        [TestMethod]
        public void IsValidHand_PassNullHand_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            bool isValid = checker.IsValidHand(null);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValidHand_PassHandWithoutCards_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            bool isValid = checker.IsValidHand(new Hand(new List<ICard>()));

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValidHand_PassHandWithLessThanFiveCards_ExpectsToReturFalse()
        {
            var checker = new PokerHandsChecker();
            bool isValid = checker.IsValidHand(new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs)
            }));

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValidHand_PassHandWithMoreThanFiveCards_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            bool isValid = checker.IsValidHand(new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs)
            }));

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValidHand_PassHandWithDuplicateCards_ExpectToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var card = new Card(CardFace.Queen, CardSuit.Clubs);

            bool isValid = checker.IsValidHand(new Hand(new List<ICard>()
            {
                card,
                card
            }));

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValidHand_PassValidHand_ExpectsToReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades)
            });
            bool isValid = checker.IsValidHand(hand);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsValidHand_PassHandWithValidCards_ExpectsToReturnTrue()
        {
            var checker = new PokerHandsChecker();
            bool isValid = checker.IsValidHand(new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs)
            }));
            bool expected = true;
            bool actual = isValid;
            Assert.AreEqual(expected, actual);
        }

        /* End of PokerHandsChecker.IsValidHand() tests */

        /* PokerHandsChecker.IsFlush() tests */
        [TestMethod]
        public void IsFlush_PassNullHand_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            bool isFlush = checker.IsFlush(null);

            Assert.IsFalse(isFlush);
        }

        [TestMethod]
        public void IsFlush_PassStraightFlushHand_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades)
            });
            bool isFlush = checker.IsFlush(hand);

            Assert.IsFalse(isFlush);
        }

        [TestMethod]
        public void IsFlush_PassNoFlushHand_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades)
            });
            bool isFlush = checker.IsFlush(hand);

            Assert.IsFalse(isFlush);
        }

        [TestMethod]
        public void IsFlush_PassFlushHand_ExpectsToReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades)
            });
            bool isFlush = checker.IsFlush(hand);

            Assert.IsTrue(isFlush);
        }

        /* End of PokerHandsChecker.IsFlush() tests */

        /* PokerHandsChecker.IsStraightFlush() tests */
        [TestMethod]
        public void IsStraightFlush_PassFlushHand_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades)
            });
            bool isStraightFlush = checker.IsStraightFlush(hand);

            Assert.IsFalse(isStraightFlush);
        }

        [TestMethod]
        public void IsStraightFlush_PassNoStraightFlushHand_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades)
            });
            bool isStraightFlush = checker.IsFlush(hand);

            Assert.IsFalse(isStraightFlush);
        }

        [TestMethod]
        public void IsStraightFlush_PassStraightFlushHand_ExpectsToReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades)
            });
            bool isStraightFlush = checker.IsStraightFlush(hand);

            Assert.IsTrue(isStraightFlush);
        }

        /* End of PokerHandsChecker.IsStraightFlush() tests */

        /* PokerHandsChecker.IsFourOfAKind() tests */
        [TestMethod]
        public void IsFourOfAKind_PassHandWithFiveCardsWithDifferentFaces_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades)
            });
            bool isFourOfAKind = checker.IsFourOfAKind(hand);

            Assert.IsFalse(isFourOfAKind);
        }

        [TestMethod]
        public void IsFourOfAKind_PassValidFourOfAKindHand_ExpectsToReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades)
            });
            bool isFourOfAKind = checker.IsFourOfAKind(hand);

            Assert.IsTrue(isFourOfAKind);
        }

        /* End of PokerHandsChecker.IsFourOfAKind() tests */

        /* PokerHandsChecker.IsFullHouse() tests */
        [TestMethod]
        public void IsFullHouse_PassNotFullHouseHand_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades)
            });
            bool isFullHouse = checker.IsFullHouse(hand);

            Assert.IsFalse(isFullHouse);
        }

        [TestMethod]
        public void IsFullHouse_PassFullHouseHand_ExpectsToReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades)
            });
            bool isFullHouse = checker.IsFullHouse(hand);

            Assert.IsTrue(isFullHouse);
        }

        /* End of PokerHandsChecker.IsFullHouse() tests */

        /* PokerHandsChecker.IsStraight() tests */
        [TestMethod]
        public void IsStraight_PassNotStraightHand_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades)
            });
            bool isStraight = checker.IsStraight(hand);

            Assert.IsFalse(isStraight);
        }

        [TestMethod]
        public void IsStraight_PassStraightFlushHand_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades)
            });
            bool isStraight = checker.IsStraight(hand);

            Assert.IsFalse(isStraight);
        }

        [TestMethod]
        public void IsStraight_PassStraightHand_ExpectsToReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds)
            });
            bool isStraight = checker.IsStraight(hand);

            Assert.IsTrue(isStraight);
        }

        /* End of PokerHandsChecker.IsStraight() tests */

        /* PokerHandsChecker.IsThreeOfAKind() tests */
        [TestMethod]
        public void IsThreeOfAKind_PassNotThreeOfAKindHand_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds)
            });
            bool isThreeOfAKind = checker.IsThreeOfAKind(hand);

            Assert.IsFalse(isThreeOfAKind);
        }

        [TestMethod]
        public void IsThreeOfAKind_PassThreeOfAKindHand_ExpectsToReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds)
            });
            bool isThreeOfAKind = checker.IsThreeOfAKind(hand);

            Assert.IsTrue(isThreeOfAKind);
        }

        /* End of PokerHandsChecker.IsThreeOfAKind() tests */

        /* PokerHandsChecker.IsTwoPair() tests */
        [TestMethod]
        public void IsTwoPair_PassNotTwoPairHand_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds)
            });
            bool isTwoPair = checker.IsTwoPair(hand);

            Assert.IsFalse(isTwoPair);
        }

        [TestMethod]
        public void IsTwoPair_PassTwoPairHand_ExpectsToReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds)
            });
            bool isTwoPair = checker.IsTwoPair(hand);

            Assert.IsTrue(isTwoPair);
        }

        /* End of PokerHandsChecker.IsTwoPair() tests */

        /* PokerHandsChecker.IsPair() tests */
        public void IsOnePair_PassNotPairHand_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds)
            });
            bool isOnePair = checker.IsTwoPair(hand);

            Assert.IsFalse(isOnePair);
        }

        [TestMethod]
        public void IsOnePair_PassTwoPairHand_ExpectsToReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds)
            });
            bool isOnePair = checker.IsOnePair(hand);

            Assert.IsTrue(isOnePair);
        }

        /* End of PokerHandsChecker.IsPair() tests */

        /* PokerHandsChecker.IsHighCard() tests */
        [TestMethod]
        public void IsHighCard_PassNotHighCardHand_ExpectsToReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds)
            });
            bool isHighCard = checker.IsHighCard(hand);

            Assert.IsFalse(isHighCard);
        }

        [TestMethod]
        public void IsHighCard_PassAHighCardHand_ExpectsToReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds)
            });
            bool isHighCard = checker.IsHighCard(hand);

            Assert.IsTrue(isHighCard);
        }

        /* End of PokerHandsChecker.IsHighCard() tests*/
    }
}
