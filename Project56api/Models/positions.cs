namespace Project56api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("citygis.positions")]
    public partial class positions
    {
        public int id { get; set; }

        public DateTime datetime { get; set; }

        public long unit_id { get; set; }

        public long rdx { get; set; }

        public long rdy { get; set; }

        public int speed { get; set; }

        public int course { get; set; }

        public int numsatel { get; set; }

        public int hdop { get; set; }

        [Required]
        [StringLength(50)]
        public string quality { get; set; }
    }
}
