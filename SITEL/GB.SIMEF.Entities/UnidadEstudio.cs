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

    [Table("UnidadEstudio")]
    public partial class UnidadEstudio
    {
        public UnidadEstudio()
        {
        }

        [Key]
        public int idUnidad { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        #region Variables que no forman parte del contexto
        [NotMapped]
        public string id { get; set; }
        [NotMapped]
        public bool nuevoEstado { get; set; }
        #endregion
    }
}
