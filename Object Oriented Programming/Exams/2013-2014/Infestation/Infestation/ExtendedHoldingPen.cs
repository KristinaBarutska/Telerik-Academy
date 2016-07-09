namespace Infestation
{
    internal class ExtendedHoldingPen : HoldingPen
    {
        private const string AggressionCatalystType = "AggressionCatalyst";
        private const string PowerCatalystType = "PowerCatalyst";
        private const string HealthCatalystType = "HealthCatalyst";
        private const string WeaponSuplement = "Weapon";
        private const string TankType = "Tank";
        private const string MarineType = "Marine";
        private const string ParasiteType = "Parasite";
        private const string QueenType = "Queen";

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);
                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            string suplementType = commandWords[1];
            string targetUnitId = commandWords[2];
            Unit target = this.GetUnit(targetUnitId);

            switch (suplementType)
            {
                case AggressionCatalystType: target.AddSupplement(new AggressionCatalyst()); break;
                case HealthCatalystType: target.AddSupplement(new HealthCatalyst()); break;
                case PowerCatalystType: target.AddSupplement(new PowerCatalyst()); break;
                case WeaponSuplement: target.AddSupplement(new Weapon()); break;
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            string unitType = commandWords[1];
            string unitId = commandWords[2];

            switch (unitType)
            {
                case TankType:
                    this.InsertUnit(new Tank(unitId));
                    break;
                case MarineType:
                    this.InsertUnit(new Marine(unitId));
                    break;
                case ParasiteType:
                    this.InsertUnit(new Parasite(unitId));
                    break;
                case QueenType:
                    this.InsertUnit(new Queen(unitId));
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }
    }
}