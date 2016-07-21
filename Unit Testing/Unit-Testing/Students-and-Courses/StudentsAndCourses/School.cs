namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private const string ObjectCannotBeNull = "{0} cannot be null!";
        private const string ObjectAlreadyExists = "This {0} already exists!";
        private const string StudentString = "Student";
        private const string CourseString = "Course";

        private readonly ICollection<Student> students;
        private readonly ICollection<Course> courses;

        public School()
        {
            this.students = new List<Student>();
            this.courses = new List<Course>();
        }

        public ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public bool AddStudent(Student student)
        {
            ValidateIfObjectIsNotNull(student, StudentString);
            CheckIfObjectAlreadyExists<Student>(this.Students, student, StudentString);
            this.Students.Add(student);
            return true;
        }

        public bool RemoveStudent(Student student)
        {
            ValidateIfObjectIsNotNull(student, StudentString);
            return this.Students.Remove(student);
        }

        public bool AddCourse(Course course)
        {
            ValidateIfObjectIsNotNull(course, CourseString);
            CheckIfObjectAlreadyExists(this.Courses, course, CourseString);
            this.Courses.Add(course);
            return true;
        }

        public bool RemoveCourse(Course course)
        {
            ValidateIfObjectIsNotNull(course, CourseString);
            return this.Courses.Remove(course);
        }

        private static void ValidateIfObjectIsNotNull(object objectToValidate, string objectName)
        {
            if (objectToValidate == null)
            {
                throw new ArgumentNullException(string.Format(ObjectCannotBeNull, objectName));
            }
        }

        private static void CheckIfObjectAlreadyExists<T>(ICollection<T> collection, T objectToCheck, string objectName)
        {
            if (collection.Contains(objectToCheck))
            {
                throw new InvalidOperationException(string.Format(ObjectAlreadyExists, objectName));
            }
        }
    }
}