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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class inscripcion
    {
        public int inscripcion_id { get; set; }
        [DisplayName("Nro Documento")]
        public int estudiante_id { get; set; }
        [DisplayName("Fecha Inscripcion")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> fecha { get; set; }
        [DisplayName("Importe")]
        public Nullable<decimal> importe { get; set; }
        [DisplayName("Estado")]
        public string estado { get; set; }
        [DisplayName("Observacion")]
        public string observacion { get; set; }
        [DisplayName("Curso")]
        public int curso_id { get; set; }
    
        public virtual curso curso { get; set; }
        public virtual estudiante estudiante { get; set; }
    }
}
