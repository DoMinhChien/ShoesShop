using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesShop.Mvc.Outputs
{
    public class SelectedItemOutput
    {
        // Currently use for select2
        public dynamic id { get; set; }
        public string text { get; set; }
        public bool IsActive { get; set; }
    }
}