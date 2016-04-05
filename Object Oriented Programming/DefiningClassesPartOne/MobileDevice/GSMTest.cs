namespace MobileDevice
{
    using System;

    public class GSMTest
    {
        public static void Main()
        {
            //Test Devices
            var devices = new GSM[3]
            {
                new GSM("3110", "Nokia"),
                new GSM("Galaxy S6", "Samsung", 1100, "Random owner"),
                new GSM("Desire 816", "HTC", 600, "Az", new Battery("Krugla", 5, 5, BatteryType.LiIon),
                new Display(5.5, 16000000))
            };
            var iphone = new GSM(null, null).IPhone;

            foreach (var device in devices)
            {
                Console.WriteLine(device);
                Console.WriteLine(new string('-', 100));
            }

            Console.WriteLine($"Ultra IPhone: {iphone}");
            Console.WriteLine(new string('=', 100));
            // Test Calls
            var myGsm = new GSM("Desire 816", "HTC");

            myGsm.AddCall(new DateTime(2016, 12, 11), "12:41", "+359 899 123 456", 600);
            myGsm.AddCall(new DateTime(2014, 10, 08), "05:22", "+359 899 123 456", 900);
            myGsm.AddCall(new DateTime(2014, 10, 08), "05:22", "+359 899 123 456", 900);
            myGsm.AddCall(new DateTime(2014, 10, 08), "05:22", "+359 899 123 456", 900);
            myGsm.AddCall(new DateTime(2014, 10, 08), "05:22", "+359 899 123 456", 1000);

            foreach (var call in myGsm.PerformedCalls)
            {
                Console.WriteLine(call);
                Console.WriteLine(new string('-', 100));
            }

            Console.WriteLine();
            Console.WriteLine("With longest call deleted : ");

            var totalPriceOfCalls = myGsm.CalculateTotalCallPrice(0.37);
            Console.WriteLine($"Total price of calls: {totalPriceOfCalls:0.00}");

            myGsm.DeleteLongestCall();

            foreach (var call in myGsm.PerformedCalls)
            {
                Console.WriteLine(call);
                Console.WriteLine(new string('-', 100));
            }

            myGsm.DeleteCalls();

            foreach (var call in myGsm.PerformedCalls)
            {
                Console.WriteLine(call);
                Console.WriteLine(new string('-', 100));
            }
        }
    }
}