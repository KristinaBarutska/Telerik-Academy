namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Text;

    using Common;
    using Interfaces;

    public abstract class Machine : IMachine
    {
        private double attackPoints;
        private double defensePoints;
        private double healthPoints;
        private string name;
        private IPilot pilot;
        private IList<string> targets;

        public Machine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Targets = new List<string>();
        }

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            protected set
            {
                Validator.ValidateIfDoubleNumberIsPositive(value, "Attack points");
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
                Validator.ValidateIfDoubleNumberIsPositive(value, "Defense points");
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
                Validator.ValidateIfDoubleNumberIsPositive(value, "Health poinst");
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
                Validator.ValidateIfStirngIsNullOrEmpty(value, "Machine name");
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
                Validator.ValidateIfPilotIsNotNull(value);
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
                this.targets = value;
            }
        }

        public void Attack(string target)
        {
            Validator.ValidateIfStirngIsNullOrEmpty(target, "Target");
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            string targetsString = this.Targets.Count == 0 ? "None" : string.Join(", ", this.Targets);

            result.AppendLine(string.Format("- {0}", this.Name));
            result.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            result.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            result.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            result.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            result.AppendLine(string.Format(" *Targets: {0}", targetsString));

            return result.ToString().Trim();
        }
    }
}