//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GB.SUTEL.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class RegionIndicadorExterno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegionIndicadorExterno()
        {
            this.RegistroIndicadorExterno = new HashSet<RegistroIndicadorExterno>();
        }
    
        public int IdRegionIndicadorExterno { get; set; }
        public string DescRegionIndicadorExterno { get; set; }
        public byte Borrado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroIndicadorExterno> RegistroIndicadorExterno { get; set; }
    }
}
