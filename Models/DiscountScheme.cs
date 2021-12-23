using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCExample.Models
{
    public class DiscountScheme
    {
        public int id { get; set; }
        [ForeignKey("prod")]
        public int prodID { get; set; }
        public Product prod { get; set; }
        public string discountName { get; set; }
        public float discount { get; set; }
    }
}