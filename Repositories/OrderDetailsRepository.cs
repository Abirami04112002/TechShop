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
    internal class OrderDetailsRepository
    {
        public static List<OrderDetails> OrderDetails = new List<OrderDetails>();
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public OrderDetailsRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public void InsertOrderDetail(OrderDetails orderDetails)
        {
            cmd.CommandText = "Insert into Orderdetails values(@id,@orderid,@productid,@quantity)";
            cmd.Connection = connect;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", orderDetails.OrderDetailID);
            cmd.Parameters.AddWithValue("@orderid", orderDetails.orders.OrderID);
            cmd.Parameters.AddWithValue("@productid", orderDetails.products.ProductID);
            cmd.Parameters.AddWithValue("@quantity", orderDetails.quantity);
            connect.Open();
            int addCustomerStatus = cmd.ExecuteNonQuery();
            connect.Close();

            Console.WriteLine($"Order Details added successfully {addCustomerStatus} row affected");
            Console.WriteLine();
        }

        //select Total_amt from Orders  join Orderdetails on Orders.Order_id=Orderdetails.Order_id where Orderdetails.Orderdetails_id= @orderdetailid
        public void CalculateSubtotal(int orderdetailid)
        {



            cmd.CommandText = "SELECT (od.Quantity * p.Price) FROM Orderdetails od INNER JOIN Products p ON od.ProductID = p.ProductID WHERE od.Orderdetails_id = @OrderDetailID";
            cmd.Connection = connect;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@OrderDetailID", orderdetailid);
            connect.Open();
            object result = cmd.ExecuteScalar();
            connect.Close();
            Console.WriteLine($"{result}");

        }

        public void GetOrderDetailInfo(int orderDetailsID)
        {


            cmd.CommandText = "SELECT * FROM Orderdetails WHERE Orderdetails_id = @OrderDetailID";
            cmd.Connection = connect;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@OrderDetailID", orderDetailsID);
            connect.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            OrderDetails orderDetail = new OrderDetails();

            while (reader.Read())
            {
                orderDetail = new OrderDetails
                {
                    OrderDetailID = (int)reader["Orderdetails_id"],
                    orderid = (int)reader["Order_id"],
                    ProductId = (int)reader["Product_id"],
                    quantity = (int)reader["Quantity"]
                };
            }

            reader.Close();
            connect.Close();
            Console.WriteLine(orderDetail);



        }
        public void UpdateQuantity(int orderdetailid, int updated_quantity)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "UPDATE OrderDetails SET Quantity = @Quantity WHERE Orderdetails_id = @OrderDetailID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Quantity", updated_quantity);
            cmd.Parameters.AddWithValue("@OrderDetailID", orderdetailid);
            cmd.ExecuteNonQuery();
            connect.Close();
            Console.WriteLine("Quantity Updated!!");
        }
        public void AddDiscount(int orderdetailsid,int discountAmount)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = @"UPDATE Products 
                                SET Price = (
                                    SELECT (od.Quantity * p.Price) - @DiscountAmount
                                    FROM Orderdetails od
                                    INNER JOIN Products p ON od.Product_id = p.Product_id
                                    WHERE od.Orderdetails_id = @OrderDetailID
                                )";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@OrderDetailID", orderdetailsid);
            cmd.Parameters.AddWithValue("@DiscountAmount", discountAmount);
            cmd.ExecuteNonQuery();
            connect.Close();

        }
    }
}

