/*
    Problem 2. Print Company Information
    A company has name, address, phone number, fax number, web site and manager.
    The manager has first name, last name, age and a phone number.
    Write a program that reads the information about a company and 
    its manager and prints it back on the console.
*/

namespace PrintCompanyInformation
{
    using System;

    public class InformationPrinter
    {
        public static void Main()
        {
            Console.Write("Company name : ");
            string companyName = Console.ReadLine();
            Console.Write("Company adress : ");
            string companyAdress = Console.ReadLine();
            Console.Write("Phone number : ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Fax number : ");
            string faxNumber = Console.ReadLine();
            Console.Write("Website : ");
            string webSite = Console.ReadLine();
            Console.Write("Manager's first name : ");
            string managerFirstName = Console.ReadLine();
            Console.Write("Manager's last name : ");
            string managerLastName = Console.ReadLine();
            Console.Write("Manager's age : ");
            byte managerAge = byte.Parse(Console.ReadLine());
            Console.Write("Manager's phone : ");
            string managerPhone = Console.ReadLine();

            if (string.IsNullOrEmpty(faxNumber))
            {
                faxNumber = "(no fax)";
            }

            Console.WriteLine($"Company name: {companyName}\nCompany adress: {companyAdress}\nPhone number: {phoneNumber}");
            Console.WriteLine($"Fax number: {faxNumber}\nWebsite: {webSite}\nManager's first name: {managerFirstName}");
            Console.WriteLine($"Manager's last name: {managerLastName}\nManager's age:{managerAge}\nManager's phine: {managerPhone}");
        }
    }
}