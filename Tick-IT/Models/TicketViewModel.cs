using System.Collections.Generic;
using System;

namespace Tick_IT.Models
{
    public class TicketsViewModel
    {
        //public IEnumerable<Issue> Issues { get; set; }
        //public IEnumerable<Response> Responses { get; set; }
        public Issue Issues { get; set; }
        public Response Responses { get; set; }

        public List<Response> ResponsesList { get; set; }
    }
}
