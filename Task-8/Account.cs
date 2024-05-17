
namespace Task_8
{
    internal class Account
    {
/*  1. Overload the deposit and withdraw methods in Account class as mentioned below. 
• deposit(amount: float): Deposit the specified amount into the account. 
• withdraw(amount: float): Withdraw the specified amount from the account. withdraw 
amount only if there is sufficient fund else display insufficient balance. 
• deposit(amount: int): Deposit the specified amount into the account. 
• withdraw(amount: int): Withdraw the specified amount from the account. withdraw 
amount only if there is sufficient fund else display insufficient balance. 
• deposit(amount: double): Deposit the specified amount into the account. 
• withdraw(amount: double): Withdraw the specified amount from the account. withdraw 
amount only if there is sufficient fund else display insufficient balance.  */
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

        public void Deposite(float amount)
        {
            Console.WriteLine("Deposite Successfull");
            AccountBalance = AccountBalance + amount;
            Console.WriteLine($" Your Account Balance f:: {AccountBalance}");
        }
        public void Deposite(int amount)
        {
            Console.WriteLine("Deposite Successfull");
            AccountBalance = AccountBalance + amount;
            Console.WriteLine($" Your Account Balance i:: {AccountBalance}");
        }
        public void Deposite(double amount)
        {
            Console.WriteLine("Deposite Successfull");
            AccountBalance = AccountBalance + amount;
            Console.WriteLine($" Your Account Balance d:: {AccountBalance}");
        }
        public void Withdraw(float amount)
        {
            if (AccountBalance >= amount)
            {
                Console.WriteLine("Withdraw Successfull");
                AccountBalance = AccountBalance - amount;
                Console.WriteLine(AccountBalance);
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }
        public void Withdraw(int amount)
        {
            if (AccountBalance >= amount)
            {
                Console.WriteLine("Withdraw Successfull");
                AccountBalance = AccountBalance - amount;
                Console.WriteLine(AccountBalance);
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }
        public void Withdraw(double amount)
        {
            if (AccountBalance >= amount)
            {
                Console.WriteLine("Withdraw Successfull");
                AccountBalance = AccountBalance - amount;
                Console.WriteLine(AccountBalance);
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }

        public virtual void Calculate_interest()
        {
            double interestRate = 0.045;
            double interest = interestRate * AccountBalance;
            Console.WriteLine(interest);
        }


    }
}
