using System.Net;

namespace Task_7
{
    internal class Program
    {

/*Perform the following operation in 
main method: 
o create object for account class by calling parameter constructor. 
o deposit(amount: float): Deposit the specified amount into the account. 
o withdraw(amount: float): Withdraw the specified amount from the account. 
o calculate_interest(): Calculate and add interest to the account balance for savings 
accounts.  */
        static void Main(string[] args)
        {
            Account account = new Account(12345, "savings", 1254);
            Customer customer = new Customer(101, "praveena", "shivaani", "praveena@gmail.com", "9345776788", "trichy road,namakkal");
            Login:
            Console.WriteLine("Choose from the option \n" +
                "1.Withdraw \n" +
                "2.Deposite \n" +
                "3.Check Interest\n" +
                "4.Exit");
            int Choice = int.Parse(Console.ReadLine());
            switch(Choice)
            {
                case 1:
                    account.Withdraw(1000);
                    goto Login;
                    break;
                case 2:
                    account.Deposite(1230);
                    goto Login;
                    break;
                case 3:
                    account.Calculate_interest();
                    goto Login;
                    break;
                case 4:
                    Console.WriteLine("Thank You!!");
                    break;
            }
        }
    }
}
