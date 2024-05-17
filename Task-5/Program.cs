using System.Diagnostics.Metrics;

namespace Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
/* Write a program that prompts the user to create a password for their bank account. Implement if 
conditions to validate the password according to these rules: 
• The password must be at least 8 characters long. 
• It must contain at least one uppercase letter. 
• It must contain at least one digit. 
• Display appropriate messages to indicate whether their password is valid or not. */


        LOGIN:
                Console.WriteLine("Kindly enter the password for Authentication");
                string password = Console.ReadLine();
                Boolean flag = false;
                string special = "!@#$&*?";
                if (password.Length >= 8)
                {
                    if (password.Any(char.IsUpper))
                    {
                        if (password.Any(char.IsNumber))
                        {
                            for (int i = 0; i < password.Length; i++)
                            {
                                for (int j = 0; j < special.Length; j++)
                                {
                                    if (password[i] == special[j])
                                    {
                                        flag = true;
                                        break;
                                    }

                                }
                                if (flag)
                                {
                                    Console.WriteLine("YOUR PASSWORD IS AUTHENTICATED");
                                    break;
                                }
                            }
                            if (!flag)
                            {
                                Console.WriteLine("There is NO special character");
                                goto LOGIN;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Enter any one character with numeric value");
                            goto LOGIN;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter any one character with upper case");
                        goto LOGIN;
                    }
                }
                else
                {
                    Console.WriteLine("Enter a character that has a length of 6");
                    goto LOGIN;
                }
            }
    }
}
