using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.EfBasics.Web.Data;

namespace Wba.EfBasics.Web.Controllers
{
    public class CrudController : Controller
    {
        //declare the database context
        private readonly SchoolDbContext _schoolDbContext;

        //inject the dbcontext
        public CrudController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
        public IActionResult Index()
        {
            //get single course
            var course = _schoolDbContext
                .Courses
                .Include(c => c.Teacher)
                .ThenInclude(t => t.ContactInfo)
                .Include(c => c.Students)
                .FirstOrDefault(c => c.Id == 1);
            var courses = _schoolDbContext
                .Students
                .Where(s => s.Firstname.Equals("Bas"));
            return Content("","text/html");
        }
    }
}
