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
    
    public partial class FuenteIndicador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FuenteIndicador()
        {
            this.FormulaIndicadorDSF = new HashSet<FormulaIndicadorDSF>();
            this.FormulaIndicadorMC = new HashSet<FormulaIndicadorMC>();
        }
    
        public int idFuenteIndicador { get; set; }
        public string FuenteIndicador1 { get; set; }
        public Nullable<bool> Estado { get; set; }
    

        public virtual ICollection<FormulaIndicadorDSF> FormulaIndicadorDSF { get; set; }

        public virtual ICollection<FormulaIndicadorMC> FormulaIndicadorMC { get; set; }
    }
}