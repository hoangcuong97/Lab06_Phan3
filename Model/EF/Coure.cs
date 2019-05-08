namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Coure()
        {
            Certificates = new HashSet<Certificate>();
            Classes = new HashSet<Class>();
        }

        [Key]
        public int CouresID { get; set; }

        [StringLength(50)]
        public string CouresName { get; set; }

        [StringLength(50)]
        public string Conditions { get; set; }

        [StringLength(50)]
        public string Object { get; set; }

        [StringLength(50)]
        public string Contents { get; set; }

        [StringLength(50)]
        public string Target { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Certificate> Certificates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Class> Classes { get; set; }
    }
}
