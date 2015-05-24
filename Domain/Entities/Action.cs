using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Action
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int ActionTypeId { get; set; }
        public string ExternalId { get; set; }
        public int ProjectId { get; set; }
    }
}
