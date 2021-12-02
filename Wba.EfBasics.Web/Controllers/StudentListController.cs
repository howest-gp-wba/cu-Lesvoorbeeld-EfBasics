using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.EfBasics.Web.Data;
using Wba.EfBasics.Web.Services.Interfaces;

namespace Wba.EfBasics.Web.Controllers
{
    public class StudentListController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;
        private readonly ISessionServices _sessionServices;

        public StudentListController(SchoolDbContext schoolDbContext,
            ISessionServices sessionServices)
        {
            _schoolDbContext = schoolDbContext;
            _sessionServices = sessionServices;
        }
        public IActionResult Index()
        {
            //stap1: declareer een List<strings>
            var students = new List<string>();
            //stap2: haal de session list op
            string serializedStudents = HttpContext.Session.GetString("Students");
            //stap3: Deserialize dmv JsonConvert
            students = JsonConvert.DeserializeObject<List<string>>(serializedStudents);
            return View(students);
        }

        public async Task<IActionResult> Add(long id)
        {
            //get the student from db
            var student = await _schoolDbContext.Students
                .FirstOrDefaultAsync(s => s.Id == id);
            //use service class to add to session
            _sessionServices.AddStudentToSessionList($"{student.Firstname} {student.Lastname}");
            TempData["Message"] = "Student added to session list";
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string student)
        {
            //get the serialized list from session
            var students = JsonConvert.DeserializeObject<List<string>>
                    (HttpContext.Session.GetString("Students"));
            //remove from list
            students.Remove(student);
            //store back in session
            
            //stap2 => voeg als text toe aan session
            HttpContext.Session.SetString
                ("Students", JsonConvert.SerializeObject(students));
            TempData["Message"] = "Student removed from session list";
            return RedirectToAction("Index");
        }
    }
}
