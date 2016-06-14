namespace Timer
{
    using System;
    using System.Threading;

    public delegate void TimerEvent();

    public class Timer
    {
        private int count;
        private int interval;

        public Timer(int count, int interval, TimerEvent timerEvent)
        {
            this.Count = count;
            this.Interval = interval;
            this.TimerEvent = timerEvent;
            this.Ticks = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                ValidateValue(value, "Count");
                this.count = value;
            }
        }

        public int Interval
        {
            get
            {
                return this.interval;
            }

            private set
            {
                ValidateValue(value, "Interval");
                this.interval = value;
            }
        }

        public TimerEvent TimerEvent
        {
            get;
            private set;
        }

        public int Ticks
        {
            get;
            private set;
        }

        public void Start()
        {
            while (this.Ticks < this.Count)
            {
                Thread.Sleep(this.Interval);
                this.Ticks++;
                this.TimerEvent();
            }
        }

        private static void ValidateValue(int value, string propertyName)
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format("The {0} must be non-negative ot equals to 0 number!", propertyName));
            }
        }
    }
}
