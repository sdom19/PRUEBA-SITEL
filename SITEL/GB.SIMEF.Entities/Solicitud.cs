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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Solicitud")]
    public partial class Solicitud
    {
       
        public Solicitud()
        {
           
        }
        [Key] 
        public int idSolicitud { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
        public int CantidadFormularios { get; set; }
        public string Mensaje { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public int idFuente { get; set; }
        public int idMes { get; set; }

        public int idAnno { get; set; }

   
        public int IdEstado { get; set; }

        [NotMapped]

        public string id { get; set; }

        [NotMapped]

        public EstadoRegistro Estado { get; set; }


        [NotMapped]

        public FuentesRegistro Fuente { get; set; }
        [NotMapped]
        public List<FormularioWeb> FormularioWeb { get; set; }

        [NotMapped]
        public SolicitudEnvioProgramado EnvioProgramado { get; set; }
        [NotMapped]
        public List<DetalleSolicitudFormulario> SolicitudFormulario { get; set; }
    }
}
