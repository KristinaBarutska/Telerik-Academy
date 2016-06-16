namespace TradeAndTravel
{
    public class GatheringLocation : Location, IGatheringLocation
    {
        public GatheringLocation(string name, ItemType gatheredType, ItemType requiredItem, LocationType locationType)
            : base(name, locationType)
        {
        }

        public ItemType GatheredType { get; private set; }

        public ItemType RequiredItem { get; private set; }

        public Item ProduceItem(string name)
        {
            if (this.GatheredType == ItemType.Iron)
            {
                return new Iron(name);
            }
            else if (this.GatheredType == ItemType.Wood)
            {
                return new Wood(name);
            }
            else
            {
                return null;
            }
        }
    }
}