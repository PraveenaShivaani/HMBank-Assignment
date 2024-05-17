


namespace Task_11
{
    internal class CurrentAccount : Account //overdraft
    {
        public float OverdraftLimit { get; set; }

        public CurrentAccount(Customer customer, float initialBalance, float overdraftLimit) : base(customer, "Current", initialBalance)
        {
            OverdraftLimit = overdraftLimit;
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
            if (AccountBalance + OverdraftLimit >= amount)
            {
                AccountBalance -= amount;
                Console.WriteLine($"The Current Balance After Withdraw :: {AccountBalance}");
            }
            else
            {
                Console.WriteLine("Withdrawal amount exceeds overdraft limit.");
            }
           
        }

        public override void Transfer(long toAccountNumber, float amount,Account tac)
        {
            if (AccountBalance + OverdraftLimit >= amount)
            {
                AccountBalance -= amount;
                tac.AccountBalance += amount;
                Console.WriteLine($"Amount {amount} Successfully Transfered..!!");
            }
            else
            {
                Console.WriteLine("Insufficient Balane in Sender's Account");
            }
        }

        public override void GetAccountDetails(long accountNumber)
        {
            // Implement account details retrieval
        }
    }
}
