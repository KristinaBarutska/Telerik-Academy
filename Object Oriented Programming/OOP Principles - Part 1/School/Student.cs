namespace School
{
    public class Student : Person, ICommentable
    {
        public Student(string name, string uniqueClassNumber) 
            : base(name)
        {
            this.UniqueClassNumber = uniqueClassNumber;
        }

        public string UniqueClassNumber
        {
            get;
            private set;
        }
    }
}