namespace BankAccounts.Accounts
{
    using BankAccounts.Customers;

    public class MortgageAccount : Account
    {
        private const int HalfCompanyInterestPeriod = 12;
        private const decimal UnderTwelveMonthsCompanyRateFactor = 0.5m;
        private const int IndividualsNoInterestPeriod = 6;
        private const decimal IndividualsSixMonthRate = 0.0m;

        public MortgageAccount(CustomerType customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterestRate(int months)
        {
            if (months <= HalfCompanyInterestPeriod && this.Customer == CustomerType.Company)
            {
                this.InterestRate *= UnderTwelveMonthsCompanyRateFactor;
            }

            if (months <= IndividualsNoInterestPeriod && this.Customer == CustomerType.Individual)
            {
                this.InterestRate = 0;
            }

            decimal calculatedRate = this.InterestRate * this.Balance;
            return calculatedRate;
        }
    }
}