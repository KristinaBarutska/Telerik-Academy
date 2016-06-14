namespace ExtractStudentsWithTwoMarks
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
                new Student("Anna", "Velinova", new List<double>() { 3, 2, 6, 2 }),
                new Student("Maria", "Angelova", new List<double>() { 3, 2, 2 }),
                new Student("Stanimira", "Evlogieva", new List<double>() { 3, 2, 4 }),
                new Student("Alexandra", "Ianeva", new List<double>() { 5, 5, 6 }),
                new Student("Penka", "Dimitrova", new List<double>() { 3, 2, 4 }),
                new Student("Dimitrichka", "Dimitrichkova", new List<double>() { 2, 2, 6 })
            };
            var filteredStudents = students
                .Where(s => s.Marks.Count(m => m == 2) == 2)
                .ToArray();

            foreach (var student in filteredStudents)
            {
                Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, string.Join(", ", student.Marks));
            }
        }
    }
}