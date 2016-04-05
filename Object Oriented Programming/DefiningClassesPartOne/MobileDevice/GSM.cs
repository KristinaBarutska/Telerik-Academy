namespace MobileDevice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GSM
    {
        private static readonly GSM iPhone = new GSM("IPhone", "Apple", 1000, "Lorenco",
            new Battery("Some crazy battery model"), new Display(5.5, 16000000));
        private string model;
        private string manufacturer;
        private double price;
        private string owner;
        private Battery battery;
        private Display display;

        public GSM(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.PerformedCalls = new List<Call>();
        }

        public GSM(string model, string manufacturer, double price)
            : this(model, manufacturer)
        {
            this.price = price;
        }

        public GSM(string model, string manufacturer, double price, string owner)
            : this(model, manufacturer, price)
        {
            this.owner = owner;
        }

        public GSM(string model, string manufacturer, double price, string owner,
            Battery battery, Display display)
            : this(model, manufacturer, price, owner)
        {
            this.battery = battery;
            this.display = display;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                ValueValidator.ValidateString(value, "GSM Model");
                this.model = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                ValueValidator.ValidateNumber(value, "GSM Price");
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                ValueValidator.ValidateString(value, "GSM Owner");
                this.owner = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                ValueValidator.ValidateString(value, "GSM Manufacturer");
                this.manufacturer = value;
            }
        }

        public GSM IPhone
        {
            get
            {
                return iPhone;
            }
        }

        public List<Call> PerformedCalls
        {
            get;
            private set;
        }

        public void AddCall(DateTime date, string time, string dialedPhoneNumber, int durationInSeconds)
        {
            var call = new Call(date, time, dialedPhoneNumber, durationInSeconds);

            this.PerformedCalls.Add(call);
        }

        public void DeleteLongestCall()
        {
            this.PerformedCalls.Sort((x,y) => x.DurationInSeconds.CompareTo(y.DurationInSeconds));
            this.PerformedCalls.Remove(this.PerformedCalls[this.PerformedCalls.Count - 1]);
        }

        public void DeleteCalls()
        {
            this.PerformedCalls.Clear();
        }

        public double CalculateTotalCallPrice(double pricePerMinute)
        {
            return PerformedCalls.Sum(call => (call.DurationInSeconds / 60) * pricePerMinute);
        }

        public override string ToString()
        {
            if (this.price == 0 && string.IsNullOrEmpty(this.owner) && this.battery == null && this.display == null)
            {
                return $"GSM: Model {this.model}, Manufacturer {this.manufacturer}";
            }
            else if (string.IsNullOrEmpty(this.owner) && this.battery == null && this.display == null)
            {
                return $"GSM: Model {this.model}, Manufacturer {this.manufacturer}, Price {this.price:0.00}";
            }
            else if (this.battery == null && this.display == null)
            {
                return $"GSM: Model {this.model}, Manufacturer {this.manufacturer}," +
                       $" Price {this.price:0.00}, Owner: {this.owner}";
            }
            else if (this.display == null)
            {
                return $"GSM: Model {this.model}, Manufacturer {this.manufacturer}, Price {this.price}," +
                       $" Owner: {this.owner}, Battery {this.battery}";
            }
            else
            {
                return $"GSM: Model {this.model}, Manufacturer {this.manufacturer}, Price {this.price:0.00}," +
                       $" Owner: {this.owner}, {this.battery}, {this.display}";
            }
        }
    }
}