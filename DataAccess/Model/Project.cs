//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public Project()
        {
            this.RatingTypes = new HashSet<RatingType>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    
        public virtual User User { get; set; }
        public virtual ICollection<RatingType> RatingTypes { get; set; }
    }
}
