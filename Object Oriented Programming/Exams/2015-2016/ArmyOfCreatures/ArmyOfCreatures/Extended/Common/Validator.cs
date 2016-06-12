namespace ArmyOfCreatures.Extended.Common
{
    using System;

    using Logic.Battles;
    using Logic.Battles;

    public static class Validator
    {
        private const string NegativeRoundsErrorMessage = "The number of rounds should be greater than 0";
        private const string Rounds = "rounds";

        public static void ValidateIfCreaturesAreNotNull(ICreaturesInBattle creatures, 
            string argumentName)
        {
            if (creatures == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void ValidateIfRoundsArePositiveNumber(int rounds)
        {
            if(rounds <= 0)
            {
                throw new ArgumentOutOfRangeException(Rounds, NegativeRoundsErrorMessage);
            }
        }

        public static void ValidateIdentifier(CreatureIdentifier identifier, string indetifierName)
        {
            if (identifier == null)
            {
                throw new ArgumentNullException(indetifierName);
            }
        }
    }
}