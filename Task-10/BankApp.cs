
using System.Text.RegularExpressions;

namespace Task_10
{
    internal class Program //main--bank-acc
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Get Account Balance");
                Console.WriteLine("6. Get Account Details");
                Console.WriteLine("7. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateAccount(bank);
                        Console.WriteLine("-----------------------------------------------------");
                        break;
                    case 2:
                        Deposit(bank);
                        Console.WriteLine("-----------------------------------------------------");
                        break;
                    case 3:
                        Withdraw(bank);
                        Console.WriteLine("-----------------------------------------------------");
                        break;
                    case 4:
                        Transfer(bank);
                        Console.WriteLine("-----------------------------------------------------");
                        break;
                    case 5:
                        GetAccountBalance(bank);
                        Console.WriteLine("-----------------------------------------------------");
                        break;
                    case 6:
                        GetAccountDetails(bank);
                        Console.WriteLine("-----------------------------------------------------");
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.WriteLine("-----------------------------------------------------");
                        break;
                }
            }
        }

        public static void CreateAccount(Bank bank)
        {
            Console.WriteLine("Enter Customer ID:");
            int customerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();

            string emailAddress = null;
            Email:
            try
            {
                Console.WriteLine("Enter Email Address:");
                emailAddress = Console.ReadLine();

                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(emailAddress, pattern))
                {
                    throw new ArgumentException("Invalid email address format.");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Email;
            }

            string phoneNumber = null;
            phoneNumber:
            try
            {
                Console.WriteLine("Enter Phone Number:");
                phoneNumber = Console.ReadLine();
                //Validating phone nnumber
                string pattern = @"^\d{10}$";
                if (!Regex.IsMatch(phoneNumber, pattern))
                {
                    throw new ArgumentException("Invalid phone number format. Please enter a 10-digit phone number.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto phoneNumber;
            }
          

            Console.WriteLine("Enter Address:");
            string address = Console.ReadLine();

            Customer customer = new Customer(customerId, firstName, lastName, emailAddress, phoneNumber, address);

            Console.WriteLine("Enter Account Type (Savings/Current):");
            string accountType = Console.ReadLine();

            Console.WriteLine("Enter Initial Balance:");
            decimal initialBalance = decimal.Parse(Console.ReadLine());

            bank.CreateAccount(customer, accountType, initialBalance);
        }

        public static void Deposit(Bank bank)
        {
            Console.WriteLine("Enter Account Number:");
            long accountNumber = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter Deposit Amount:");
            decimal amount = decimal.Parse(Console.ReadLine());

            bank.Deposit(accountNumber, amount);
        }

        public static void Withdraw(Bank bank)
        {
            Console.WriteLine("Enter Account Number:");
            long accountNumber = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter Withdraw Amount:");
            decimal amount = decimal.Parse(Console.ReadLine());

            bank.Withdraw(accountNumber, amount);
        }

        public static void Transfer(Bank bank)
        {
            Console.WriteLine("Enter Source Account Number:");
            long fromAccountNumber = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter Destination Account Number:");
            long toAccountNumber = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter Transfer Amount:");
            decimal amount = decimal.Parse(Console.ReadLine());

            bank.Transfer(fromAccountNumber, toAccountNumber, amount);
        }

        public static void GetAccountBalance(Bank bank)
        {
            Console.WriteLine("Enter Account Number:");
            long accountNumber = long.Parse(Console.ReadLine());

            decimal balance = bank.GetAccountBalance(accountNumber);
            Console.WriteLine($"Current Balance: {balance:C}");
        }

        public static void GetAccountDetails(Bank bank)
        {
            Console.WriteLine("Enter Account Number:");
            long accountNumber = long.Parse(Console.ReadLine());

            bank.GetAccountDetails(accountNumber);
            }
    }
}
