//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace il_Topolino.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Klant
    {
        public int klant_id { get; set; }
        public string straat { get; set; }
        public Nullable<int> huisnummer { get; set; }
        public string postcode { get; set; }
        public string plaats { get; set; }
        public int afstand { get; set; }
    }
}
