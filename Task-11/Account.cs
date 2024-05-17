
namespace Task_11

{
    internal abstract class Account
    {
        private static long lastAccNo = 1001;

        public long AccountNumber { get; private set; }
        public string AccountType { get; set; }
        public float AccountBalance { get; set; }
        public Customer Customer { get; set; }

        public Account(Customer customer, string accountType, float initialBalance)
        {
            AccountNumber = lastAccNo++;
            AccountType = accountType;
            AccountBalance = initialBalance;
            Customer = customer;
        }

        // Abstract methods
        public abstract float GetAccountBalance();
        public abstract float Deposit(float amount);
        public abstract void Withdraw(float amount);
        public abstract void Transfer( long toAccountNumber, float amount,Account tac);
        public abstract void GetAccountDetails(long accountNumber);
    }
}
