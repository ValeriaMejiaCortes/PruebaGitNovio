//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AcademiaDeBaile
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clase()
        {
            this.ClaseBailarin = new HashSet<ClaseBailarin>();
        }
    
        public long Id { get; set; }
        public string Nombre { get; set; }
        public System.TimeSpan Horario { get; set; }
        public int Duración { get; set; }
        public long IdInstructor { get; set; }
    
        public virtual Instructor Instructor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClaseBailarin> ClaseBailarin { get; set; }
    }
}
