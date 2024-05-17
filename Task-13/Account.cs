
namespace Task_13
{
    internal class Account
    {
        private static long nextAccountNumber = 1001; //for unique implementation of acccount number
        public long AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal AccountBalance { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }



        public Account()
        {
            throw new NotImplementedException();
        }
        public Account(string accountType, decimal initialBalance,string name,string phoneNumber,string emailId)
        {
            AccountNumber = nextAccountNumber++;
            AccountType = accountType;
            AccountBalance = initialBalance;
            Name = name;
            PhoneNumber = phoneNumber;
            EmailId = emailId;
        }

        public void Deposit(decimal amount)
        {
            AccountBalance += amount;
            Console.WriteLine($"Deposited {amount:C}. New balance: {AccountBalance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (AccountBalance >= amount)
            {
                AccountBalance -= amount;
                Console.WriteLine($"Withdrawn {amount:C}. New balance: {AccountBalance:C}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

    }
}
