namespace GenericList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            GenericList<int> list = new GenericList<int>(4);

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            list.Insert(2, 11);

            list.RemoveAt(2);

            Console.WriteLine(list.Min());
            Console.WriteLine(list.Max());
        }
    }
}