
namespace Task_11
{
    internal class CustomerServiceProvider : ICustomerServiceProvider
    {
        
        public void Deposit(long accountNumber, float amount)
        {
            Account ac = BankServiceProvider.accounts.FirstOrDefault(ac => ac.AccountNumber == accountNumber);
            if (ac != null)
            {
                ac.AccountBalance += amount;

                Console.WriteLine($"Deposited {amount:C} into account number {accountNumber}. New balance: {ac.AccountBalance:C}");
            }
            else
            {
                Console.WriteLine("Invalid Account");
            }
        }

        public void GetAccountBalance(long accountNumber)
        {
            Account ac = BankServiceProvider.accounts.FirstOrDefault(ac => ac.AccountNumber == accountNumber);
            if (ac != null)
            {
                

                Console.WriteLine($" number: {accountNumber} ==> balance: {ac.AccountBalance:C}");
            }
            else
            {
                Console.WriteLine("Invalid Account");
            }
        }

        public void GetAccountDetails(long accountNumber)
        {
            Account ac = BankServiceProvider.accounts.FirstOrDefault(ac => ac.AccountNumber == accountNumber);
            if (ac != null)
            {
                Console.WriteLine($"Account Balance {ac.AccountBalance} \n Account Type {ac.AccountType} ");
            }
            else
            {
                Console.WriteLine("Account Doesn't Exist");
            }
        }

        public void Transfer(long fromAccountNumber,long toAccountNumber, float amount)
        {
            Account fac = BankServiceProvider.accounts.FirstOrDefault(ac => ac.AccountNumber == fromAccountNumber);
            Account tac = BankServiceProvider.accounts.FirstOrDefault(ac => ac.AccountNumber == toAccountNumber);
            if (fac != null && tac !=null) 
            {
                if(fac.AccountType == "Current")
                {
                    CurrentAccount ca = BankServiceProvider.curaccounts.FirstOrDefault(ac => ac.AccountNumber == fromAccountNumber);
                    ca.Transfer(toAccountNumber, amount, tac);
                   
                }
                else if(fac.AccountType =="Savings" ||  fac.AccountType == "ZeroBalance")
                {
                    if(fac.AccountBalance >= amount)
                    {
                        fac.AccountBalance -= amount;
                        tac.AccountBalance += amount;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient Balance");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Account Type");
                }
            }
            else
            {
                Console.WriteLine("Account Doesn't  Exist");
            }
            

        }

        public void Withdraw(long accountNumber, float amount)
        {
            Account ac = BankServiceProvider.accounts.FirstOrDefault(ac => ac.AccountNumber == accountNumber);

            if (ac != null)
            {
                if (ac.AccountType == "Current")
                {
                    CurrentAccount ca = BankServiceProvider.curaccounts.FirstOrDefault(ca => ca.AccountNumber == accountNumber);
                    ca.Withdraw(amount);
                }
                else if (ac.AccountType == "Savings")
                {
                    SavingsAccount sa = BankServiceProvider.savaccounts.FirstOrDefault(sa => sa.AccountNumber == accountNumber);
                    sa.Withdraw(amount);
                }
                else if (ac.AccountType == "ZeroBalance")
                {
                    ZeroBalanceAccount za = BankServiceProvider.zeroaccounts.FirstOrDefault(za => za.AccountNumber == accountNumber);
                    za.Withdraw(amount);
                }
                else
                {
                    Console.WriteLine("Account doesn't exist..");
                }
 
            }
            else
            {
                Console.WriteLine("Invalid Account");
            }
            
        }
    }
}
