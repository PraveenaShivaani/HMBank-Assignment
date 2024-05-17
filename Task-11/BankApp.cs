

namespace Task_11
{ 
    internal class Program
    {
        private static BankServiceProvider bank = new BankServiceProvider("MyBank", "123 Main St");
        static void Main(string[] args)
        {

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Get Balance");
                Console.WriteLine("5. Transfer");
                Console.WriteLine("6. Get Account Details");
                Console.WriteLine("7. List Accounts");
                Console.WriteLine("8. Calculate Interest");
                Console.WriteLine("9. Get Transactions");
                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreateAccountMenu();
                        break;
                    case "2":
                        DepositMenu();
                        break;
                    case "3":
                        WithdrawMenu();
                        break;
                    case "4":
                        GetBalanceMenu();
                        break;
                    case "5":
                        TransferMenu();
                        break;
                    case "6":
                        GetAccountDetailsMenu();
                        break;
                    case "7":
                        ListAccountsMenu();
                        break;
                    case "8":
                        exit = true;
                        Console.WriteLine("Exiting the system. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void CreateAccountMenu()
        {
            Console.WriteLine("Select type of account:");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            Console.WriteLine("3. Zero Balance Account");
            Console.Write("Enter your choice: ");
            string accountTypeChoice = Console.ReadLine();

            Console.Write("Enter customer ID: ");
            int customerId = int.Parse(Console.ReadLine());

            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter email address: ");
            string emailAddress = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter address: ");
            string address = Console.ReadLine();

            Customer customer = new Customer(customerId, firstName, lastName, emailAddress, phoneNumber, address);

            switch (accountTypeChoice)
            {
                case "1":
                    bank.CreateAccount(customer, "Savings", 500); // Minimum balance for savings account is 500
                    Console.WriteLine("Savings account created successfully.");
                    break;
                case "2":
                    bank.CreateAccount(customer, "Current", 0); // No minimum balance for current account
                    Console.WriteLine("Current account created successfully.");
                    break;
                case "3":
                    bank.CreateAccount(customer, "ZeroBalance", 0);
                    Console.WriteLine("Zero balance account created successfully.");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private static void DepositMenu()
        {
            Console.Write("Enter account number: ");
            long accountNumber = long.Parse(Console.ReadLine());

            Console.Write("Enter deposit amount: ");
            float amount = float.Parse(Console.ReadLine());

            bank.Deposit(accountNumber, amount);
            
        }

        private static void WithdrawMenu()
        {
            Console.Write("Enter account number: ");
            long accountNumber = long.Parse(Console.ReadLine());

            Console.Write("Enter withdrawal amount: ");
            float amount = float.Parse(Console.ReadLine());

            bank.Withdraw(accountNumber, amount);
          
        }

        private static void GetBalanceMenu()
        {
            Console.Write("Enter account number: ");
            long accountNumber = long.Parse(Console.ReadLine());

            bank.GetAccountBalance(accountNumber);
       
        }

        private static void TransferMenu()
        {
            Console.Write("Enter source account number: ");
            long fromAccountNumber = long.Parse(Console.ReadLine());

            Console.Write("Enter destination account number: ");
            long toAccountNumber = long.Parse(Console.ReadLine());

            Console.Write("Enter transfer amount: ");
            float amount = float.Parse(Console.ReadLine());

            bank.Transfer(fromAccountNumber, toAccountNumber, amount);
            Console.WriteLine("Transfer successful.");
        }

        private static void GetAccountDetailsMenu()
        {
            Console.Write("Enter account number: ");
            long accountNumber = long.Parse(Console.ReadLine());

            bank.GetAccountDetails(accountNumber);
            Console.WriteLine("Account details displayed.");
        }

        private static void ListAccountsMenu()
        {
            bank.ListAccounts();
            
        }
    }
}
