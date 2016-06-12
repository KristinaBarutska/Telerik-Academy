namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;
    using Specialties;

    public class CyclopsKing  : Creature
    {
        private const int InitialAttack = 17;
        private const int InitialDefense = 13;
        private const int InitialHealthPoints = 70;
        private const decimal InitialDamage = 18;
        private const int AttackToAddWhenSkip = 3;
        private const int RoundsWithDoubledAtack = 4;
        private const int RoundsWithDoubledDamage = 1;

        public CyclopsKing() 
            : base(InitialAttack, InitialDefense, InitialHealthPoints, InitialDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(AttackToAddWhenSkip));
            this.AddSpecialty(new DoubleAttackWhenAttacking(RoundsWithDoubledAtack));
            this.AddSpecialty(new DoubleDamage(RoundsWithDoubledDamage));
        }
    }
}