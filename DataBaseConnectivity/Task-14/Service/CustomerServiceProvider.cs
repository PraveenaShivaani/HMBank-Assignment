
using Task_14.Exceptions;

namespace Task_14
{
    internal class CustomerServiceProvider : ICustomerServiceProvider
    {
        
        public double Deposit(Account account,int amount)
        {
            if(account != null) 
            {
                //Console.WriteLine("Enter the Amount to be Deposited::");
                //double amount = double.Parse(Console.ReadLine());
                return account.AccountBalance + amount; 
                //Console.WriteLine($"Deposited {amount:C} into account number {account.AccountNumber}. New balance: {ac.AccountBalance:C}");
            }
            else
            {
                throw new Exception("Invalid Account.");
            }
        }

        public double Withdraw(Account account,int amount)
        {
            if (account != null)
            {
                String AccountType = account.AccountType.ToLower();
                if(AccountType == "current")
                {
                    account.AccountBalance = CurrentAccount.Withdraw(account,amount);
                    return account.AccountBalance;
                }
                else if(AccountType == "savings")
                {
                    account.AccountBalance = SavingsAccount.Withdraw(account,amount);
                    return account.AccountBalance;
                }
                else if (AccountType == "zero_balance")
                {
                    account.AccountBalance = ZeroBalanceAccount.Withdraw(account,amount);
                    return account.AccountBalance;
                }
                else
                {
                    throw new Exception($"Invalid account type: {AccountType}");
                }
            }
            else
            {
                throw new InvalidAccountException("Invalid Account.");
            }
        }

        public void GetAccountBalance(Account account)
        {
            if(account != null)
            {
                Console.WriteLine($"Your Account Balance is {account.AccountBalance}");
            }
        }

        public void GetAccountDetails(Account account,Customer customer)
        {
            if(account != null && customer != null)
            {
                Console.WriteLine($"Account Id :: {account.InterestRate} \n " +
                    $"Customer Id :: {customer.CustomerID}\n" +
                    $"First Nmae :: {customer.FirstName +" "+ customer.LastName} \n" +
                    $"Account Balance :: {account.AccountBalance} \n" +
                    $"Account Type :: {account.AccountType} \n");
            }
            else
            {
                throw new Exception("Invalid Account or CustomerId");
            }
        }

       

        public void CalculateInterest(Account account)
        {
            
            Console.WriteLine($"Your Interest Rate is :: {account.InterestRate * (decimal)account.AccountBalance}");
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, float amount)
        {
            throw new NotImplementedException();
        }
    }
    }

