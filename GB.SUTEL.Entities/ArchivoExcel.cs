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
    
    public partial class ArchivoExcel
    {
        public int IdArchivoExcel { get; set; }
        public System.Guid IdSolicitudIndicador { get; set; }
        public string IdOperador { get; set; }
        public bool ArchivoExcelGenerado { get; set; }
        public byte[] ArchivoExcelBytes { get; set; }
        public System.DateTime FechaHoraSolicitud { get; set; }
        public Nullable<System.DateTime> FechaHoraGeneracionAutomatica { get; set; }
        public Nullable<bool> Borrado { get; set; }
        public Nullable<bool> Descarga { get; set; }
        public bool FormularioWeb { get; set; }
    }
}
