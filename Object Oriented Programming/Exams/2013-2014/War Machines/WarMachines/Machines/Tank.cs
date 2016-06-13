namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Text;

    using Interfaces;

    public class Tank : Machine, ITank
    {
        private const double InitialHealthPoints = 100;
        private const double BonusDefensePointsInDefenseMode = 30;
        private const double AttackPointsToLoseInDefenseMode = 40;

        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode
        {
            get
            {
                return this.defenseMode;
            }

            private set
            {
                this.defenseMode = value;
            }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;
                this.DefensePoints -= BonusDefensePointsInDefenseMode;
                this.AttackPoints += AttackPointsToLoseInDefenseMode;
            }
            else
            {
                this.DefenseMode = true;
                this.DefensePoints += BonusDefensePointsInDefenseMode;
                this.AttackPoints -= AttackPointsToLoseInDefenseMode;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            string defenseModeString = this.DefenseMode ? "ON" : "OFF";

            result.AppendLine(string.Format(" *Defense: {0}", defenseModeString));

            return result.ToString();
        }
    }
}