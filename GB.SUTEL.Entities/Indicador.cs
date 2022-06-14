//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GB.SUTEL.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Indicador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Indicador()
        {
            this.BitacoraParametrizacionIndicador = new HashSet<BitacoraParametrizacionIndicador>();
            this.Constructor = new HashSet<Constructor>();
            this.Criterio = new HashSet<Criterio>();
            this.DetalleIndicadorCruzado = new HashSet<DetalleIndicadorCruzado>();
            this.DetalleIndicadorCruzado1 = new HashSet<DetalleIndicadorCruzado>();
            this.InidicadorUmbralPeso = new HashSet<InidicadorUmbralPeso>();
            this.ParamFormulas = new HashSet<ParamFormulas>();
            this.ParametroIndicador = new HashSet<ParametroIndicador>();
            this.ServicioIndicador = new HashSet<ServicioIndicador>();
            this.Direccion = new HashSet<Direccion>();
            this.IndicadorUIT = new HashSet<IndicadorUIT>();
            this.Servicio = new HashSet<Servicio>();
        }
    
        public string IdIndicador { get; set; }
        public int IdTipoInd { get; set; }
        public string NombreIndicador { get; set; }
        public string DescIndicador { get; set; }
        public byte Borrado { get; set; }
        public string DefinicionIndicador { get; set; }
        public string FuenteIndicador { get; set; }
        public string NotaAlPie { get; set; }
        public virtual ICollection<Servicio> Servicio { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public Nullable<System.TimeSpan> HoraUltimaModificacion { get; set; }
        public Nullable<int> UsuarioUltimaModificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BitacoraParametrizacionIndicador> BitacoraParametrizacionIndicador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Constructor> Constructor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Criterio> Criterio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleIndicadorCruzado> DetalleIndicadorCruzado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleIndicadorCruzado> DetalleIndicadorCruzado1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InidicadorUmbralPeso> InidicadorUmbralPeso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParamFormulas> ParamFormulas { get; set; }
        public virtual ServicioDefinicion ServicioDefinicion { get; set; }
        public virtual TipoIndicador TipoIndicador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParametroIndicador> ParametroIndicador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServicioIndicador> ServicioIndicador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Direccion> Direccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IndicadorUIT> IndicadorUIT { get; set; }
    }
}
