using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExample.Models
{
    public class Sale
    {
        public int id { get; set; }
        public string productName { get; set; }
        public float grossSalevalue { get; set; }
    }
}