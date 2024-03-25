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
    internal class DuplicateInventoryIdException: Exception
    {
        public DuplicateInventoryIdException(string text):base(text) { }

        public static void DuplicateId(int inventoryID)
        {
            bool idexixt = false;
            foreach(Inventory inventory in InventoryRepository.Inventories)
            {
                if(inventory.InventoryID == inventoryID)
                {
                    idexixt = true;
                    break;
                }
            }
            if(idexixt)
            {
                throw new DuplicateInventoryIdException("Id Already exist try new one!!!");
            }
        }
    }
}
