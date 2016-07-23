namespace Poker
{
    using System;
    using System.Linq;

    using Contracts;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int ProperCardsCountInAHand = 5;

        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                return false;
            }
            else if (hand.Cards.Count == 0)
            {
                return false;
            }
            else if (hand.Cards.Count < ProperCardsCountInAHand)
            {
                return false;
            }
            else if (hand.Cards.Count > ProperCardsCountInAHand)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }
            else
            {
                bool areFromSameSuit = hand.Cards.GroupBy(gr => gr.Suit).Count() == 1;
                var sortedCards = hand.Cards.Select(c => (int)c.Face).OrderBy(v => v).ToList();

                if (!areFromSameSuit)
                {
                    return false;
                }
                else
                {
                    for (int i = 1; i < sortedCards.Count(); i++)
                    {
                        if (sortedCards[i] - 1 != sortedCards[i - 1])
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }
            else
            {
                return hand.Cards.GroupBy(gr => gr.Face).Any(gr => gr.Count() == 4);
            }
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }
            else
            {
                var groupedCards = hand.Cards.GroupBy(gr => gr.Face);

                return groupedCards.Any(gr => gr.Count() == 2) &&
                       groupedCards.Any(gr => gr.Count() == 3);
            }
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }
            else if (this.IsStraightFlush(hand))
            {
                return false;
            }
            else
            {
                return hand.Cards.GroupBy(card => card.Suit).Count() == 1;
            }
        }

        public bool IsStraight(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }
            else if (this.IsStraightFlush(hand))
            {
                return false;
            }
            else
            {
                var sortedCards = hand.Cards.Select(c => (int)c.Face).OrderBy(v => v).ToArray();

                for (int i = 1; i < sortedCards.Length; i++)
                {
                    if (sortedCards[i] - 1 != sortedCards[i - 1])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }
            else
            {
                return hand.Cards.GroupBy(gr => gr.Face).Any(gr => gr.Count() == 3);
            }
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }
            else
            {
                return hand.Cards.GroupBy(gr => gr.Face).Count(gr => gr.Count() == 2) == 2;
            }
        }

        public bool IsOnePair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }
            else
            {
                return hand.Cards.GroupBy(gr => gr.Face).Count(gr => gr.Count() == 2) == 1;
            }
        }

        public bool IsHighCard(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }
            else
            {
                return hand.Cards.GroupBy(gr => gr.Face).Count() == ProperCardsCountInAHand && !this.IsFlush(hand);
            }
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}