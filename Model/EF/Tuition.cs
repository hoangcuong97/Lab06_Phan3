namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tuition")]
    public partial class Tuition
    {
        public int TuitionID { get; set; }

        public int? ClassID { get; set; }

        public int? StudentID { get; set; }

        [StringLength(10)]
        public string ObjectsReduced { get; set; }

        public double? Money { get; set; }

        [StringLength(50)]
        public string Payments { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public virtual Class Class { get; set; }

        public virtual Student Student { get; set; }
    }
}
