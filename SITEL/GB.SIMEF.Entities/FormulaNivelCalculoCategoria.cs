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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FormulasNivelCalculoCategoria")]
    public partial class FormulasNivelCalculoCategoria
    {
        [Key]
        public int IdFormulaNivel { get; set; }
        public int IdFormula { get; set; }
        public int IdCategoria { get; set; }

        #region Variable fuera del modelo
        [NotMapped]
        public string id { get; set; }

        [NotMapped]
        public string IdCategoriaString { get; set; }

        [NotMapped]
        public string IdFormulaString { get; set; }

        #endregion
    }
}
