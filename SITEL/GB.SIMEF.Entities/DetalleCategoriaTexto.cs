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

    [Table("DetalleCategoriaTexto")]
    public partial class DetalleCategoriaTexto
    {
        public  DetalleCategoriaTexto()
        {
            CategoriasDesagregacion = new CategoriasDesagregacion();
        }
        [Key]
        public int idCategoriaDetalle { get; set; }
        public int idCategoria { get; set; }
        public int Codigo { get; set; }
        public string Etiqueta { get; set; }
        public bool Estado { get; set; }
        [NotMapped]
        public string usuario { get; set; }

        [NotMapped]

        public CategoriasDesagregacion CategoriasDesagregacion { get; set; }
        [NotMapped]

        public string id { get; set; }
    }
}
