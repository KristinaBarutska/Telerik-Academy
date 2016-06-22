namespace BankAccounts.Accounts
{
    using BankAccounts.Accounts.Contracts;
    using BankAccounts.Customers;

    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterestRate(int months)
        {
            if (this.Customer == Customer.Individual)
            {
                months = months > 3 ? months : 0;
            }
            else
            {
                months = months > 2 ? months : 0;
            }

            return months * (this.Balance + this.InterestRate) / 10;
        }
    }
}