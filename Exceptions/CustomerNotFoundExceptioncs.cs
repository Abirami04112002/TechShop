using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.model;
using Task_1.Repositories;

namespace Task_1.Exceptions
{
    internal class CustomerNotFoundExceptioncs:Exception
    {
        public CustomerNotFoundExceptioncs(string text) : base(text)
        {

        }

        public static void CustomerNotFound(int CustomerID)
        {
            bool CustomerExists = false;
            foreach (Customers customers in CustomerRepository.Customers)
            {
                if (customers.CustomerID == CustomerID)
                {
                    CustomerExists = true;
                    break;
                }
            }
            if (!CustomerExists)
            {
                throw new CustomerNotFoundExceptioncs("Student not found!!!");
            }
        }
    }
}
