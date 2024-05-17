
namespace Task_11
{
    internal interface IBankServiceProvider
    {
        void CreateAccount(Customer customer, string accType, float balance);
        void ListAccounts();
       
    }
}
