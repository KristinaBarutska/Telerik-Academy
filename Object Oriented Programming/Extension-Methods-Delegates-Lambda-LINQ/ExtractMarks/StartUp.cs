namespace ExtractMarks
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
                new Student("Anna", "Velinova", new List<double>() { 3, 2, 6 }, "123906321"),
                new Student("Maria", "Angelova", new List<double>() { 3, 2, 2 }, "123946321"),
                new Student("Stanimira", "Evlogieva", new List<double>() { 3, 2, 4 }, "943906381"),
                new Student("Alexandra", "Ianeva", new List<double>() { 5, 5, 6 }, "123906321"),
                new Student("Penka", "Dimitrova", new List<double>() { 3, 2, 4 }, "11111111"),
                new Student("Dimitrichka", "Dimitrichkova", new List<double>() { 2, 2, 6 }, "222222222")
            };
            var studentsMarks = students
                .Where(s => s.FN.Substring(4, 2).Equals("06"))
                .Select(s => new List<double>(s.Marks))
                .ToArray();

            foreach (var marksList in studentsMarks)
            {
                Console.WriteLine(string.Join(", ", marksList));
            }
        }
    }
}