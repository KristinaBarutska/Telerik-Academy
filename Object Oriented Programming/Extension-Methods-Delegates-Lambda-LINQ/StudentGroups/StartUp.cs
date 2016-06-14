namespace StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

            Student[] filteredStudents = GetStudentsFromGroup(students, 2);

            for (int i = 0; i < filteredStudents.Length; i++)
            {
                Student student = filteredStudents[i];
                Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.GroupNumber);
            }
        }

        private static Student[] GetStudentsFromGroup(List<Student> students, long group)
        {
            Student[] filteredStudents = (from student in students
                                          where student.GroupNumber == 2
                                          orderby student.FirstName
                                          select student).ToArray();

            return filteredStudents;
        }
    }
}