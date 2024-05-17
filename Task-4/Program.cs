using System;

namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {

/* You are tasked with creating a program that allows bank customers to check their account balances. 
The program should handle multiple customer accounts, and the customer should be able to enter their 
account number, balance to check the balance. 
Tasks: 
1. Create a Python program that simulates a bank with multiple customer accounts. 
2. Use a loop (e.g., while loop) to repeatedly ask the user for their account number and 
balance until they enter a valid account number. 
3. Validate the account number entered by the user. 
4. If the account number is valid, display the account balance. If not, ask the user to try again.  */

            int numacc = 5;
            Boolean flag = false;
            double[,] account =
            {
                {12345,1000 },
                {23456,2000 },
                {34567,3000 },
                {45678,4000 },
                {56789,3500 }
            };

        //enter the user account number
        login:
            Console.WriteLine("enter your account number:");
            int accountnum = int.Parse(Console.ReadLine());
            for (int i = 0; i < numacc; i++)
            {
                if (accountnum == account[i, 0])
                {
                    flag = true;
                    Console.WriteLine($"your balance is {account[i, 1]}");
                    break;
                }
            }
            while (!flag)
            {
                Console.WriteLine("enter the correct account number");
                goto login;
            }
        }
    }
}
