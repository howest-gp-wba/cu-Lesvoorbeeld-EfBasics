using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.EfBasics.Core.Entities;
using Wba.EfBasics.Web.Data;
using Wba.EfBasics.Web.Models;
using Wba.EfBasics.Web.ViewModels;

namespace Wba.EfBasics.Web.Controllers
{
    
    public class StudentsController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;

        public StudentsController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            StudentsIndexViewmodel studentsIndexViewmodel
                = new();
            studentsIndexViewmodel.Students
                = await _schoolDbContext
                .Students
                .Select(s => new StudentsInfoViewmodel
                { 
                    Id = s.Id,
                    StudentName = $"{s.Firstname} {s.Lastname}"
                })
                .ToListAsync();
            return View(studentsIndexViewmodel);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //instantiate viewmodel
            StudentsAddViewmodel studentsAddViewmodel
                = new StudentsAddViewmodel();
            //get the courses from Db
            studentsAddViewmodel
                .Courses = await _schoolDbContext
                .Courses
                .Select(c => new CheckboxHelper
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                }).ToListAsync();
            return View(studentsAddViewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(StudentsAddViewmodel
            studentsAddViewmodel)
        {
            if(!ModelState.IsValid)
            {
                return View(studentsAddViewmodel);
            }
            //store student in Db
            //instantiate a new student
            Student student = new();
            student.Firstname = studentsAddViewmodel
                .FirstName;
            student.Lastname = studentsAddViewmodel
                .LastName;
            //init course list
            student.Courses = new List<Course>();
            student.Courses.Clear();
            //get the selected courses from viewmodel
            var selectedCourses = studentsAddViewmodel
                .Courses.Where(c => c.IsSelected == true);
            //get the courses from the db
            //and
            //compare and add to new student course list
            foreach(var course in await _schoolDbContext
                .Courses.ToListAsync())
            {
                if(selectedCourses.Any(sc => sc.Value == course.Id.ToString()))
                {
                    //add to collection
                    student.Courses.Add(course);
                }
            }
            //add tot the Db context
            _schoolDbContext.Students.Add(student);
            //save to db
            try
            {
                await _schoolDbContext.SaveChangesAsync();
            }
            catch(DbUpdateException dbUpdateException)
            {
                //handle error
                Console.WriteLine(dbUpdateException.Message);
            }
            return RedirectToAction("Index");
        }

    }

    
}
