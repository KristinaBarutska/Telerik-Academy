namespace StudentAndCourses.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StudentsAndCourses;

    [TestClass]
    public class SchoolTests
    {
        /* School.AddStudent() tests */

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStudent_AddNullAsStudent_ExpectsToThrowArgumentNullException()
        {
            var school = new School();

            school.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddStudent_AddTheSameStudentTwice_ExpectsToThrowInvalidOperationException()
        {
            var school = new School();
            var student = new Student("Student", 10001);

            school.AddStudent(student);
            school.AddStudent(student);
        }

        [TestMethod]
        public void AddStudent_AddValidStudent_ExpectsToReturnTrue()
        {
            var school = new School();
            var student = new Student("Student", 10001);

            bool isAdded = school.AddStudent(student);
            bool expected = true;
            bool actual = isAdded;

            Assert.AreEqual(expected, actual, string.Format("Expects to return True but the method returned {0}", actual));
        }

        /* End of School.AddStudent() tests */

        /* School.RemoveStudent() tests */
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveStudent_RemoveNullStudent_ExpectsToThrowArgumentNullException()
        {
            var school = new School();

            school.RemoveStudent(null);
        }

        [TestMethod]
        public void RemoveStudent_RemoveNonExistingStudent_ExpectsToReturnFalse()
        {
            var school = new School();
            var student = new Student("Non-existing", 10001);

            bool isRemoved = school.RemoveStudent(student);

            bool expected = false;
            bool actual = isRemoved;

            Assert.AreEqual(
                            expected,
                            actual,
                            "If non existing student is passed the expected return value is False, but the method returned " + actual);
        }

        [TestMethod]
        public void RemoveStudent_RemoveValidStudent_ExpectsToReturnTrue()
        {
            var school = new School();
            var student = new Student("Non-existing", 10001);

            school.AddStudent(student);
            bool isRemoved = school.RemoveStudent(student);

            bool expected = true;
            bool actual = isRemoved;

            Assert.AreEqual(
                            expected,
                            actual,
                            "If valid student is passed the expected return value is True, but the method returned " + actual);
        }

        /* End ofSchool.RemoveStudent() tests */

        /* School.AddCourse() tests */

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddCourse_AddNullAsCourse_ExpectsToThrowArgumentNullException()
        {
            var school = new School();

            school.AddCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddCourse_AddTheSameCourseTwice_ExpectsToThrowInvalidOperationException()
        {
            var school = new School();
            var course = new Course();

            course.AddStudent(new Student("Student", 10001));
            school.AddCourse(course);
            school.AddCourse(course);
        }

        [TestMethod]
        public void AddCourse_AddValidCourse_ExpectsToReturnTrue()
        {
            var school = new School();
            var course = new Course();

            bool isAdded = course.AddStudent(new Student("Student", 10001));
            bool expected = true;
            bool actual = isAdded;

            Assert.AreEqual(expected, actual, string.Format("Expects to return True but the method returned {0}", actual));
        }

        /* End of School.AddCourse() tests */

        /* School.RemoveCourse() tests */

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveCourse_RemoveNullCourse_ExpectsToThrowArgumentNullException()
        {
            var school = new School();

            school.RemoveCourse(null);
        }

        [TestMethod]
        public void RemoveCourse_RemoveNonExistingCourse_ExpectsToReturnFalse()
        {
            var school = new School();
            var course = new Course();

            bool isRemoved = school.RemoveCourse(course);

            bool expected = false;
            bool actual = isRemoved;

            Assert.AreEqual(
                            expected, 
                            actual,
                            "If non existing course is passed the expected return value is False, but the method returned " + actual);
        }

        [TestMethod]
        public void RemoveCourse_RemoveValidCourse_ExpectsToReturnTrue()
        {
            var school = new School();
            var course = new Course();

            school.AddCourse(course);
            bool isRemoved = school.RemoveCourse(course);

            bool expected = true;
            bool actual = isRemoved;

            Assert.AreEqual(
                            expected, 
                            actual,
                            "If valid course is passed the expected return value is True, but the method returned " + actual);
        }

        /* End ofSchool.RemoveCourse() tests */
    }
}