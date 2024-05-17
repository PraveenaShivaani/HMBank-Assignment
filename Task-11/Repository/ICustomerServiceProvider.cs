
namespace Task_11
{
    internal interface ICustomerServiceProvider
    {
        void GetAccountBalance(long accountNumber);
        void Deposit(long accountNumber, float amount);
        void Withdraw(long accountNumber, float amount);
        void Transfer(long fromAccountNumber, long toAccountNumber, float amount);
        void GetAccountDetails(long accountNumber);
    }
}
