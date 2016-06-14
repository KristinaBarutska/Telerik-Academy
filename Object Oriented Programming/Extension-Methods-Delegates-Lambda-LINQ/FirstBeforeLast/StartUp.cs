namespace FirstBeforeLast
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
                new Student("Anna", "Velinova"),
                new Student("Maria", "Angelova"),
                new Student("Stanimira", "Evlogieva"),
                new Student("Alexandra", "Ianeva")
            };

            Student[] filteredStudents = (from student in students
                                          where student.FirstName.CompareTo(student.LastName) < 0
                                          select student).ToArray();

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }
    }
}