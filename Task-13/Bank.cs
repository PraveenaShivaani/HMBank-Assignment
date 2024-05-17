
namespace Task_13
{
    internal class Bank
    {
        public List<Account> listaccounts = new List<Account>();
        public HashSet<Account> setaccounts;
        public Dictionary<long, Account> dictaccounts;

        public void CreateAccount(string accountType, decimal initialBalance, string name, string phoneNumber, string emailId)
        {
            Account newAccount = new Account(accountType,initialBalance,name,phoneNumber,emailId);
            int a = 0;
            listaccounts.Add(newAccount);
            foreach (Account account in listaccounts) //to prevent from duplicate value
            {
                if(newAccount == account)
                {
                    a++;
                }
            }
            if(a==0)
            {
                setaccounts.Add(newAccount);
                dictaccounts.Add(newAccount.AccountNumber, newAccount);
            }
            
            Console.WriteLine($"Account created successfully. Account Number: {newAccount.AccountNumber}");
        }

        public void Deposit(long accountNumber, decimal amount)
        {
            Account account = listaccounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void Withdraw(long accountNumber, decimal amount)
        {
            Account account = listaccounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
            if (account != null)
            {
                account.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public decimal GetAccountBalance(long accountNumber)
        {
            Account account = listaccounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber); //first occurence or default value
            if (account != null)
            {
                return account.AccountBalance;
            }
            else
            {
                throw new NullReferenceException();

            }
        }

        public void ListOfAccounts()
        {
            if (listaccounts != null)
            {
                var sortedAccounts = listaccounts.OrderBy(acc => acc.Name);

                // Print sorted accounts
                foreach (var account in sortedAccounts)
                {
                    Console.WriteLine($"{account.Name} : {account.AccountNumber}");
                }

            }
        }

    }
}
