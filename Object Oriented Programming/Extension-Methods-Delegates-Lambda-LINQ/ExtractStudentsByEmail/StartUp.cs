namespace ExtractStudentsByEmail
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
                new Student("Anna", "Velinova", "google@abv.bg"),
                new Student("Maria", "Angelova", "abv@gmail.com"),
                new Student("Stanimira", "Evlogieva", "google@yahoo.com"),
                new Student("Alexandra", "Ianeva", "abv@abv.bg"),
                new Student("Penka", "Dimitrova", "bitch@bitches.org"),
                new Student("Dimitrichka", "Dimitrichkova", "slutValley@gmail.com")
            };
            var filteredStudents = (from student in students
                                    where student.Email.Contains("abv.bg")
                                    select student).ToArray();

            foreach (var student in filteredStudents)
            {
                Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Email);
            }
        }
    }
}