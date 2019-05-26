using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesShop.Mvc.Outputs
{
    public class CategoryOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public List<ProductOutput> Products { get; set; }
        public bool IsActive { get; set; }
    }
}