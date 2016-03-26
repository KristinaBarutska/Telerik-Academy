/*
    Problem 10. Employee Data
    A marketing company wants to keep record of its employees. Each record would have the following characteristics:
    First name
    Last name
    Age (0...100)
    Gender (m or f)
    Personal ID number (e.g. 8306112507)
    Unique employee number (27560000…27569999)
    Declare the variables needed to keep the information for a single employee using appropriate primitive data
    types. Use descriptive names. Print the data at the console.
*/

namespace EmployeeData
{
    using System;

    public class EmployeeData
    {
        public static void Main()
        {
            Console.Write("Employee's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Employee's last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Employee's age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Employee's gender: ");
            char gender = char.Parse(Console.ReadLine());
            Console.Write("Employee's number: ");
            int uniqueEmployeeNumber = int.Parse(Console.ReadLine());
            Console.Write("Personal ID: ");
            string personalID = Console.ReadLine();

            Console.WriteLine($"Employee's first name: {firstName}");
            Console.WriteLine($"Employee's last name: {lastName}");
            Console.WriteLine($"Employee's age: {age}");
            Console.WriteLine($"Employee's gender: {gender}");
            Console.WriteLine($"Employee's unique number: {uniqueEmployeeNumber}");
            Console.WriteLine($"Employee's personal ID: {personalID}");
        }
    }
}