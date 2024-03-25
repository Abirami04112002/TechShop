using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Exceptions;
using Task_1.model;
using Task_1.Repositories;

namespace DbConnect.service
{
    internal class InventoryService
    {
        public InventoryService() { }
        public void InventoryDirectory()
        {
            Inventory inventory = new Inventory();
            int choice6 = 0;
            InventoryRepository inventoryRepository = new InventoryRepository();
            do
            {
                Console.WriteLine("****Inventory Details****");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"1: Insert Inventory Details\n2: Get Product Details\n3: Get Quantity In Stock\n4. Add Quantity to Inventory\n5: Remove from inventory\n6: Update Stock Quantity\n7: IsPRoductAvailable\n8: Get Inventory Value\n9: Get Low Stock Products\n10: Get all the OutOfStockProduct\n11: List all PRoducts\n12: Exit\n ");
                Console.WriteLine("Enter your choice: ");

                choice6 = int.Parse(Console.ReadLine());
                switch (choice6)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Enter Inventory ID: ");
                            int Inventoryid = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Productid: ");
                            int productid = int.Parse(Console.ReadLine());
                            Products products1 = new Products(productid);
                            Console.WriteLine("Enter Quantity in stock");
                            int QuantityInStock = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Last stock update: ");
                            string LastStockUpdate = Console.ReadLine();
                            inventory = new Inventory(Inventoryid, products1, QuantityInStock, DateTime.Parse(LastStockUpdate));
                            InvalidInventoryDataException.InvalidData(inventory);
                            DuplicateInventoryIdException.DuplicateId(Inventoryid);
                            ProductNotFoundException.ProductNotFound(products1.ProductID);
                            inventoryRepository.InsertInventory(inventory);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("Enter ProductId to get: ");
                            int ProductID = int.Parse(Console.ReadLine());
                            ProductNotFoundException.ProductNotFound(ProductID);
                            inventoryRepository.GetProduct(ProductID);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 3:
                        try
                        {
                            Console.WriteLine("Enter ProductId to get: ");
                            int ProductID = int.Parse(Console.ReadLine());
                            ProductNotFoundException.ProductNotFound(ProductID);
                            inventoryRepository.GetQuantityInStock(ProductID);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 4:
                        try
                        {
                            Console.WriteLine("Enter ProductId to add: ");
                            int ProductID = int.Parse(Console.ReadLine());
                            ProductNotFoundException.ProductNotFound(ProductID);
                            Console.WriteLine("Enter the Quantity to add");
                            int quantity = int.Parse(Console.ReadLine());
                            inventoryRepository.AddToInventory(ProductID, quantity);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 5:
                        try
                        {
                            Console.WriteLine("Enter ProductId to remove: ");
                            int ProductID = int.Parse(Console.ReadLine());
                            ProductNotFoundException.ProductNotFound(ProductID);
                            Console.WriteLine("Enter the Quantity to add");
                            int quantity = int.Parse(Console.ReadLine());
                            inventoryRepository.RemoveFromInventory(ProductID, quantity);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 6:
                        try
                        {
                            Console.WriteLine("Enter ProductId to update: ");
                            int ProductID = int.Parse(Console.ReadLine());
                            ProductNotFoundException.ProductNotFound(ProductID);
                            Console.WriteLine("Enter the Quantity to add");
                            int newquantity = int.Parse(Console.ReadLine());
                            inventoryRepository.UpdateStockQuantity(ProductID, newquantity);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 7:
                        try
                        {
                            Console.WriteLine("Enter ProductId to check available: ");
                            int ProductID = int.Parse(Console.ReadLine());
                            ProductNotFoundException.ProductNotFound(ProductID);
                            Console.WriteLine("Enter the Quantity to check");
                            int quantity = int.Parse(Console.ReadLine());
                            inventoryRepository.IsProductAvailable(ProductID, quantity);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 8:
                        try
                        {
                            Console.WriteLine("Enter ProductId to get total inventory value: ");
                            int ProductID = int.Parse(Console.ReadLine());
                            ProductNotFoundException.ProductNotFound(ProductID);
                            inventoryRepository.GetInventoryValue(ProductID);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 9:
                        try
                        {
                            Console.WriteLine("Enter threshold value to list low stock: ");
                            int threshold = int.Parse(Console.ReadLine());
                            InvalidThresholdDataException.InvalidThresholdData(threshold);
                            inventoryRepository.ListLowStockProducts(threshold);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 10:
                        inventoryRepository.ListOutOfStockProducts();
                        break;

                    case 11:
                        inventoryRepository.ListAllProducts();
                        break;

                    case 12:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice6 != 12);
        }
    }
}
