using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityService.DataLibrary.Models
{
    public class UserEventModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EventId { get; set; }
    }
}
