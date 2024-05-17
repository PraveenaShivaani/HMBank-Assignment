namespace Task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* Create a program that maintains a list of bank transactions (deposits and withdrawals) for a customer. 
Use a while loop to allow the user to keep adding transactions until they choose to exit. Display the 
transaction history upon exit using looping statements.  */

            Boolean valid = false;
            string[] transactionhistory = new string[100];
            int transactioncount = 0;
            Boolean continueaddingtransactions = true;
            int attempt = 0;
        login:
            Console.WriteLine("enter your account number");
            int accountnumber = int.Parse(Console.ReadLine());
            int balance = 0;


            int[,] accounts =
            {
                        {12345,1000 },
                        {23456,2000 },
                        {34567,3000 },
                        {45678,4000 },
                        {56789,3500 }
                };
            for (int i = 0; i < 5; i++)
            {
                if (accountnumber == accounts[i, 0])
                {
                    balance = accounts[i, 1];
                    valid = true;
                }

            }
            if (!valid && attempt < 2)
            {
                attempt++;
                Console.WriteLine("The account number is incorrect!!");
                goto login;
            }
            else if (!valid && attempt > 2)
            {
                Console.WriteLine("The account Number is inccorrect!! Try After 24 Hrs");
            }

            while (continueaddingtransactions && valid)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdrawal");
                Console.WriteLine("3. Transaction History");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter deposit amount: $");
                        int depositAmount = int.Parse(Console.ReadLine());
                        transactionhistory[transactioncount] = $"Deposit: +${depositAmount}";
                        balance = balance + depositAmount;
                        transactioncount++;
                        break;
                    case "2":
                        Console.Write("Enter withdrawal amount: $");
                        int withdrawalAmount = int.Parse(Console.ReadLine());
                        if (withdrawalAmount < balance)
                        {
                            transactionhistory[transactioncount] = $"Withdrawal: -${withdrawalAmount}";
                            balance = balance - withdrawalAmount;
                            transactioncount++;
                        }
                        else
                        {
                            Console.WriteLine("Insufficient Balance");
                        }
                        break;
                    case "3":
                        Console.Write("Here is the Transaction History\n");
                        for (int i = 0; i <= transactioncount; i++)
                        {
                            Console.WriteLine(transactionhistory[i]);
                        }
                        break;
                    case "4":
                        Console.Write($"The Balance is ${balance}");
                        break;

                    case "5":
                        Console.Write("The transaction is terminated");
                        continueaddingtransactions = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, Please try again.");
                        break;

                }

            }
        }
    }
}
