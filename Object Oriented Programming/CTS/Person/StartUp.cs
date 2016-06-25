namespace Person
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var person = new Person("Petraki", null);
            Console.WriteLine(person);

            var secondPerson = new Person("Goce", 20);
            Console.WriteLine(secondPerson);
        }
    }
}