using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Entities
{
    class File
    {
        //public File()
        //{
        //    this.BadgeType = new HashSet<BadgeType>();
        //}

        public int Id { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<BadgeType> BadgeType { get; set; }
    }
}
