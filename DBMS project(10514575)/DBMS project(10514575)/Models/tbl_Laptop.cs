//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBMS_project_10514575_.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Laptop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Laptop()
        {
            this.tbl_ServiceLine = new HashSet<tbl_ServiceLine>();
        }
    
        public int SerialNo { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public Nullable<int> ClientID { get; set; }
    
        public virtual tbl_Client tbl_Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ServiceLine> tbl_ServiceLine { get; set; }
    }
}
