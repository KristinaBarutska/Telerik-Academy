namespace AnimalHerarchy
{
    using System.Collections.Generic;

    public abstract class Animal : ISound
    {
        public Animal(string name, int age, Gender sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public string Name
        {
            get;
            private set;
        }

        public int Age
        {
            get;
            private set;
        }

        public Gender Sex
        {
            get;
            private set;
        }

        public static double GetAverageAge(IEnumerable<Animal> animalsOfKind)
        {
            double totalAge = 0;
            int animalsCount = 0;

            foreach (Animal animal in animalsOfKind)
            {
                totalAge += animal.Age;
                animalsCount++;
            }

            return totalAge / animalsCount;
        }

        public abstract void ProduceSound();
    }
}