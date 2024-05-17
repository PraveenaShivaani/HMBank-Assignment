namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Create a program that simulates an ATM transaction. Display options such as "Check Balance," 
            "Withdraw," "Deposit,". Ask the user to enter their current balance and the amount they want to 
            withdraw or deposit. Implement checks to ensure that the withdrawal amount is not greater than the 
            available balance and that the withdrawal amount is in multiples of 100 or 500. Display appropriate 
            messages for success or failure. */
            Console.WriteLine("click any options:\n 1.Check Balance \n 2.Withdraw \t 3.Deposite");
            string result = Console.ReadLine();
            Console.WriteLine("Enter the Current Balance:");
            int balance = int.Parse(Console.ReadLine());
            Console.WriteLine($"Amount of {result}");
            int amount = int.Parse(Console.ReadLine());
            if (result == "withdraw")
            {
                if (amount < balance && amount % 100 == 0 || amount % 500 == 0)
                {
                    Console.WriteLine($"Your {result} is SUCCESS!! \n " +
                        $"balance is {balance - amount}");
                }
                else
                {
                    Console.WriteLine($"Your {result} is Failure \n" +
                        $"balance is {balance}");
                }
            }
            else if (result == "checkbalance")
            {
                Console.WriteLine($"balance is {balance}");
            }
            else if (result == "deposite")
            {
                Console.WriteLine($"Your {result} is SUCCESS!!  \n" +
                        $"balance is {balance + amount}");
            }
            else
            {
                Console.WriteLine($"Your {result}  Failed \n" +
                        $"balance is {balance}");
            }
        }
    }
}
