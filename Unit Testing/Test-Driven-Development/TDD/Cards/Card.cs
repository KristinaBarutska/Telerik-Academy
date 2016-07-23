namespace Poker.Cards
{
    using System;
    using System.Text;

    using Contracts;

    public class Card : ICard
    {
        private const string FaceSuitFormatString = "Face: {0} Suit: {1}";

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }
        
        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            return string.Format(FaceSuitFormatString, this.Face, this.Suit);
        }
    }
}
