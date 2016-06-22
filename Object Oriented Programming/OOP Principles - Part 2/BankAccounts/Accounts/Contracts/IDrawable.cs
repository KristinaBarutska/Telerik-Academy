namespace BankAccounts.Accounts.Contracts
{
    public interface IDrawable
    {
        decimal Withdraw(decimal amount);
    }
}