namespace MobileDevice
{
    using System;

    public class Call
    {
        public Call(DateTime date, string time, string dialedPhoneNumber, int durationInSeconds)
        {
            this.Date = date;
            this.Time = time;
            this.DialedPhoneNumber = dialedPhoneNumber;
            this.DurationInSeconds = durationInSeconds;
        }

        public DateTime Date { get; set; }

        public string Time { get; set; }

        public string DialedPhoneNumber { get; set; }

        public int DurationInSeconds { get; set; }

        public override string ToString()
        {
            return $"Date: {this.Date.Year}.{this.Date.Month}.{this.Date.Day}, Time: {this.Time}, Dialed phone number: {this.DialedPhoneNumber}," +
                   $"Duration in seconds: {this.DurationInSeconds}";
        }
    }
}