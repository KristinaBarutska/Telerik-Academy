namespace School
{
    public class Teacher : Person, ICommentable
    {
        public Teacher(string name) 
            : base(name)
        {
        }
    }
}