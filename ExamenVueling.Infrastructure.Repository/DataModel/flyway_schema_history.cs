//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamenVueling.Infrastructure.Repository.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class flyway_schema_history
    {
        public int installed_rank { get; set; }
        public string version { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string script { get; set; }
        public Nullable<int> checksum { get; set; }
        public string installed_by { get; set; }
        public System.DateTime installed_on { get; set; }
        public int execution_time { get; set; }
        public bool success { get; set; }
    }
}
