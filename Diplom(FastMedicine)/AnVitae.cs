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
    
    public partial class AnVitae
    {
        public decimal vitae_id { get; set; }
        public decimal reception_id { get; set; }
        public string vitae_value { get; set; }
    
        public virtual Reception Reception { get; set; }
    }
}
