
namespace Task_8
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public void PrintInformations()
        {
            Console.WriteLine($"Customer ID :: {CustomerId} \n First Name :: {FirstName} \n Last Name :: {LastName} \n Email Address :: {Email} \n Phone Number :: {PhoneNumber} \n Address :: {Address}");
        }


        public Customer(int CustomerId, string FirstName, string LastName, string Email, string PhoneNumber, string Address)
        {
            this.CustomerId = CustomerId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
        }
    }
}
