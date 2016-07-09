namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Infester : Unit
    {
        public Infester(string id, UnitClassification unitType, int health, int power, int aggression) 
            : base(id, unitType, health, power, aggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> infestableUnits = units
                .Where(u => u.Id != this.Id && this.UnitClassification == InfestationRequirements.RequiredClassificationToInfest(u.UnitClassification));
            var optimalInfestableUnit = GetOptimalAttackableUnit(infestableUnits);

            if (optimalInfestableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalInfestableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MaxValue, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health < optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}