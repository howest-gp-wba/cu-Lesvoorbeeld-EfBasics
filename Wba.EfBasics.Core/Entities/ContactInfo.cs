using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.EfBasics.Core.Entities
{
    public class ContactInfo : BaseEntity
    {
        public string Email { get; set; }
        public Teacher Teacher { get; set; }
    }
}
