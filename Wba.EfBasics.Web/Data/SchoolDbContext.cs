using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.EfBasics.Core.Entities;
using Wba.EfBasics.Web.Data.Seeding;

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
            //modelBuilder.Entity<Course>()
            //    .HasKey(c => c.ItemId);
            ////configure one to many
            //modelBuilder.Entity<Teacher>()
            //    .HasMany(t => t.Courses)
            //    .WithOne(c => c.Teacher)
            //    .HasForeignKey(c => c.IdOfTeacher);
            ////one to one with generic method HasForeignKey
            //modelBuilder.Entity<ContactInfo>()
            //    .HasOne(c => c.Teacher)
            //    .WithOne(t => t.ContactInfo)
            //    .HasForeignKey<Teacher>(t => t.IdOfcontactInfo);
            ////many to many => old school
            //modelBuilder.Entity<Coursestudents>()
            //    .HasOne(cs => cs.Course)
            //    .WithMany(c => c.Students)
            //    .HasForeignKey(cs => cs.IdOfCourse)
            //    .OnDelete(DeleteBehavior.SetNull);
            //  modelBuilder.Entity<Coursestudents>()
            //    .HasOne(cs => cs.Student)
            //    .WithMany(c => c.Courses)
            //    .HasForeignKey(cs => cs.IdOfCourse)
            //    .HasForeignKey(c => c.IdOfStudent)
            //    .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<Coursestudents>()
            //    .HasKey(cs => cs.ItemId);
            //configuration on property level
            modelBuilder.Entity<Course>()
                .Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(150);
            //decimal warning 
            modelBuilder.Entity<Teacher>()
                .Property(c => c.YearlyWage)
                .HasColumnType("money")
                .HasPrecision(2);
            //Seed the database
            Seeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
