namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private const int MinUniqueNumber = 10000;
        private const int MaxUniqueNumber = 99999;
        private const string EmptyName = "Name cannot be empty string or string with only white spaces!";
        private const string NullName = "Name cannot be null!";
        private const string InvalidUniqueNumber = "Unique number must be between 10000 and 99999!";
        private const string NullCourseToJoin = "Students cannot join course which is null!";

        private string name;
        private int uniqueNumber;

        public Student()
        {
        }

        public Student(string name, int uniqueNumber)
            : this()
        {
            this.Name = name;
            this.UniqueNumber = uniqueNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                ValidateName(value);
                this.name = value;
            }
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }

            private set
            {
                if (value < MinUniqueNumber || value > MaxUniqueNumber)
                {
                    throw new ArgumentOutOfRangeException(InvalidUniqueNumber);
                }

                this.uniqueNumber = value;
            }
        }

        public void JoinCourse(Course course)
        {
            ValidateIfCourseIsNotNull(course);
            course.AddStudent(this);
        }

        public bool LeaveCourse(Course course)
        {
            ValidateIfCourseIsNotNull(course);

            if (course.RemoveStudent(this))
            {
                return true;
            }

            return false;
        }

        private static void ValidateName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(NullName);
            }
            else if (name.Trim() == string.Empty)
            {
                throw new ArgumentException(EmptyName);
            }
        }

        private static void ValidateIfCourseIsNotNull(Course course)
        {
            if (course == null)
            {
                throw new InvalidOperationException(NullCourseToJoin);
            }
        }
    }
}