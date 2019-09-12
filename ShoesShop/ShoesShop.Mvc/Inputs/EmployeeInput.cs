using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesShop.Mvc.Inputs
{
    public class EmployeeInput
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string DisplayName { get; set; }
        public DateTime HireDate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public int departmentId { get; set; }
    }
}