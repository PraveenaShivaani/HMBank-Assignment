using Task_14.Exceptions;

namespace Task_14
{
    internal class CurrentAccount : Account //overdraft
    {
        public static float OverdraftLimit = 1000;

        public CurrentAccount()
        {

        }

        public static double Withdraw(Account account , int amount)
        {
            //Console.WriteLine("Enter the amount to Wthdraw :: ");
            //int amount = int.Parse(Console.ReadLine());
            if (account.AccountBalance + OverdraftLimit >= amount)
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
