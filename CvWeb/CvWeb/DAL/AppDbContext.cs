using CvWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvWeb.DAL
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Education>  Educations { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Skills2> Skills2 { get; set; }
        public DbSet<Interests> Interests { get; set; }
        public DbSet<Awards> Awards { get; set; }
        public DbSet<Setting> Settings { get; set; }

    }
}
