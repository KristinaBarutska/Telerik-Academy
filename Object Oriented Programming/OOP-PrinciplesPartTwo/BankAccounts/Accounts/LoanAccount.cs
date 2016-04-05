namespace BankAccounts.Accounts
{
    using BankAccounts.Customers;

    public class LoanAccount : Account
    {
        private const int MinMonthsForIndividualsInterestRate = 3;
        private const int MinMonthsForCompaniesInterestRate = 2;

        public LoanAccount(CustomerType customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterestRate(int months)
        {
            if (months <= MinMonthsForIndividualsInterestRate && this.Customer == CustomerType.Individual)
            {
                this.InterestRate = 0;
            }

            if (months <= MinMonthsForCompaniesInterestRate && this.Customer == CustomerType.Company)
            {
                this.InterestRate = 0;
            }

            decimal calculatedRate = this.Balance * this.InterestRate;
            return calculatedRate;
        }
    }
}