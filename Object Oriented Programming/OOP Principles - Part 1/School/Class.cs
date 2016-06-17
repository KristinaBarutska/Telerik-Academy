namespace School
{
    using System.Collections.Generic;

    public class Class : ICommentable
    {
        public Class(string id)
        {
            this.Teachers = new List<Teacher>();
            this.Id = id;
        }

        public List<Teacher> Teachers
        {
            get;
            private set;
        }

        public string Id
        {
            get;
            private set;
        }

        public string Comment
        {
            get;
            set;
        }
    }
}