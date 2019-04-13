using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesShop.Mvc.Outputs
{
    public class ProductOutput
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public System.Guid SupplierId { get; set; }
        public int Quantity { get; set; }
        public int StatusId { get; set; }
        public System.Guid CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<int> ViewCounts { get; set; }
        public List<string> ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<int> UnitsInStock { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }

        public List<SelectedItemOutput> ListCategory { get; set; }
        public List<SelectedItemOutput> ListSupplier { get; set; }
    }
}