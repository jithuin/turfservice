//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TurfManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class TurfBooking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TurfBooking()
        {
            this.TurfBookingFacilityLists = new HashSet<TurfBookingFacilityList>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public Nullable<System.DateTime> RegistrationTime { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string ApprovedStatus { get; set; }
        public string PaymentStatus { get; set; }
        public int TurfMasterId { get; set; }
        public int TurfUserId { get; set; }
        public string AprovalDate { get; set; }
    
        public virtual TurfMaster TurfMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TurfBookingFacilityList> TurfBookingFacilityLists { get; set; }
        public virtual TurfUser TurfUser { get; set; }
    }
}
