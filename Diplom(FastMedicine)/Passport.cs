//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom_FastMedicine_
{
    using System;
    using System.Collections.Generic;
    
    public partial class Passport
    {
        public decimal patient_id { get; set; }
        public string series { get; set; }
        public string numbers { get; set; }
    
        public virtual Patient Patient { get; set; }
    }
}
