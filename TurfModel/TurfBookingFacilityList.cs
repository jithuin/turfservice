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
    
    public partial class TurfBookingFacilityList
    {
        public int Id { get; set; }
        public string TurfFacilityMasterId { get; set; }
        public string BookingId { get; set; }
        public string Amount { get; set; }
        public int TurfMasterId { get; set; }
        public int TurfFecilityMasterId { get; set; }
        public int TurfBookingId { get; set; }
    
        public virtual TurfFecilityMaster TurfFecilityMaster { get; set; }
        public virtual TurfBooking TurfBooking { get; set; }
    }
}
