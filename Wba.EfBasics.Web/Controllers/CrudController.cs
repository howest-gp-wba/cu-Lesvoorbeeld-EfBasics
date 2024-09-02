using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.EfBasics.Core.Entities;
using Wba.EfBasics.Web.Data;

namespace Wba.EfBasics.Web.Controllers
{
    public class CrudController : Controller
    {
        //declare the database context
        private readonly SchoolDbContext _schoolDbContext;
        private readonly ILogger<CrudController> _logger;

        //inject the dbcontext
        public CrudController(SchoolDbContext schoolDbContext, ILogger<CrudController> logger)
        {
            _schoolDbContext = schoolDbContext;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            ////get single course
            //var course = await _schoolDbContext
            //    .Courses
            //    .Include(c => c.Teacher)
            //    .ThenInclude(t => t.ContactInfo)
            //    .Include(c => c.Students)
            //    .FirstOrDefaultAsync(c => c.Id == 1);
            //var courses = _schoolDbContext
            //    .Students
            //    .Where(s => s.Firstname.Equals("Bas")).ToListAsync();
            ////declare a course entity
            //Course newCourse = new Course();
            //newCourse.Title = "WFA";
            //newCourse.DateCreated = DateTime.Now;
            //newCourse.TeacherId = 2;
            //newCourse.Students = await _schoolDbContext
            //    .Students.ToListAsync();
            ////add to dbcontext
            //_schoolDbContext.Courses.Add(newCourse);
            ////update
            var wfaCourse = await _schoolDbContext
                .Courses
                .FirstOrDefaultAsync(c => c.Id == 6);
            //wfaCourse.Title = "Web Frontend Advanced";

            //delete
            _schoolDbContext.Courses.Remove(wfaCourse);

            //save to database
            try
            {
                await _schoolDbContext.SaveChangesAsync();
            }
            catch(DbUpdateException dbUpdateException)
            {
                //logging
                _logger.LogError(dbUpdateException.Message);
                //redirect to error page
                return RedirectToAction("Error", "Home");    
            }
            return Content("","text/html");
        }
    }
}
