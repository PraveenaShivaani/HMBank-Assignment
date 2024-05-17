

namespace Task_11

{
    internal class ZeroBalanceAccount : Account //can be created with zero balance
    {
        public ZeroBalanceAccount(Customer customer) : base(customer, "Zero Balance", 0)
        {
            // No additional attributes for ZeroBalanceAccount
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
            if (AccountBalance  >= amount)
            {
                AccountBalance -= amount;
                Console.WriteLine($"The Current Balance After Withdraw :: {AccountBalance}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance.");
            }
            
        }

        public override void Transfer(long toAccountNumber, float amount,Account tac)
        {
            // Implemented in CustomerServiceProvider
        }

        public override void GetAccountDetails(long accountNumber)
        {
            // Implement account details retrieval
        }
    }
}
