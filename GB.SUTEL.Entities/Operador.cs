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
    
    public partial class Operador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Operador()
        {
            this.DetalleAgrupacion = new HashSet<DetalleAgrupacion>();
            this.ServicioOperador = new HashSet<ServicioOperador>();
            this.SolicitudConstructor = new HashSet<SolicitudConstructor>();
            this.Usuario = new HashSet<Usuario>();
        }
    
        public string IdOperador { get; set; }
        public string NombreOperador { get; set; }
        public bool Estado { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleAgrupacion> DetalleAgrupacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServicioOperador> ServicioOperador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolicitudConstructor> SolicitudConstructor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }

        public virtual ICollection<ArchivoExcel> ArchivoExcel { get; set; }
    }
}
