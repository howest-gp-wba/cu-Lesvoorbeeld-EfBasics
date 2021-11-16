using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Wba.EfBasics.Web.Models;

namespace Wba.EfBasics.Web.ViewModels
{
    public class StudentsAddViewmodel
    {
        [Required(ErrorMessage = "Please provide firstname")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please provide Lastname")]
        public string LastName { get; set; }

        public List<CheckboxHelper> Courses { get; set; }


    }
}
