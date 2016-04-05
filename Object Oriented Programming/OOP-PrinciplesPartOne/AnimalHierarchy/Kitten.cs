namespace AnimalHierarchy
{
    public class Kitten : Cat, IAnimal, ISound
    {
        private new const char Sex = 'F';

        public Kitten(string name, int age) 
            : base(name, age, Sex)
        {
        }
    }
}