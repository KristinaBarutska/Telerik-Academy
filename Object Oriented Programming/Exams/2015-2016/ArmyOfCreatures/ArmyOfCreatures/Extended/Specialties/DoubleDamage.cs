namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Globalization;

    using Common;
    using Logic.Battles;
    using Logic.Specialties;

    public class DoubleDamage : Specialty
    {
        private int rounds;

        public DoubleDamage(int rounds)
        {
            Validator.ValidateIfRoundsArePositiveNumber(rounds);
            this.rounds = rounds;
        }

        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender,
            decimal currentDamage)
        {
            Validator.ValidateIfCreaturesAreNotNull(attackerWithSpecialty, "attackerWithSpecialty");
            Validator.ValidateIfCreaturesAreNotNull(defender, "defender");

            return currentDamage * 2;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.rounds);
        }
    }
}