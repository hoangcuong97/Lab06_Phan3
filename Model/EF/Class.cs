namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Class")]
    public partial class Class
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Class()
        {
            Schedules = new HashSet<Schedule>();
            Tuitions = new HashSet<Tuition>();
        }

        public int ClassID { get; set; }

        [StringLength(50)]
        public string ClassName { get; set; }

        public int? CourseID { get; set; }

        public int? TeacherID { get; set; }

        public double? Tuition { get; set; }

        [StringLength(10)]
        public string SessionNum { get; set; }

        public virtual Coure Coure { get; set; }

        public virtual Teacher Teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tuition> Tuitions { get; set; }
    }
}
