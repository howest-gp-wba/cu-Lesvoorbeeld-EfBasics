using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.EfBasics.Core.Entities;

namespace Wba.EfBasics.Web.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //students
            Student[] students = new Student[]
            {
                new Student{Id=1,Firstname="Bas",Lastname="Van Massenhove"},
                new Student{Id=2,Firstname="Bas",Lastname="Pale Ale"},
                new Student{Id=3,Firstname="Bas",Lastname="Taard"},
                new Student{Id=4,Firstname="Bas",Lastname="Ing"}
            };
            //Contactinfo
            ContactInfo[] contactInfos = new ContactInfo[]
            {
                new ContactInfo{Id=1,Email="teacher@mail.com"},
                new ContactInfo{Id=2,Email="teacher2@mail.com"},
            };
            //teachers
            var teachers = new Teacher[]
            {
                new Teacher{Id=1,Firstname="Bart",Lastname="Soete", ContactInfoId=1},
                new Teacher{Id=2,Firstname="Siegfried",Lastname="Derdeyn", ContactInfoId=2},
            };
            //courses
            var courses = new Course[]
            {
                new Course{Id=1,Title="WBA",TeacherId=1},
                new Course{Id=2,Title="DBS",TeacherId=2},
            };
            //tussentabel Coursestudents
            //moet met een anoniem object[]
            //volg de conventions
            
            var courseStudents = new[]
            {
               new {CoursesId=1L,StudentsId=1L}, 
               new {CoursesId=1L,StudentsId=2L}, 
               new {CoursesId=1L,StudentsId=3L}, 
               new{CoursesId=1L,StudentsId=4L},
               new{CoursesId=2L,StudentsId=1L},
               new{CoursesId=2L,StudentsId=2L},
               new{CoursesId=2L,StudentsId=3L},
               new{CoursesId=2L,StudentsId=4L},
            };
            modelBuilder.Entity<Student>()
                .HasData(students);
            modelBuilder.Entity<ContactInfo>()
                .HasData(contactInfos);
            modelBuilder.Entity<Teacher>()
                .HasData(teachers);
            modelBuilder.Entity<Course>()
                .HasData(courses);
            //use entity basic method for Coursestudent
            modelBuilder.Entity($"{nameof(Course)}{nameof(Student)}")
                .HasData(courseStudents);

        }
    }
}
