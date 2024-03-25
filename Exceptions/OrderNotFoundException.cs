using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.model;
using Task_1.Repositories;

namespace Task_1.Exceptions
{
    internal class OrderNotFoundException:Exception
    {
        public OrderNotFoundException(string message): base(message) 
        { 
        
        }
        public static void OrderNotFound(int orderid)
        {
            bool orderExist = false;
            foreach(Orders orders in OrdersRepository.Orders)
            {
                orderExist=true;
            }
            if(!orderExist)
            {
                throw new OrderNotFoundException("Order not found");
            }
        }
    }
}
