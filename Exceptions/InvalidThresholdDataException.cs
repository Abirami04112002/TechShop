using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Exceptions
{
    internal class InvalidThresholdDataException:Exception
    {
        public InvalidThresholdDataException(string text):base(text) { }

        public static void InvalidThresholdData(int threshold)
        {
            if(threshold < 0)
            {
                throw new InvalidThresholdDataException("Enter valid Threshold ");
            }
        }

    }
}
