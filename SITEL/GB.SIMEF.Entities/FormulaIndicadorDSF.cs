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

    public partial class FormulaIndicadorDSF
    {
        [Key]
        public int idFormula { get; set; }
        public int idDetalleIndicador { get; set; }
        public int idIndicador { get; set; }
        public int idcategoria { get; set; }
        public int idDetalle { get; set; }
        public Nullable<bool> ValorTotal { get; set; }
    
        public virtual FormulasCalculoDetalle FormulasCalculoDetalle { get; set; }
        public virtual FuenteIndicador FuenteIndicador { get; set; }
        public virtual TipoIndicador TipoIndicadores { get; set; }
    }
}
