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
    
    public partial class Action
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime DateTime { get; set; }
        public int ActionTypeId { get; set; }
        public int ProjectUserId { get; set; }
        public Nullable<int> RatingId { get; set; }
    
        public virtual ActionType ActionType { get; set; }
        public virtual ProjectUser ProjectUser { get; set; }
        public virtual Rating Rating { get; set; }
    }
}