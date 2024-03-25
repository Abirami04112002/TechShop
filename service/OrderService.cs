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
    internal class OrderService
    {
        public OrderService() { }
        public void OrderDirectory()
        {
            int choice4 = 0;
            OrdersRepository ordersRepository = new OrdersRepository();
            Orders orders = new Orders();
            do
            {
                Console.WriteLine("*****Orders Placed****");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"1: InsertOrders\n2: CalculateTotalAmount\n3: GetOrderDetails\n4: UpdateOrderStatus\n5: CancelOrders\n6: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice4 = int.Parse(Console.ReadLine());
                switch (choice4)
                {
                    case 1:
                        ordersRepository.InsertOrder();
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("Enter Order ID: ");
                            int orderID = int.Parse(Console.ReadLine());
                            OrderNotFoundException.OrderNotFound(orderID);
                            ordersRepository.CalculateTotalAmount(orderID);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 3:
                        try
                        {
                            Console.WriteLine("Enter Order ID: ");
                            int orderId = int.Parse(Console.ReadLine());
                            OrderNotFoundException.OrderNotFound(orderId);
                            ordersRepository.GetOrderDetails(orderId);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 4:
                        try
                        {
                            Console.WriteLine("ProductId to be updated: ");
                            int orderid = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the status of the Product");
                            string status = Console.ReadLine();
                            OrderNotFoundException.OrderNotFound(orderid);
                            ordersRepository.UpdateOrderStatus(orderid, status);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 5:
                        try
                        {
                            Console.WriteLine("Enter the orderId to cancel");
                            int orderid1 = int.Parse(Console.ReadLine());
                            OrderNotFoundException.OrderNotFound(orderid1);
                            ordersRepository.CancelOrder(orderid1);
                        }
                        catch (Exception ex1) { Console.WriteLine(ex1.Message); }
                        break;

                    case 6:
                        Console.WriteLine("Exiting....");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;

                }
            } while (choice4 != 6);
        }
    }
}
