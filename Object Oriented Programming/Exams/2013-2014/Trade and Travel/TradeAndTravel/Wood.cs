namespace TradeAndTravel
{
    public class Wood : Item
    {
        private const int GeneralWoodValue = 2;

        public Wood(string name, Location location = null)
            : base(name, Wood.GeneralWoodValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            base.UpdateWithInteraction(interaction);

            if (interaction == "drop")
            {
                this.Value--;
            }

            this.Value = this.Value < 0 ? 0 : this.Value;
        }
    }
}