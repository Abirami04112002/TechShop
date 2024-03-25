using DbConnect.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Exceptions;
using Task_1.model;
using Task_1.Repositories;

namespace DbConnect.Techshopsys
{
    internal class TechshopManagement
    {

        public static void run()
        {
            CustomerService customerService = new CustomerService();
            ProductService productService= new ProductService();
            OrderDetailsService orderDetailsService = new OrderDetailsService();
            OrderService orderService = new OrderService();
            InventoryService inventoryService = new InventoryService();
            int choice1 = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("******Main Menu********");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"1: Customers\n2: Products\n3: Orders\n4: OrderDetails\n5: Inventory\n6: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice1 = int.Parse(Console.ReadLine());
                switch (choice1)
                {
                    case 1:
                        Console.Clear();
                        customerService.CustomerDirectory();
                        break;

                    case 2:
                        Console.Clear();
                        productService.PRoductDirectory();
                        break;

                    case 3:
                        Console.Clear();
                        orderService.OrderDirectory();
                        break;

                    case 4:
                        Console.Clear();
                        orderDetailsService.OrderDetailDirectory();
                        break;

                    case 5:
                        Console.Clear();
                        inventoryService.InventoryDirectory();
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice1 != 6);
        }
    }
}
