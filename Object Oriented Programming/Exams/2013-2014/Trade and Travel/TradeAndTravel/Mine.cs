namespace TradeAndTravel
{
    internal class Mine : GatheringLocation
    {
        public Mine(string name) 
            : base(name, LocationType.Mine)
        {
            this.GatheredType = ItemType.Iron;
            this.RequiredItem = ItemType.Armor;
        }

        public override Item ProduceItem(string name)
        {
            return new Iron(name, this);
        }
    }
}