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
    
    [Table("DetalleReglaValidacion") ]
    public partial class DetalleReglaValidacion
    {
      
        public DetalleReglaValidacion()
        {
            
        }
        [Key]
        public int IdReglasValidacionTipo { get; set; }
        public int IdOperador { get; set; }
        public int IdRegla { get; set; }
        public int IdTipo { get; set; }
        public bool Estado { get; set; }
    
        [NotMapped]
        public string id { get; set; }
        
        [NotMapped]
        public string idIndicadorVariableString { get; set; }
        
        [NotMapped]
        public string idIndicadorString { get; set; }
        
        [NotMapped]
        public string idReglasValidacionTipoString { get; set; }
        
        [NotMapped]
        public ReglaValidacion reglaValidacion { get; set; }
        
        [NotMapped]
        public virtual TipoReglaValidacion tipoReglaValidacion { get; set; }
        
        [NotMapped]
        public virtual OperadorArismetico operadorArismetico { get; set; }
        
        [NotMapped]
        public virtual DetalleIndicadorVariables detalleIndicadorVariables { get; set; }

        [NotMapped]
        public virtual ReglaAtributosValidos ReglaAtributosValidos { get; set; }


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