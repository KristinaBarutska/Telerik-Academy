namespace MobileDevices
{
    using System;
    using System.Text;

    public class Battery
    {
        private string model;
        private double hoursIddle;
        private double hoursTalk;
        private BatteryType type;

        public Battery(string model)
        {
            this.model = model;
        }

        public Battery(string model, double hoursIddle, double hoursTalk, BatteryType type)
            : this(model)
        {
            this.hoursIddle = hoursIddle;
            this.hoursTalk = hoursTalk;
            this.type = type;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                ValueValidator.ValidateStringValue(value, "Battery model");
                this.model = value;
            }
        }

        public double HoursIddle
        {
            get
            {
                return this.hoursIddle;
            }

            private set
            {
                ValueValidator.ValidateDoubleValue(value, "Hours iddle");
                this.hoursIddle = value;
            }
        }

        public double HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            private set
            {
                ValueValidator.ValidateDoubleValue(value, "Hours talk");
                this.hoursTalk = value;
            }
        }

        public BatteryType Type
        {
            get
            {
                return this.type;
            }

            private set
            {
                this.type = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            if (this.hoursIddle == 0)
            {
                result.AppendLine(string.Format("Battery model: {0}", this.model));
            }
            else
            {
                result.AppendLine(string.Format("Battery model: {0}{1}Hours iddle: {2}{3}Hours talk: {4}{5}Type: {6}",
                    this.model, Environment.NewLine, this.hoursIddle, Environment.NewLine, this.hoursTalk, Environment.NewLine, this.type));
            }

            return result.ToString();
        }
    }
}