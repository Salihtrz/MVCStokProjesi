//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStokProjesi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_Musteriler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Musteriler()
        {
            this.Tbl_Satislar = new HashSet<Tbl_Satislar>();
        }
    
        public int MusteriID { get; set; }

        [Required(ErrorMessage = "Bu alan bo� b�rak�lamaz!")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakterlik isim giriniz.")]
        public string MusteriAd { get; set; }

        [Required(ErrorMessage = "Bu alan bo� b�rak�lamaz!")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakterlik isim giriniz.")]
        public string MusteriSoyad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Satislar> Tbl_Satislar { get; set; }
    }
}
