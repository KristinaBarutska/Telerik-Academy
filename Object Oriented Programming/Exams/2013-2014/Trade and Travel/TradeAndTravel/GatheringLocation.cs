namespace TradeAndTravel
{
    internal abstract class GatheringLocation : Location, IGatheringLocation
    {
        public GatheringLocation(string name, LocationType type) 
            : base(name, type)
        {
        }

        public ItemType GatheredType
        {
            get; protected set;
        }

        public ItemType RequiredItem
        {
            get; protected set;
        }

        public abstract Item ProduceItem(string name);
    }
}
