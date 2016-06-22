namespace BankAccounts.Accounts
{
    using BankAccounts.Accounts.Contracts;
    using BankAccounts.Customers;

    public class DepositAccount : Account, IDepositable, IDrawable
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        public decimal Withdraw(decimal amount)
        {
            this.Balance -= amount;
            return amount;
        }

        public override decimal CalculateInterestRate(int months)
        {
            if (this.Balance >= 1000)
            {
                return months * (this.Balance + this.InterestRate) / 10;
            }

            return 0;
        }
    }
}