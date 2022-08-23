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

    [Table("RelacionCategoria")]
    public partial class RelacionCategoria
    {
       
        public RelacionCategoria()
        {
            
        }
        [Key]
        public int idRelacionCategoria { get; set; }

        [MaxLength(10, ErrorMessage = "Máximo de caracteres permitido *")]
        public string Codigo { get; set; }
        [MaxLength(10, ErrorMessage = "Máximo de caracteres permitido *")]
        public string Nombre { get; set; }
        //VALIDAR EL RANGO
        public Nullable<int> CantidadCategoria { get; set; }
        public int idCategoria { get; set; }
        public string idCategoriaValor { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public int idEstado { get; set; }


        #region Variables que no estan en la entiendad
        [NotMapped]
        public virtual EstadoRegistro EstadoRegistro { get; set; }

        [NotMapped]
        public bool TieneDetalle { get; set; }

        [NotMapped]

        public List<DetalleRelacionCategoria> DetalleRelacionCategoria { get; set; }

        [NotMapped]
        public string id { get; set; }
        #endregion
    }
}
