using Task_14.Exceptions;

namespace Task_14

{
    internal class SavingsAccount : Account //with minimum balance 500
    {
        
        internal static double Withdraw(Account account, int amount)
        {
            
            if (account.AccountBalance - 100 >= amount) //100 is the minimum balance
            {
                account.AccountBalance -= amount;
                Console.WriteLine($"The Current Balance After Withdraw :: {account.AccountBalance}");
                return account.AccountBalance;
            }
            else
            {
                throw new InsufficientBalanceException("Withdrawal amount exceeds Minimum Balance.");
            }
        }
    }
}
