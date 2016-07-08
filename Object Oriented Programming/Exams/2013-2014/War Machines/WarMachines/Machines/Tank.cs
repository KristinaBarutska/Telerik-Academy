namespace WarMachines.Machines
{
    using System.Text;

    using WarMachines.Interfaces;

    internal class Tank : Machine, ITank
    {
        private const double InitialHealthPoints = 100;
        private const double BonusDefensePointsInDefenseMode = 30;
        private const double AttackPointsLostInDefenseMode = 40;
        private const string DefenseModeFormatString = " *Defense: {0}";

        internal Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = InitialHealthPoints;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode
        {
            get; private set;
        }

        public void ToggleDefenseMode()
        {
            if (!this.DefenseMode)
            {
                this.DefenseMode = true;
                this.DefensePoints += BonusDefensePointsInDefenseMode;
                this.AttackPoints -= AttackPointsLostInDefenseMode;
            }
            else
            {
                this.DefenseMode = false;
                this.DefensePoints -= BonusDefensePointsInDefenseMode;
                this.AttackPoints += AttackPointsLostInDefenseMode;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());

            result.AppendLine(string.Format(DefenseModeFormatString,
                this.DefenseMode ? MachineSpecialAbilityOn : MachineSpecialAbilityOff));
            return result.ToString();
        }
    }
}