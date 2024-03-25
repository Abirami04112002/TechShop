using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.model;

namespace Task_1.Exceptions
{
    internal class InvalidCustomerDataException: Exception
    {
        public InvalidCustomerDataException(string text) : base(text)
        {

        }
        public static void InvalidCustomerData(Customers customers)
        {
            if (customers.phoneNumber.Length > 10)
            {
                throw new InvalidCustomerDataException("Invalid PhoneNumber!!!");
            }
            else if (!customers.email.Contains('@'))
            {
                throw new InvalidCustomerDataException("Invalid email address!!!");
            }
        }
    }
}
