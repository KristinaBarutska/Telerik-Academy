namespace School.People
{
    using System.Collections.Generic;

    using Contracts;
    
    public class Student : IPerson, IComment
    {
        public Student(string name, int classNumber, IEnumerable<string> comments = null)
        {
            this.Name = name;
            this.ClassNumber = classNumber;
            this.Comments = comments;
        }

        public string Name
        {
            get; private set;
        }

        public int ClassNumber
        {
            get; private set;
        }

        public IEnumerable<string> Comments
        {
            get; private set;
        }
    }
}