/*
    Problem 11. Bank Account Data
    A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, 3 credit card numbers associated with the account.
    Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.
*/

namespace BankAccount
{
    using System;

    public class BankAccount
    {
        public static void Main()
        {
            Console.WriteLine("Enter first name account:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter middle name account:");
            string middleName = Console.ReadLine();
            Console.WriteLine("Enter last name account:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter balance account:");
            int balance = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter bank name account:");
            string bankName = Console.ReadLine();
            Console.WriteLine("Enter IBAN account:");
            string iban = Console.ReadLine();
            Console.WriteLine("Enter number of first credit card account:");
            string firstCreditCard = Console.ReadLine();
            Console.WriteLine("Enter number of second credit card account:");
            string secondCreditCard = Console.ReadLine();
            Console.WriteLine("Enter number of third credit card account:");
            string thirdCreditCard = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"first name:{firstName}");
            Console.WriteLine($"middle name:{middleName}");
            Console.WriteLine($"last name:{lastName}");
            Console.WriteLine($"balance:{balance}");
            Console.WriteLine($"bank name:{bankName}");
            Console.WriteLine($"IBAN: {iban}");
            Console.WriteLine($"first credit card:{firstCreditCard}");
            Console.WriteLine($"second credit card:{secondCreditCard}");
            Console.WriteLine($"third credit card:{thirdCreditCard}");
        }
    }
}
