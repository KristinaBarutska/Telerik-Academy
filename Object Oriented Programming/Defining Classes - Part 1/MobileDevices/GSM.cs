namespace MobileDevices
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GSM
    {
        private static GSM iPhone4S = new GSM("IPhone 4S", "Apple");

        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory;

        public GSM(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.callHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
            : this(model, manufacturer)
        {
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.display = display;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                ValueValidator.ValidateStringValue(value, "Device model");
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            private set
            {
                ValueValidator.ValidateStringValue(value, "Manufacturer");
                this.manufacturer = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                ValueValidator.ValidateDecimalValue(value, "Price");
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            private set
            {
                ValueValidator.ValidateStringValue(value, "Owner");
                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }

            private set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }

            private set
            {
                this.display = value;
            }
        }

        public GSM IPhone
        {
            get
            {
                return iPhone4S;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }

            private set
            {
                this.callHistory = value;
            }
        }

        public void DeleteCall(Call call)
        {
            this.callHistory.Remove(call);
        }

        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public decimal CalculateTotalCallsPrice(decimal pricePerMinute)
        {
            double totalDuration = 0;

            for (int i = 0; i < this.callHistory.Count; i++)
            {
                Call currentCall = this.callHistory[i];

                totalDuration += currentCall.Duration;
            }

            decimal totalPrice = (decimal)totalDuration / pricePerMinute;

            return totalPrice;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            if (this.price == 0)
            {
                result.AppendLine(string.Format("Device model: {0}{1}Manufacturer: {2}", this.model, Environment.NewLine, this.manufacturer));
            }
            else
            {
                string modelString = this.model + Environment.NewLine;
                string manufacturerString = this.manufacturer + Environment.NewLine;
                string priceString = string.Format("{0:0.00}", this.price) + Environment.NewLine;
                string ownerString = this.owner + Environment.NewLine;
                string batteryString = this.battery.ToString();
                string displayString = this.display.ToString();

                result.AppendLine(string.Format("Device model: {0}Manufacturer: {1}Price: {2}Owner: {3}Battery: {4}Display: {5}",
                    modelString, manufacturerString, priceString, ownerString, batteryString, displayString));
            }

            return result.ToString().Trim();
        }
    }
}