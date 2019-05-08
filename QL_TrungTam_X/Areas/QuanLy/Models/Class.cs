//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QL_TrungTam_X.Areas.QuanLy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Class
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Class()
        {
            this.Schedules = new HashSet<Schedule>();
            this.Tuitions = new HashSet<Tuition>();
        }
    
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public Nullable<int> CourseID { get; set; }
        public Nullable<int> TeacherID { get; set; }
        public Nullable<double> Tuition { get; set; }
        public string SessionNum { get; set; }
    
        public virtual Coure Coure { get; set; }
        public virtual Teacher Teacher { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedules { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tuition> Tuitions { get; set; }
    }
}