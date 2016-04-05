namespace AnimalHierarchy
{
    public class Frog : Animal, IAnimal, ISound
    {
        public Frog(string name, int age, char sex)
            : base(name, age, sex)
        {
        }

        public override void MakeSound()
        {
            System.Console.WriteLine("Kvaaak");
        }
    }
}