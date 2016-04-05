/*
    Problem 2. Students and workers
    Define abstract class Human with a first name and a last name. Define a new class Student which 
    is derived from Human and has a new field – grade. Define class Worker derived from Human with a 
    new property WeekSalary and WorkHoursPerDay and a method MoneyPerHour() that returns money earned 
    per hour by the worker. Define the proper constructors and properties for this hierarchy.
    Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
    Initialize a list of 10 workers and sort them by money per hour in descending order.
    Merge the lists and sort them by first name and last name.
*/

namespace StudentsAndWorkers
{
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static void Main()
        {
            var students = new List<Student>()
            {
                new Student("Angel", "Angelov", 2),
                new Student("Petur", "Petrov", 3),
                new Student("Ivan", "Ivanov", 2),
                new Student("Goce", "Delchev", 5),
                new Student("Teleto", "Rik", 3),
                new Student("Tele", "Rik", 4),
                new Student("Az sum", "Gabriel", 6),
                new Student("Moisei", "Angelov", 2),
                new Student("Moses", "Angelov", 4),
                new Student("Todor", "Todor", 5)
            };

            var workers = new List<Worker>()
            {
                new Worker("Angel", "Angelov", 200, 8),
                new Worker("Hasan", "Ciganina", 20, 16),
                new Worker("Petur", "Petrov", 300, 6),
                new Worker("Vutetot", "Angelov", 200, 8),
                new Worker("Naneto", "Petrov", 200, 8),
                new Worker("Tele", "Rik", 200, 8),
                new Worker("Angel", "Angelov", 200, 8),
                new Worker("Moses", "Angelov", 200, 8),
                new Worker("Todor", "Todor", 200, 8),
                new Worker("Goce", "Delchev", 200, 8)
            };

            var people = new List<Human>();

            people.AddRange(students);
            people.AddRange(workers);

            var sortedPeople = people
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .ToList();

            sortedPeople.ForEach(p => System.Console.WriteLine(p));
        }
    }
}