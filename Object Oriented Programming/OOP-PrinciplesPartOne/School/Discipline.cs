namespace School
{
    using System.Collections.Generic;

    public class Discipline : IComment
    {
        public Discipline(string name, int numberOfLectures, int numberOfExercises, IEnumerable<string> comments = null)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
            this.Comments = comments;
        }

        public string Name
        {
            get; private set;
        }

        public int NumberOfLectures
        {
            get; private set;
        }

        public int NumberOfExercises
        {
            get; private set;
        }

        public IEnumerable<string> Comments
        {
            get; private set;
        }
    }
}