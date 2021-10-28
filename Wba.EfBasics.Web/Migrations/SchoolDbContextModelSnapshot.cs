﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wba.EfBasics.Web.Data;

namespace Wba.EfBasics.Web.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wba.EfBasics.Core.Entities.ContactInfo", b =>
                {
                    b.Property<long>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.ToTable("ContactInfos");
                });

            modelBuilder.Entity("Wba.EfBasics.Core.Entities.Course", b =>
                {
                    b.Property<long>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<long>("IdOfTeacher")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ItemId");

                    b.HasIndex("IdOfTeacher");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Wba.EfBasics.Core.Entities.Coursestudents", b =>
                {
                    b.Property<long>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<long?>("IdOfCourse")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdOfStudent")
                        .HasColumnType("bigint");

                    b.HasKey("ItemId");

                    b.HasIndex("IdOfCourse");

                    b.HasIndex("IdOfStudent");

                    b.ToTable("Coursestudents");
                });

            modelBuilder.Entity("Wba.EfBasics.Core.Entities.Student", b =>
                {
                    b.Property<long>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ItemId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Wba.EfBasics.Core.Entities.Teacher", b =>
                {
                    b.Property<long>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdOfcontactInfo")
                        .HasColumnType("bigint");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("YearlyWage")
                        .HasPrecision(2)
                        .HasColumnType("money");

                    b.HasKey("ItemId");

                    b.HasIndex("IdOfcontactInfo")
                        .IsUnique();

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Wba.EfBasics.Core.Entities.Course", b =>
                {
                    b.HasOne("Wba.EfBasics.Core.Entities.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("IdOfTeacher")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Wba.EfBasics.Core.Entities.Coursestudents", b =>
                {
                    b.HasOne("Wba.EfBasics.Core.Entities.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("IdOfCourse")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Wba.EfBasics.Core.Entities.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("IdOfStudent")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Wba.EfBasics.Core.Entities.Teacher", b =>
                {
                    b.HasOne("Wba.EfBasics.Core.Entities.ContactInfo", "ContactInfo")
                        .WithOne("Teacher")
                        .HasForeignKey("Wba.EfBasics.Core.Entities.Teacher", "IdOfcontactInfo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactInfo");
                });

            modelBuilder.Entity("Wba.EfBasics.Core.Entities.ContactInfo", b =>
                {
                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Wba.EfBasics.Core.Entities.Course", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Wba.EfBasics.Core.Entities.Student", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Wba.EfBasics.Core.Entities.Teacher", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
