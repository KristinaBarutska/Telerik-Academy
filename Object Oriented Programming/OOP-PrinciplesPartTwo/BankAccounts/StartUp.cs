namespace BankAccounts
{
    using System;

    using BankAccounts.Accounts;
    using BankAccounts.Customers;

    public class StartUp
    {
        public static void Main()
        {
            Account depositAccount = new DepositAccount(CustomerType.Company, 1500, 2.9m);
            Account mortgageAccount = new MortgageAccount(CustomerType.Individual, 900, 10);
            Account loanAccount = new LoanAccount(CustomerType.Company, 30000, 3.9m);
            decimal depositAccountRate = depositAccount.CalculateInterestRate(10);
            decimal mortgageAccountRate = mortgageAccount.CalculateInterestRate(5);
            decimal loanAccountRate = loanAccount.CalculateInterestRate(100);

            Console.WriteLine($"Deposit account's interest rate: {depositAccountRate}\n" +
                $"Motgage account's interest rate: {mortgageAccountRate}\n" +
                $"Loan account's interest rate: {loanAccountRate}");
        }
    }
}