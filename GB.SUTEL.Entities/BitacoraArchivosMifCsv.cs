//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GB.SUTEL.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class BitacoraArchivosMifCsv
    {
        public int IdBitacora { get; set; }
        public Nullable<int> IdArchivo { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public int Accion { get; set; }
        public string Usuario { get; set; }
        public string Maquina { get; set; }
        public string TipoArchivo { get; set; }
        public bool AccionExitosa { get; set; }
        public string DetalleTransaccion { get; set; }
    
        public virtual Accion Accion1 { get; set; }
    }
}
