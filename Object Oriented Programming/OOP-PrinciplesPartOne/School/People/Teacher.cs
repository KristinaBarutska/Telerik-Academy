namespace School.People
{
    using System.Collections.Generic;

    using Contracts;

    public class Teacher : IPerson, IComment
    {
        public string Name
        {
            get; private set;
        }

        public IEnumerable<Discipline> Disciplines
        {
            get; private set;
        }

        public IEnumerable<string> Comments
        {
            get; private set;
        }
    }
}