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
    
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            this.AntremanYoklama = new HashSet<AntremanYoklama>();
        }
    
        public int No { get; set; }
        public Nullable<int> TcKimlikNo { get; set; }
        public string şifre { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string DogumTarihi { get; set; }
        public string KayitTarihi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AntremanYoklama> AntremanYoklama { get; set; }
    }
}
