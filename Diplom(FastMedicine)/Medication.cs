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
    
    public partial class Medication
    {
        public decimal selected_med_id { get; set; }
        public decimal med_id { get; set; }
        public decimal reception_id { get; set; }
        public decimal med_days { get; set; }
    
        public virtual Preparation Preparation { get; set; }
        public virtual Reception Reception { get; set; }
    }
}