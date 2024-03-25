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
    internal class OrderDetailsService
    {
        public OrderDetailsService() { }
        public void OrderDetailDirectory()
        {
            OrderDetails orderDetails = new OrderDetails();
            OrderDetailsRepository orderDetailsRepository = new OrderDetailsRepository();
            int choice5 = 0;
            do
            {
                Console.WriteLine("****OrderDetails****");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"1: Insert Order Details\n2: Calculate Sub Total\n3: Get order Detail Info\n4: Update Quantity\n5:Add Discount\n 6: Exit\n");
                Console.WriteLine("Enter your choice: ");

                choice5 = int.Parse(Console.ReadLine());
                switch (choice5)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Enter OrderDetail Id: ");
                            int OrderdetailID = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the Order ID");
                            int OrderID = int.Parse(Console.ReadLine());
                            Orders orders1 = new Orders(OrderID);
                            Console.WriteLine("Enter Quantity: ");
                            int quantity = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the ProductID ");
                            int ProductID = int.Parse(Console.ReadLine());
                            Products products1 = new Products(ProductID);
                            orderDetails = new OrderDetails(OrderdetailID, orders1, quantity, products1);
                            InvalidOrderDetailsDataException.InvalidOrderDetails(orderDetails);
                            ProductNotFoundException.ProductNotFound(products1.ProductID);
                            OrderNotFoundException.OrderNotFound(orders1.OrderID);
                            orderDetailsRepository.InsertOrderDetail(orderDetails);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("Enter OrderDetail ID: ");
                            int Orderdetailid = int.Parse(Console.ReadLine());
                            OrderDetailNotFoundException.OrderDetailNotFound(Orderdetailid);
                            orderDetailsRepository.CalculateSubtotal(Orderdetailid);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 3:
                        try
                        {
                            Console.WriteLine("Enter OrderDetailID to get Info: ");
                            int orderdetailid1 = int.Parse(Console.ReadLine());
                            OrderDetailNotFoundException.OrderDetailNotFound(orderdetailid1);
                            orderDetailsRepository.GetOrderDetailInfo(orderdetailid1);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 4:
                        try
                        {
                            Console.WriteLine("Enter OrderDetailID to update the Quantity: ");
                            int orderdetailid = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the Quantity:: ");
                            int Quantity = int.Parse(Console.ReadLine());
                            OrderDetailNotFoundException.OrderDetailNotFound(orderdetailid);
                            InvalidQuantityException.InvalidQuantity(Quantity);
                            orderDetailsRepository.UpdateQuantity(orderdetailid, Quantity);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 5:
                        try
                        {
                            Console.WriteLine("Enter the orderdetail ID:");
                            int orderdetailid = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the  discountAmount:");
                            int discountAmount = int.Parse(Console.ReadLine());
                            orderDetailsRepository.AddDiscount(orderdetailid,discountAmount);
                            OrderDetailNotFoundException.OrderDetailNotFound(orderdetailid);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice5 != 6);
        }
    }
}
