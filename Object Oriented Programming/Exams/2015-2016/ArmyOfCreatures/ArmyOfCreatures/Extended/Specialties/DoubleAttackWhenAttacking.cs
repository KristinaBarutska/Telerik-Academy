namespace ArmyOfCreatures.Extended.Specialties
{
    using System.Globalization;

    using Logic.Specialties;
    using Common;
    using Logic.Battles;

    public class DoubleAttackWhenAttacking : Specialty
    {
        private int rounds;

        public DoubleAttackWhenAttacking(int rounds)
        {
            Validator.ValidateIfRoundsArePositiveNumber(rounds);
            this.rounds = rounds;
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, 
            ICreaturesInBattle defender)
        {
            Validator.ValidateIfCreaturesAreNotNull(attackerWithSpecialty, "attackerWithSpecialty");
            Validator.ValidateIfCreaturesAreNotNull(defender, "defender");

            if (this.rounds <= 0)
            {
                return;
            }

            attackerWithSpecialty.CurrentAttack *= 2;
            this.rounds--;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.rounds);
        }
    }
}