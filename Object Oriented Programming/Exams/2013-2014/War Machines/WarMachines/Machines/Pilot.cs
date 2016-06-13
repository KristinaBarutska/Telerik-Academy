namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Common;
    using Interfaces;

    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.ValidateIfStirngIsNullOrEmpty(value, "Pilot name");
                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            Validator.ValidateIfMachineIsNotNull(machine);
            this.machines.Add(machine);
        }

        public string Report()
        {
            var result = new StringBuilder();
            string machinesCountString = string.Empty;

            this.machines = this.machines
                .OrderBy(m => m.HealthPoints)
                .ThenBy(m => m.Name)
                .ToList();

            switch (this.machines.Count)
            {
                case 0:
                    result.AppendLine(string.Format("{0} – {1} {2}", this.Name, "no", "machines"));
                    break;
                case 1:
                    result.AppendLine(string.Format("{0} – {1} {2}", this.Name, "1", "machine"));
                    break;
                default:
                    result.AppendLine(string.Format("{0} – {1} {2}", this.Name, this.machines.Count, "machines"));
                    break;
            }

            result.AppendLine(string.Format("{0} – {1} {2}", this.Name, this.machines.Count, machinesCountString));
            result.AppendLine(string.Join(string.Empty, this.machines));

            return result.ToString().Trim();
        }
    }
}