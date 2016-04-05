namespace BankAccounts.Accounts
{
    using System;

    using BankAccounts.Accounts;
    using Customers;

    public class DepositAccount : Account
    {
        private const decimal MinimalAmountToOperateWith = 1.0m;
        private const decimal MinimumBalanceForInterestRate = 1000.0m;

        public DepositAccount(CustomerType customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
            if (balance < 1000)
            {
                this.InterestRate = MinimumBalanceForInterestRate;
            }
        }

        public void Deposit(decimal amountToDeposit)
        {
            if(amountToDeposit < MinimalAmountToOperateWith)
            {
                throw new InvalidOperationException("Cannot deposit negative or less than 1.00 amount of money.");
            }
            else
            {
                this.Balance += amountToDeposit;
            }
        }

        public decimal Withdraw(decimal amountToDraw)
        {
            if (amountToDraw < MinimalAmountToOperateWith)
            {
                throw new InvalidOperationException("Cannot withdraw negative amount of money.");
            }
            else if(amountToDraw > this.Balance)
            {
                throw new InvalidOperationException("Not enough balance.");
            }
            else
            {
                this.Balance -= amountToDraw;
                return amountToDraw;
            }
        }

        public override decimal CalculateInterestRate(int months)
        {
            decimal calculatedRate = this.Balance * this.InterestRate;
            return calculatedRate;
        }
    }
}