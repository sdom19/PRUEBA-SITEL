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

    public partial class FormulaIndicadorMC
    {
        [Key]
        public int idFormula { get; set; }
        public int idDetalleIndicador { get; set; }
        public string Criterio { get; set; }
        public string Detalle { get; set; }
        public string Indicador { get; set; }
        public Nullable<bool> ValorTotal { get; set; }
    
        public virtual FormulasCalculoDetalle FormulasCalculoDetalle { get; set; }
        public virtual FuenteIndicador FuenteIndicador { get; set; }
        public virtual TipoIndicadores TipoIndicadores { get; set; }
    }
}
