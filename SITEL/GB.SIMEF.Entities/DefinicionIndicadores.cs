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

    [Table("DefinicionIndicador")]
    public partial class DefinicionIndicador
    {
        [Key]
        public int idDefinicion { get; set; }
        
        [MaxLength(3000)]
        [DataType(DataType.MultilineText)]
        public string Fuente { get; set; }
        [DataType(DataType.MultilineText)]
        [MaxLength(3000)]
        public string Notas { get; set; }

        [MaxLength(3000)]
        [DataType(DataType.MultilineText)]
        public string Definicion { get; set; }
        public int idIndicador { get; set; }
        public int idEstado { get; set; }
        
        [NotMapped]
        public virtual Indicador Indicador { get; set; }


        [NotMapped]
        public virtual string id { get; set; }
    }
}
