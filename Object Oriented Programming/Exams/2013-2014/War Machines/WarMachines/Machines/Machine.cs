namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Text;

    using Common;
    using Interfaces;

    internal abstract class Machine : IMachine
    {
        private const string MachineAttackPoints = "Machine attack points";
        private const string MachineDefensePoints = "Machine defense points";
        private const string MachineHealthPoints = "Machine health points";
        private const string MachineName = "Machine name";
        private const string MachinePilot = "Machine pilot";
        private const string MachineTargets = "Machine targets";
        private const string MachineNameFormatString = "- {0}";
        private const string MachineTypeFormatString = " *Type: {0}";
        private const string MachineHealthFormatString = " *Health: {0}";
        private const string MachineAttackFormatString = " *Attack: {0}";
        private const string MachineDefenseFormatString = " *Defense: {0}";
        private const string MachineTargetsFormatString = " *Targets: {0}";
        private const string TargetsSeparator = ", ";
        private const string NoneTargets = "None";
        protected const string MachineSpecialAbilityOn = "ON";
        protected const string MachineSpecialAbilityOff = "OFF";

        private double attackPoints;
        private double defensePoints;
        private double healthPoints;
        private string name;
        private IPilot pilot;
        private IList<string> targets;

        internal Machine(string name, double attackPoints, double defensePoints)
        {
            this.name = name;
            this.attackPoints = attackPoints;
            this.defensePoints = defensePoints;
            this.targets = new List<string>();
        }

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            protected set
            {
                Validator.ValidateDouble(value, MachineAttackPoints);
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }

            protected set
            {
                Validator.ValidateDouble(value, MachineDefensePoints);
                this.defensePoints = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }

            set
            {
                Validator.ValidateDouble(value, MachineHealthPoints);
                this.healthPoints = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.ValidateString(value, MachineName);
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                Validator.ValidateObject(value, MachinePilot);
                this.pilot = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }

            private set
            {
                Validator.ValidateObject(value, MachineTargets);
                this.targets = value;
            }
        }

        public void Attack(string target)
        {
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format(MachineNameFormatString, this.Name));
            result.AppendLine(string.Format(MachineTypeFormatString, this.GetType().Name));
            result.AppendLine(string.Format(MachineHealthFormatString, this.HealthPoints));
            result.AppendLine(string.Format(MachineAttackFormatString, this.AttackPoints));
            result.AppendLine(string.Format(MachineDefenseFormatString, this.DefensePoints));
            result.AppendLine(string.Format(MachineTargetsFormatString,
                this.Targets.Count == 0 ? NoneTargets : string.Join(TargetsSeparator, this.Targets)));

            return result.ToString();
        }
    }
}