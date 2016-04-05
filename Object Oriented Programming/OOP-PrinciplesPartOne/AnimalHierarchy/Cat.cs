namespace AnimalHierarchy
{
    public class Cat : Animal, IAnimal, ISound
    {
        public Cat(string name, int age, char sex) 
            : base(name, age, sex)
        {
        }

        public override void MakeSound()
        {
            System.Console.WriteLine("Myauuuuuuuuu!!!!!!");
        }
    }
}