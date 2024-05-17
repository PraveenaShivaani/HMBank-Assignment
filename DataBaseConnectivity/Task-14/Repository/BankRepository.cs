using Microsoft.Data.SqlClient;
using Task_14.Bean;
using Task_14.Exceptions;
using Task14.Utility;

namespace Task_14.Repo
{
    internal class BankRepository : IBankRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        List<Account> accounts = new List<Account>();
        Account account = null;
        Customer customer = null;

        public BankRepository()
        {
            sqlConnection = new SqlConnection("Server=PRASHI;Database=HMBank;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=true");
            //sqlConnection = new SqlConnection("Server=PRASHI;Database=HMBank;Trusted_Connection=True");

            //sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        //GET-ACCOUNT-DETAILS
        public void GetAccountDetails(long AccountNumber)
        {
            cmd.CommandText = "select * from Accounts as A " +
                              "join Customers C on A.customer_id = C.customer_id " +
                              "where A.account_id = @AccountId";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@AccountId", AccountNumber);
            try
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    account = new Account();
                    account.InterestRate = (int)reader[0];
                    account.AccountType = (string)reader[2];
                    account.AccountBalance = (int)reader[3];
                    account.InterestRate = (decimal)reader[4];
                    accounts.Add(account);
                    
                    customer = new Customer();
                    customer.CustomerID = (int)reader["customer_id"];
                    customer.FirstName = (string)reader["first_name"];
                    customer.LastName = (string)reader["last_name"];
                    customer.EmailAddress = (string)reader["email"];

                    CustomerServiceProvider customerServiceProvider = new CustomerServiceProvider();
                    customerServiceProvider.GetAccountDetails(account, customer);
                    //Console.WriteLine($"Account Balance :: {account.AccountBalance} \t CustomerId :: {customer.CustomerID}");
                }
                else
                {
                    throw new InvalidAccountException("Invalid Account");
                }
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
            sqlConnection.Close();
        }

