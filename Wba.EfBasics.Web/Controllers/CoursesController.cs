using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.EfBasics.Web.Data;
using Wba.EfBasics.Web.ViewModels;

namespace Wba.EfBasics.Web.Controllers
{
    public class CoursesController : Controller
    {
        //declare the db context
        private readonly SchoolDbContext _schoolDbContext;


        public CoursesController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
        public async Task<IActionResult> Index()
        {
            //get the data from the database
            //declare the viewmodel
            //fill the model
            CoursesIndexViewModel coursesIndexViewModel
                = new CoursesIndexViewModel();
            coursesIndexViewModel.Courses  = await _schoolDbContext
                .Courses
                .Select(c => new CoursesInfoViewModel
                {
                    Id = c.Id,
                    Title = c.Title
                }).ToListAsync();
            
            //pass to the view
            return View(coursesIndexViewModel);
        }
    }
}
