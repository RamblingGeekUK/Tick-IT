using System.Collections.Generic;

namespace Tick_IT.Models
{
    public class TicketsViewModel
    {
        public IEnumerable<Issue> Issues { get; set; }
        public IEnumerable<Response> Responses { get; set; }
    }
}
