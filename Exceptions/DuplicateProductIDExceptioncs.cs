using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Task_1.model;
using Task_1.Repositories;

namespace Task_1.Exceptions
{
    internal class DuplicateProductIDExceptioncs: Exception
    {
        public DuplicateProductIDExceptioncs(string text):base(text) { }

        public static void DuplicateId(int ProductID)
        {
            foreach (Products products1 in ProductsRespository.Products)
            {
                if (products1.ProductID == ProductID)
                {
                    throw new InvalidProductDataException("Product Id already exist. Try with different ID");
                }
            }
        }

    }
}
