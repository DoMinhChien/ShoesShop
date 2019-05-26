using System;
using System.Collections.Generic;

namespace ShoesShop.Model
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public List<ProductModel> Products { get; set; }

        public bool IsActive { get; set; }
    }
}
