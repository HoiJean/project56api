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
        public int id { get; set; }

        public DateTime? datetime { get; set; }

        public int value { get; set; }

        [Required]
        [StringLength(200)]
        public string port { get; set; }

        public long unit_id { get; set; }
    }
}
