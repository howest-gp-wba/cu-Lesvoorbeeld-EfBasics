using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wba.EfBasics.Web.ViewModels
{
    public class CoursesAddViewModel
    {
        [Required(ErrorMessage="Please provide a name!")]
        [Display(Name="Course")]
        public string Name { get; set; }
        public List<SelectListItem> Teachers { get; set; }
        [Display(Name = "Select a Teacher")]
        public long TeacherId { get; set; }
    }
}
