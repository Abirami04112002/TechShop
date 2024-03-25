using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.model;

namespace Task_1.Exceptions
{
    internal class InvalidOrderDataException: Exception
    {
        public InvalidOrderDataException(string text):base (text)
        { 
           
        }

        public static void InvalidOrderData(Orders orders)
        {
            if(orders.OrderDate > DateTime.Now)
            {
                throw new InvalidOrderDataException("Invalid Order Date");
            }
            else if(orders.TotalAmount<0)
            {
                throw new InvalidOrderDataException("Invalid Amount");
            }
        }
    }
}
