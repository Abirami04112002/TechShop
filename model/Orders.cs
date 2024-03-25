using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace Task_1.model
{
    internal class Orders
    {
        public int OrderID { get; set; }
        public Customers Customers {  get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate {  get; set; }
        public decimal TotalAmount {  get; set; }

        public string status { get; set; }

        public Orders() { }
        public Orders(int orderID) { this.OrderID = orderID; }
        public Orders(int orderID, Customers customers, DateTime orderdate, decimal totalamount,string status)
        {
            this.OrderID = orderID;     
            this.Customers = customers;
            this.OrderDate = orderdate;
            this.TotalAmount = totalamount;
            this.status = status;
        }
        public override string ToString() 
        {
            return $"ORderId::{OrderID}\t CustomerID::{Customers.CustomerID}\t OrderDate::{OrderDate}\t TotalAmount::{TotalAmount}\t Status::{status}";
        }

        

    }
}
