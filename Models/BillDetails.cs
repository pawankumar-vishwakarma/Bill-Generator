using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillGenerator.Models
{
    public class BillDetails
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public int TotalAmount { get; set; }

    }
}