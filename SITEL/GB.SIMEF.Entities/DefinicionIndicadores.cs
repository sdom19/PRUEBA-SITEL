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
    using GB.SIMEF.Resources;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    [Table("DefinicionIndicador")]
    public partial class DefinicionIndicador
    {
        [Key]

        public int idDefinicionIndicador { get; set; }

        [MaxLength(300)]
        [DataType(DataType.MultilineText)]
        public string Fuente { get; set; }
        [DataType(DataType.MultilineText)]
        [MaxLength(3000)]
        public string Nota { get; set; }

        [MaxLength(2000)]
        [DataType(DataType.MultilineText)]
        public string Definicion { get; set; }


        public int IdEstadoRegistro  { get; set; }
        
        [NotMapped]
        public virtual Indicador Indicador { get; set; }

        [NotMapped]
        public virtual string NombreIndicador { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual string json { get; set; }


        [NotMapped]
        public virtual string id { get; set; }


        [NotMapped]
        public virtual string idClonado { get; set; }

        public override string ToString()
        {
            StringBuilder json = new StringBuilder();
            json.Append("{\"Código\":\"").Append(this.Indicador.Codigo).Append("\",");
            json.Append("\"Grupo\":\"").Append(this.Indicador.GrupoIndicadores.Nombre).Append("\",");
            json.Append("\"Nombre\":\"").Append(this.Indicador.Nombre).Append("\",");
            json.Append("\"Tipo\":\"").Append(this.Indicador.TipoIndicadores.Nombre).Append("\",");
            json.Append("\"Definición\":\"").Append(this.Definicion).Append("\",");
            json.Append("\"Fuente\":\"").Append(this.Fuente).Append("\",");
            json.Append("\"Notas\":\"").Append(this.Nota).Append("\",");

            string estado = string.Empty;
            switch (this.IdEstadoRegistro)
            {
                case (int)Constantes.EstadosRegistro.Desactivado:
                    estado = Enum.GetName(typeof(Constantes.EstadosRegistro), this.IdEstadoRegistro);
                    break;
                case (int)Constantes.EstadosRegistro.Activo:
                    estado = Enum.GetName(typeof(Constantes.EstadosRegistro), this.IdEstadoRegistro);
                    break;
                case (int)Constantes.EstadosRegistro.Eliminado:
                    estado = Enum.GetName(typeof(Constantes.EstadosRegistro), this.IdEstadoRegistro);
                    break;
                case (int)Constantes.EstadosRegistro.EnProceso:
                    estado = "En Proceso";
                    break;
            }
            json.Append("\"Estado\":\"").Append(estado).Append("\"}");

            return json.ToString();
        }



    }
}
