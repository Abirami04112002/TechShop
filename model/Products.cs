using Task_1.model;
using System.Diagnostics;
using System.Net;
using System.Transactions;
using System.Runtime.CompilerServices;

namespace Task_1.model
{
    internal class Products
    {
        public int ProductID
        { get; set; }
        public string ProductName
        { get; set; }
        public string Description
        { get; set; }
        public decimal Price
        { get; set; }

        public Products()
        {
        }
        public Products(int ProductID)
        {
            this.ProductID = ProductID;
        }


        public Products(int ProductID, string ProductName, string Description, decimal price)
        {
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.Description = Description;
            this.Price = price;
        }
        public override string ToString() 
        {
            return $"ProductID::{ProductID}\t ProductName::{ProductName}\t Description::{Description}\t price::{Price}";
        }


    }
}
