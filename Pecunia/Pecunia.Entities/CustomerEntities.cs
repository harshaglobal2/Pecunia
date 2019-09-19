using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pecunia.Entities
{
    public class CustomerEntities
    {
        private string _customerID;
        private string _customerName;
        private string _customerAddress;
        private string _customerMobile;
        private string _customerEmail;
        private string _customerPan;

        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPan { get; set; }
    }
}
