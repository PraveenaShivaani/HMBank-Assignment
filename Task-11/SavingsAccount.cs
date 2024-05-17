
namespace Task_11

{
    internal class SavingsAccount : Account //with minimum balance 500
    {
        public float InterestRate { get; set; }

        public SavingsAccount(Customer customer, float initialBalance, float interestRate) : base(customer, "Savings", initialBalance)
        {
            InterestRate = interestRate;
        }
        public override float GetAccountBalance()
        {
            return AccountBalance;
        }

        public override float Deposit(float amount)
        {
            AccountBalance += amount;
            return AccountBalance;
        }

        public override void Withdraw(float amount)
        {
            if (AccountBalance >= amount)
            {
                AccountBalance -= amount;
                Console.WriteLine($"The Current Balance After Withdraw :: {AccountBalance}");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
            
        }

        public override void Transfer(long toAccountNumber, float amount, Account tac)
        {
            // Implemented in CustomerServiceProvider
        }

        public override void GetAccountDetails(long accountNumber)
        {
            // Implement account details retrieval
        }
    }
}
