using Microsoft.AspNet.Identity.EntityFramework;
using SugarFreeDiet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SugarFreeDiet.DAL
{
    public class SugarFreeDietContext : IdentityDbContext<ApplicationUser>
    {
        public SugarFreeDietContext()
            : base("SugarFreeDietContext", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Recipe> Recipes { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Reply> Replies { get; set; }

        public static SugarFreeDietContext Create()
        {
            return new SugarFreeDietContext();
        }
    }
}