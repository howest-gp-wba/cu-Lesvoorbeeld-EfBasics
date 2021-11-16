using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wba.EfBasics.Web.ViewModels
{
    public class StudentsIndexViewmodel
    {
        public IEnumerable<StudentsInfoViewmodel> Students { get; set; }
    }
}
