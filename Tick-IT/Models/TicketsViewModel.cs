using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tick_IT.Models
{
    public class TicketsViewModel
    {
        public IEnumerable<Issues> Issue { get; set; }
        public IEnumerable<Responses> Response { get; set; }
    }
}
