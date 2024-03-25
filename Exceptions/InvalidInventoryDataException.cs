using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.model;

namespace Task_1.Exceptions
{
    internal class InvalidInventoryDataException: Exception
    {
        public InvalidInventoryDataException(string text):base(text) { }

        public static void InvalidData(Inventory inventory)
        {
            if(inventory.QuantityInStock>0)
            {
                throw new InvalidInventoryDataException("Check the quantity");
            }
            else if(inventory.LastStockUpdate>DateTime.Now)
            {
                throw new InvalidInventoryDataException("Enter the valid date");
            }
        }
    }
}
