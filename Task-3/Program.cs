using System;

namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* You are responsible for calculating compound interest on savings accounts for bank customers. You 
            need to calculate the future balance for each customer's savings account after a certain number of years. 
            Tasks: 
            1. Create a program that calculates the future balance of a savings account. 
            2. Use a loop structure (e.g., for loop) to calculate the balance for multiple customers. 
            3. Prompt the user to enter the initial balance, annual interest rate, and the number of years. 
            4. Calculate the future balance using the formula:      
            future_balance = initial_balance * (1 + annual_interest_rate/100)^years. 
            5. Display the future balance for each customer.*/


            /*  //Getting user input initial  balance
            Console.WriteLine("Enter the Initial Balance");
            int initialBalance = int.Parse(Console.ReadLine());

            //Getting user input annual interest rate
            Console.WriteLine("Enter the Annual Interest Rate");
            int interestRate = int.Parse(Console.ReadLine());

            //Getting user input Number of Years
            Console.WriteLine("Enter the Number of Years");
            int numOfYears = int.Parse(Console.ReadLine());

            int future_balance = initialBalance * (1 + interestRate / 100) ^ numOfYears;
            Console.WriteLine(future_balance);  */

            //-----------using array

            //getting output
            Console.WriteLine("Welcome!!");

            //enter the number of customers
            Console.Write("Enter the number of customers: ");
            int numberOfCustomers = int.Parse(Console.ReadLine());

            // Create a multidimensional array to store customer data [customer, data]
            double[,] customerData = new double[numberOfCustomers, 3]; // Columns: initial balance, annual interest rate, years

            // Loop to get input for each customer
            for (int i = 0; i < numberOfCustomers; i++)
            {
                Console.WriteLine($"\nCustomer {i + 1}:");

                // enter initial balance, annual interest rate, and number of years
                Console.Write("Enter the initial balance: $");
                customerData[i, 0] = double.Parse(Console.ReadLine());

                Console.Write("Enter the annual interest rate in %: ");
                customerData[i, 1] = double.Parse(Console.ReadLine());

                Console.Write("Enter the number of years: ");
                customerData[i, 2] = int.Parse(Console.ReadLine());
            }

            // Calculate and display the future balance for each customer
            for (int i = 0; i < numberOfCustomers; i++)
            {
                double initialBalance = customerData[i, 0];
                double annualInterestRate = customerData[i, 1];
                int years = (int)customerData[i, 2];

                double futureBalance = initialBalance * Math.Pow((1 + annualInterestRate / 100), years);

                Console.WriteLine($"\nFuture balance for Customer {i + 1}: ${futureBalance:F2}");
            }

            Console.WriteLine("\nThank you !!");
        }
    }
}
