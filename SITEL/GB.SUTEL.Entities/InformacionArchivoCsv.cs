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
    
    public partial class InformacionArchivoCsv
    {
        public int IdInformacionArchivoCsv { get; set; }
        public int IdArchivoCsv { get; set; }
        public string InformacionArchivoCsv1 { get; set; }
    
        public virtual ArchivoCsv ArchivoCsv { get; set; }
    }
}
