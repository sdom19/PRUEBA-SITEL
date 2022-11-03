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

    [Table("RegistroIndicadorFonatel")]

    public partial class RegistroIndicadorFonatel
    {
        [Key, Column(Order =0)]
        public int IdSolicitud { get; set; }
        [Key, Column(Order = 1)]
        public int IdFormulario { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int IdMes { get; set; }
        public string Mes { get; set; }
        public int IdAnno { get; set; }
        public string Anno { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaInicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaFin { get; set; }
        public int IdFuente { get; set; }
        public string Mensaje { get; set; }
        public string Formulario { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }

        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }


        [NotMapped]
        public bool RangoFecha { get; set; }
        [NotMapped]
        public List<DetalleRegistroIndcadorFonatel> DetalleRegistroIndcadorFonatel { get; set; }

        [NotMapped]
        public string IdSolicitudString { get; set; }
        [NotMapped]
        public string IdFormularioString { get; set; }

    }
}