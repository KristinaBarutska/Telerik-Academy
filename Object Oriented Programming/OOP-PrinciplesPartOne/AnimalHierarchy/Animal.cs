namespace AnimalHierarchy
{
    public abstract class Animal : IAnimal, ISound 
    {
        public Animal(string name, int age, char sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public string Name
        {
            get; private set;
        }

        public int Age
        {
            get; private set;
        }

        public char Sex
        {
            get; private set;
        }

        public abstract void MakeSound();
    }
}