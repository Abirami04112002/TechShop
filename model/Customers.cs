
namespace Task_1.model
{
    internal class  Customers
    {
        public int CustomerID {  get; set; }
        public string FirstName {  get; set; }
        public string LastName {  get; set; }
        public string email { get; set; }
        public string phoneNumber {  get; set; }
        public string address { get; set; }


        public Customers()
        {

        }

        public Customers(int CustomerID)
        {
            this.CustomerID = CustomerID;
        }
        public Customers(int CustomerID,string FirstName,string LastName,string email,string phoneNumber,string address) 
        {
            this.CustomerID = CustomerID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }
        public override string ToString()
        {
            return $"CustomerID:: {CustomerID}\t FirstName::{FirstName}\t LastName:: {LastName}\t email::{email}\t phoneNumber::{phoneNumber}\t address::{address}\t";
        }
    }
}
