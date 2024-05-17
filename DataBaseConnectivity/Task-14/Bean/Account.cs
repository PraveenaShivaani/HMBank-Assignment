
namespace Task_14

{
    internal class Account
    {
  
        public int CustomerId { get; set; }
        public string AccountType { get; set; }
        public double AccountBalance { get; set; }

        public decimal InterestRate { get; set; }

        public Customer customer { get; set; }


        public Account(long accountNumber , int CustomerId,string accountType, double accountBalance,float initialBalance)
        {
            InterestRate = accountNumber;
            AccountType = accountType;
            AccountBalance = initialBalance;
            
        }

        public Account()
        {
        }
    }
}
