using DbConnect.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.model;

namespace Task_1.Repositories
{
    internal class InventoryRepository
    {
        public static List<Inventory> Inventories=new List<Inventory>();
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public InventoryRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public void InsertInventory(Inventory inventory)
        {
            Inventories.Add(inventory);
        }
           public void GetProduct(int productid)
        {
            Console.WriteLine("*****GetProduct Method*****");
               
            foreach (Inventory inventory in Inventories)
            {
                if (inventory.Products.ProductID == productid)
                {
                    Console.WriteLine(inventory);
                }
            }

        }
        public void GetQuantityInStock(int productid)
        {
           
            foreach (Inventory inventory in Inventories)
            {
                if (inventory.Products.ProductID == productid)
                {
                    Console.WriteLine("QuantityInStock::" +  inventory.QuantityInStock);
                }
            }
        }
        public void AddToInventory(int ProductID,int Quantity)
        {
           Console.WriteLine("**AddToInventory**");
           foreach(Inventory inventory in Inventories)
            {
                if(inventory.Products.ProductID == ProductID)
                {
                    inventory.QuantityInStock=inventory.QuantityInStock+Quantity;

                }
            }
        }

        public void RemoveFromInventory(int Productid, int Quantity)
        {
            Console.WriteLine("**AddToInventory**");
            foreach (Inventory inventory in Inventories)
            {
                if (inventory.Products.ProductID == Productid)
                {
                    inventory.QuantityInStock = inventory.QuantityInStock - Quantity;

                }
            }
        }
        public void UpdateStockQuantity(int Productid, int Quantity)
        {
            Console.WriteLine("**UpdateStockQuantity**");
            foreach (Inventory inventory in Inventories)
            {
                if (inventory.Products.ProductID == Productid)
                {
                    inventory.QuantityInStock =  Quantity;

                }
            }

        }
        public void IsProductAvailable(int ProductId,int quantity)
        {
           foreach (Inventory inventory in Inventories)
          {
                if(inventory.Products.ProductID==ProductId)
                 {
                    if(inventory.QuantityInStock>quantity)
                    {
                        Console.WriteLine("Product Available");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Product Unavailable");
                    }
                 }
          }
        }
        public void GetInventoryValue(int ProductId)
        {
            
            foreach (Inventory inventory in Inventories)
            {
                if (inventory.Products.ProductID == ProductId)
                {
                    int inventory_value = Convert.ToInt32(inventory.Products.Price) * inventory.QuantityInStock;
                    Console.WriteLine(inventory_value);
                }
            }
        }
        public void ListLowStockProducts(int threshold)
        {
            
            foreach (Inventory inventory in Inventories)
            {
                if (inventory.QuantityInStock < threshold)
                {
                    Console.WriteLine(inventory);
                }
            }
        }
        public void ListOutOfStockProducts()
        {
            foreach (Inventory inventory in Inventories)
            {
                if (inventory.QuantityInStock == 0)
                {
                    Console.WriteLine(inventory);
                }
            }
        }
        public void ListAllProducts()
        {
            foreach (Inventory inventory in Inventories)
            {
                Console.WriteLine(inventory.Products.ProductName);
            }
        }
    }
}
