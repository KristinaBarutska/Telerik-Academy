namespace StudentAndCourses.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StudentsAndCourses;

    [TestClass]
    public class StudentTests
    {
        /* Student.Name test methods */
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetName_EmptyStringForName_ExpectsToThrowArgumentException()
        {
            var student = new Student(string.Empty, 10001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetName_NullForName_ExpectsToThrowArgumentNullException()
        {
            var student = new Student(null, 10001);
        }

        [TestMethod]
        public void GetName_GetValidSetName_ExpectsToReturnThisName()
        {
            string name = "Valid Student";
            var student = new Student(name, 10001);

            string expected = name;
            string actual = student.Name;

            Assert.AreEqual(
                            expected,
                            actual,
                            string.Format("The method should return {0} but instead returned {1}", expected, actual));
        }

        /* End of Student.Name test methods */

        /* Student.UniqueNumber test methods */
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetUniqueNumber_UniqueNumberUnder10000_ExpectsToThrowArgumentOutOfRangeException()
        {
            int uniqueNumber = 5;
            var student = new Student("Student", uniqueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetUniqueNumber_UniqueNumberAbove99999_ExpectsToThrowArgumentOutOfRangeException()
        {
            int uniqueNumber = 999999;
            var student = new Student("Student", uniqueNumber);
        }

        [TestMethod]
        public void GetUniqueNumber_GetValidSetUniqueNumber_ExpectsToReturnThisUniqueNumber()
        {
            int uniqueNumber = 10001;
            var student = new Student("Student", uniqueNumber);
            int expected = uniqueNumber;
            int actual = student.UniqueNumber;

            Assert.AreEqual(
                            expected,
                            actual,
                            string.Format("Method shloud return {0} but instead returned {1}", expected, actual));
        }

        /* End of Student.UniqueNumber test methods */

        /* Student.JoinCourse test methods */

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void JoinCourse_AttemptToJoinNullCourse_ExpectsToThrowInvalidOperationException()
        {
            var student = new Student("Student", 10001);

            student.JoinCourse(null);
        }

        /* End of Student.JoinCourse test methods */

        /* Student.LeaveCourse test methods */
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LeaveCourse_AttemptToLeaveNullCourse_ExpectsToThrowInvalidOperationException()
        {
            var student = new Student("Student", 10001);

            student.LeaveCourse(null);
        }

        [TestMethod]
        public void LeaveCourse_LeaveryAlreadyJoinedCourse_ExpectsToReturnTrue()
        {
            var student = new Student("Student", 10001);
            var course = new Course();

            student.JoinCourse(course);
            bool hasLeft = student.LeaveCourse(course);

            bool expected = true;
            bool actual = hasLeft;

            Assert.AreEqual(expected, actual, "The method should return true, but instead returned " + actual);
        }

        /* End of Student.JoinCourse test methods */
    }
}