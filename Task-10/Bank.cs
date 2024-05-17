
namespace Task_10
{
    internal class Bank //check for conditions whether accuntNumber exist or not
    {
        private List<Account> accounts = new List<Account>();

        public void CreateAccount(Customer customer, string accountType, decimal balance)
        {
            Account newAccount = new Account(customer, accountType, balance);
            accounts.Add(newAccount);
            Console.WriteLine($"Account created successfully. Account Number: {newAccount.AccountNumber}");
        }

        public decimal GetAccountBalance(long accountNumber)
        {
            Account account = accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber); //first occurence or default value
            if (account != null)
            {
                return account.AccountBalance;
            }
            else
            {
                Console.WriteLine("Account not found.");
                return 0;
            }
        }

        public void Deposit(long accountNumber, decimal amount)
        {
            Account account = accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
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
            Account account = accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
            if (account != null)
            {
                account.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount)
        {
            Account sourceAccount = accounts.FirstOrDefault(acc => acc.AccountNumber == fromAccountNumber);
            Account destinationAccount = accounts.FirstOrDefault(acc => acc.AccountNumber == toAccountNumber);
            if (sourceAccount != null && destinationAccount != null)
            {
                sourceAccount.Transfer(destinationAccount, amount);
            }
            else
            {
                Console.WriteLine("Invalid account numbers.");
            }
        }

        public void GetAccountDetails(long accountNumber)
        {
            Account account = accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
            if (account != null)
            {
                account.PrintAccountDetails();
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }
}
