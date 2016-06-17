namespace AnimalHerarchy
{
    using System;

    public abstract class Cat : Animal, ISound
    {
        public Cat(string name, int age, Gender sex)
            : base(name, age, sex)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("I'm a Cat!");
        }
    }
}