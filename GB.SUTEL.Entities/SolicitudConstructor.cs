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
    
    public partial class SolicitudConstructor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SolicitudConstructor()
        {
            this.RegistroIndicador = new HashSet<RegistroIndicador>();
        }
    
        public System.Guid IdSolicitudContructor { get; set; }
        public System.Guid IdSolicitudIndicador { get; set; }
        public System.Guid IdConstructor { get; set; }
        public int IdEstado { get; set; }
        public string IdOperador { get; set; }
        public byte Borrado { get; set; }
        public byte FormularioWeb { get; set; }
        public Nullable<int> OrdenIndicadorEnExcel { get; set; }
        public Nullable<bool> Cargado { get; set; }
        public Nullable<int> CantidadCarga { get; set; }
        public Nullable<int> IdSemaforo { get; set; }
    
        public virtual Constructor Constructor { get; set; }
        public virtual EstadoSolicitud EstadoSolicitud { get; set; }
        public virtual Operador Operador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroIndicador> RegistroIndicador { get; set; }
        public virtual SolicitudIndicador SolicitudIndicador { get; set; }
    }
}
