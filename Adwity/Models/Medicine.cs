//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Adwity.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Medicine
    {
        public int id { get; set; }
        public string name { get; set; }
        public string material { get; set; }
        public int quantity { get; set; }
        public System.DateTime production_date { get; set; }
        public System.DateTime expiration_date { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }
        public int PharmacyId { get; set; }
    
        public virtual PharmacyBranch PharmacyBranch { get; set; }
    }
}
