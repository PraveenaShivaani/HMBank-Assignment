
namespace Task_14
{
    internal interface ICustomerServiceProvider
    {
        void GetAccountBalance(Account account);
        double Deposit(Account account,int amount);
        double Withdraw(Account account,int amount);
        void Transfer(long fromAccountNumber, long toAccountNumber, float amount);
        void GetAccountDetails(Account account, Customer customer);

        void CalculateInterest(Account account);
    }
}
