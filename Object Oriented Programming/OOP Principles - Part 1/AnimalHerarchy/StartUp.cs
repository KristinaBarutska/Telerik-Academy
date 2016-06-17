namespace AnimalHerarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            IEnumerable<Animal> dogs = new Animal[]
            {
                new Dog("Rex", 5, Gender.Male),
                new Dog("Lolly", 4, Gender.Female)
            };

            IEnumerable<Animal> frogs = new Animal[]
            {
                new Frog("Prince", 3, Gender.Male),
                new Frog("Princess", 4, Gender.Female),
            };

            IEnumerable<Animal> cats = new Animal[]
            {
                new Kitten("Becky", 5),
                new Tomcat("Josh", 6)
            };

            double dogsAverageAge = Animal.GetAverageAge(dogs);
            double frogsAverageAge = Animal.GetAverageAge(frogs);
            double catsAverageAge = Animal.GetAverageAge(cats);

            Console.WriteLine("Dogs average age: {0:0.0}", dogsAverageAge);
            Console.WriteLine("Frogs average age: {0:0.0}", frogsAverageAge);
            Console.WriteLine("Cats average age: {0:0.0}", catsAverageAge);
        }
    }
}