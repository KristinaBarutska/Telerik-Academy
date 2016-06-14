namespace Group
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Student;

    public class StartUp
    {
        public static void Main()
        {
            var groups = new Group[3]
            {
                new Group(1, "Mathematics"),
                new Group(2, "Physics"),
                new Group(3, "Sports"),
            };
            var students = new List<Student>()
            {
                new Student("Anna", 1),
                new Student("Maria", 2),
                new Student("Stanimira", 1),
                new Student("Alexandra", 2),
                new Student("Penka", 3),
                new Student("Dimitrichka", 1)
            };
            var studentsFromMathematics = (from student in students
                                           join grp in groups on student.GroupNumber equals grp.GroupNumber
                                           where grp.DepartmentName.Equals("Mathematics")
                                           select student).ToArray();

            foreach (var student in studentsFromMathematics)
            {
                Console.WriteLine("{0}", student.FirstName);
            }
        }
    }
}