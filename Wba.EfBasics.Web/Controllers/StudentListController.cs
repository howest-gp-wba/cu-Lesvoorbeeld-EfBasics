using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.EfBasics.Web.Data;

namespace Wba.EfBasics.Web.Controllers
{
    public class StudentListController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;

        public StudentListController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
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
            var students = new List<string>();
            //check if session list exists add to session
            if(HttpContext.Session.Keys.Contains("Students"))
            {
                //get the list from the session
                students = JsonConvert.DeserializeObject<List<string>>
                    (HttpContext.Session.GetString("Students"));
            }
            if(!students.Contains($"{student.Firstname} {student.Lastname}"))
            {
                students.Add($"{student.Firstname} {student.Lastname}");
            }
            //stappen om complexe objecten toe te voegen aan session
            //stap 1 => zet om naar tekst(serialize(JsonConvert))
            string serializedStudents = JsonConvert.SerializeObject(students);
            //stap2 => voeg als text toe aan session
            HttpContext.Session.SetString("Students",serializedStudents);
            return RedirectToAction("Index");
        }
    }
}
