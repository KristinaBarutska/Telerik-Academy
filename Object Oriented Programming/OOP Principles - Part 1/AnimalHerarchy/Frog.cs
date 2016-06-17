namespace AnimalHerarchy
{
    using System;

    public class Frog : Animal, ISound
    {
        public Frog(string name, int age, Gender sex)
            : base(name, age, sex)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("I'm a frog!");
        }
    }
}