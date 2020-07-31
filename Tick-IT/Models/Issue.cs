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

    public class Issue  // Blog
    {
        [Key]
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Createdby { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime DateTime { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Issues_Status? Status { get; set; }
        public List<Response> Responses { get; set; }
    }
}
