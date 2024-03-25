using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.model;
using Task_1.Repositories;

namespace DbConnect.service
{
    internal class ProductService
    {
        public ProductService() { }
        public void PRoductDirectory()
        {
            int choice3 = 0;
            ProductsRespository productsRespository = new ProductsRespository();
            Products products = new Products();
            do
            {
                Console.WriteLine("****List of Products****");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"1: Insert Product\n2: Get Product Details\n3: Update Product\n4: check stock availability\n5: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice3 = int.Parse(Console.ReadLine());
                switch (choice3)
                {
                    case 1:
                        productsRespository.InsertProduct();
                        break;

                    case 2:
                        productsRespository.GetProductDetails();
                        break;

                    case 3:
                        productsRespository.UpdateProductInfo();
                        break;

                    case 4:
                        productsRespository.IsProductInStock();
                        break;

                    case 5:
                        Console.WriteLine("Exiting... ");
                        break;

                    default:
                        Console.WriteLine("Provide the valid Input");
                        break;
                }
            } while (choice3 != 5);
        }
    }
}
