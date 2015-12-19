using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project56api.Models
{
    [Table("citygis.events")]
    public class Event
    {
        public int Id { get; set; }

        public DateTime? Datetime { get; set; }

        public int? Value { get; set; }

        public string port { get; set; }

        public int unit_id { get; set; }
    }
}