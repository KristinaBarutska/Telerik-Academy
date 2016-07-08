namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Common;
    using WarMachines.Interfaces;

    internal class Pilot : IPilot
    {
        private const string PilotName = "Pilot's name";
        private const string PilotMachine = "Pilot's machine";
        private const string PilotInformationFormatString = "{0} - {1} {2}";
        private const string NoMachines = "no";
        private const string SingleMachine = "machine";
        private const string ZeroOrMoreThanOneMachines = "machines";

        private string name;
        private ICollection<IMachine> machines;

        internal Pilot(string name)
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
                Validator.ValidateString(value, PilotName);
                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            Validator.ValidateObject(machine, PilotMachine);
            this.machines.Add(machine);
        }

        public string Report()
        {
            var report = new StringBuilder();
            string machinesCount = this.machines.Count == 0 ? NoMachines : this.machines.Count.ToString();
            string machinesCountString = this.machines.Count == 1 ? SingleMachine : ZeroOrMoreThanOneMachines;

            this.machines = this.machines
                                .OrderBy(m => m.HealthPoints)
                                .ThenBy(m => m.Name)
                                .ToList();

            report.AppendLine(string.Format(PilotInformationFormatString, this.Name, machinesCount, machinesCountString));

            foreach (var machine in this.machines)
            {
                report.Append(machine.ToString());
            }

            return report.ToString().TrimEnd();
        }
    }
}