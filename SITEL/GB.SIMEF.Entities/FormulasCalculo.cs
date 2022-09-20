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

    [Table("FormulasCalculo")]
    public partial class FormulasCalculo
    {
        
        public FormulasCalculo()
        {
        }
        [Key]
        public int idFormula { get; set; }

        public int IdIndicador { get; set; }
        public int IdIndicadorVariable { get; set; }
        public int IdFrecuencia { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        [MaxLength(3000)]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        public bool NivelCalculoTotal { get; set; }
        public string UsuarioModificacion { get; set; }
        public int IdEstado { get; set; }
        
        //public DateTime FechaCalculo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }


        public DateTime FechaCalculo { get; set; }

        [NotMapped]

        public string id { get; set; }

        [NotMapped]
        public EstadoRegistro EstadoRegistro { get; set; }


 
        
    }
}
