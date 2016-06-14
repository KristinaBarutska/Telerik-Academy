namespace GroupedByGroupNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Extensions;
    using Student;

    public class StartUp
    {
        public static void Main()
        {
            var students = new List<Student>()
            {
                new Student("Anna", 1),
                new Student("Maria", 2),
                new Student("Stanimira", 3),
                new Student("Alexandra", 2),
                new Student("Penka", 3),
                new Student("Dimitrichka", 1)
            };

            var groupedStudents = (from student in students
                                   orderby student.GroupNumber
                                   select student).ToList();

            var groupedStudentsUsingExtension = students.GroupStudentsByGroupNumber();

            PrintStudents(groupedStudents);
            Console.WriteLine(new string('=', 30));
            PrintStudents(groupedStudentsUsingExtension);
        }

        private static void PrintStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine("Name: {0}; Group Number: {1}", student.FirstName, student.GroupNumber);
            }
        }
    }
}