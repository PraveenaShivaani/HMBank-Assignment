
namespace Task_9
{
    internal abstract class Account
    {
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public double AccountBalance { get; set; }

        public Account(int accountNumber, string accountType, double accountBalance)
        {
            AccountNumber = accountNumber;
            AccountType = accountType;
            AccountBalance = accountBalance;

        }

        public void PrintInformations()
        {
            Console.WriteLine($"Account Number :: {AccountNumber} \n Account Type :: {AccountType} \n Account Balance :: {AccountBalance}");
        }

        public abstract void Deposite(double amount);
        public abstract void Withdraw(double amount);
        public abstract void Calculate_interest(double amount);


       

    }
}
