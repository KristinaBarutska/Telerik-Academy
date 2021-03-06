﻿namespace School
{
    using System;

    public class Discipline : ICommentable
    {
        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
        }

        public string Name
        {
            get;
            private set;
        }

        public int NumberOfLectures
        {
            get;
            private set;
        }

        public int NumberOfExercises
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