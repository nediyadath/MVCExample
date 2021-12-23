using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExample.Models
{
    public class Inventory
    {
        public int id { get; set; }
        public string productname { get; set; }
        public float qty { get; set; }
    }
}