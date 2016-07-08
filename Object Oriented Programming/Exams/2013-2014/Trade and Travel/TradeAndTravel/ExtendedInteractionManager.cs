using System.Collections.Generic;
using System.Linq;

namespace TradeAndTravel
{
    internal class ExtendedInteractionManager : InteractionManager
    {
        private const string Weapon = "weapon";
        private const string Wood = "wood";
        private const string Iron = "iron";
        private const string Mine = "mine";
        private const string Forest = "forest";
        private const string Gather = "gather";
        private const string Craft = "craft";
        private const string Armor = "armor";
        private const string Merchant = "merchant";

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case Weapon: return new Weapon(itemNameString, itemLocation);
                case Wood: return new Wood(itemNameString, itemLocation);
                case Iron: return new Iron(itemNameString, itemLocation);
                default: return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            switch (locationTypeString)
            {
                case Mine: return new Mine(locationName);
                case Forest: return new Forest(locationName);
                default: return base.CreateLocation(locationTypeString, locationName);
            }
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            string commandType = commandWords[1];

            switch (commandType)
            {
                case Gather: this.HandleGatherInteraction(commandWords, actor); break;
                case Craft: this.HandleCraftInteraction(commandWords, actor); break;
                default: base.HandlePersonCommand(commandWords, actor); break;
            }
        }
        
        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            switch (personTypeString)
            {
                case Merchant: return new Merchant(personNameString, personLocation);
                default: return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            IEnumerable<Item> actorInventory = actor.ListInventory();
            var actorLocationAsGathering = actor.Location as GatheringLocation;
            string itemName = commandWords[2];

            if (this.CanGatherFromWood(actorLocationAsGathering, actorInventory))
            {
                this.AddToPerson(actor, actorLocationAsGathering.ProduceItem(itemName));
            }
            else if (this.CanGatherFromMine(actorLocationAsGathering, actorInventory))
            {
                this.AddToPerson(actor, actorLocationAsGathering.ProduceItem(itemName));
            }
        }

        private bool CanGatherFromWood(GatheringLocation actorLocationAsGathering, IEnumerable<Item> actorInventory)
        {
            bool hasWeapon = actorInventory.Any(i => i.ItemType == ItemType.Weapon);
            ItemType gatheredItem = actorLocationAsGathering.GatheredType;

            return actorLocationAsGathering != null && gatheredItem == ItemType.Wood && hasWeapon;
        }

        private bool CanGatherFromMine(GatheringLocation actorLocationAsGathering, IEnumerable<Item> actorInventory)
        {
            bool hasArmor = actorInventory.Any(i => i.ItemType == ItemType.Armor);
            ItemType gatheredItem = actorLocationAsGathering.GatheredType;

            return actorLocationAsGathering != null && gatheredItem == ItemType.Iron && hasArmor;
        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            string itemTypeToCraft = commandWords[2];
            string itemName = commandWords[3];
            IEnumerable<Item> actorInventory = actor.ListInventory();

            if (itemTypeToCraft == Armor && this.HasIron(actorInventory))
            {
                this.AddToPerson(actor, new Armor(itemName, actor.Location));
            }
            else if (itemTypeToCraft == Weapon && this.HasIronAndWood(actorInventory))
            {
                this.AddToPerson(actor, new Weapon(itemName, actor.Location));
            }
        }

        private bool HasIron(IEnumerable<Item> actorInventory)
        {
            return actorInventory.Any(i => i.ItemType == ItemType.Iron);
        }

        private bool HasIronAndWood(IEnumerable<Item> actorInventory)
        {
            return actorInventory.Any(i => i.ItemType == ItemType.Iron) &&
                actorInventory.Any(i => i.ItemType == ItemType.Wood);
        }
    }
}