using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.model;
using Task_1.Repositories;

namespace Task_1.Exceptions
{
    internal class InvalidProductDataException: Exception
    {
        public InvalidProductDataException(string text): base(text) 
        {

        }

        public  static void InvalidProductException(Products products)
        {
            
            if(products.Price<0)
            {
                throw new InvalidProductDataException("Price cannot be negative value");
            }
            
        }
    }
}
