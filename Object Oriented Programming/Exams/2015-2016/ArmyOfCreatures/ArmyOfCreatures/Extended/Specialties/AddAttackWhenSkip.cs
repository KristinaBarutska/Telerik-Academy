namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Globalization;

    using Logic.Specialties;
    
    public class AddAttackWhenSkip : Specialty
    {
        private const int MinAttackToAddValue = 1;
        private const int MaxAttackToAddValue = 10;
        private const string AttackToAddErrorMessage = "attackToAdd should be between 1 and 10, inclusive";

        private readonly int attackToAdd;

        public AddAttackWhenSkip(int attackToAdd)
        {
            this.ValidateAttackToAddValue(attackToAdd, "attackToAdd");
            this.attackToAdd = attackToAdd;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.attackToAdd);
        }

        private void ValidateAttackToAddValue(int attackToAdd, string argumentName)
        {
            if (attackToAdd < MinAttackToAddValue || attackToAdd > MaxAttackToAddValue)
            {
                throw new ArgumentOutOfRangeException(argumentName, AttackToAddErrorMessage);
            }
        }
    }
}