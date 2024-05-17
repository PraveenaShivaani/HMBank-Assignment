using Task_14.Exceptions;

namespace Task_14

{
    internal class ZeroBalanceAccount : Account //can be created with zero balance
    {
      
        internal static double Withdraw(Account account, int amount)
        {
            //Console.WriteLine("Enter the amount to Wthdraw :: ");
            //int amount = int.Parse(Console.ReadLine());
            if (account.AccountBalance >= amount)
            {
                account.AccountBalance -= amount;
                Console.WriteLine($"The Current Balance After Withdraw :: {account.AccountBalance}");
                return account.AccountBalance;
            }
            else
            {
                throw new InsufficientBalanceException("Withdrawal amount exceeds overdraft limit.");
             
            }
        }
    }
}
