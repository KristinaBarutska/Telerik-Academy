namespace WarMachines.Machines
{
    using System.Text;

    using WarMachines.Interfaces;

    internal class Fighter : Machine, IFighter
    {
        private const double InitialHealthPoints = 200;
        private const string FighterStealthModeFormatString = " *Stealth: {0}";

        internal Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints)
        {
            this.StealthMode = stealthMode;
            this.HealthPoints = InitialHealthPoints;
        }

        public bool StealthMode
        {
            get; private set;
        }

        public void ToggleStealthMode()
        {
            if (!this.StealthMode)
            {
                this.StealthMode = true;
            }
            else
            {
                this.StealthMode = false;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());

            result.AppendLine(string.Format(FighterStealthModeFormatString,
                this.StealthMode ? MachineSpecialAbilityOn : MachineSpecialAbilityOff));
            return result.ToString();
        }
    }
}