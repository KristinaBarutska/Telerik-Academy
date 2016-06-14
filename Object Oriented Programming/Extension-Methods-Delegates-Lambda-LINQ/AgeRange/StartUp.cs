namespace AgeRange
{
    using System;
    using System.Linq;

    using Student;

    public class StartUp
    {
        public static void Main()
        {
            Student[] students = new Student[4]
            {
                new Student("Anna", "Velinova", 20),
                new Student("Maria", "Angelova", 10),
                new Student("Stanimira", "Evlogieva", 30),
                new Student("Alexandra", "Ianeva", 23)
            };

            Student[] studentsFilteredByAge = (from student in students
                                               where student.Age >= 18 && student.Age <= 24
                                               select student).ToArray();

            foreach (Student student in studentsFilteredByAge)
            {
                Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Age);
            }
        }
    }
}