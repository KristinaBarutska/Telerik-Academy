namespace MobileDevice
{
    public class Battery
    {
        private string model;
        private double hoursIddle;
        private double hoursTalk;
        private BatteryType batteryType;

        public Battery(string model)
        {
            this.model = model;
        }

        public Battery(string model, double hoursIddle)
            : this(model)
        {
            this.hoursIddle = hoursIddle;
        }

        public Battery(string model, double hoursIddle, double hoursTalk)
           : this(model, hoursIddle)
        {
            this.hoursTalk = hoursTalk;
        }

        public Battery(string model, double hoursIddle, double hoursTalk, BatteryType batteryType)
           : this(model, hoursIddle, hoursTalk)
        {
            this.batteryType = batteryType;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                ValueValidator.ValidateString(value, "Model");
                this.model = value;
            }
        }

        public double HoursIddle
        {
            get
            {
                return this.hoursIddle;
            }

            set
            {
                ValueValidator.ValidateNumber(value, "Hours-Iddle");
                this.hoursIddle = value;
            }
        }

        public double HoursTalk
        {
            get
            {
                return this.hoursIddle;
            }

            set
            {
                ValueValidator.ValidateNumber(value, "Hours-Talk");
                this.hoursIddle = value;
            }
        }

        public override string ToString()
        {
            if (this.hoursIddle == 0 && this.hoursTalk == 0 && this.batteryType == 0)
            {
                return $"Battery: Model {this.model}";
            }
            else if (this.hoursTalk == 0 && this.batteryType == 0)
            {
                return $"Battery: Model {this.model}, Hours-iddle {this.hoursIddle}";
            }
            else if (this.batteryType == 0)
            {
                return $"Battery: Model {this.model}, Hours-iddle {this.hoursIddle}, HoursTalk {this.hoursTalk}";
            }
            else
            {
                return
                    $"Battery: Model {this.model}, Hours-iddle {this.hoursIddle}, " +
                    $"HoursTalk {this.hoursTalk} Battery-type {this.batteryType}";
            }
        }
    }
}