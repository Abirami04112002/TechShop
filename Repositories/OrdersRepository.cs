using DbConnect.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Exceptions;
using Task_1.model;

namespace Task_1.Repositories
{
    internal class OrdersRepository
    {
        public static List<Orders> Orders= new List<Orders>();
        Orders orders=new Orders();
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public OrdersRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public void InsertOrder()
        {
           
            try
            {
                Console.WriteLine("Enter Order ID: ");
                int Orderid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter CustomerID: ");
                int customerID = int.Parse(Console.ReadLine());
                Customers customers1 = new Customers(customerID);
                DateTime OrderDate = DateTime.Now;
                Console.WriteLine("Enter Total Amount: ");
                decimal TotalAmount = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter the status of the Order:");
                string Status = Console.ReadLine();
                orders = new Orders(Orderid, customers1, OrderDate, TotalAmount, Status);
                DuplicateOrderIdException.DuplicateOrderId(Orderid);
                InvalidOrderDataException.InvalidOrderData(orders);
                Orders.Add(orders);

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }



        }
        public void CalculateTotalAmount(int OrderID)
        {
            
            connect.Open();
            cmd.CommandText = @"
                UPDATE Orders
                SET TotalAmount = (
                    SELECT SUM(od.Quantity * p.Price)
                    FROM OrderDetails od
                    INNER JOIN Products p ON od.ProductID = p.ProductID
                    WHERE od.OrderID = @orderid
                )";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("orderid", OrderID);
            cmd.ExecuteNonQuery();
            connect.Close();
        }
        public void GetOrderDetails(int orderid)
        {
            cmd.CommandText = "Select * from Orderdetails  where Order_id=@orderid";
            cmd.Connection = connect;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@orderid", orderid);
            connect.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            OrderDetails orderDetails = new OrderDetails();
            while (Reader.Read())
            {
                orderDetails.OrderDetailID = (int)Reader["Orderdetails_id"];
                orderDetails.orderid = (int)Reader["Order_id"];
                orderDetails.ProductId = (int)Reader["Product_id"];
                orderDetails.quantity = (int)Reader["Quantity"];
            }
            Console.WriteLine(orderDetails);
            connect.Close();

            Console.WriteLine();
        }
        public void UpdateOrderStatus(int orderid,string status)
        {
            connect.Open();
            cmd.CommandText = @"
                UPDATE Orders
                SET StatusOfOrder=@status where Order_id=@orderid
                )";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.ExecuteNonQuery();
            connect.Close();

        }
        public void CancelOrder(int orderid)
        {
            connect.Open();
            cmd.CommandText = @"
                delete from Orders
                where Order_id=@orderid
                )";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.ExecuteNonQuery();
            connect.Close();

        }
    }
}
