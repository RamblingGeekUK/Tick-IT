using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tick_IT.Models
{
    public class Responses
    {
        [Key]
        public Guid Responses_ID { get; set; }

        public Guid Responses_TicketID { get; set; }
        public Guid Responses_UserID { get; set; }
        public DateTime Responses_DateTime { get; set; }
        public string Responses_Message { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public string Responses_CreatedBy { get; set; }
        public Issues Issues { get; set; }
    }
}
