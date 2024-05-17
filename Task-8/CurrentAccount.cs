
namespace Task_8
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

        public new void Withdraw(double amount)
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
    }
}
