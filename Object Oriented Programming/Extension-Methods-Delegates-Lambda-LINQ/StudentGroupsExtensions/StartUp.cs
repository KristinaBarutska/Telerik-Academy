namespace StudentGroupsExtensions
{
    using System;
    using System.Collections.Generic;

    using Extensions;
    using Student;

    public class StartUp
    {
        public static void Main()
        {
            var students = new List<Student>()
            {
                new Student("Anna", "Velinova", (long)2),
                new Student("Maria", "Angelova", (long)19),
                new Student("Stanimira", "Evlogieva", (long)3),
                new Student("Alexandra", "Ianeva", (long)2),
                new Student("Penka", "Dimitrova", (long)14),
                new Student("Dimitrichka", "Dimitrichkova", (long)2)
            };
            List<Student> filteredStudents = students.GetStudentsFromGroup(2);

            for (int i = 0; i < filteredStudents.Count; i++)
            {
                Student student = filteredStudents[i];
                Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.GroupNumber);
            }
        }
    }
}