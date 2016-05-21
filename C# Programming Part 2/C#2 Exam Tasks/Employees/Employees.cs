namespace Employees
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class Employee
    {
        public Employee(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get;
            private set;
        }

        public string LastName
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }

    public class Employees
    {
        private static SortedDictionary<int, List<string>> positionsByRating = new SortedDictionary<int, List<string>>();
        private static Dictionary<string, List<Employee>> peopleByPositions = new Dictionary<string, List<Employee>>();
        private static List<Employee> totalOrderedEmployees = new List<Employee>();

        public static void Main()
        {
            GetPositionsByRating();

            GetPeopleByPosition();

            GetOrderedPeople();
            
            PrintEmployees();
        }

        private static void PrintEmployees()
        {
            StringBuilder result = new StringBuilder();

            foreach (var employee in totalOrderedEmployees)
            {
                result.AppendLine(employee.ToString());
            }

            Console.WriteLine(result.ToString().Trim());
        }

        private static void GetPositionsByRating()
        {
            int numberOfPositions = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPositions; i++)
            {
                string[] lineTokens = Console.ReadLine()
                    .Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                string position = lineTokens[0];
                int rating = int.Parse(lineTokens[1]);

                if (!positionsByRating.ContainsKey(rating))
                {
                    positionsByRating.Add(rating, new List<string>());
                }

                positionsByRating[rating].Add(position);
            }
        }

        private static void GetPeopleByPosition()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] lineTokens = Console.ReadLine()
                    .Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                string[] names = lineTokens[0].Split(' ');
                string position = lineTokens[1];

                Employee currentEmployee = new Employee(names[0], names[1]);

                if (!peopleByPositions.ContainsKey(position))
                {
                    peopleByPositions.Add(position, new List<Employee>());
                }

                peopleByPositions[position].Add(currentEmployee);
            }
        }

        private static void GetOrderedPeople()
        {
            foreach (var pair in positionsByRating.Reverse())
            {
                List<string> currentRatingPositions = pair.Value;
                List<Employee> currentRatingEmployees = new List<Employee>();

                foreach (var position in currentRatingPositions)
                {
                    try
                    {
                        List<Employee> currentPositionEmployees = peopleByPositions[position];
                        currentRatingEmployees.AddRange(currentPositionEmployees);
                    }
                    catch (KeyNotFoundException)
                    {
                        continue;
                    }
                }

                List<Employee> currentOrderedEmployees = currentRatingEmployees
                    .OrderBy(e => e.LastName)
                    .ThenBy(e => e.FirstName)
                    .ToList();

                totalOrderedEmployees.AddRange(currentOrderedEmployees);
            }
        }
    }
}