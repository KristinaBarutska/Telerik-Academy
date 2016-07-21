namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course
    {
        private const int MaxStudentsInCourse = 29;
        private const string AvailableStudentsPositionsExceeded = "The maximum number student in a course is 29. Student cannot be added!";
        private const string NullStudent = "Student cannot be null!";
        private const string StudenAlreadyExists = "This student has already joined this course!";
        private const string StudentDoesNotExist = "This student does not exist in this course!";

        private ICollection<Student> students;

        public Course()
        {
            this.students = new List<Student>();
        }

        public ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public bool AddStudent(Student student)
        {
            ValidateIfStudentIsNotNull(student);

            if (this.Students.Count > MaxStudentsInCourse)
            {
                throw new InvalidOperationException(AvailableStudentsPositionsExceeded);
            }
            else if (this.Students.Any(s => s == student))
            {
                throw new InvalidOperationException(StudenAlreadyExists);
            }
            else
            {
                this.Students.Add(student);
                return true;
            }
        }

        public bool RemoveStudent(Student student)
        {
            ValidateIfStudentIsNotNull(student);

            bool isRemoved = this.Students.Remove(student);

            if (!isRemoved)
            {
                throw new InvalidOperationException(StudentDoesNotExist);
            }

            return isRemoved;
        }

        private static void ValidateIfStudentIsNotNull(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(NullStudent);
            }
        }
    }
}