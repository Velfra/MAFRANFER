//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MAFRANFER.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class curso
    {
        public int curso_id { get; set; }
        public string descripcion { get; set; }
        public short duracion { get; set; }
        public System.DateTime fecha_inicio { get; set; }
        public System.DateTime fecha_fin { get; set; }
        public decimal precio { get; set; }
        public int profesor_id { get; set; }
        public string estado { get; set; }
    }
}
