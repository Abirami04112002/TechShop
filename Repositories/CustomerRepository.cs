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
    internal class CustomerRepository
    {
        public static List<Customers> Customers = new List<Customers>();
        Customers customers=new Customers();
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public CustomerRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }


        public void AddCustomer()
        {
            try
            {

                cmd.CommandText = "Insert into Customers values(@id,@firstname,@lastname,@email,@phone,@address)";
                cmd.Connection = connect;
                Console.WriteLine("Enter Customer id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter first name: ");
                string Firstname = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                string Lastname = Console.ReadLine();
                Console.WriteLine("Enter email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Enter phone number ");
                string PhoneNumber = Console.ReadLine();
                Console.WriteLine("Enter Address: ");
                string Address = Console.ReadLine();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id",id);
                cmd.Parameters.AddWithValue("@firstname", Firstname);
                cmd.Parameters.AddWithValue("@lastname", Lastname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", PhoneNumber);
                cmd.Parameters.AddWithValue("@address", Address);
                connect.Open();
                int addCustomerStatus=cmd.ExecuteNonQuery();
                connect.Close();

                Console.WriteLine("Customer added successfully");
                Console.WriteLine();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }    
        }
        public void CalculateTotalOrders()
        {
            try
            {
                cmd.CommandText = "select distinct count(Order_id) from Orders where Customer_id=@customerid";
                cmd.Connection = connect;
                Console.WriteLine("Enter Customer Id: ");
                int customerID = int.Parse(Console.ReadLine());
                CustomerNotFoundExceptioncs.CustomerNotFound(customerID);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@customerid", customerID);
                connect.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                int totalOrders = (int)Reader[0];
                connect.Close();
                
                Console.WriteLine($"Total Order Made by Customer::{customerID} is {totalOrders}");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void GetCustomerDetails()
        {
            try
            {
                Customers customers = new Customers();
                cmd.CommandText = "select * from Customer where Customer_id=@customerid";
                cmd.Connection = connect;
                Console.WriteLine("Enter Customer Id: ");
                int customerID = int.Parse(Console.ReadLine());
                CustomerNotFoundExceptioncs.CustomerNotFound(customerID);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@customerid", customerID);
                connect.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                while(Reader.Read())
                {
                    customers.CustomerID = (int)Reader["Customer_id"];
                    customers.FirstName = (string)Reader["First_name"];
                    customers.LastName = (string)Reader["Last_name"];
                    customers.email = (string)Reader["email"];
                    customers.address = (string)Reader["address_customer"];
                    customers.phoneNumber = (string)Reader["mobile_no"];
                }
                Console.WriteLine(customers);
                connect.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void UpdateCustomerInfo()
        {
            try
            {

                
               
                Customers customers = new Customers();
                cmd.CommandText = "update Customer set First_Name=@firstname where Customer_id=@customerid";
                cmd.Connection = connect;
                Console.WriteLine("Enter Customer Id: ");
                int customerID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the updated Name");
                string UpdatedFirstName = Console.ReadLine();
                CustomerNotFoundExceptioncs.CustomerNotFound(customerID);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@customerid", customerID);
                cmd.Parameters.AddWithValue("@firstname", UpdatedFirstName);

                connect.Open();
                int updatestatus= cmd.ExecuteNonQuery();
               
                Console.WriteLine("CustomerDataUpdated....!!");
                connect.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }


            
            
        }
    }
}
