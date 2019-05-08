namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Schedule")]
    public partial class Schedule
    {
        public int ScheduleID { get; set; }

        public int? ClassID { get; set; }

        public int? ClassroomID { get; set; }

        [StringLength(10)]
        public string Shifts { get; set; }

        public virtual Class Class { get; set; }

        public virtual Classroom Classroom { get; set; }
    }
}
