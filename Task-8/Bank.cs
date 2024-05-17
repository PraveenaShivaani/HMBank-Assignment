namespace Task_8
{
    internal class Bank
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer(101, "praveena", "shivaani", "praveena@gmail.com", "9345776788", "trichy road,namakkal");
            SavingsAccount savingsAccount1 = null;
            CurrentAccount currentAccount1 = null;
            Console.WriteLine("------------------------------------------------------------------");
            //3.
            Console.WriteLine("Welcome to the Bank!");

            // Display menu to create account
            Console.WriteLine("Choose account type:");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    savingsAccount1 = new SavingsAccount(23456, "savings", 5000, 3);
                    break;
                case 2:
                    currentAccount1 = new CurrentAccount(23456, "savings", 5000);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        Login:
            Console.WriteLine("------------------------------------------------------------------");
            if (savingsAccount1 == null)
            {
                Console.WriteLine("Choose from the option \n" +
                "1.Withdraw \n" +
                "2.Deposite \n" +
                "3.Exit");
                int Choice = int.Parse(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        currentAccount1.Withdraw(6000);
                        goto Login;
                    case 2:
                        account.Deposite(20.0f); //change this 
                        goto Login;
                    case 4:
                        Console.WriteLine("Thank You!!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Choose from the option \n" +
                "1.Withdraw \n" +
                "2.Deposite \n" +
                "3.Check Interest\n" +
                "4.Exit");
                int Choice = int.Parse(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        savingsAccount1.Withdraw(1000);
                        goto Login;
                        break;
                    case 2:
                        savingsAccount1.Deposite(20.0f); //change this 
                        goto Login;
                        break;
                    case 3:
                        savingsAccount1.Calculate_interest();
                        goto Login;
                        break;
                    case 4:
                        Console.WriteLine("Thank You!!");
                        break;
                }
            }
 
        }
    }
}
