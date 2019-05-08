namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Certificate")]
    public partial class Certificate
    {
        public int CertificateID { get; set; }

        [StringLength(50)]
        public string CertificateName { get; set; }

        public int? CouresID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReleaseDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpirationDate { get; set; }

        public virtual Coure Coure { get; set; }
    }
}
