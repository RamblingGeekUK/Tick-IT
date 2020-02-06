using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tick_IT.Models
{
    public enum Issues_Status
    {
        Open, Closed, Pending
    }

    public class Issues
    {
        [Key]
        public Guid Issues_ID { get; set; }
        public Guid Issues_UserID { get; set; }
        public string Issues_Createdby { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Issues_Number { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime Issues_DateTime { get; set; }
        public string Issues_Subject { get; set; }
        public string Issues_Description { get; set; }
        public Issues_Status? Issues_Status { get; set; }
        public List<Responses> Responses { get; set; }
    }
}
