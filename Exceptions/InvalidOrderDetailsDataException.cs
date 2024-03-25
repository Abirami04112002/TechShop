using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.model;
using Task_1.Repositories;

namespace Task_1.Exceptions
{
    internal class InvalidOrderDetailsDataException: Exception
    {
         public InvalidOrderDetailsDataException(string text):base(text) { }

        public static void InvalidOrderDetails(OrderDetails orderDetails)
        {
            if(orderDetails.quantity<0)
            {
                throw new InvalidOrderDetailsDataException("Quantity value cannot be Negative");
            }
            else
            {
                foreach(OrderDetails orderDetails1 in OrderDetailsRepository.OrderDetails)
                {
                    if(orderDetails1.OrderDetailID == orderDetails.OrderDetailID) 
                    {
                        throw new InvalidOrderDetailsDataException("OrderDetails ID already exist");
                    }
                }
            }
        }
    }
}
