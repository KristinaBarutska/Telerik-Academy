namespace ExtractStudentsByPhone
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
                new Student("Anna", "Velinova", 20, "+02 123 456"),
                new Student("Maria", "Angelova", 22 ,"21321421421"),
                new Student("Stanimira", "Evlogieva", 15,"3829132136"),
                new Student("Alexandra", "Ianeva", 40, "+02 899 13 14"),
                new Student("Penka", "Dimitrova", 60, "bitch3829132136bitches.org"),
                new Student("Dimitrichka", "Dimitrichkova", 73, "+02 899 13 14")
            };
            var filteredStudents = (from student in students
                                    where student.Tel.Contains("+02")
                                    select student).ToArray();

            foreach (var student in filteredStudents)
            {
                Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Tel);
            }
        }
    }
}