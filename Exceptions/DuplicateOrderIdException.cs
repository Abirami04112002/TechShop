using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.model;
using Task_1.Repositories;

namespace Task_1.Exceptions
{
    internal class DuplicateOrderIdException:Exception
    {
        public DuplicateOrderIdException(string message):base(message) 
        { 
        
        }

        public static void DuplicateOrderId(int OrderId)
        {
            foreach(Orders orders in OrdersRepository.Orders)
            {
                if(orders.OrderID== OrderId)
                {
                    throw new DuplicateOrderIdException("OrderID already Exist");
                }
            }
        }
    }
}
