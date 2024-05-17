

namespace Task_9
{
    internal class SavingsAccount : Account
    {
        public double InterestRate { get; set; }

        public SavingsAccount(int accountNumber, string accountType, double initialBalance, double interestRate)
            : base(accountNumber, accountType, initialBalance)
        {
            InterestRate = interestRate;
        }
        //Deposite
        public override void Deposite(double amount)
        {
            Console.WriteLine("Deposite Successfull");
            AccountBalance = AccountBalance + amount;
            Console.WriteLine($" Your Account Balance d:: {AccountBalance}");
        }
        //withdraw method
        public override void Withdraw(double amount)
        {
            if (AccountBalance >= amount)
            {
                Console.WriteLine("Withdraw Successfull");
                AccountBalance = AccountBalance - amount;
                Console.WriteLine($" Your Account Balance d:: {AccountBalance}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }
       


        public override void Calculate_interest(double amount)
        {
            double interestAmount = AccountBalance * InterestRate;
            AccountBalance = AccountBalance + interestAmount;
            Console.WriteLine($"Interest of {interestAmount:C} added. New balance: {AccountBalance:C}"); //:C formate specifier
        }
    }
}
