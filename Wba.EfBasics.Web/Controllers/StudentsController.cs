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
    
    public class StudentsController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;

        public StudentsController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
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
    }


}
