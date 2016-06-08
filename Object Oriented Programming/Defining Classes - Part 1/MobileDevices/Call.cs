namespace MobileDevices
{
    using System;

    public class Call
    {
        private DateTime date;
        private string dialedPhone;
        private double duration;

        public Call(DateTime date, string dialedPhone, double duration)
        {
            this.date = date;
            this.dialedPhone = dialedPhone;
            this.duration = duration;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            private set
            {
                ValueValidator.ValidateObjectValue(value, "Call date");
                this.date = value;
            }
        }

        public string DialedPhone
        {
            get
            {
                return this.dialedPhone;
            }

            private set
            {
                ValueValidator.ValidateStringValue(value, "Dialed phone");
                this.dialedPhone = value;
            }
        }

        public double Duration
        {
            get
            {
                return this.duration;
            }

            private set
            {
                ValueValidator.ValidateDoubleValue(value, "Duration");
                this.duration = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Date: {0}{1}Dialed phone: {2}{3}Duration: {4:0.00}{5}",
                this.date, Environment.NewLine, this.dialedPhone, Environment.NewLine, this.duration, Environment.NewLine);
        }
    }
}