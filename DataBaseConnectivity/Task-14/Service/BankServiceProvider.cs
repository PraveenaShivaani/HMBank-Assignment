

namespace Task_14

{
    internal class BankServiceProvider : CustomerServiceProvider, IBankServiceProvider
    {
    
        
        public static List<Account> accounts = new List<Account>();
        public static List<SavingsAccount> savaccounts = new List<SavingsAccount>();
        public static List<CurrentAccount> curaccounts = new List<CurrentAccount>();
        public static List<ZeroBalanceAccount> zeroaccounts = new List<ZeroBalanceAccount>();
        private string branchName;
        private string branchAddress;

        public BankServiceProvider()
        {}

        public void CreateAccount(Customer customer, string accType, float balance)
        {
            throw new NotImplementedException();
        }


        public void  ListAccounts()
        {
            foreach(var account in accounts)
            {
                Console.WriteLine(account.InterestRate);
            }
        }

     
    }
}
