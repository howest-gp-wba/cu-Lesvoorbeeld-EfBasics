using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.EfBasics.Core.Entities;
using Wba.EfBasics.Web.Data;
using Wba.EfBasics.Web.Services;
using Wba.EfBasics.Web.ViewModels;

namespace Wba.EfBasics.Web.Controllers
{
    public class CoursesController : Controller
    {
        //declare the db context
        private readonly SchoolDbContext _schoolDbContext;
        //selectListBuilder
        private readonly SelectBuilderService _selectBuilderService;

        public CoursesController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
            _selectBuilderService = new SelectBuilderService();
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

            //retrieve ze cookie from the request
            ViewBag.UserName = Request.Cookies["Login"];
            //pass to the view
            return View(coursesIndexViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            CoursesAddViewModel coursesAddViewModel = new();
            //add the teacher list
            coursesAddViewModel.Teachers
                = await _selectBuilderService.GetSelectList(_schoolDbContext);
            return View(coursesAddViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CoursesAddViewModel coursesAddViewModel)
        {
            if(!ModelState.IsValid == true)
            {
                coursesAddViewModel.Teachers
                = await _selectBuilderService.GetSelectList(_schoolDbContext);
                return View(coursesAddViewModel);
            }
            //store course
            var course = new Course();
            course.Title = coursesAddViewModel.Name;
            course.TeacherId = coursesAddViewModel.TeacherId;
            //add to context
            _schoolDbContext.Courses.Add(course);
            await _schoolDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
