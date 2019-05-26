using ShoesShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesShop.Mvc.Inputs
{
    public class SupplierInput
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }

        public bool IsActive { get; set; }
    }
}