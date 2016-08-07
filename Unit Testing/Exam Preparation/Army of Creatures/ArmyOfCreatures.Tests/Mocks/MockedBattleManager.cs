namespace ArmyOfCreatures.Tests.Mocks
{
    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;

    public class MockedBattleManager : BattleManager
    {
        public MockedBattleManager(ICreaturesFactory creaturesFactory, ILogger logger)
            : base(creaturesFactory, logger)
        {
        }

        public void AddCreaturesByIdentifier_Exposed(CreatureIdentifier creatureIdentifier, ICreaturesInBattle creaturesInBattle)
        {
            base.AddCreaturesByIdentifier(creatureIdentifier, creaturesInBattle);
        }

        public ICreaturesInBattle GetByIdentifier_Exposed(CreatureIdentifier identifier)
        {
            return base.GetByIdentifier(identifier);
        }
    }
}
