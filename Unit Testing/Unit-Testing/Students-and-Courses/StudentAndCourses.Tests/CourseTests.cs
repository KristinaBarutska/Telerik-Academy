namespace StudentAndCourses.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StudentsAndCourses;

    [TestClass]
    public class CourseTests
    {
        /* Course:AddStudent() test methods */

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddStudent_AddMoredThan29Students_ExpectsToThrowInvalidOperationException()
        {
            var course = new Course();

            for (int i = 0; i < 40; i++)
            {
                course.AddStudent(new Student(i.ToString(), i + 10001));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStudent_AddNullStudent_ExpectsToThrowArgumentNullException()
        {
            var course = new Course();

            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddStudent_AddStudentMoreThanOnce_ExpectsToThrowInvalidOperationException()
        {
            var course = new Course();
            var student = new Student("Test Method is my name in real life", 77777);

            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        public void AddStudent_AddStudentSuccessfuly_ExpectsToReturnTrue()
        {
            var course = new Course();
            var student = new Student("SadStudent", 10001);
            
            bool expected = true;
            bool actual = course.AddStudent(student);

            Assert.AreEqual(expected, actual, "After successful added student the method should return true.");
        }

        /* End of Course:AddStudent() test methods */

        /* Course:RemoveStudent() test methods */

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveStudent_RemoveNullStudent_ExpectsToThrowArgumentNullException()
        {
            var course = new Course();

            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveStudent_RemoveStudentThatDoesNotExists_ExpectsToThrowInvalidOperationException()
        {
            var course = new Course();
            var firstStudent = new Student("Maxim", 10001);
            var secontStudent = new Student("NotMaxim", 10002);

            course.AddStudent(firstStudent);
            course.RemoveStudent(secontStudent);
        }

        [TestMethod]
        public void RemoveStudent_SuccessfulyRemoveStudent_ExpectsToReturnTrue()
        {
            var course = new Course();
            var student = new Student("NewStudent", 10001);

            course.AddStudent(student);

            bool expected = true;
            bool actual = course.RemoveStudent(student);

            Assert.AreEqual(expected, actual, "After successfuly removed student the method should return true.");
        }

        /* End of Course:RemoveStudent() test methods */
    }
}