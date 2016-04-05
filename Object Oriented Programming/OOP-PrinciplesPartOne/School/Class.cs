namespace School
{
    using System.Collections.Generic;

    using People;

    public class Class : IComment
    {
        public Class(string textIdentifier, IEnumerable<Teacher> teachers, IEnumerable<string> comments = null)
        {
            this.TextIdentifier = textIdentifier;
            this.Teachers = teachers;
            this.Comments = comments;
        }

        public string TextIdentifier
        {
            get; private set;
        }

        public IEnumerable<Teacher> Teachers
        {
            get; private set;
        }

        public IEnumerable<string> Comments
        {
            get; private set;
        }
    }
}