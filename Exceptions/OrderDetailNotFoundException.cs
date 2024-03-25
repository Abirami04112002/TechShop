using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.model;
using Task_1.Repositories;

namespace Task_1.Exceptions
{
    internal class OrderDetailNotFoundException : Exception
    {
        public OrderDetailNotFoundException(string text) : base(text) { }

        public static void OrderDetailNotFound(int OrderdetailID)
        {
            bool idexist = false;
            foreach (OrderDetails orderDetails in OrderDetailsRepository.OrderDetails)
            {
                if (orderDetails.OrderDetailID == OrderdetailID)
                {
                    idexist = true; break;
                }
            }
            if ((!idexist))
            {
                throw new OrderDetailNotFoundException("Order details id not found");
            }
        }
    }
}
