namespace OrderStudents
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

            Student[] orderedUsingExtMethods = OrderStudentsUsingExtMethods(students);
            Student[] orderedUsingLinq = OrderStudentsUsingLinq(students);

            Console.WriteLine("Students ordered using Linq: ");
            PrintStudents(orderedUsingLinq);

            Console.WriteLine(new string('=', 30));
            Console.WriteLine("Students ordered using extension methods: ");
            PrintStudents(orderedUsingExtMethods);
        }

        private static Student[] OrderStudentsUsingLinq(Student[] students)
        {
            Student[] orderedStudents = (from student in students
                                         orderby student.FirstName descending,
                                                 student.LastName descending
                                         select student).ToArray();

            return orderedStudents;
        }

        private static Student[] OrderStudentsUsingExtMethods(Student[] students)
        {
            Student[] orderedStudents = students
                .OrderByDescending(s => s.FirstName)
                .ThenByDescending(s => s.LastName)
                .ToArray();

            return orderedStudents;
        }

        private static void PrintStudents(Student[] students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
    }
}