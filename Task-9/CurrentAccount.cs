
namespace Task_9
{
    internal class CurrentAccount : Account
    {
        public double OverdraftLimit { get; set; }
        public const double DefaultOverdraftLimit = 1000; // Default overdraft limit

        public CurrentAccount(int accountNumber, string accountType, double initialBalance)
            : base(accountNumber, accountType, initialBalance)
        {
            OverdraftLimit = DefaultOverdraftLimit;
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
            if (AccountBalance + OverdraftLimit >= amount)
            {
                AccountBalance -= amount;
                Console.WriteLine($"Withdrawn {amount:C}. New balance: {AccountBalance:C}");
            }
            else
            {
                Console.WriteLine("Withdrawal amount exceeds overdraft limit.");
            }
        }

        public override void Calculate_interest(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
