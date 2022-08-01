//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GB.SIMEF.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class FuentesRegistro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FuentesRegistro()
        {
            this.DetalleFuentesRegistro = new HashSet<DetalleFuentesRegistro>();
            this.Solicitud = new HashSet<Solicitud>();
            this.SolicitudDetalleFuentes = new HashSet<SolicitudDetalleFuentes>();
        }
    
        public int idFuente { get; set; }
        public string Fuente { get; set; }
        public int CantidadDestinatario { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    

        public virtual ICollection<DetalleFuentesRegistro> DetalleFuentesRegistro { get; set; }
        public virtual EstadoRegistro EstadoRegistro { get; set; }

        public virtual ICollection<Solicitud> Solicitud { get; set; }

        public virtual ICollection<SolicitudDetalleFuentes> SolicitudDetalleFuentes { get; set; }
    }
}