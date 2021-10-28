using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.EfBasics.Core.Entities
{
    public class Coursestudents :BaseEntity
    {
        //navigation properties
        public Course Course { get; set; }
        public Student Student { get; set; }
        //unshadowed keys
        public long? IdOfCourse { get; set; }
        public long? IdOfStudent { get; set; }
    }
}
