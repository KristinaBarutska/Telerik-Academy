namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;

    public class Goblin : Creature
    {
        private const int InitialAttack = 4;
        private const int InitialDefense = 2;
        private const int InitialHealthPoints = 5;
        private const decimal InitialDamage = 1.5m;

        public Goblin() 
            : base(InitialAttack, InitialDefense, InitialHealthPoints, InitialDamage)
        {
        }
    }
}