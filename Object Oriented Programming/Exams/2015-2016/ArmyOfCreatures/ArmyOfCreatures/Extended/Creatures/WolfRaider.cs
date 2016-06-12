namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Specialties;

    class WolfRaider : Creature
    {
        private const int InitialAttack = 8;
        private const int InitialDefense = 5;
        private const int InitialHealthPoints = 10;
        private const decimal InitialDamage = 3.5m;
        private const int RoundsWithDoubledDefense = 7;

        public WolfRaider()
            : base(InitialAttack, InitialDefense, InitialHealthPoints, InitialDamage)
        {
            this.AddSpecialty(new DoubleDamage(RoundsWithDoubledDefense));
        }
    }
}