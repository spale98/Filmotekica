//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Filmotekica.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class film
    {
        public int id { get; set; }
        public string imefilma { get; set; }
        public string opis { get; set; }
        public Nullable<int> reziser_id { get; set; }
        public Nullable<int> zanr_id { get; set; }
    
        public virtual film film1 { get; set; }
        public virtual film film2 { get; set; }
        public virtual reziser reziser { get; set; }
        public virtual zanr zanr { get; set; }
    }
}