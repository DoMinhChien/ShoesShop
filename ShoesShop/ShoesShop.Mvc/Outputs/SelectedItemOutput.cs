using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesShop.Mvc.Outputs
{
    public class SelectedItemOutput
    {
        // Currently use for select2
        public dynamic Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}