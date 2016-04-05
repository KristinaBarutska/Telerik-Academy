namespace AnimalHierarchy
{
    public class Tomcat : Cat, ISound, IAnimal
    {
        private new const char Sex = 'M';

        public Tomcat(string name, int age) 
            : base(name, age, Sex)
        {
        }
    }
}