using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Repositories;

namespace DbConnect.service
{
    internal class CustomerService
    {
        public CustomerService() { }
        CustomerRepository customerRepository = new CustomerRepository();

        public void CustomerDirectory()
            
        {
            int choice2 = 0;
            do
            {
                Console.WriteLine("****Customer Details****");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"1: AddCustomer\n2: CalculateTotalOrder\n3: GetCustomerInfo\n4. UpdateCustomerDetails\n5: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice2 = int.Parse(Console.ReadLine());
                switch (choice2)
                {

                    case 1:
                        customerRepository.AddCustomer();
                        break;

                    case 2:
                        customerRepository.CalculateTotalOrders();
                        break;

                    case 3:
                        customerRepository.GetCustomerDetails();
                        break;

                    case 4:
                        customerRepository.UpdateCustomerInfo();
                        break;

                    case 5:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice2 != 5);
        }
    }
}
