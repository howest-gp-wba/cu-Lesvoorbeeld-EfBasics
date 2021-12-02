using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.EfBasics.Web.Services.Interfaces;

namespace Wba.EfBasics.Web.Services
{
    public class SessionService : ISessionServices
    {
        //inject HttpContext accessor
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void AddStudentToSessionList(string studentName)
        {
            var students = new List<string>();
            //check if session list exists add to session
            if (_httpContextAccessor.HttpContext.Session.Keys.Contains("Students"))
            {
                //get the list from the session
                students = JsonConvert.DeserializeObject<List<string>>
                    (_httpContextAccessor.HttpContext.Session.GetString("Students"));
            }
            if (!students.Contains(studentName))
            {
                students.Add(studentName);
            }
            //stappen om complexe objecten toe te voegen aan session
            //stap 1 => zet om naar tekst(serialize(JsonConvert))
            string serializedStudents = JsonConvert.SerializeObject(students);
            //stap2 => voeg als text toe aan session
            _httpContextAccessor.HttpContext.Session.SetString("Students", serializedStudents);
        }

        public List<string> GetStudentListFromSession()
        {
            return new List<string>();
        }

        public void RemoveStudentFromSessionList(string studentName)
        {
            
        }
    }
}
