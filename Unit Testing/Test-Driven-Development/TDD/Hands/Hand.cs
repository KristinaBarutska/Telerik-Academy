namespace Poker
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class Hand : IHand
    {
        private const string CardsSeparator = ", ";

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards { get; private set; }

        public override string ToString()
        {
            return string.Join(CardsSeparator, this.Cards);
        }
    }
}
