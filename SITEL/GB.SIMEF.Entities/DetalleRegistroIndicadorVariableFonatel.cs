//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GB.SIMEF.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DetalleRegistroIndicadorVariableFonatel")]
    public partial class DetalleRegistroIndicadorVariableFonatel
    {
        [Key, Column(Order = 0)]
        public int IdSolicitud { get; set; }

        [Key, Column(Order = 1)]
        public int idFormularioWeb { get; set; }

        [Key, Column(Order = 2)]
        public int IdIndicador { get; set; }

        [Key, Column(Order = 3)]
        public int idVariable { get; set; }
        public string NombreVariable { get; set; }
        public string Descripcion { get; set; }



        [NotMapped]
        public string html { get; set; }
    }
}
