namespace MobileDevices
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            TestDevice();

            Console.WriteLine(new string('=', 30));

            TestCallHistory();
        }

        private static void TestDevice()
        {
            GSM[] mobileDevices =
            {
                new GSM("Desire 816", "HTC"),
                new GSM("M8", "HTC", 800m, "Anonymous", new Battery("Secret model"), new Display(5.5))
            };

            PrintMobileDevicesInfo(mobileDevices);
            Console.WriteLine(new string('-', 30));
            Console.WriteLine(mobileDevices[0].IPhone);
        }

        private static void PrintMobileDevicesInfo(GSM[] mobileDevices)
        {
            for (int i = 0; i < mobileDevices.Length; i++)
            {
                GSM currentDevice = mobileDevices[i];

                Console.WriteLine(currentDevice + Environment.NewLine);
            }
        }

        private static void TestCallHistory()
        {
            GSM device = new GSM("3110", "Nokia");

            device.AddCall(new Call(new DateTime(2016, 12, 3), "+359 899 345 613", 123));
            device.AddCall(new Call(new DateTime(2015, 8, 3), "+359 899 345 613", 4.3));
            device.AddCall(new Call(new DateTime(2014, 11, 9), "+359 899 345 613", 88.99123));

            Console.WriteLine("Total price of all calls: {0:0.00}", device.CalculateTotalCallsPrice(33.921321m));

            device.DeleteCall(device.CallHistory[2]);
            device.ClearCallHistory();
        }
    }
}