//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Euris.AirportExample
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aeroporto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aeroporto()
        {
            this.Voloes = new HashSet<Volo>();
            this.Voloes1 = new HashSet<Volo>();
        }
    
        public string Citta { get; set; }
        public string Nazione { get; set; }
        public Nullable<int> NumPiste { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Volo> Voloes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Volo> Voloes1 { get; set; }
    }
}