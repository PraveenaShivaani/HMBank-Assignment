
namespace Task_8
{
    internal class SavingsAccount : Account
    {
        public double InterestRate { get; set; }

        public SavingsAccount(int accountNumber, string accountType, double initialBalance, double interestRate)
            : base(accountNumber, accountType, initialBalance)
        {
            InterestRate = interestRate;
        }

        public override void Calculate_interest()
        {
            double interestAmount = AccountBalance * InterestRate;
            AccountBalance = AccountBalance + interestAmount;
            Console.WriteLine($"Interest of {interestAmount:C} added. New balance: {AccountBalance:C}"); //:C formate specifier
        }
    }
}
