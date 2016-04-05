namespace BankAccounts.Accounts
{
    using BankAccounts.Customers;

    public abstract class Account
    {
        public Account(CustomerType customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public CustomerType Customer
        {
            get;
            protected set;
        }

        public decimal Balance
        {
            get; protected set;
        }

        public decimal InterestRate
        {
            get; protected set;
        }

        public abstract decimal CalculateInterestRate(int months);
    }
}