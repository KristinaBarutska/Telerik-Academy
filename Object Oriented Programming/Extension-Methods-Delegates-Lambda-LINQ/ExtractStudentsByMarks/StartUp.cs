namespace ExtractStudentsByMarks
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Student;

    public class StartUp
    {
        public static void Main()
        {
            var students = new List<Student>()
            {
                new Student("Anna", "Velinova", new List<double>() { 3, 2, 6}),
                new Student("Maria", "Angelova", new List<double>() { 3, 2, 2}),
                new Student("Stanimira", "Evlogieva", new List<double>() { 3, 2, 4}),
                new Student("Alexandra", "Ianeva", new List<double>() { 5, 5, 6}),
                new Student("Penka", "Dimitrova", new List<double>() { 3, 2, 4}),
                new Student("Dimitrichka", "Dimitrichkova", new List<double>() { 2, 2, 6})
            };
            var filteredStudents = (from student in students
                                    where student.Marks.Any(m => m == 6)
                                    select new
                                    {
                                        FullName = string.Format("{0} {1}", student.FirstName, student.LastName),
                                        Marks = student.Marks
                                    }).ToArray();

            foreach (var student in filteredStudents)
            {
                Console.WriteLine("{0} {1}", student.FullName, string.Join(", ", student.Marks));
            }
        }
    }
}