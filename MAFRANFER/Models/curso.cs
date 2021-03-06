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

    public partial class curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public curso()
        {
            this.inscripcion = new HashSet<inscripcion>();
        }
        
        public int curso_id { get; set; }
        [DisplayName("Curso")]
        public string descripcion { get; set; }
        [DisplayName("Duracion")]
        public short duracion { get; set; }
        [DisplayName("Fecha Inicio")]
        public System.DateTime fecha_inicio { get; set; }
        [DisplayName("Fecha Fin")]
        public System.DateTime fecha_fin { get; set; }
        [DisplayName("Precio")]
        public decimal precio { get; set; }
        [DisplayName("Profesor")]
        public int profesor_id { get; set; }
        [DisplayName("Estado")]
        public string estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inscripcion> inscripcion { get; set; }
        public virtual profesor profesor { get; set; }
    }
}
