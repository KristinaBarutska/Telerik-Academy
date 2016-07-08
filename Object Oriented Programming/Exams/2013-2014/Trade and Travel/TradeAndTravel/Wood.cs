namespace TradeAndTravel
{
    internal class Wood : Item
    {
        private const int MoneyValue = 2;
        private const string DropInteraction = "drop";

        public Wood(string name, Location location = null)
            : base(name, Wood.MoneyValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == DropInteraction && this.Value > 0)
            {
                this.Value--;
            }
        }
    }
}