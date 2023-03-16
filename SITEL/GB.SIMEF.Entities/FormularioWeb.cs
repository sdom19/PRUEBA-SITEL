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
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    [Table("FormularioWeb")]

    public partial class FormularioWeb
    {
        public FormularioWeb()
        {
            this.DetalleFormularioWeb = new HashSet<DetalleFormularioWeb>();
            this.DetalleSolicitudFormulario = new HashSet<DetalleSolicitudFormulario>();
            this.ListaIndicadoresObj = new List<Indicador>();

        }
        [Key]
        public int idFormularioWeb { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CantidadIndicador { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        
        public int idEstadoRegistro { get; set; }
        public int idFrecuenciaEnvio { get; set; }
        

        [NotMapped]
        public string ListaIndicadores { get; set; }

        [NotMapped]
        public string id { get; set; }
        
        [NotMapped]
        public int CantidadActual { get; set; }

        [NotMapped]
        public virtual ICollection<DetalleFormularioWeb> DetalleFormularioWeb { get; set; }
        [NotMapped]
        public virtual ICollection<DetalleSolicitudFormulario> DetalleSolicitudFormulario { get; set; }
        [NotMapped]
        public virtual EstadoRegistro EstadoRegistro { get; set; }
        [NotMapped]
        public virtual FrecuenciaEnvio FrecuenciaEnvio { get; set; }

        [NotMapped]
        public List<Indicador> ListaIndicadoresObj { get; set; }

        public override string ToString()
        {
            StringBuilder json = new StringBuilder();
            json.Append("{\"Código\":\"").Append(this.Codigo.Trim()).Append("\",");
            json.Append("\"Nombre\":\"").Append(this.Nombre).Append("\",");
            json.Append("\"Descripción\":\"").Append(this.Descripcion).Append("\",");
            json.Append("\"Frecuencia de envío\":\"").Append(this.FrecuenciaEnvio.Nombre).Append("\",");
            json.Append("\"Cantidad de indicadores\":").Append(this.CantidadIndicador).Append(",");

            string estado = string.Empty;
            switch (this.EstadoRegistro.IdEstadoRegistro)
            {
                case (int)Constantes.EstadosRegistro.Desactivado:
                    estado = Enum.GetName(typeof(Constantes.EstadosRegistro), this.EstadoRegistro.IdEstadoRegistro);
                    break;
                case (int)Constantes.EstadosRegistro.Activo:
                    estado = Enum.GetName(typeof(Constantes.EstadosRegistro), this.EstadoRegistro.IdEstadoRegistro);
                    break;
                case (int)Constantes.EstadosRegistro.Eliminado:
                    estado = Enum.GetName(typeof(Constantes.EstadosRegistro), this.EstadoRegistro.IdEstadoRegistro);
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
