using System.Buffers.Text;
using System.Diagnostics;

namespace Task_1.model
{
    internal class Inventory
    {
        public int InventoryID {  get; set; }
        public Products Products { get; set; }
        public int ProductID { get; set; }
        public int QuantityInStock
        {  get; set; }
        public DateTime LastStockUpdate { get; set; }
        public Inventory()
        {   
        }
        public Inventory( int InventoryID, Products Products, int QuantityInStock, DateTime LastStockUpdate)
        { 
            this.InventoryID = InventoryID;
            this.Products = Products;
            this.QuantityInStock = QuantityInStock; 
            this.LastStockUpdate = LastStockUpdate;
        }
        public override string ToString()
        {
            return $"InventoryId::{InventoryID}\t productName::{Products.ProductName}\t Quantity in stock::{QuantityInStock}\t LastStockUpdate::{LastStockUpdate}";
        }



    }
}
