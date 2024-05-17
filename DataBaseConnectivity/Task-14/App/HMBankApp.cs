using Task_14.Repo;

namespace Task_14.App
{
    internal class HMBankApp
    {
        internal void Run()
        {
            BankRepository bankRepository = new BankRepository();
            bool loop = false;
            // Display menu options
            while (!loop)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("WELCOME");
                Console.WriteLine("\nHMBank Menu\n");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Get Account Balance");
                Console.WriteLine("6. Get Account Details");
                Console.WriteLine("7. List Accounts");
                Console.WriteLine("8. Get Transactions");
                Console.WriteLine("9. Calulate Interest");
                Console.WriteLine("10. EXIT");
                Console.Write("\nEnter your choice: ");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateAccount(bankRepository);
                        break;
                    case 2:
                        Deposit(bankRepository);
                        break;
                    case 3:
                        Withdraw(bankRepository);
                        break;
                    case 4:
                        Transfer(bankRepository);
                        break;
                    case 5:
                        GetAccountBalance(bankRepository);
                        break;
                    case 6:
                        GetAccountDetails(bankRepository);
                        break;
                    case 7:
                        ListAccounts(bankRepository);
                        return;
                    case 8:
                        GetTransactions(bankRepository);
                        break;
                    case 9:
                        CalculateInterest(bankRepository);
                        break;
                    case 10:
                        loop = true;
                        Console.WriteLine("Thankyou for using HMBank!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void CalculateInterest(BankRepository bankRepository)
        {
            Console.WriteLine("Enter the  Account Number::");
            int AccountId = int.Parse(Console.ReadLine());
            bankRepository.CalculateInterest(AccountId);
        }

        private void GetTransactions(BankRepository bankRepository)
        {
            Console.WriteLine("Enter the Account Number ::");
            int AccountId = int.Parse(Console.ReadLine());
            bankRepository.GetTransactions(AccountId);

        }

        private void CreateAccount(BankRepository bankRepository)
        {
            Console.WriteLine("Enter the Customer ID ::");
            int CustomerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Account Type ::");
            string AccountType = Console.ReadLine();
            Console.WriteLine("Enter the intial Balance ::");
            int InitialBalance = int.Parse(Console.ReadLine());
            bankRepository.CreateAccount(CustomerId,AccountType,InitialBalance);
        }

        private void GetAccountBalance(BankRepository bankRepository)
        {

            Console.WriteLine("Enter the Account Number ::");
            int AccountNumber = int.Parse(Console.ReadLine());
            bankRepository.GetAccountBalance(AccountNumber);
        }

        private void ListAccounts(BankRepository bankRepository)
        {
            bankRepository.ListAccounts();
        }

        private void Transfer(BankRepository bankRepository)
        {
            Console.WriteLine("Enter the Sender's Account Number ::");
            int FromAccountNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Receiver's Account Number ::");
            int ToAccountNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount to transfer :: ");
            int AmountToTransfer = int.Parse(Console.ReadLine());
            bankRepository.Transfer(FromAccountNumber , ToAccountNumber , AmountToTransfer);
        }

        private void Withdraw(BankRepository bankRepository)
        {
            Console.WriteLine("Enter the Account Number ::");
            int AccountNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount to Withdraw :: ");
            int amount = int.Parse(Console.ReadLine());
            bankRepository.Withdraw(AccountNumber,amount);
        }

        private void Deposit(BankRepository bankRepository)
        {
            Console.WriteLine("Enter the Account Number ::");
            int AccountNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount to Deposit :: ");
            int amount = int.Parse(Console.ReadLine());
            bankRepository.Deposit(AccountNumber,amount);
        }

        void GetAccountDetails(BankRepository bankRepository)
            {
                Console.WriteLine("Enter the Account Number ::");
                int AccountNumber = int.Parse(Console.ReadLine());
                bankRepository.GetAccountDetails(AccountNumber);
            }
    }
}

