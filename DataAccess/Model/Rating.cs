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
    
    public partial class Rating
    {
        public Rating()
        {
            this.Action = new HashSet<Action>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int RatingTypeId { get; set; }
        public Nullable<int> ProjectUserId { get; set; }
    
        public virtual ICollection<Action> Action { get; set; }
        public virtual ProjectUser ProjectUser { get; set; }
        public virtual RatingType RatingType { get; set; }
    }
}