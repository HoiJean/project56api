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
        public int Min { get; set; }
        public int Max { get; set; }
        public int Sum { get; set; }
    }
}