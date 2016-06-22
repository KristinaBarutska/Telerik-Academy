namespace BankAccounts.Accounts
{
    using BankAccounts.Accounts.Contracts;
    using BankAccounts.Customers;

    public class MortgageAccount : Account, IDepositable
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterestRate(int months)
        {
            if (this.Customer == Customer.Individual)
            {
                if (months <= 6)
                {
                    return 0.0m;
                }
                else
                {
                    return months * (this.Balance + this.InterestRate) / 10;
                }
            }
            else
            {
                if (months <= 12)
                {
                    return months * this.Balance * 0.5m;
                }
                else
                {
                    return months * (this.Balance + this.InterestRate) / 10;
                }
            }
        }
    }
}