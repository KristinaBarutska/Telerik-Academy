namespace School
{
    public abstract class Person : ICommentable
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name
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