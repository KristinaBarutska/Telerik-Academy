namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Text;

    using Interfaces;

    public class Fighter : Machine, IFighter
    {
        private const double InitialHealthPoints = 200;

        private bool stealthMode;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.stealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get
            {
                return this.stealthMode;
            }

            private set
            {
                this.stealthMode = value;
            }
        }

        public void ToggleStealthMode()
        {
            if (this.StealthMode)
            {
                this.StealthMode = false;
            }
            else
            {
                this.StealthMode = true;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            string stealthModeString = this.StealthMode ? "ON" : "OFF";

            result.AppendLine(string.Format(" *Stealth: {0}", stealthModeString));

            return result.ToString();
        }
    }
}