namespace GenericList
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var myList = new GenericList<int>();

            for (int i = 1; i < 10; i++)
            {
                myList.Add(i);
            }

            Console.WriteLine(myList.Count);
            Console.WriteLine(myList);
            Console.WriteLine(myList.Min());
            Console.WriteLine(myList.Max());
        } 
    }
}