
namespace Task_14
{
    internal interface IBankServiceProvider
    {
        void CreateAccount(Customer customer, string accType, float balance);
        void ListAccounts();
       
    }
}
