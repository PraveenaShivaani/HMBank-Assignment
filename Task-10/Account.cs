
using System.ComponentModel;

namespace Task_10
{
    internal class Account
    {
        private static long nextAccountNumber = 1001; //for unique implementation of acccount number
        public long AccountNumber { get; private set; }
        public string AccountType { get; set; }
        public decimal AccountBalance { get; private set; }
        public Customer Customer { get; set; }

        public Account()
        {
            throw new NotImplementedException();
        }
        public Account(Customer customer, string accountType, decimal initialBalance)
        {
            AccountNumber = nextAccountNumber++;
            Customer = customer;
            AccountType = accountType;
            AccountBalance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            AccountBalance += amount;
            Console.WriteLine($"Deposited {amount:C}. New balance: {AccountBalance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (AccountBalance >= amount)
            {
                AccountBalance -= amount;
                Console.WriteLine($"Withdrawn {amount:C}. New balance: {AccountBalance:C}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        public void Transfer(Account destinationAccount, decimal amount)
        {
            if (AccountBalance >= amount)
            {
                Withdraw(amount); //sourceAccount because we called with that obj
                destinationAccount.Deposit(amount);
                Console.WriteLine($"Transferred {amount:C} to Account {destinationAccount.AccountNumber}.");
            }
            else
            {
                Console.WriteLine("Insufficient balance for transfer.");
            }
        }

        public void PrintAccountDetails()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Type: {AccountType}");
            Console.WriteLine($"Balance: {AccountBalance:C}");
            Customer.PrintCustomerDetails();
        }
    }
}
