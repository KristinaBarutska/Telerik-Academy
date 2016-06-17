namespace AnimalHerarchy
{
    using System;

    public class Dog : Animal, ISound
    {
        public Dog(string name, int age, Gender sex)
            : base(name, age, sex)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("I'm a dog!");
        }
    }
}