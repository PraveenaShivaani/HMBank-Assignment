using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task_14.Repo
{
    internal interface IBankRepository
    {
        public void GetAccountDetails(long AccountNumber);

        public void Deposit(int AccountNumber, int amount);    

        public void Withdraw(int AccountNumber, int amount);

        public void Transfer (int fromAccountNumber,int toAccountNumber, int amount);

        public void ListAccounts();

        public void GetAccountBalance(int AccountNumber);

        public void CreateAccount(int customerId, string accountType, int initialBalance);

        public void GetTransactions(int accountId);

        public void CalculateInterest(int accountId);
    }
}
