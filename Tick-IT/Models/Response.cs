using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tick_IT.Models
{
    public class Response  // Post
    {
        [Key]
        public Guid ID { get; set; }
        public Guid TicketID { get; set; }
        public Guid UserID { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public string CreatedBy { get; set; }
        public Issue Issue { get; set; }
    }
}
