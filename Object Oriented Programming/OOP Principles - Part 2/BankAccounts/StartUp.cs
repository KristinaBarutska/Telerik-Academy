namespace BankAccounts
{
    using System;

    using BankAccounts.Accounts;
    using BankAccounts.Customers;

    public class StartUp
    {
        public static void Main()
        {
            Account[] accounts = new Account[3]
            {
                new DepositAccount(Customer.Individual, 1500, 3),
                new MortgageAccount(Customer.Company, 300, 19),
                new LoanAccount(Customer.Company, 1000, 30)
            };

            foreach (Account account in accounts)
            {
                Console.WriteLine("{0} has {1:0.00} interest rate!", account.GetType().Name, account.CalculateInterestRate(22));
            }
        }
    }
}