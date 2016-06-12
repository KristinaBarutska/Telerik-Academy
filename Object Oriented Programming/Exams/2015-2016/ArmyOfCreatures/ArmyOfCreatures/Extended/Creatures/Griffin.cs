namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    public class Griffin : Creature
    {
        private const int InitialAttack = 8;
        private const int InitialDefense = 8;
        private const int InitialHealthPoints = 25;
        private const decimal InitialDamage = 4.5m;
        private const int RoundsWithDoubledDefense = 5;
        private const int DefenseToAddWhenSkip = 3;

        public Griffin()
            : base(InitialAttack, InitialDefense, InitialHealthPoints, InitialDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(RoundsWithDoubledDefense));
            this.AddSpecialty(new AddDefenseWhenSkip(DefenseToAddWhenSkip));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}