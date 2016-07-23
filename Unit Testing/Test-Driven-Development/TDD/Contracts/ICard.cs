namespace Poker.Contracts
{
    using Poker.Cards;

    public interface ICard
    {
        CardFace Face { get; }

        CardSuit Suit { get; }

        string ToString();
    }
}