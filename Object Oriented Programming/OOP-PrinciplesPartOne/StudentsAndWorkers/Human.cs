namespace StudentsAndWorkers
{
    public abstract class Human
    {
        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get; private set;
        }

        public string LastName
        {
            get; private set;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}