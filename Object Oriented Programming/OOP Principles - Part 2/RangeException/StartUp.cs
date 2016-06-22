namespace RangeException
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                throw new InvalidRangeException<int>("Invalid elements!", 1, 100);
            }
            catch (InvalidRangeException<int> ire)
            {
                Console.WriteLine(ire.Message);
            }

            try
            {
                throw new InvalidRangeException<DateTime>("Invalid date paramaters!", new DateTime(1980, 1, 1), DateTime.Now);
            }
            catch (InvalidRangeException<DateTime> ire)
            {
                Console.WriteLine(ire.Message);
            }
        }
    }
}