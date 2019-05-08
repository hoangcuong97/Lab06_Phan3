namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Teacher")]
    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            Classes = new HashSet<Class>();
        }

        public int TeacherID { get; set; }

        [StringLength(50)]
        public string TeacherName { get; set; }

        public int? UserID { get; set; }

        public bool? Sex { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public int? IdentityCard { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Class> Classes { get; set; }

        public virtual User User { get; set; }
    }
}
