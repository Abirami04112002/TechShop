using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.model;
using Task_1.Repositories;

namespace Task_1.Exceptions
{
    internal class ProductNotFoundException: Exception
    {
        public ProductNotFoundException(string text): base (text) 
        {
            
        }
        public static void ProductNotFound(int productId)
        {
            bool ProductExist = false;
            foreach(Products products in ProductsRespository.Products)
            {
                if(products.ProductID == productId)
                {
                    ProductExist= true;
                }
            }
            if(!ProductExist) 
            {
                throw new ProductNotFoundException("Product Not Found!!!");
            }
        }
    }
}
