namespace StudentsAndWorkers
{
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private static Student[] students;
        private static Worker[] workers;

        public static void Main()
        {
            InitializeStudents();
            PrintOrderedStudents();

            Console.WriteLine(new string('=', 30));

            InitializeWorkers();
            PrintOrderedWorkers();
        }

        private static void InitializeStudents()
        {
            students = new Student[10]
            {
                new Student("Ivan", "Ivanov", 4),
                new Student("Petar", "Petrov", 3),
                new Student("Georgi", "Georgiev", 5),
                new Student("Kristina", "Kristinova", 2),
                new Student("Petya", "Peteva", 9),
                new Student("Maria", "Marieva", 11),
                new Student("Dimitrichka", "Dimitrova", 1),
                new Student("Spaska", "Spasova", 12),
                new Student("Elica", "Elicova", 7),
                new Student("Genadi", "Ivanov", 6)
            };
        }

        private static void PrintOrderedStudents()
        {
            Student[] orderedStudents = students
               .OrderBy(s => s.Grade)
               .ToArray();
            StringBuilder result = new StringBuilder();

            Console.WriteLine("Students ordered by grade:");

            for (int i = 0; i < orderedStudents.Length; i++)
            {
                result.AppendLine(orderedStudents[i].ToString());
            }

            Console.WriteLine(result.ToString().TrimEnd());
        }

        private static void InitializeWorkers()
        {
            workers = new Worker[10]
            {
                new Worker("Ivan", "Ivanov", 444.3m, 8),
                new Worker("Petar", "Petrov", 333.78m, 8),
                new Worker("Georgi", "Georgiev", 255.55m, 8),
                new Worker("Kristina", "Kristinova", 244, 8),
                new Worker("Petya", "Peteva", 189.8123213m, 8),
                new Worker("Maria", "Marieva", 111.11m, 8),
                new Worker("Dimitrichka", "Dimitrova", 500m, 8),
                new Worker("Spaska", "Spasova", 600m, 8),
                new Worker("Elica", "Elicova", 799m, 8),
                new Worker("Genadi", "Ivanov", 421m, 8)
            };
        }

        private static void PrintOrderedWorkers()
        {
            Worker[] orderedWorkers = workers
               .OrderByDescending(w => w.MoneyPerHour())
               .ToArray();
            StringBuilder result = new StringBuilder();

            Console.WriteLine("Workers ordered by money per hour:");

            for (int i = 0; i < orderedWorkers.Length; i++)
            {
                result.AppendLine(orderedWorkers[i].ToString());
            }

            Console.WriteLine(result.ToString().TrimEnd());
        }
    }
}