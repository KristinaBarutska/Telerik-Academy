namespace AnimalHierarchy
{
    public class Dog : Animal, IAnimal, ISound
    {
        public Dog(string name, int age, char sex) 
            : base(name, age, sex)
        {
        }

        public override void MakeSound()
        {
            System.Console.WriteLine("Bau bau niggaz!!!!");
        }
    }
}