namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    public class AncientBehemoth : Creature
    {
        private const int InitialAttack = 19;
        private const int InitialDefense = 19;
        private const int InitialHealthPoints = 40;
        private const decimal InitialDamage = 300m;
        private const decimal PercentageToReduceAttack = 80;
        private const int RoundsWithDoubledDefense = 5;

        public AncientBehemoth()
            : base(InitialAttack, InitialDefense, InitialHealthPoints, InitialDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(PercentageToReduceAttack));
            this.AddSpecialty(new DoubleDefenseWhenDefending(RoundsWithDoubledDefense));
        }
    }
}