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
    
    public partial class tbl_Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Client()
        {
            this.tbl_Laptop = new HashSet<tbl_Laptop>();
            this.tbl_Order = new HashSet<tbl_Order>();
        }
    
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail_Address { get; set; }
        public int ClientContact_no { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int EIRCode { get; set; }
        public string Feedback { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Laptop> tbl_Laptop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Order> tbl_Order { get; set; }
    }
}
