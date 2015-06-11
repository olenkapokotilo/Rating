using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Badge
    {
        public int Id { get; set; }
        public int BadgeTypeId { get; set; }
        public int ProjectUserId { get; set; }

        public virtual BadgeType BadgeType { get; set; }
        public virtual ProjectUser ProjectUser { get; set; }
    }
}
