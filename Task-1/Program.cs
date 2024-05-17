namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
/* In a bank, you have been given the task is to create a program that checks if a customer is eligible for 
a loan based on their credit score and income. The eligibility criteria are as follows: 
• Credit Score must be above 700. 
• Annual Income must be at least $50,000. 
Tasks: 
1. Write a program that takes the customer's credit score and annual income as input. 
2. Use conditional statements (if-else) to determine if the customer is eligible for a loan. 
3. Display an appropriate message based on eligibility. */


            //Getting input from the user
            Console.WriteLine("Kindly provide the Customer's Credit Score:");
            int customerCreditScore = int.Parse(Console.ReadLine());
            Console.WriteLine("Kindly provide the Customer's Annual Income:");
            int annualIncome = int.Parse(Console.ReadLine());

            //check for the condition using if else
            if (customerCreditScore > 700 && annualIncome >= 50000)
            {
                Console.WriteLine("CONGRATS!!! You Are Eligible");
            }
            else
            {
                Console.WriteLine("SORRY!!! You Are Not Eligible");
            }

            //using ternary operator
            Console.WriteLine((customerCreditScore > 700 && annualIncome >= 50000) ? "CONGRATS!!! You Are Eligible" : "SORRY!!! You Are Not Eligible");
        }
    }
}
