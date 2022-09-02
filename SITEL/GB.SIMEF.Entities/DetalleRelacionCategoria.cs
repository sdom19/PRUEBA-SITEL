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

    [Table("DetalleRelacionCategoria")]
    public partial class DetalleRelacionCategoria
    {
      
        public DetalleRelacionCategoria()
        {
            RelacionCategoria = new RelacionCategoria();
        }
        [Key]
        public int idDetalleRelacionCategoria { get; set; }
        public int IdRelacionCategoria { get; set; }
        public int idCategoriaAtributo { get; set; }
        public string CategoriaAtributoValor { get; set; }
        public bool Estado { get; set; }

        #region Variables Fuera del contexto 

        [NotMapped]
        public virtual List<CategoriasDesagregacion> DetalleCategoriaTexto { get; set; }

        [NotMapped]
        public virtual CategoriasDesagregacion CategoriaDesagracion { get; set; }

        [NotMapped]
        public string usuario { get; set; }

        [NotMapped]
        public RelacionCategoria RelacionCategoria { get; set; }

        [NotMapped]
        public string id { get; set; }

        [NotMapped]
        public string relacionid { get; set; }

        [NotMapped]
        public bool Completo { get; set; }

        #endregion

    }
}
