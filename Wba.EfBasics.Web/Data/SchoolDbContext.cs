using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.EfBasics.Core.Entities;

namespace Wba.EfBasics.Web.Data
{
    public class SchoolDbContext : DbContext
    {
        //define DbSets => tables in the database
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Course>()
                .HasKey(c => c.ItemId);
            //configure one to many
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.IdOfTeacher);
            //one to one with generic method HasForeignKey
            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Teacher)
                .WithOne(t => t.ContactInfo)
                .HasForeignKey<Teacher>(t => t.IdOfcontactInfo);
            //many to many => old school

                

            base.OnModelCreating(modelBuilder);
        }
    }
}
