namespace StudentsAndWorkers
{
    public class Student : Human
    {
        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} Grade: {2}", this.FirstName, this.LastName, this.Grade);
        }
    }
}