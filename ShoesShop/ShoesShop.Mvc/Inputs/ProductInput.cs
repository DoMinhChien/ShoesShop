using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesShop.Mvc.Inputs
{
    public class ProductInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public int CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public int Quantity { get; set; }
        public long UnitPrice { get; set; }
    }
}