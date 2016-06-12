namespace ArmyOfCreatures.Extended.Battles
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Logic;
    using Logic.Battles;

    public class ExtendedBattleManager : BattleManager
    {
        private ICollection<ICreaturesInBattle> thirdArmyCreatures;

        public ExtendedBattleManager(ICreaturesFactory creaturesFactory, ILogger logger)
            : base(creaturesFactory, logger)
        {
            this.thirdArmyCreatures = new List<ICreaturesInBattle>();
        }

        protected override void AddCreaturesByIdentifier(CreatureIdentifier creatureIdentifier,
            ICreaturesInBattle creaturesInBattle)
        {
            Validator.ValidateIdentifier(creatureIdentifier, "creatureIdentifier");

            if (creatureIdentifier.ArmyNumber == 3)
            {
                Validator.ValidateIfCreaturesAreNotNull(creaturesInBattle, "creaturesInBattle");
                this.thirdArmyCreatures.Add(creaturesInBattle);
            }
            else
            {
                base.AddCreaturesByIdentifier(creatureIdentifier, creaturesInBattle);
            }
        }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            Validator.ValidateIdentifier(identifier, "identifier");

            if (identifier.ArmyNumber == 3)
            {
                return this.thirdArmyCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }
            else
            {
                return base.GetByIdentifier(identifier);
            }
        }
    }
}