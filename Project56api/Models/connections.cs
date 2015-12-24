namespace Project56api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("citygis.connections")]
    public partial class connections
    {
        public int Id { get; set; }

        public DateTime? Datetime { get; set; }

        public int? Value { get; set; }

        [Required]
        [StringLength(200)]
        public string Port { get; set; }

        public double Unit_id { get; set; }
    }
}
