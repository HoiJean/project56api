using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project56api.Models
{
    [Table("citygis.monitoring")]
    public class Monitor
    {
        public int Id { get; set; }
        public DateTime Begin_time { get; set; }
        public DateTime End_time { get; set; }
        public string Type { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Sum { get; set; }
        public double Unit_id { get; set; }
    }
}