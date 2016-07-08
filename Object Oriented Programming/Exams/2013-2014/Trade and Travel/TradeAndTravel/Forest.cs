namespace TradeAndTravel
{
    internal class Forest : GatheringLocation
    {
        public Forest(string name)
            : base(name, LocationType.Forest)
        {
            this.RequiredItem = ItemType.Weapon;
            this.GatheredType = ItemType.Wood;
        }

        public override Item ProduceItem(string name)
        {
            return new Wood(name, this);
        }
    }
}