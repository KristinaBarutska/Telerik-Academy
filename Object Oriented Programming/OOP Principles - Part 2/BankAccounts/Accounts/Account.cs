namespace BankAccounts.Accounts
{
    using BankAccounts.Accounts.Contracts;
    using BankAccounts.Customers;

    public abstract class Account : IDepositable
    {
        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer
        {
            get;
            protected set;
        }

        public decimal Balance
        {
            get;
            protected set;
        }

        public decimal InterestRate
        {
            get;
            protected set;
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public abstract decimal CalculateInterestRate(int months);
    }
}