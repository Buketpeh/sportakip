//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AntremanProgram
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AntremanProgram()
        {
            this.AntremanYoklama = new HashSet<AntremanYoklama>();
        }
    
        public int No { get; set; }
        public Nullable<int> AntremanNo { get; set; }
        public Nullable<System.DateTime> AntremanBaslama { get; set; }
        public Nullable<System.DateTime> AntremanBitis { get; set; }
        public Nullable<int> GunNo { get; set; }
    
        public virtual Antreman Antreman { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AntremanYoklama> AntremanYoklama { get; set; }
    }
}
