namespace Student
{
    using System.Collections.Generic;

    public class Student
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Student(string firstName, string lastName, int age)
            : this(firstName, lastName)
        {
            this.Age = age;
        }

        public Student(string firstName, string lastName, long groupNumber)
            : this(firstName, lastName)
        {
            this.GroupNumber = groupNumber;
        }

        public Student(string firstName, string lastName, string email)
           : this(firstName, lastName)
        {
            this.Email = email;
        }

        public Student(string firstName, string lastName, int age, string telephoneNumber)
            : this(firstName, lastName, age)
        {
            this.Tel = telephoneNumber;
        }

        public Student(string firstName, string lastName, List<double> marks)
            : this(firstName, lastName)
        {
            this.Marks = marks;
        }

        public Student(string firstName, string lastName, List<double> marks, string fn)
            : this(firstName, lastName, marks)
        {
            this.FN = fn;
        }

        public Student(string firstName, int groupNumber)
        {
            this.FirstName = firstName;
            this.GroupNumber = groupNumber;
        }

        public string FirstName
        {
            get;
            private set;
        }

        public string LastName
        {
            get;
            private set;
        }

        public int Age
        {
            get;
            private set;
        }

        public string FN
        {
            get;
            private set;
        }

        public string Tel
        {
            get;
            private set;
        }

        public string Email
        {
            get;
            private set;
        }

        public List<double> Marks
        {
            get;
            private set;
        }

        public long GroupNumber
        {
            get;
            private set;
        }
    }
}