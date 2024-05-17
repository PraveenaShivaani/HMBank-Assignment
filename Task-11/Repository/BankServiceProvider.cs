

namespace Task_11

{
    internal class BankServiceProvider : CustomerServiceProvider, IBankServiceProvider
    {
    
        
        public static List<Account> accounts = new List<Account>();
        public static List<SavingsAccount> savaccounts = new List<SavingsAccount>();
        public static List<CurrentAccount> curaccounts = new List<CurrentAccount>();
        public static List<ZeroBalanceAccount> zeroaccounts = new List<ZeroBalanceAccount>();
        private string branchName;
        private string branchAddress;

        public BankServiceProvider(string branchName, string branchAddress)
        {
            this.branchName = branchName;
            this.branchAddress = branchAddress;
            
        }
       

        public void CreateAccount(Customer customer, string accType, float balance)
        {
            if(accType == "Savings")
            {
                SavingsAccount savingsAccount  = new SavingsAccount(customer,balance, 0.5f);
                accounts.Add(savingsAccount);
                savaccounts.Add(savingsAccount);
                Console.WriteLine($"Account Number is {savingsAccount.AccountNumber}");
            }
            else if (accType == "Current")
            {
                CurrentAccount  currentAccount = new CurrentAccount(customer,balance,1000);
                accounts.Add(currentAccount);
                curaccounts.Add(currentAccount);
                Console.WriteLine($"Account Number is {currentAccount.AccountNumber}");
            }
            else if (accType == "ZeroBalanceAccount")
            {
                ZeroBalanceAccount zeroBalanceAccount= new ZeroBalanceAccount(customer);
                accounts.Add(zeroBalanceAccount);
                zeroaccounts.Add(zeroBalanceAccount);
                Console.WriteLine($"Account Number is {zeroBalanceAccount.AccountNumber}");
            }
            else
            {
                Console.WriteLine("Invalid Account Type");
            }


        }
        public void  ListAccounts()
        {
            foreach(var account in accounts)
            {
                Console.WriteLine(account.AccountNumber);
            }
        }

     
    }
}
