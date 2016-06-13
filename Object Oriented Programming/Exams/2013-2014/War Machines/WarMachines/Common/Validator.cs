namespace WarMachines.Common
{
    using System;

    using Interfaces;

    public static class Validator
    {
        private const string StringIsNullOrEmptyMessage = "{0} cannot be null or empty string!";
        private const string NegativeDoubleNumberMessage = "{0} cannot be negative number!";
        private const string NullPilotMessage = "Pilot cannot be null!";
        private const string NullMachineMessage = "Machine cannot be null!";

        public static void ValidateIfStirngIsNullOrEmpty(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(string.Format(StringIsNullOrEmptyMessage, propertyName));
            }
        }

        public static void ValidateIfDoubleNumberIsPositive(double value, string propertyName)
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(NegativeDoubleNumberMessage, propertyName));
            }
        }

        public static void ValidateIfPilotIsNotNull(IPilot pilot)
        {
            if (pilot == null)
            {
                throw new ArgumentNullException(NullPilotMessage);
            }
        }

        public static void ValidateIfMachineIsNotNull(IMachine machine)
        {
            if (machine == null)
            {
                throw new ArgumentNullException(NullMachineMessage);
            }
        }
    }
}