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
    
    public partial class Diagnosi
    {
        public decimal diag_id { get; set; }
        public decimal reception_id { get; set; }
        public string diag_value { get; set; }
        public string diag_type { get; set; }
    
        public virtual Reception Reception { get; set; }
    }
}