

namespace Task_7
{
    internal class Customer
    {
        /* 1. Create a `Customer` class with the following confidential attributes: 
• Attributes 
o Customer ID 
o First Name 
o Last Name 
o Email Address 
o Phone Number 
o Address 
• Constructor and Methods 
o Implement default constructors and overload the constructor with Customer 
attributes, generate getter and setter, (print all information of attribute) methods for 
the attributes.  */
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Customer(int CustomerId,string FirstName, string LastName, string Email, string PhoneNumber, string Address) 
        {
            this.CustomerId = CustomerId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;

            Console.WriteLine($"Customer ID :: {CustomerId} \n First Name :: {FirstName} \n Last Name :: {LastName} \n Email Address :: {Email} \n Phone Number :: {PhoneNumber} \n Address :: {Address}");
        }

    }
}
