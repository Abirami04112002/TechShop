using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Exceptions
{
    internal class InvalidQuantityException:Exception
    {
        public InvalidQuantityException(string text):base(text) { }

        public static void InvalidQuantity(int  quantity) 
        {
            if(quantity < 0)
            {
                throw new InvalidQuantityException("Quantity cannot be negative");
            }
        }
    }
}
