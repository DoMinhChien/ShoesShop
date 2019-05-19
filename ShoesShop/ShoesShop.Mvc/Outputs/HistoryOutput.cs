using ShoesShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesShop.Mvc.Outputs
{
    public class HistoryOutput
    {
        public int Id { get; set; }
        public Guid ObjectId { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public ProductModel Product { get; set; }
        public List<HistoryDetailModel> HistoryDetails { get; set; }
        public EmployeeModel Employee { get; set; }
        public string Content { get; set; }
        public string DisplayName { get; set; }
    }
}