using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiClient.Models
{
    public class ClientContext : DbContext
    {
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}