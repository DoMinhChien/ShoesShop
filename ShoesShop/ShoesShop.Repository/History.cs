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
    
    public partial class History
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public History()
        {
            this.HistoryDetails = new HashSet<HistoryDetail>();
        }
    
        public int Id { get; set; }
        public System.Guid ObjectId { get; set; }
        public System.Guid CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string Content { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoryDetail> HistoryDetails { get; set; }
        public virtual Product Product { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
