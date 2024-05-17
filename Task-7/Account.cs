

namespace Task_7
{
    internal class Account
    {
        /* 2. Create an `Account` class with the following confidential attributes: 
• Attributes 
o Account Number 
o Account Type (e.g., Savings, Current) 
o Account Balance 
• Constructor and Methods 
o Implement default constructors and overload the constructor with Account 
attributes,  
o Generate getter and setter, (print all information of attribute) methods for the 
attributes. 
o Add methods to the `Account` class to allow deposits and withdrawals. - 
deposit(amount: float): Deposit the specified amount into the account. 

withdraw(amount: float): Withdraw the specified amount from the account. 
withdraw amount only if there is sufficient fund else display insufficient 
balance. - 
calculate_interest(): method for calculating interest amount for the available 
balance. interest rate is fixed to 4.5% */


        public int AccountNumber { get;  set; }
        public string AccountType { get; set; }
        public double AccountBalance { get; set; }

        public Account(int accountNumber, string accountType, double accountBalance)
        {
            AccountNumber = accountNumber;
            AccountType = accountType;
            AccountBalance = accountBalance;
            Console.WriteLine($"Account Number :: {AccountNumber} \n Account Type :: {AccountType} \n Account Balance :: {AccountBalance}");
        }

        public void Deposite(float amount)
        {
            Console.WriteLine("Withdraw Successfull");
            AccountBalance = AccountBalance + amount;
            Console.WriteLine($" Your Account Balance :: {AccountBalance}");
        }
        public void Withdraw(float amount)
        {
            if( AccountBalance >= amount)
            {
                Console.WriteLine("Deposite Successfull");
                AccountBalance = AccountBalance - amount;
                Console.WriteLine(AccountBalance);
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }

        public void Calculate_interest()
        {
            double interestRate = 0.045;
            double interest = interestRate * AccountBalance;
            Console.WriteLine(interest);
        }

    
    }
}
