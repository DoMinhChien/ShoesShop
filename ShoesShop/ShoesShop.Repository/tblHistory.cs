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
    
    public partial class tblHistory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblHistory()
        {
            this.tblHistoryDetails = new HashSet<tblHistoryDetail>();
        }
    
        public int Id { get; set; }
        public System.Guid ObjectId { get; set; }
        public System.Guid CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string Content { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblHistoryDetail> tblHistoryDetails { get; set; }
        public virtual tblProduct tblProduct { get; set; }
    }
}
