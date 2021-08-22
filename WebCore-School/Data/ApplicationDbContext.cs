using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebCore_School.Entities;

namespace WebCore_School.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Pupil> Forms { get; set; }
        public DbSet<Pupil> Categories { get; set; }
        public DbSet<Pupil> Teachers { get; set; }
        public DbSet<Pupil> Groups { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebCore_School.Entities.Form> Form { get; set; }
        public DbSet<WebCore_School.Entities.Category> Category { get; set; }
        public DbSet<WebCore_School.Entities.Teacher> Teacher { get; set; }
        public DbSet<WebCore_School.Entities.Group> Group { get; set; }
    }
}
