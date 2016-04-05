namespace StudentsAndWorkers
{
    public class Student : Human
    {
        public Student(string firstName, string lastName, double grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public double Grade
        {
            get; private set;
        }
    }
}