namespace TradeAndTravel
{
    using System.Linq;

    public class ExtendedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon": return new Weapon(itemNameString, itemLocation);
                case "wood": return new Wood(itemNameString, itemLocation);
                case "iron": return new Iron(itemNameString, itemLocation);
                default: return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            switch (locationTypeString)
            {
                case "mine": return new Mine(locationName);
                case "forest": return new Forest(locationName);
                default: return base.CreateLocation(locationTypeString, locationName);
            }
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            string command = commandWords[1];

            switch (command)
            {
                case "gather": this.HandleGatherInteraction(commandWords, actor); break;
                case "craft": this.HandleCraftInteraction(commandWords, actor); break;
                default: base.HandlePersonCommand(commandWords, actor); break;
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            switch (personTypeString)
            {
                case "merchant": return new Person(personNameString, personLocation);
                default: return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            var gatheringLocation = actor.Location as IGatheringLocation;

            if (gatheringLocation != null)
            {
                var actorInventory = actor.ListInventory();
                var requiredItem = gatheringLocation.RequiredItem;
                string itemName = commandWords[2];
                bool hasRequiredItem = actorInventory.Any(i => i.ItemType == requiredItem);

                if (hasRequiredItem)
                {
                    var producedItem = gatheringLocation.ProduceItem(itemName);
                    this.AddToPerson(actor, producedItem);
                }
            }
        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            string itemToCraft = commandWords[2];
            string itemName = commandWords[3];
            var inventory = actor.ListInventory();
            bool hasIron = inventory.Any(i => i.ItemType == ItemType.Iron);
            bool hasWood = inventory.Any(i => i.ItemType == ItemType.Wood);

            if (itemToCraft == "armor" && hasIron)
            {
                var armor = new Armor(itemName);
                this.AddToPerson(actor, armor);
            }
            else if (itemToCraft == "weapon" && hasIron && hasWood)
            {
                var weapon = new Weapon(itemName);
                this.AddToPerson(actor, weapon);
            }
        }
    }
}