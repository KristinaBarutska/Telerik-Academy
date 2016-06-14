namespace Timer
{
    using System;

    public class StartUp
    {
        private static int executesCount = 0;

        public static void Main()
        {
            TimerEvent timerEvent = new TimerEvent(PrintMessage);
            Timer timer = new Timer(1000, 4, timerEvent);

            timer.Start();
        }

        private static void PrintMessage()
        {
            executesCount++;
            Console.WriteLine(executesCount);
        }
    }
}