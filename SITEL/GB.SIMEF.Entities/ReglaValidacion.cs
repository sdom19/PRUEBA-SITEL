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

    [Table("ReglaValidacion")]
    public partial class ReglaValidacion
    {
       
        public ReglaValidacion()
        {
            DetalleReglaValidacion = new List<DetalleReglaValidacion>();
        }
        [Key]
        public int idRegla { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int idIndicador { get; set; }
        public int idEstado { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    
        [NotMapped]
        public EstadoRegistro EstadoRegistro { get; set; }

        [NotMapped]
        public String id{ get; set; }

        [NotMapped]
        public int idCompara { get; set; }


        [NotMapped]
        public String idIndicadorVariableString { get; set; }

        [NotMapped]
        public string idIndicadorString { get; set; }

        [NotMapped]
        public string ListadoTipoReglas { get; set; }

        [NotMapped]
        public List<DetalleReglaValidacion> DetalleReglaValidacion { get; set; }

        [NotMapped]
        public string idDetalleReglaValidacion { get; set; }

        [NotMapped]
        public List<string> NoSerialize = new List<string>()
        {
            "id",
            "idRegla",
            "idOperador",
            "idIndicador",
            "Codigo",
            "Nombre",
            "FechaModificacion",
            "UsuarioCreacion",
            "FechaCreacion",
            "UsuarioModificacion",
            "Descripcion"

        };
    }
}
