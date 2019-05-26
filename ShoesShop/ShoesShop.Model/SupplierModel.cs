using System;
using System.Collections.Generic;

namespace ShoesShop.Model
{
    public class SupplierModel
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}
