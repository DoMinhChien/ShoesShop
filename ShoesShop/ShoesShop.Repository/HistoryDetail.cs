//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoesShop.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class HistoryDetail
    {
        public int Id { get; set; }
        public int historyId { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public string Field { get; set; }
    
        public virtual History History { get; set; }
    }
}
