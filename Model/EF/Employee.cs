namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        [Key]
        public int EmployeesID { get; set; }

        [StringLength(50)]
        public string EmployeesName { get; set; }

        public int? UserID { get; set; }

        public bool? Sex { get; set; }

        public int? IdentityCard { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public virtual User User { get; set; }
    }
}
