﻿using System.Collections.Generic;

namespace Wba.EfBasics.Core.Entities
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        //1 course heeft maar 1 teacher = navigation property
        public Teacher Teacher { get; set; }
        public long IdOfTeacher { get; set; }//unshadowed foreign key
        public ICollection<Coursestudents> Students { get; set; }
    }
}