        //DEPOSITE METHOD
        public void Deposit(int AccountNumber, int amount)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "select * from Accounts as A " +
                              "where account_id = @AccountId";
            cmd.Parameters.AddWithValue("@AccountId", AccountNumber);
            SqlDataReader reader = null;
            bool flage = true;
            try
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    account = new Account();
                    account.AccountBalance = (int)reader["balance"];
                    CustomerServiceProvider customerServiceProvider = new CustomerServiceProvider();
                    account.AccountBalance = customerServiceProvider.Deposit(account, amount);
                }
                else
                {
                    flage = false;
                    throw new InvalidAccountException("Account Not Found.");
                }
                sqlConnection.Close();
                if (flage)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE Accounts " +
                        "SET balance = @AccountBalance " +
                        "WHERE account_id = @AccountId";
                    cmd.Parameters.AddWithValue("@AccountId", AccountNumber);
                    cmd.Parameters.AddWithValue("@AccountBalance", account.AccountBalance);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int addProductStatus = cmd.ExecuteNonQuery();
                    if (addProductStatus <= 0)
                    {
                        throw new InvalidAccountException("Unable to Update Account Balance");
                    }
                    
                }
                //sqlConnection.Close();
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }

            sqlConnection.Close();
            //Add to transaction
            if (flage)
            {
                int TranNo = 0;
                cmd.Parameters.Clear();
                cmd.CommandText = "select top 1 transaction_id from Transactions " +
                                  "ORDER BY transaction_id DESC";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    TranNo = (int)reader["transaction_id"];
                }
                sqlConnection.Close();
                TranNo++;

                cmd.CommandText = "insert into Transactions " +
                                  "values(@tranid,@accid,@acctype,@amt,GETDATE())";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@tranid", TranNo);
                cmd.Parameters.AddWithValue("@accid", AccountNumber);
                cmd.Parameters.AddWithValue("@acctype", "deposite");
                cmd.Parameters.AddWithValue("@amt", amount);
                //cmd.Parameters.AddWithValue("@date", DateOnly);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int accountStatus = cmd.ExecuteNonQuery();
                if (accountStatus <= 0)
                {
                    throw new Exception("Unable to Add Transaction to the Transaction History");
                }
                sqlConnection.Close();
            }
        }

        //WITHDRAW METHOD
        public void Withdraw(int AccountNumber,int amount)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "select * from Accounts as A " +
                              "where account_id = @AccountId";
            cmd.Parameters.AddWithValue("@AccountId", AccountNumber);
            bool flage = true;
            SqlDataReader reader = null;
            try
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    account = new Account();
                    account.AccountBalance = (int)reader["balance"];
                    account.AccountType = (string)reader["account_type"];
                    CustomerServiceProvider customerServiceProvider = new CustomerServiceProvider();
                    account.AccountBalance = customerServiceProvider.Withdraw(account, amount);
                }
                else
                {
                    flage = false;
                    throw new InvalidAccountException("Account Not Found.");
                }
                sqlConnection.Close();
                if (flage)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE Accounts " +
                        "SET balance = @AccountBalance " +
                        "WHERE account_id = @AccountId";
                    cmd.Parameters.AddWithValue("@AccountId", AccountNumber);
                    cmd.Parameters.AddWithValue("@AccountBalance", account.AccountBalance);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int addProductStatus = cmd.ExecuteNonQuery();
                    if (addProductStatus <= 0)
                    {
                        throw new InvalidAccountException("Unable to Update Account Balance");
                    }
                    
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            sqlConnection.Close();

            //Add to transaction
            if (flage)
            {
                int TranNo = 0;
                cmd.Parameters.Clear();
                cmd.CommandText = "select top 1 transaction_id from Transactions " +
                                  "ORDER BY transaction_id DESC";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    TranNo = (int)reader["transaction_id"];
                }
                sqlConnection.Close();
                TranNo++;

                cmd.CommandText = "insert into Transactions " +
                                  "values(@tranid,@accid,@acctype,@amt,GETDATE())";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@tranid", TranNo);
                cmd.Parameters.AddWithValue("@accid", AccountNumber);
                cmd.Parameters.AddWithValue("@acctype", "withdrawal");
                cmd.Parameters.AddWithValue("@amt", amount);
                //cmd.Parameters.AddWithValue("@date", DateOnly);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int accountStatus = cmd.ExecuteNonQuery();
                if (accountStatus <= 0)
                {
                    throw new Exception("Unable to Add Transaction to the Transaction History");
                }
                sqlConnection.Close();
            }

        }

        //TRANSFER METHOD
        public void Transfer(int fromAccountNumber, int toAccountNumber,int amount)
        {
            List<int> AccNo = new List<int>();
            cmd.CommandText = "select account_id from Accounts";
            try
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AccNo.Add((int)reader["account_id"]);
                }
                sqlConnection.Close();
                int fromAccNumber = AccNo.FirstOrDefault(acc => acc == fromAccountNumber);
                int toAccNumber = AccNo.FirstOrDefault(acc => acc == toAccountNumber);
                if (fromAccNumber != null && toAccNumber != null)
                {
                    Withdraw(fromAccNumber, amount);
                    Deposit(toAccNumber, amount);
                }
                else
                {
                    throw new InvalidAccountException("Incorrect Sender's or Receriver's Account Number");
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        //LISTACCOUNTS METHOD
        public void ListAccounts()
        {
            List<int> AccNo = new List<int>();
            cmd.CommandText = "select account_id from Accounts";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AccNo.Add((int)reader["account_id"]);
            }
            sqlConnection.Close();
            int i = 1;
            foreach(int acc in AccNo)
            {
                Console.WriteLine($"Account Number {i++}:: {acc}");
            }
        }

        //GET-ACCOUNT-BALANCE
        public void GetAccountBalance(int AccountNumber)
        {
            cmd.CommandText = "select balance from Accounts "+
                              "where account_id = @AccountId";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@AccountId", AccountNumber);
            try
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    account = new Account();
                    account.AccountBalance = (int)reader[0];

                    CustomerServiceProvider customerServiceProvider = new CustomerServiceProvider();
                    customerServiceProvider.GetAccountBalance(account);
                }
                else
                {
                    throw new InvalidAccountException("Invalid Account");
                }
                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //CREATE ACCOUNT METHOD
        public void CreateAccount(int customerId, string accountType, int initialBalance)
        {
            bool flage = false;
            cmd.CommandText = "select customer_id from Customers ";
            cmd.Parameters.Clear();
            try
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if ((int)reader["customer_id"] == customerId)
                    {
                        flage = true;
                    }
                }
                sqlConnection.Close();
                if (!flage)
                {
                    throw new Exception("Invalid Customer Exception");
                }
                int AccNo = 0;
                cmd.CommandText = "select top 1  account_id from Accounts " +
                                  "ORDER BY account_id DESC";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    AccNo = (int)reader["account_id"];
                }
                sqlConnection.Close();
                AccNo++;

                cmd.CommandText = "insert into Accounts " +
                                  "values(@acnum,@custid,@type,@bal,@rate)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@acnum", AccNo);
                cmd.Parameters.AddWithValue("@custid", customerId);
                cmd.Parameters.AddWithValue("@type", accountType);
                cmd.Parameters.AddWithValue("@bal", initialBalance);
                cmd.Parameters.AddWithValue("@rate", 0.5);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int accountStatus = cmd.ExecuteNonQuery();
                if (accountStatus <= 0)
                {
                    throw new Exception("Unable to Create Account");
                }
                else
                {
                    Console.WriteLine("Account Created Successfully..!!\n" +
                        $"Your Account Number is :: {AccNo}");
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                   Console.WriteLine (ex.Message );
            }
        }

        //GET TRANSACTIONS METHODS
        public void GetTransactions(int accountId)
        {
            List<Transactions> transactions = new List<Transactions>(); 
            cmd.CommandText = "SELECT * FROM Transactions " +
                  "WHERE account_id = @accid";
            bool flag = false;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@accid",accountId);
            try
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    flag = true;
                    Transactions transactions1 = new Transactions();
                    transactions1.amount = (int)reader["amount"];
                    transactions1.transaction_id = (int)reader["transaction_id"];
                    transactions1.transaction_type = (string)reader["transaction_type"];
                    transactions1.account_id = (int)reader["account_id"];
                    transactions.Add(transactions1);
                }
                sqlConnection.Close();
                if (!flag)
                {
                    throw new InvalidAccountException("Invalid Account");
                }
                Transactions.ViewTransactions(transactions);
            }
            catch(Exception ex)
            {
                Console.WriteLine (ex.Message );
            }
        }

        //CALCULATE INTEREST
        public void CalculateInterest(int accountId)
        {
            cmd.CommandText = "SELECT balance,interest_rate FROM Accounts " +
                  "WHERE account_id = @accid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@accid", accountId);
            try
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    account = new Account();
                    account.AccountBalance = (int)reader["balance"];
                    account.InterestRate = (decimal)reader["interest_rate"];
                    CustomerServiceProvider provider = new CustomerServiceProvider();
                    provider.CalculateInterest(account);
                }
                else
                {
                    throw new InvalidAccountException("Invalid Account");
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine (ex.Message );
            }
        }
    }
}

