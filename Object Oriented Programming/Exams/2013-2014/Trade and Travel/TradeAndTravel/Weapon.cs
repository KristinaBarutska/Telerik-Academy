namespace TradeAndTravel
{
    internal class Weapon : Item
    {
        private const int MoneyValue = 10;

        public Weapon(string name, Location location = null)
            : base(name, Weapon.MoneyValue, ItemType.Weapon, location)
        {
        }
    }
}